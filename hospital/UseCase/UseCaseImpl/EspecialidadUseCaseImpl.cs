using hospital.Domain;
using hospital.DTO;
using Microsoft.EntityFrameworkCore;

namespace hospital.UseCase.UseCaseImpl
{
    public class EspecialidadUseCaseImpl : EspecialidadUseCase
    {
        private readonly HospitalDbContext _context;

        public EspecialidadUseCaseImpl(HospitalDbContext context)
        {
            _context = context;
        }
        public EspecialidadDTO insertEspecialidad(EspecialidadDTO pEspecialidad)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoEspecialidad = new Especialidad()
                    {
                        
                        Nombre = pEspecialidad.Nombre,
                    };

                    this._context.Especialidads.Add(pocoEspecialidad);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pEspecialidad;
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
         * la tabla Especialidad
         * mediante la llave primaria 	
         */

        public EspecialidadDTO getByIdEspecialidad(EspecialidadDTO pEspecialidad)
        {
            var pocoEspecialidad = this._context.Especialidads.FirstOrDefault(Especialidad => Especialidad.Id == pEspecialidad.Id);
            if (pocoEspecialidad == null)
                return null;
            var oEspecialidad = new EspecialidadDTO()
            {
                Id = pocoEspecialidad.Id,
                Nombre = pocoEspecialidad.Nombre
            };
            return oEspecialidad;
        }



        /**
         * Este codigo se genero con Arquitecto MVC.
         * Este m\u00E9todo ejecuta las reglas de negocio 
         * para dar de baja fisicamente un registro en  
         * la tabla Especialidad
         * mediante la llave primaria 	
         */
        public EspecialidadDTO? deleteEspecialidad(EspecialidadDTO pEspecialidad)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoEspecialidad = this._context.Especialidads.FirstOrDefault(Especialidad => Especialidad.Id == pEspecialidad.Id);
                    if (pocoEspecialidad == null)
                        return null;

                    this._context.Especialidads.Remove(pocoEspecialidad);
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pEspecialidad;
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
         * la tabla Especialidad
         * mediante la llave primaria 	
         */
        public EspecialidadDTO updateEspecialidad(EspecialidadDTO pEspecialidad)
        {
            using (var transaction = this._context.Database.BeginTransaction())
            {
                try
                {
                    var pocoEspecialidad = this._context.Especialidads.FirstOrDefault(Especialidad => Especialidad.Id == pEspecialidad.Id
                   );
                    if (pocoEspecialidad == null)
                    {
                        transaction.Rollback();
                        return null;
                    }

                    this._context.Especialidads
                        .Where(Especialidad => Especialidad.Id == pEspecialidad.Id)
                        .ExecuteUpdate(setters => setters
                                .SetProperty(Especialidad => Especialidad.Nombre, pEspecialidad.Nombre)
                                );
                    this._context.SaveChanges();
                    transaction.Commit();
                    return pEspecialidad;
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
         * la tabla Especialidad 
         * dependiendo de las propiedades del parametro 	
         */
        public List<EspecialidadDTO> selectByExampleEspecialidad(string? pCriterio)
        {
            var query = this._context.Especialidads.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pCriterio))
            {
                pCriterio.ToLower();
                query = query.Where(Especialidad =>
                        EF.Functions.Like(Especialidad.Nombre.ToLower(), $"%{pCriterio}%"));
            }

            return query.Select(Especialidad => new EspecialidadDTO()
            {
                Id = Especialidad.Id,
                Nombre = Especialidad.Nombre
            }).ToList();
        }
    }
}
