using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class RolDA : IRolDA
    {
        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();
        public RolResponse GetRol(string id)
        {
            try
            {

                var _rol = new RolResponse();
                using (db)
                {
                    //roles = db.AspNetRoles.Where(x => x.Id ==id);

                    var rol= db.AspNetRoles.Where(x => x.Id == id).FirstOrDefault();

                    _rol.rol = rol.Name;
                    _rol.id = rol.Id;

                }

                return _rol;
            }
            catch (Exception e)
            {
                var message = e.Message;

                return null;
            }
        }

    }
}
