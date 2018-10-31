using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Response;
using SenorQuinuapata.GestionCostos.Models;

namespace SenorQuinuapata.GestionCostos.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationDbContext userContext;
       
        private ApplicationUserManager _userManager;
        private readonly RolBL _RolBL = new RolBL();

       
        public ActionResult Index()
        {
            userContext = new ApplicationDbContext();

           
            //var users = userContext.Users.ToList();           
           
            List<UsuarioResponse> users = (from o in userContext.Users
                                         join p in userContext.Roles on o.Roles.Select(t => t.RoleId).FirstOrDefault() equals p.Id
                                         select new UsuarioResponse
                                         {
                                             Id = o.Id,
                                             Email=o.Email,
                                             Rol=p.Name                                             
                                         }).ToList();


            UsuarioViewModel _listUsuario= new UsuarioViewModel()
            {
                ListUsuario = users
            };

            return View(_listUsuario);
        }





        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            userContext = new ApplicationDbContext();
            var roles = userContext.Roles.ToList();
            ViewBag.roles = new SelectList(roles, "Id", "Name");
            return View();
        }

    
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model, string rol)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {

                    var _rol = _RolBL.GetRol(rol);

                    await UserManager.AddToRoleAsync(user.Id, _rol.rol);

                    TempData["Success"] = "El usuario fue registrado con éxito";

                    return RedirectToAction("Create", "Usuario");
                }
                AddErrors(result);
            }

            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}