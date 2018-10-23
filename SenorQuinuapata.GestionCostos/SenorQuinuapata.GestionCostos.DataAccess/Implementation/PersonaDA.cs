using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class PersonaDA : IPersonaDA
    {
        public readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();

       

        #region transaccional
        public void RegisterPersona(PersonaRequest persona)
        {
            try
            {
                using (db)
                {

                    db.Persona.Add(

                        new Persona()
                        {
                            //id=persona.id,
                            nombres = persona.nombres,
                            apellido_paterno = persona.apellido_paterno,
                            apellido_materno = persona.apellido_materno,
                            direccion = persona.direccion,
                            telefono = persona.telefono,
                            dni = persona.dni,
                            id_cargo = persona.id_cargo,
                            asistencia = "F"
                        }

                        );

                    db.SaveChanges();

                }
            }
            finally
            {

                db.Dispose();
            }
        }

        public void MarcarAsistencia(int id)
        {
            try
            {
                decimal? sueldo = 0;
                var result = new List<ProductoResponse>();
                using (db)
                {                    

                    Persona per = db.Persona.Where(c => c.id == id).FirstOrDefault();

                    if (per.asistencia == "F")
                    {
                        per.asistencia = "A";
                    }

                    sueldo = per.Cargo.sueldo;

                    //DateTime? fecha = DateTime.Now;

                    //Movimiento_departamento md = db.Movimiento_departamento.Where(x => x.fecha==fecha).FirstOrDefault();

                    db.Asistencia.Add(new Asistencia()
                    {
                        id_persona = id,
                        fecha = DateTime.Now,
                        sueldo=Convert.ToDecimal(sueldo/31),
                        estado="A"
                    });

                    db.SaveChanges();

                }

            }
            finally
            {
                db.Dispose();
            }
        }

        public void ResetAsistencia()
        {
            try
            {
                
                using (db)
                {
                   var persona = db.Persona.ToList();

                    foreach (var item in persona)
                    {
                        item.asistencia = "F";
                        
                    }

                    db.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }
        #endregion

        #region no transaccional
        public IEnumerable<PersonaResponse> List()
        {
            try
            {
                var result = new List<PersonaResponse>();
                using (db)
                {

                    result = db.Database.SqlQuery<PersonaResponse>("sp_persona_list").ToList();

                }

                return result;
            }
            finally
            {
                db.Dispose();
            }
        }



        public IEnumerable<AsistenciaResponse> ReportAsistencia(int mes, int anio)
        {
            var result = new List<AsistenciaResponse>();

            try
            {
                using (var ctx= new bd_sgcquinuapataEntities())
                {
                    result = ctx.Database.SqlQuery<AsistenciaResponse>("sp_asistencia_persona_list @mes, @anio",                        
                        new SqlParameter("@mes", mes),
                        new SqlParameter("@anio", anio)
                        //new SqlParameter("@dni", dni)

                        ).ToList();

                }

                return result;
            }
            finally
            {
                db.Dispose();
            }
        }

        public PersonaResponse GetPersonaByDni(string dni)
        {
            var result = new PersonaResponse();

            try
            {
                using (db)
                {
                    var persona = db.Persona.Where(x =>x.dni==dni).SingleOrDefault();

                    result = new PersonaResponse()
                    {
                       nombres=persona.nombres,
                       apellido_paterno=persona.apellido_paterno,
                       apellido_materno=persona.apellido_materno,
                       telefono=persona.telefono,
                       direccion=persona.direccion,
                       dni=persona.dni,
                       cargo=persona.Cargo.descripcion

                    };

                    return result;

                }

               
            }
            finally
            {
                db.Dispose();
            }
        }


        #endregion

    }
}
