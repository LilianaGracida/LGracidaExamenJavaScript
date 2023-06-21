using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult Getall()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }

        [HttpGet]
        public JsonResult Get()
        {
            ML.Result result = BL.Empleado.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.IdEmpleado = IdEmpleado;
            ML.Result result = BL.Empleado.Delete(empleado);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}