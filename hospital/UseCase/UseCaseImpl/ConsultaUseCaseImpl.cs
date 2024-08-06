using hospital.Domain;
using hospital.DTO;
using Microsoft.EntityFrameworkCore;

namespace hospital.UseCase.UseCaseImpl
{
    public class ConsultaUseCaseImpl : ConsultaUseCase
    {
        private readonly HospitalDbContext _context;
        public ConsultaUseCaseImpl(HospitalDbContext context)
        {
            this._context = context;
        }
        public ConsultaDTO deleteConsulta(ConsultaDTO pConsulta)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoConculta = this._context.Consulta.FirstOrDefault(consulta => consulta.Id == pConsulta.Id);
                    if (pocoConculta == null)
                        throw new Exception("No se encontro una consulta con este id");

                    this._context.Consulta.Remove(pocoConculta);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pConsulta;
                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception("No se pudo realizar la eliminacion");
                }
            }
        }

        public ConsultaDTO getByIdConsulta(ConsultaDTO pConsulta)
        {
            var pocoConculta = this._context.Consulta.FirstOrDefault(consulta => consulta.Id == pConsulta.Id);
            if (pocoConculta == null)
                throw new Exception("No se encontro una cita con este id");
            var oConsulta = new ConsultaDTO()
            {
                Id = pConsulta.Id,
                CitaId = pConsulta.Id,
                Diagnostico = pConsulta.Diagnostico,
                Tratamiento = pConsulta.Tratamiento,
            };
            return oConsulta;
        }

        public ConsultaDTO insertConsulta(ConsultaDTO pConsulta)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var verificarConsulta = this._context.Consulta.FirstOrDefault(Consulta => Consulta.Id == pConsulta.Id);
                    if (verificarConsulta == null)
                    {
                        var verificarCita = this._context.Consulta.FirstOrDefault(Consulta => Consulta.CitaId == pConsulta.CitaId);
                        if (verificarCita != null)
                            throw new Exception("No se puede agregar esta consulta, debido a que la cita ya esta asiganda a otra consulta");
                        var pocoConsulta = new Consulta()
                        {
                            Id = pConsulta.Id,
                            CitaId = pConsulta.CitaId,
                            Diagnostico = pConsulta.Diagnostico,
                            Tratamiento = pConsulta.Tratamiento,
                        };
                        this._context.Consulta.Add(pocoConsulta);
                        this._context.SaveChanges();
                        transaction.Commit();
                        pConsulta.Id = pocoConsulta.Id;
                        return pConsulta;
                    }
                    else
                    {
                        var updatedConsulta = updateConsulta(pConsulta);
                        transaction.Commit();
                        return updatedConsulta;
                    }

                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception("No se pudo realizar la insercion o actualizaicon de la consulta");
                }
            }
        }

        public List<ConsultaDTO> selectByExampleConsulta(string? pCriterio)
        {
            var query = this._context.Consulta.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pCriterio))
            {
                pCriterio.ToLower();
                query = query.Where(Consulta =>
                        EF.Functions.Like(Consulta.Id.ToString(), $"%{pCriterio}%") ||
                        EF.Functions.Like(Consulta.CitaId.ToString(), $"%{pCriterio}%") ||
                        EF.Functions.Like(Consulta.Diagnostico.Trim().ToLower(), $"%{pCriterio.Trim()}%") ||
                        EF.Functions.Like(Consulta.Tratamiento.Trim().ToLower(), $"%{pCriterio.Trim()}%"));
            }
            return query.Select(Consulta => new ConsultaDTO()
            {
                Id = Consulta.Id,
                CitaId = Consulta.CitaId,
                Diagnostico = Consulta.Diagnostico,
                Tratamiento = Consulta.Tratamiento,
            }).ToList();
        }

        public ConsultaDTO updateConsulta(ConsultaDTO pConsulta)
        {
            try
            {
                var pocoConsulta = this._context.Consulta.FirstOrDefault(Consulta => Consulta.Id == pConsulta.Id);
                if (pocoConsulta == null)
                {
                    throw new Exception("No se encontro la consulta a actualizar");
                }

                this._context.Consulta
                    .Where(Consulta => Consulta.Id == pConsulta.Id)
                    .ExecuteUpdate(setters => setters
                            .SetProperty(Consulta => Consulta.CitaId, pConsulta.CitaId)
                            .SetProperty(Consulta => Consulta.Diagnostico, pConsulta.Diagnostico)
                            .SetProperty(Consulta => Consulta.Tratamiento, pConsulta.Tratamiento));
                this._context.SaveChanges();

                return pConsulta;
            }
            catch
            {
                throw;

            }
        }
    }
}
