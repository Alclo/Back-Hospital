using hospital.Domain;
using hospital.UseCase;
using hospital.DTO;
using System.Runtime.ExceptionServices;
using Microsoft.EntityFrameworkCore;

namespace hospital.UseCase.UseCaseImpl
{
    public class HospitalUseCaseImpl : HospitalUseCase
    {
        private readonly HospitalDbContext _context;
        public HospitalUseCaseImpl(HospitalDbContext context)
        {
            this._context = context;
        }

        public HospitalDTO insertHospital(HospitalDTO pHospital)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var verificarHospiatl= this._context.Hospitals.FirstOrDefault(Hospital => Hospital.Id == pHospital.Id);
                    if (verificarHospiatl == null)
                    {
                        var pocoHospital = new Hospital()
                        {
                            Id = pHospital.Id,
                            Correo = pHospital.Correo,
                            Direccion = pHospital.Direccion,
                            Nombre = pHospital.Nombre,
                            RazonSocial = pHospital.RazonSocial,
                            Rfc = pHospital.Rfc,
                            Telefono = pHospital.Telefono
                        };
                        this._context.Hospitals.Add(pocoHospital);
                        this._context.SaveChanges();
                        transaction.Commit();
                        pHospital.Id = pocoHospital.Id;
                        return pHospital;
                    }
                    else
                    {
                        var updatedCita = updateHospital(pHospital);
                        transaction.Commit();
                        return updatedCita;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public HospitalDTO updateHospital(HospitalDTO pHospital)
        {
                try
                {
                    var pocoHospital = this._context.Hospitals.FirstOrDefault(hospital => hospital.Id == pHospital.Id);
                    if (pocoHospital == null)
                    {
                        return null;
                    }

                    this._context.Hospitals
                        .Where(hospital => hospital.Id == pHospital.Id)
                        .ExecuteUpdate(setters => setters
                            .SetProperty(hospital => hospital.Nombre, pHospital.Nombre)
                            .SetProperty(hospital => hospital.RazonSocial, pHospital.RazonSocial)
                            .SetProperty(hospital => hospital.Direccion, pHospital.Direccion)
                            .SetProperty(hospital => hospital.Rfc, pHospital.Rfc)
                            .SetProperty(hospital => hospital.Telefono, pHospital.Telefono)
                            .SetProperty(hospital => hospital.Correo, pHospital.Correo));
                    this._context.SaveChanges();
                    return pHospital;
                }
                catch
                {
                    throw;
                }
        }

        public HospitalDTO deleteHospital(HospitalDTO pHospital)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var pocoHospital = this._context.Hospitals.FirstOrDefault(hospital => hospital.Id == pHospital.Id);
                    if (pocoHospital == null)
                        return null;

                    this._context.Hospitals.Remove(pocoHospital);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pHospital;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public HospitalDTO getByIdHospital(HospitalDTO pHospital)
        {
            var pocoHospital = this._context.Hospitals.FirstOrDefault(hospital => hospital.Id == pHospital.Id);
            if (pocoHospital == null)
                return null;
            var oHospital = new HospitalDTO()
            {
                Id = pocoHospital.Id,
                Nombre = pocoHospital.Nombre,
                RazonSocial = pocoHospital.RazonSocial,
                Direccion = pocoHospital.Direccion,
                Rfc = pocoHospital.Rfc,
                Telefono = pocoHospital.Telefono,
                Correo = pocoHospital.Correo
            };
            return oHospital;
        }

        public List<HospitalDTO> selectByExampleHospital(string? pCriterio)
        {
            var query = this._context.Hospitals.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pCriterio))
            {
                pCriterio.ToLower();
                query = query.Where(hospital =>
                        EF.Functions.Like(hospital.Nombre.ToLower(), $"%{pCriterio}%") ||
                        EF.Functions.Like(hospital.Rfc.ToLower(), $"%{pCriterio}%"));
            }
            return query.Select(hospital => new HospitalDTO()
            {
                Id = hospital.Id,
                Nombre = hospital.Nombre,
                RazonSocial = hospital.RazonSocial,
                Direccion = hospital.Direccion,
                Rfc = hospital.Rfc,
                Telefono = hospital.Telefono,
                Correo = hospital.Correo
            }).ToList();
        }
    }
}
