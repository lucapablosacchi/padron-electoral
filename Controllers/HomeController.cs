using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP10.Models;

namespace TP10.Controllers
{
    public class HomeController : Controller
    {
        private string ERR_NO_EXISTE_DNI="Este DNI no existe";
        private string ERR_NO_EXISTE_DNI_EXISTE_NTRAMITE="Este numero de tramite no existe";
        private string ERR_ERROR="ERROR!";
        private string ERR_VOTO_CORRECTAMENTE="Voto completado correctamente";
        private string SUCCESS_YA_VOTO="Voto registrado anteriormente";
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ConsultarPadron(int DNI)
        {
            Persona persona = BD.ConsultarPadron(DNI);

            if(persona == null)
            {
                ViewBag.ErrorMessage = ERR_NO_EXISTE_DNI;
                return View("Index");
            }

            ViewBag.ErrorMessage = null;
            ViewBag.Persona = persona;
            ViewBag.Establecimiento = BD.ConsultarEstablecimiento(persona.IdEstablecimiento);

            return View("Votar");
        }

        [HttpPost]
        public IActionResult Votar(int DNI, int NumeroTramite)
        {
            Persona persona = BD.ConsultarPadron(DNI);

             if(persona == null)
            {
                ViewBag.ErrorMessage = ERR_NO_EXISTE_DNI;
                return View("Index");
            }

            ViewBag.Persona = persona;
            ViewBag.Establecimiento = BD.ConsultarEstablecimiento(persona.IdEstablecimiento);

            if(persona.Voto)
            {
                ViewBag.ErrorMessage = SUCCESS_YA_VOTO;
                return View();
            }
            
            if(persona.NumeroTramite != NumeroTramite)
            {
                ViewBag.ErrorMessage = ERR_NO_EXISTE_DNI_EXISTE_NTRAMITE;
                return View();
            }

             if(!BD.Votar(DNI, NumeroTramite))
            {
                ViewBag.ErrorMessage = ERR_ERROR;
                return View();
            }

            ViewBag.SuccessMessage = ERR_VOTO_CORRECTAMENTE;
            return ConsultarPadron(DNI);
        }

        
    }
}
