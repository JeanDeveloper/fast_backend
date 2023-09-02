using ApiRestaurante.DbHandle;
using ApiRestaurante.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class RestauranteController : ControllerBase
    {
        [Route("GetNiveles")]
        [HttpGet]
        public Response MSalon_Listar(string tEmpresaRuc, Int64 iDSucursal)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MSalon_Listar(tEmpresaRuc, iDSucursal);
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
        [Route("GetMesas")]
        [HttpGet]
        public Response MMesa_Listar(Int64 iMSalon)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MMesa_Listar(iMSalon);
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
        [Route("GetOrdenMesa")]
        [HttpGet]
        public Response DPedidoDetalle_Listar(Int64 iMMesa, string tEmpresaRuc)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoDetalle_Listar(iMMesa, tEmpresaRuc);
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
        [Route("GetOrdenProductoMesa")]
        [HttpGet]
        public Response DPedidoDetalle_ListarPorId(Int64 iDPedidoDetalle)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoDetalle_ListarPorId(iDPedidoDetalle);
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
                    data = new { }
                };
            }
            return result;
        }
        [Route("GetCartaCategoria")]
        [HttpGet]
        public Response MCategoria_Listar(string tEmpresaRuc)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MCategoria_Listar(tEmpresaRuc);
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
        [Route("GetCartaProductos")]
        [HttpGet]
        public Response MProductos_Listar(string tEmpresaRuc)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MProductos_Listar(tEmpresaRuc);
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
        [Route("PostGenerarOrden")]
        [HttpPost]
        public Response DPedido_Registrar([FromForm] DPedido data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedido_Registrar(data);
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
        [Route("PostAgregarItemOrden")]
        [HttpPost]
        public async Task<Response> DPedidoDetalle_RegistrarAsync([FromForm] DPedidoProducto data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoDetalle_Registrar(data);
            if (list != null)
            {
                if (data.iConexion == 1)
                {
                    dynamic pdf = new { formatos = new string[] { } };

                    if (list.code == 0) pdf = await Pedido_GenerarPdfAsync(data.iDPedido, data.iDFormatoOrden, list.data, data.iConexion,"MESA");

                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = list.code == 0 ? pdf.data : new { }
                    };
                }
                else
                {
                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = list.code 
                    };
                }
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
        
        [Route("PutAnularOrden")]
        [HttpPut]
        public async Task<Response> DPedidoDetalle_AnularAsync([FromForm] DPedidoDetalleAnular data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoDetalle_Anular(data);
            if (list != null)
            {
                if (data.iConexion == 1)
                {
                    dynamic pdf = new { formatos = new string[] { } };

                    if (list.code == 0 || list.code == -6) pdf = await Pedido_GenerarPdfAsync(data.iDPedido, data.iDFormatoAnulacion, list.data, data.iConexion,"ANULAR");
                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = (list.code == 0 || list.code == -6) ? pdf.data : new { }
                    };
                }
                else
                {
                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = (list.code == 0 || list.code == -6) 
                    };
                }
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

        [Route("PutAnularOrdenQA")]
        [HttpPut]
        public async Task<Response> DPedidoDetalle_AnularAsyncQA([FromForm] DPedidoDetalleAnularQA data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoDetalle_AnularQA(data);
            if (list != null)
            {
                if (data.iConexion == 1)
                {
                    dynamic pdf = new { formatos = new string[] { } };

                    if (list.code == 0 || list.code == -6) pdf = await Pedido_GenerarPdfAsync(data.iDPedido, data.iDFormatoAnulacion, list.data, data.iConexion, "ANULAR");
                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = (list.code == 0 || list.code == -6) ? pdf.data : new { }
                    };
                }
                else
                {
                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = (list.code == 0 || list.code == -6)
                    };
                }
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


        [Route("GetFormatosEmpresas")]
        [HttpGet]
        public Response DFormatoEmpresa_Listar(string tEmpresaRuc, Int64 iDSucursal)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DFormatoEmpresa_Listar(tEmpresaRuc, iDSucursal);
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
                    message = "Datos invalidos, vuelva  a intentarlo",
                    data = new { }
                };
            }
            return result;
        }
        [Route("GetPedido_GenerarPdf")]
        [HttpGet]
        public async Task<Response> Pedido_GenerarPdfAsync(Int64 iDPedido, Int64 iDFormato, Int64? iNumeroOrden, int iConexion, string tipo)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();


            if (iConexion==2)
            {
                if (tipo == "PRECUENTA")
                {
                    var list = db.DPedido_Precuenta(iDPedido, iDFormato);
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
                }
                return result;
            }
            else
            {
                WS_FastBeta.ws_fastSoapClient WS = new WS_FastBeta.ws_fastSoapClient(WS_FastBeta.ws_fastSoapClient.EndpointConfiguration.ws_fastSoap12);
                var  list = await WS.FormatoApiRestauranteAsync(iDPedido, iDFormato, iNumeroOrden.ToString());
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
        }

        [Route("PostUnirMesas")]
        [HttpPost]
        public async Task<Response> DUnirMesas([FromForm] DUnirMesas data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DUnirMesas(data);
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

        [Route("PostDesUnirMesas")]
        [HttpPost]
        public async Task<Response> DDesUnirMesas([FromForm] DDesUnirMesas data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DDesUnirMesas(data);
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

        [Route("PostTransferirMesa")]
        [HttpPost]
        public async Task<Response> DTransferirMesa([FromForm] DTransferirMesa data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DTransferirMesa(data);
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

        [Route("GetParaLlevarDelivery")]
        [HttpGet]
        public Response MParaLlevarDelivery_Listar(Int64 iMCanal, Int64 iDSucursal)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MParaLlevarDelivery_Listar(iMCanal, iDSucursal);
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

        [Route("PostLiberar")]
        [HttpPost]
        public async Task<Response> DLiberar([FromForm] DLiberarMesa data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DLiberar(data);
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

        [Route("PostGenerarOrdenLlevar")]
        [HttpPost]
        public async Task<Response> DPedidoOrdenLlevar_RegistrarAsync([FromForm] DPedidoOrdenLlevar data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoOrdenLlevar_Registrar(data);
            if (list != null)
            {
                if (data.iConexion == 1)
                {
                    dynamic pdf = new { formatos = new string[] { } };

                    if (list.code == 0) pdf = await Pedido_GenerarPdfAsync(Int64.Parse(list.message), data.iDFormatoOrden, list.data, data.iConexion,"LLEVAR");

                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = list.code == 0 ? pdf.data : new { }
                    };
                }
                else
                {
                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = list.code
                    };
                }
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

        [Route("PostGenerarOrdenDelivery")]
        [HttpPost]
        public async Task<Response> DPedidoOrdenDelivery_RegistrarAsync([FromForm] DPedidoOrdenDelivery data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoOrdenDelivery_Registrar(data);
            if (list != null)
            {
                if (data.iConexion == 1)
                {
                    dynamic pdf = new { formatos = new string[] { } };

                    if (list.code == 0) pdf = await Pedido_GenerarPdfAsync(Int64.Parse(list.message), data.iDFormatoOrden, list.data, data.iConexion,"DELIVERY");

                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = list.code == 0 ? pdf.data : new { }
                    };
                }
                else
                {
                    result = new Response()
                    {
                        code = list.code,
                        message = list.message,
                        data = list.code
                    };
                }
                
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

        [Route("GetOrdenLlevar")]
        [HttpGet]
        public Response DPedidoDetalleLlevar_Listar(Int64 iDPedido, string tEmpresaRuc)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoDetalleLlevar_Listar(iDPedido, tEmpresaRuc);
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

        [Route("GetZona")]
        [HttpGet]
        public Response MZona_Listar(Int64 iDSucursal)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MZona_Listar(iDSucursal);
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

        [Route("GetClienteDelivery")]
        [HttpGet]
        public Response MClienteDelivery_Listar(string tTelefono, Int64 iDSucursal)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MClienteDelivery_Listar(tTelefono, iDSucursal); 
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

        [Route("PostPedidoDelivery")]
        [HttpPost]
        public async Task<Response> DPedidoDelivery_RegistrarAsync([FromForm] DPedidoDelivery data)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.DPedidoDelivery_Registrar(data);
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

        [Route("GetReasons")]
        [HttpGet]
        public Response MReasonsByEnterprise(string ruc)
        {
            Response result = null;
            RestauranteDb db = new RestauranteDb();
            var list = db.MGetReasonByEnterprise(ruc); 
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
            

    }
}
