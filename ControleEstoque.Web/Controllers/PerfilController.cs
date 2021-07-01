using ControleEstoque.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Web.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult BuscarPerfil()
        {
            return View(PerfilUsuarioModel.BuscarPefil());
        }

        public ActionResult BuscarPerfilID(int id)
        {
            return Json(PerfilUsuarioModel.BuscarPerilId(id));

        }
    }
}