using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenJavaScriptEntities context = new DL.ExamenJavaScriptEntities())
                {
                    var query = context.EmpleadoAdd(empleado.NumeroNomina,empleado.Nombre,empleado.ApellidoPaterno,empleado.ApellidoMaterno,empleado.Estado.IdEstado);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenJavaScriptEntities context = new DL.ExamenJavaScriptEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.IdEmpleado,empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el update";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenJavaScriptEntities context = new DL.ExamenJavaScriptEntities())
                {
                    var query = context.EmpleadoDelete(empleado.IdEmpleado);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenJavaScriptEntities context = new DL.ExamenJavaScriptEntities())
                {
                    var obj = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = obj.IdEmpleado;
                        empleado.NumeroNomina = obj.NumeroNomina;
                        empleado.Nombre = obj.Nombre;
                        empleado.ApellidoPaterno = obj.ApellidoPaterno;
                        empleado.ApellidoMaterno = obj.ApellidoMaterno;

                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = obj.IdEstado;
                        empleado.Estado.Nombre = obj.Estado;

                        result.Object = empleado;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenJavaScriptEntities context = new DL.ExamenJavaScriptEntities())
                {
                    var empleados = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (empleados != null)
                    {
                        foreach (var obj in empleados)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroNomina = obj.NumeroNomina;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;

                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = obj.IdEstado;
                            empleado.Estado.Nombre = obj.Estado;

                            result.Objects.Add(empleado);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
