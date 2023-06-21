using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        // GET api/aseguradora
        public IHttpActionResult GetAll()
        {

            ML.Empleado empleado = new ML.Empleado();
            empleado.Estado = new ML.Estado();
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }
        [HttpGet]
        [Route("api/Empleado/GetById/{IdEmpleado}")]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }
        [HttpPost]
        [Route("api/Empleado/Add")]
        public IHttpActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpPost]
        [Route("api/Empleado/Update")]
        public IHttpActionResult Put([FromBody] ML.Empleado empleado)
        {
            var result = BL.Empleado.Update(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpGet]
        [Route("api/Empleado/Delete/{IdEmpleado}")]
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();       
            empleado.IdEmpleado = IdEmpleado;
            ML.Result result = BL.Empleado.Delete(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }
    }
}