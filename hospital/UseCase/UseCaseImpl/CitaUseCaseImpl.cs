using hospital.Domain;
using hospital.DTO;
using Microsoft.EntityFrameworkCore;

namespace hospital.UseCase.UseCaseImpl
{
    public class CitaUseCaseImpl : CitaUseCase
    {
        private readonly HospitalDbContext _context;
        public CitaUseCaseImpl(HospitalDbContext context)
        {
            this._context = context;
        }
        public CitaDTO deleteCita(CitaDTO pCita)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoCita= this._context.Cita.FirstOrDefault(cita => cita.Id == pCita.Id);
                    if (pocoCita == null)
                        throw new Exception("No se encontro una cita con este id");

                    this._context.Cita.Remove(pocoCita);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pCita;
                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception("No se pudo realizar la eliminacion");
                }
            }
        }

        public CitaDTO getByIdCita(CitaDTO pCita)
        {
            var pocoCita = this._context.Cita.FirstOrDefault(cita => cita.Id == pCita.Id);
            if (pocoCita == null)
                throw new Exception("No se encontro una cita con este id");
            var oCita = new CitaDTO()
            {
                Id = pCita.Id,
                DoctorId = pCita.DoctorId,
                Fecha =  pCita.Fecha,
                PacienteId = pCita.PacienteId,
            };
            return oCita;
        }

        public CitaDTO insertCita(CitaDTO pCita)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var verificarCita = this._context.Cita.FirstOrDefault(Cita => Cita.Id == pCita.Id);
                    if (verificarCita == null)
                    {
                        var pocoCita = new Cita()
                        {
                            
                            DoctorId = pCita.DoctorId,
                            Fecha = pCita.Fecha,
                            PacienteId = pCita.PacienteId,
                        };
                        this._context.Cita.Add(pocoCita);
                        this._context.SaveChanges();
                        transaction.Commit();
                        pCita.Id = pocoCita.Id;
                        return pCita;
                    }
                    else
                    {
                        var updatedCita = updateCita(pCita);
                        transaction.Commit();
                        return updatedCita;
                    }

                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception("No se pudo realizar la insercion o actualizaicon de la cita");
                }
            }
        }

        public List<CitaDTO> selectByExampleCita(string? pCriterio)
        {
            var query = this._context.Cita.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pCriterio))
            {
                pCriterio.ToLower();
                query = query.Where(Cita =>
                        EF.Functions.Like(Cita.Id.ToString(), $"%{pCriterio}%") ||
                        EF.Functions.Like(Cita.DoctorId.ToString(), $"%{pCriterio}%") ||
                        EF.Functions.Like(Cita.Fecha.ToString(), $"%{pCriterio}%") ||
                        EF.Functions.Like(Cita.PacienteId.ToString(), $"%{pCriterio}%"));
            }
            return query.Select(Cita => new CitaDTO()
            {
                Id = Cita.Id,
                DoctorId = Cita.DoctorId,
                Fecha = Cita.Fecha,
                PacienteId = Cita.PacienteId,
            }).ToList();
        }

        public CitaDTO updateCita(CitaDTO pCita)
        {
            try
            {
                var pocoCita = this._context.Cita.FirstOrDefault(Cita => Cita.Id == pCita.Id);
                if (pocoCita == null)
                {
                    throw new Exception("No se encontro la cita a actualizar");
                }

                this._context.Cita
                    .Where(Cita => Cita.Id == pCita.Id)
                    .ExecuteUpdate(setters => setters
                            .SetProperty(Cita => Cita.DoctorId, pCita.DoctorId)
                            .SetProperty(Cita => Cita.Fecha, pCita.Fecha)
                            .SetProperty(Cita => Cita.PacienteId, pCita.PacienteId));
                this._context.SaveChanges();

                return pCita;
            }
            catch
            {
                throw new Exception("No se pudo actualizar la cita"); ;

            }
        }
    }
}
