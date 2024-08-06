using hospital.Domain;
using hospital.DTO;
using Microsoft.EntityFrameworkCore;

namespace hospital.UseCase.UseCaseImpl
{
    public class DoctorUseCaseImpl : DoctorUseCase
    {
        private readonly HospitalDbContext _context;
        public DoctorUseCaseImpl(HospitalDbContext context)
        {
            this._context = context;
        }
        public DoctorDTO insertDoctor(DoctorDTO pDoctor)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoDoctor = new Doctor()
                    {
                        Id = pDoctor.Id,
                        Nombre = pDoctor.Nombre,
                        Edad = pDoctor.Edad,
                        Curp = pDoctor.Curp,
                        Telefono = pDoctor.Telefono,
                        Direccion = pDoctor.Direccion,
                        Cedula = pDoctor.Cedula,
                        EspecialidadId = pDoctor.EspecialidadId,
                        HospitalId = pDoctor.HospitalId
                    };

                    this._context.Doctors.Add(pocoDoctor);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pDoctor;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }



        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo implementa las reglas de negocio 
         * para seleccion de un registro en  
         * la tabla Doctor
         * mediante la llave primaria 	
         */

        public DoctorDTO getByIdDoctor(DoctorDTO pDoctor)
        {
            var pocoDoctor = this._context.Doctors.FirstOrDefault(doctor => doctor.Id == pDoctor.Id);
            if (pocoDoctor == null)
                return null;
            var oDoctor = new DoctorDTO()
            {
                Id = pocoDoctor.Id,
                Nombre = pocoDoctor.Nombre
            };
            return oDoctor;
        }



        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo ejecuta las reglas de negocio 
         * para dar de baja fisicamente un registro en  
         * la tabla Doctor
         * mediante la llave primaria 	
         */
        public DoctorDTO? deleteDoctor(DoctorDTO pDoctor)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoDoctor = this._context.Doctors.FirstOrDefault(Doctor => Doctor.Id == pDoctor.Id);
                    if (pocoDoctor == null)
                        return null;

                    this._context.Doctors.Remove(pocoDoctor);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pDoctor;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo ejecuta las reglas de negocio 
         * para actualizar un registro en  
         * la tabla Doctor
         * mediante la llave primaria 	
         */
        public DoctorDTO updateDoctor(DoctorDTO pDoctor)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoDoctor = this._context.Doctors.FirstOrDefault(Doctor => Doctor.Id == pDoctor.Id
                   );
                    if (pocoDoctor == null)
                    {
                        transaction.Rollback();
                        return null;
                    }

                    this._context.Doctors
                        .Where(Doctor => Doctor.Id == pDoctor.Id)
                        .ExecuteUpdate(setters => setters
                                .SetProperty(Doctor => Doctor.Nombre, pDoctor.Nombre)
                                .SetProperty(Doctor => Doctor.Edad, pDoctor.Edad)
                                .SetProperty(Doctor => Doctor.Curp, pDoctor.Curp)
                                .SetProperty(Doctor => Doctor.Telefono, pDoctor.Telefono)
                                .SetProperty(Doctor => Doctor.Direccion, pDoctor.Direccion)
                                .SetProperty(Doctor => Doctor.Cedula, pDoctor.Cedula)
                                .SetProperty(Doctor => Doctor.EspecialidadId, pDoctor.EspecialidadId)
                                .SetProperty(Doctor => Doctor.HospitalId, pDoctor.HospitalId)
                                );
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pDoctor;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo ejecuta las reglas de negocio 
         * para seleccion de registros en  
         * la tabla Doctor 
         * dependiendo de las propiedades del parametro 	
         */
        public List<DoctorDTO> selectByExampleDoctor(string? pCriterio)
        {
            var query = this._context.Doctors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pCriterio))
            {
                pCriterio.ToLower();
                query = query.Where(Doctor =>
                        EF.Functions.Like(Doctor.Nombre.ToLower(), $"%{pCriterio}%"));
            }

            return query.Select(Doctor => new DoctorDTO()
            {
                Id = Doctor.Id,
                Nombre = Doctor.Nombre,
                Edad = Doctor.Edad,
                Curp = Doctor.Curp,
                Telefono = Doctor.Telefono,
                Direccion = Doctor.Direccion,
                Cedula = Doctor.Cedula,
                EspecialidadId = Doctor.EspecialidadId,
                HospitalId = Doctor.HospitalId,
            }).ToList();
        }
    }
}
