using Microsoft.AspNetCore.Mvc;
using ApiRestaurante.DbHandle;
using ApiRestaurante.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;


namespace ApiRestaurante.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        [Route("GetProductoPorNombre")]
        [HttpGet]
        public Response MProducto_ListarPorNombre(string tNombre, string tEmpresaRuc)
        {
            Response result = null;
            ProductoDb db = new ProductoDb();
            var list = db.MProducto_ListarPorNombre(tNombre, tEmpresaRuc);
            if (list != null)
            {
                result = new Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                result = new Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;
        }
        [Route("PutKMProductoEditarPrecioStock")]
        [HttpPut]
        public ActionResult<Response> KoreaMotosMProducto_EditarPrecioStock([FromForm] ERPProducto data)
        {
            Response result = null;
            ProductoDb db = new ProductoDb();
            var list = db.KoreaMotosMProducto_EditarPrecioStock(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.data
                };
            }
            else
            {
                result = new Response()
                {
                    code = -1,
                    message = "Algo salio mal, vuelva a intentarlo",
                    data = new { }
                };
            }
            return result;
        }
        [Route("PostNotificacionStock")]
        [HttpPost]
        public ActionResult<Response> DNotificacionApi_RegistrarStock([FromForm] string notification)
        {
            Response result = null;
            ProductoDb db = new ProductoDb();
            var obj = new Nancy.Json.JavaScriptSerializer().Deserialize<JGRespuesta>(notification);
            var list = db.DNotificacionApi_Registrar(obj, notification);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.data
                };
            }
            else
            {
                result = new Response()
                {
                    code = -1,
                    message = "Algo salio mal, vuelva a intentarlo",
                    data = new { }
                };
            }
            return result;
        }
        [Route("PostNotificacionPrecio")]
        [HttpPost]
        public ActionResult<Response> DNotificacionApi_RegistrarPrecio([FromForm] string notification)
        {
            Response result = null;
            ProductoDb db = new ProductoDb();
            var obj = new Nancy.Json.JavaScriptSerializer().Deserialize<JGRespuesta>(notification);
            var list = db.DNotificacionApi_Registrar(obj, notification);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.data
                };
            }
            else
            {
                result = new Response()
                {
                    code = -1,
                    message = "Algo salio mal, vuelva a intentarlo",
                    data = new { }
                };
            }
            return result;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
