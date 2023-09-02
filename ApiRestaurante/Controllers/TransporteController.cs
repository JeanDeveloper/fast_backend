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
    public class TransporteController : Controller
    {
        [Route("GetCiudad")]
        [HttpGet]
        public Response MCiudad_Listar(string tEmpresaRuc)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MCiudad_Listar(tEmpresaRuc);
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

        [Route("GetProgramacion")]
        [HttpGet]
        public Response MProgramacion_Listar(string tEmpresaRuc, DateTime fFecha, int iOrigen, int iDestino)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MProgramacion_Listar(tEmpresaRuc, fFecha, iOrigen, iDestino);
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

        [Route("GetNiveles")]
        [HttpGet]
        public Response MNivelesVehiculo_Listar(Int64 iMModeloTransporte)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MNivelesVehiculo_Listar(iMModeloTransporte);
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

        [Route("GetModeloAsientoBuscar")]
        [HttpGet]
        public Response MModeloAsiento_Buscar(Int64 iDProgramacionFecha, Int64 iMModeloTransporte, int iNivel, int iMOrigen, int iMDestino)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MModeloAsiento_Buscar(iDProgramacionFecha, iMModeloTransporte, iNivel, iMOrigen, iMDestino);
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

        [Route("GetObtenerDatosBoleto")]
        [HttpGet]
        public Response MObtenerDatosBoleto_Buscar(Int64 iMVentaTransporte)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MObtenerDatosBoleto_Buscar(iMVentaTransporte);
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

        [Route("PostAnularReserva")]
        [HttpPost]
        public Response MVentasBoleto_Reserva_Anular([FromForm] BoletoReservaAnular data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MVentasBoleto_Reserva_Anular(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iMVentaTransporte = Ok(list.data).Value } : new { }
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

        [Route("PostVentasBoletoRegistrar")]
        [HttpPost]
        public Response MVentasBoleto_Transporte_Registrar([FromForm] VentaBoleto data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MVentasBoleto_Transporte_Registrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iMVentaTransporte = Ok(list.data).Value } : new { }
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

        [Route("PostCodigoVentasTransporteRegistrar")]
        [HttpPost]
        public Response MCodigoVentasTransporte_Registrar([FromForm] CodigoVentaBoleto data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MCodigoVentasTransporte_Registrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iMVentaTransporte = Ok(list.data).Value } : new { }
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

        [Route("PostVentasReservaRegistrar")]
        [HttpPost]
        public Response MVentasReserva_Transporte_Registrar([FromForm] VentaBoleto data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MVentasReserva_Transporte_Registrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iDPedido = Ok(list.data).Value } : new { }
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

        [Route("PostVentasBoletoReservar")]
        [HttpPost]
        public Response MVentasBoleto_Transporte_Reservar([FromForm] VentaBoleto data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MVentasBoleto_Transporte_Reservar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iDPedido = Ok(list.data).Value } : new { }
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

        [Route("PostAnularBoleto")]
        [HttpPost]
        public Response MVentasBoleto_Anular([FromForm] BoletoAnular data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MVentasBoleto_Anular(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iMVentaTransporte = Ok(list.data).Value } : new { }
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

        [Route("PostOrdenTrasladoRegistrar")]
        [HttpPost]
        public Response MOrdenTraslado_Registrar([FromForm] OrdenTrasladoRegistrar data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MOrdenTraslado_Registrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iMOrden = Ok(list.data).Value } : new { }
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

        [Route("PostCodigoOrdenTrasladoRegistrar")]
        [HttpPost]
        public Response MCodigoOrdenTraslado_Registrar([FromForm] CodigOrdenTraslado data)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MCodigoOrdenTraslado_Registrar(data);
            if (list != null)
            {
                result = new Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iMVentaTransporte = Ok(list.data).Value } : new { }
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

        [Route("GetOrdenTraslado")]
        [HttpGet]
        public Response MOrdenTraslado_Listar(string tEmpresaRuc,  DateTime fDesde, DateTime fHasta)
        {
            Response result = null;
            TransporteDb db = new TransporteDb();
            var list = db.MOrdenTraslado_Listar(tEmpresaRuc, fDesde,fHasta);
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
