using hospital.Domain;
using hospital.DTO;
using Microsoft.EntityFrameworkCore;

namespace hospital.UseCase.UseCaseImpl
{
    public class PacienteUseCaseImpl : PacienteUseCase
    {
        private readonly HospitalDbContext _context;
        public PacienteUseCaseImpl(HospitalDbContext context)
        {
            this._context = context;
        }

        public PacienteDTO insertPaciente(PacienteDTO pPaciente)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var pocoPaciente = this._context.Pacientes.FirstOrDefault(paciente => paciente.Id == pPaciente.Id);
                    if (pocoPaciente == null)
                    {

                        var Paciente = new Paciente()
                        {
                            Aseguradora = pPaciente.Aseguradora,
                            Curp = pPaciente.Curp,
                            Direccion = pPaciente.Direccion,
                            FechaNacimiento = pPaciente.FechaNacimiento,
                            FechaRegistro = DateTime.Now,
                            Sexo = pPaciente.Sexo,
                            Nombre = pPaciente.Nombre,
                            Telefono = pPaciente.Telefono,
                        };

                        this._context.Pacientes.Add(Paciente);
                        this._context.SaveChanges();
                        transaction.Commit();
                        pPaciente.Id = Paciente.Id;
                        return pPaciente;
                    }
                    else {
                        var updatedPaciente = updatePaciente(pPaciente);
                        transaction.Commit();
                        return updatedPaciente;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public PacienteDTO? deletePaciente(PacienteDTO pPaciente)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var pocoPaciente = this._context.Pacientes.FirstOrDefault(paciente => paciente.Id == pPaciente.Id);
                    if (pocoPaciente == null)
                        return null;

                    this._context.Pacientes.Remove(pocoPaciente);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pPaciente;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public PacienteDTO? getidPaciente(PacienteDTO pPaciente)
        {
            var pocoPaciente = this._context.Pacientes.FirstOrDefault(paciente => paciente.Id == pPaciente.Id);
            if (pocoPaciente == null)
                return null;
            var oPaciente = new PacienteDTO()
            {
                Id = pPaciente.Id,
                Nombre = pPaciente.Nombre,
                Sexo = pPaciente.Sexo,
                Curp = pPaciente.Curp,
                FechaNacimiento = pPaciente.FechaNacimiento,
                Telefono = pPaciente.Telefono,
                Direccion = pPaciente.Direccion,
                Aseguradora = pPaciente.Aseguradora,
                FechaRegistro = pPaciente.FechaRegistro
            };
            return oPaciente;
        }

        public List<PacienteDTO> selectByExamplePaciente(string? pCriterio)
        {
            var query = this._context.Pacientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pCriterio))
            {
                pCriterio.ToLower();
                query = query.Where(paciente =>
                        EF.Functions.Like(paciente.Nombre.ToLower(), $"%{pCriterio}%") ||
                        EF.Functions.Like(paciente.Curp.ToLower(), $"%{pCriterio}%"));
            }

            return query.Select(paciente => new PacienteDTO()
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Sexo = paciente.Sexo,
                Curp = paciente.Curp,
                FechaNacimiento = paciente.FechaNacimiento,
                Telefono = paciente.Telefono,
                Direccion = paciente.Direccion,
                Aseguradora = paciente.Aseguradora,
                FechaRegistro = paciente.FechaRegistro
            }).ToList();
        }

        public PacienteDTO updatePaciente(PacienteDTO pPaciente)
        {
            try
            {
                var pocoPaciente= this._context.Pacientes.FirstOrDefault(Paciente => Paciente.Id == pPaciente.Id);
                if (pocoPaciente == null)
                {
                    throw new Exception("No se encontro la cita a actualizar");
                }

                this._context.Pacientes
                    .Where(Paciente => Paciente.Id == pPaciente.Id)
                    .ExecuteUpdate(setters => setters
                            .SetProperty(Paciente => Paciente.Nombre, pPaciente.Nombre)
                            .SetProperty(Paciente => Paciente.Sexo, pPaciente.Sexo)
                            .SetProperty(Paciente => Paciente.Curp, pPaciente.Curp)
                            .SetProperty(Paciente => Paciente.FechaNacimiento, pPaciente.FechaNacimiento)
                            .SetProperty(Paciente => Paciente.Telefono, pPaciente.Telefono)
                            .SetProperty(Paciente => Paciente.Direccion, pPaciente.Direccion)
                            .SetProperty(Paciente => Paciente.Aseguradora, pPaciente.Aseguradora));
                this._context.SaveChanges();

                return pPaciente;
            }
            catch
            {
                throw new Exception("No se pudo actualizar la cita");

            }
        }
    }
}
