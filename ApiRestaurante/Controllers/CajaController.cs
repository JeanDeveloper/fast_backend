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
    public class CajaController : Controller
    {
        [Route("GetCajaDiaria")]
        [HttpGet]
        public Response MCajaDiaria_Listar(string tEmpresaRuc,DateTime fFechaInicio, DateTime fFechaFin)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.MCajaDiaria_Listar(tEmpresaRuc, fFechaInicio,fFechaFin);
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

        [Route("PostCajaDiariaRegistrar")]
        [HttpPost]
        public Response DCajaDiaria_Registrar([FromForm] CajaDiariaRegistrar data)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.DCajaDiaria_Registrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iMCajadiaria = Ok(list.data).Value } : new { }
                };
            }
            else
            {
                result = new Response()
                {
                    code = 2,
                    message = "Datos invalidos, vuelva  a intentarlo",
                    data = new { }
                };
            }
            return result;
        }

        [Route("GetCajaDiariaPorId")]
        [HttpGet]
        public Response DCajaDiaria_BuscarPorId(string iDCajaDiaria)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.DCajaDiaria_BuscarPorId(iDCajaDiaria);
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

        [Route("GetTerminalCajaDiariaImporte")]
        [HttpGet]
        public Response MTerminal_DCajaDiaria_Importe_Buscar(Int64 iMCaja, Int64 iDCajaDiaria)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.MTerminal_DCajaDiaria_Importe_Buscar(iMCaja, iDCajaDiaria);
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

        [Route("GetCajaDiariaDetalle")]
        [HttpGet]
        public Response DCajaDiariaDetalle_Listar(Int64 iDCajaDiaria, int iTipo)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.DCajaDiariaDetalle_Listar(iDCajaDiaria, iTipo);
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

        [Route("PostCajaDiariaCerrar")]
        [HttpPost]
        public Response DCajaDiaria_Cerrar([FromForm] CajaDiariaCerrar data)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.DCajaDiaria_Cerrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iDCajaDiaria = Ok(list.data).Value } : new { }
                };
            }
            else
            {
                result = new Response()
                {
                    code = 2,
                    message = "Datos invalidos, vuelva  a intentarlo",
                    data = new { }
                };
            }
            return result;
        }

        [Route("GetCajaDiariaAbiertaUsuario")]
        [HttpGet]
        public Response DCajaDiariaAbiertaUsuario_Listar(DateTime fFechaInicio, DateTime fFechaFin, string tEmpresaRuc, Int64 iDSucursal, Int64 iMUsuario)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.DCajaDiariaAbiertaUsuario_Listar(fFechaInicio, fFechaFin, tEmpresaRuc, iDSucursal, iMUsuario);
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

        [Route("PostCajaDiariaDetalleRegistrar")]
        [HttpPost]
        public Response DCajaDiariaDetalle_Registrar([FromForm] CajaDiariaDetalleRegistrar data)
        {
            Response result = null;
            CajaDb db = new CajaDb();
            var list = db.DCajaDiariaDetalle_Registrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iDCajaDiaria = Ok(list.data).Value } : new { }
                };
            }
            else
            {
                result = new Response()
                {
                    code = 2,
                    message = "Datos invalidos, vuelva  a intentarlo",
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
