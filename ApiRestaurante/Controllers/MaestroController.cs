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
using Microsoft.IdentityModel.Protocols;
using System.Net.Http.Headers;
using System.Net.Http;
using WS_FAST;
using System.Collections;
using System.Text.Json;

namespace ApiRestaurante.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MaestroController : Controller
    {
        [Route("GetTipoDocumentoIdentidad")]
        [HttpGet]
        public Models.Response MTipoDocumentoIdentidad_Listar()
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.MTipoDocumentoIdentidad_Listar();
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;
        }

        [Route("GetClienteBuscarPorNroDoc")]
        [HttpGet]
        public Models.Response MCliente_Buscar_Por_NroDoc(string tNroDocumento, string tEmpresaRuc,int iTipo)
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.MCliente_Buscar_Por_NroDoc(tNroDocumento, tEmpresaRuc);
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                if (iTipo==1)
                {
                    Task<Models.Response> BusquedaDni = MCliente_Buscar_WSDni(tNroDocumento);
                    if (BusquedaDni.Result.code == 200)
                    {
                        result = BusquedaDni.Result;
                    }
                    else
                    {
                        result = new Models.Response()
                        {
                            code = 2,
                            message = "Sin información disponible",
                            data = new string[] { }
                        };
                    }
                }
                if (iTipo == 2)
                {
                    Task<Models.Response> BusquedaRuc = MCliente_Buscar_WSRuc(tNroDocumento);
                    if (BusquedaRuc.Result.code == 200)
                    {
                        result = BusquedaRuc.Result;
                    }
                    else
                    {
                        result = new Models.Response()
                        {
                            code = 2,
                            message = "Sin información disponible",
                            data = new string[] { }
                        };
                    }
                }

            }
            return result;
        }

        [Route("GetClienteBuscarWSDni")]
        [HttpGet]
        public async Task<Models.Response> MCliente_Buscar_WSDni(string tNroDocumento)
        {
            Models.Response result = null;
            ws_fastSoapClient WS = new ws_fastSoapClient(ws_fastSoapClient.EndpointConfiguration.ws_fastSoap12);
            ConsultDni list = new ConsultDni();
            list = await WS.ConsultaDniAsync("20531641451", "20531641451", tNroDocumento);
            if (list != null)
            {
                List<MCliente> listPersona = new List<MCliente>();
                listPersona.Add(new MCliente { tNroDocumento = list.tNroDocumento, tNombre= list.tNombres });
                result = new Models.Response()
                {
                    code = list.statuscode,
                    message = list.message,
                    data = listPersona
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;

        }

        [Route("GetClienteBuscarWSRuc")]
        [HttpGet]
        public async Task<Models.Response> MCliente_Buscar_WSRuc(string tNroDocumento)
        {
            Models.Response result = null;
            ws_fastSoapClient WS = new ws_fastSoapClient(ws_fastSoapClient.EndpointConfiguration.ws_fastSoap12);
            ConsultRuc list = new ConsultRuc();
            list = await WS.ConsultaRucAsync("20531641451", "20531641451", tNroDocumento);
            if (list != null)
            {
                List<MCliente> listPersona = new List<MCliente>();
                listPersona.Add(new MCliente { tNroDocumento = list.tNroDocumento, tNombre = list.tRazonSocial,tDireccion=list.tDireccionCompleta });
                result = new Models.Response()
                {
                    code = list.statuscode,
                    message = list.message,
                    data = listPersona
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;
        }

        [Route("GetEmpleado")]
        [HttpGet]
        public Models.Response MEmpleados_Listar(string tEmpresaRuc)
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.MEmpleados_Listar(tEmpresaRuc);
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;
        }

        [Route("GetCajaListar")]
        [HttpGet]
        public Models.Response MCaja_Listar(string tEmpresaRuc)
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.MCaja_Listar(tEmpresaRuc);
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;
        }

        [Route("GetMenuPrincipal")]
        [HttpGet]
        public Models.Response MMenuPrincipal_Listar(Int64 iMUsuario, string tEmpresaRuc)
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.MMenuPrincipal_Listar(iMUsuario,tEmpresaRuc);
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;
        }

        [Route("GetNavBarRight")]
        [HttpGet]
        public Models.Response MNavBarRight_Listar(Int64 iMUsuario, string tEmpresaRuc)
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.MNavBarRight_Listar(iMUsuario, tEmpresaRuc);
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Sin información disponible",
                    data = new string[] { }
                };
            }
            return result;
        }

        [Route("PostConfiguracionImpresora")]
        [HttpPost]
        public async Task<Models.Response> DConfiguracionImpresora_Registrar([FromForm] DConfigInpresora data)
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.DConfiguracionImpresora_Registrar(data);
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = list.code,
                    message = list.message,
                    data = list.code == 0 ? new { iDConfigImpresora = Ok(list.data).Value } : new { }
                };
            }
            else
            {
                result = new Models.Response()
                {
                    code = 2,
                    message = "Datos invalidos, vuelva  a intentarlo",
                    data = new { }
                };
            }
            return result;
        }

        [Route("GetConfiguracionImpresora")]
        [HttpGet]
        public Models.Response MConfiguracionImpresora_Listar(Int64 iMUsuario, string tEmpresaRuc, Int64 iDSucursal)
        {
            Models.Response result = null;
            MaestroDb db = new MaestroDb();
            var list = db.MConfiguracionImpresora_Listar(iMUsuario, tEmpresaRuc, iDSucursal);
            if (list != null)
            {
                result = new Models.Response()
                {
                    code = 0,
                    message = "Búsqueda exitosa",
                    data = list
                };
            }
            else
            {
                result = new Models.Response()
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
