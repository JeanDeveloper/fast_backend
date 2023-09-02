using ApiRestaurante.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using WS_FAST;
using System.Threading.Tasks;
using ApiRestaurante.DbHandle;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyModel;

namespace ApiRestaurante.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        [Route("AnularComprobante")]
        [HttpPost]
        public async Task<Models.Response> AnularComprobante([FromForm] DAnular data)
        {
            Models.Response result = null;
            ws_fastSoapClient WS = new ws_fastSoapClient(ws_fastSoapClient.EndpointConfiguration.ws_fastSoap12);
            int respuesta = await WS.AnularComprobanteAsync(data.ComprobanteId,data.Motivo,data.UsuarioId);
            if (respuesta == 1)
            {
                //TransporteDb db = new TransporteDb();
                //var list = db.MObtenerDatosBoleto_Buscar(data.ComprobanteId);
                result = new Models.Response()
                {
                    code = 0,
                    message = "Comprobante Anulado Correctamente",
                    data = "1"
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

        [Route("InsertWS")]
        [HttpPost]
        public async Task<Models.Response> InsertWS([FromForm] DInsertWebService data)
        {
            Models.Response result = null;
            JsonResult response = null;
            List<Comprobante> list = new List<Comprobante>();
            ComprobanteDb cn = new ComprobanteDb();
            ws_fastSoapClient WS = new ws_fastSoapClient(ws_fastSoapClient.EndpointConfiguration.ws_fastSoap12);
            List<Empresa> list_emp = new List<Empresa>();
            EmpresaDb be = new EmpresaDb();
            string RucEmisor_ = data.tEmpresaRuc.ToString();
            list_emp = be.Empresas(RucEmisor_);
            int IdComprobante = 0;
            Empresa empresa = list_emp[0];
            switch (empresa.tVersion)
            {
                case "2.1":
                    {
                        WS_FAST.Response respuesta = await WS.GenerarComprobanteV21Async(data.Comprobante.Replace("contado", "Contado"));
                        IdComprobante = Int32.Parse(respuesta.Content.ToString());
                        break;
                    }
                case "2.0":
                    {
                        switch (data.TipoDoc)
                        {
                            case "01":
                                {
                                    IdComprobante = await WS.GenerarComprobanteAsync(data.Comprobante.Replace("contado", "Contado"));
                                    break;
                                }
                            case "03":
                                {
                                    IdComprobante = await WS.GenerarComprobanteAsync(data.Comprobante.Replace("contado", "Contado"));
                                    break;
                                }
                            case "07":
                                {
                                    IdComprobante = await WS.GenerarComprobanteAsync(data.Comprobante.Replace("contado", "Contado"));
                                    break;
                                }
                            case "08":
                                {
                                    IdComprobante = await WS.GenerarComprobanteAsync(data.Comprobante.Replace("contado", "Contado"));
                                    break;
                                }
                        }
                        break;
                    }
            }

            int flag = 0;
            if (IdComprobante != 0)
            {
                if (String.IsNullOrEmpty(data.iTipo))
                {
                    flag = await WS.DocumentoPDFAsync(IdComprobante, data.FormatoPdf);
                }
                else
                {
                    flag  = await WS.DocumentoPDFAsync(IdComprobante, "16");
                }

                string userid = data.UsuarioId.ToString();
                cn.JsonLog_Registrar(IdComprobante, Int32.Parse(userid), data.Comprobante.Replace("contado", "Contado"));

                var comp = new JavaScriptSerializer().Deserialize<DocumentoElectronico>(data.Comprobante.Replace("contado", "Contado"));

                if (comp.lAfectaStock == 1)
                {
                    int lNotaSalida = 0, lNotaSalidaMov = 0;
                    for (int i = 0; i < comp.Items.Count; i++)
                    {
                        if (comp.Items[i].iDCotizacionPadreMov == 1)
                        {
                            lNotaSalida += 1;
                        }
                        else
                        {
                            lNotaSalidaMov += 1;
                        }
                    }

                    Int64 iDMovimiento = 0;
                    AlmacenDb cn2 = new AlmacenDb();

                    if (empresa.lAlmacen && comp.lEstadoAnticipo == 0 && comp.iDAlmacen != null && lNotaSalidaMov > 0) //comp.lNotaSalida == false)
                    {
                        Movimiento nMovimiento = new Movimiento();
                        nMovimiento.iMTipoMovimiento = comp.TipoDocumento == "07" ? 1 : 2;
                        nMovimiento.iMMotivoMovimiento = comp.TipoDocumento == "07" ? 2 : 3;
                        nMovimiento.iAlmacenOrigen = comp.TipoDocumento == "01" || comp.TipoDocumento == "03" ? comp.iDAlmacen : null;
                        nMovimiento.iAlmacenDestino = comp.TipoDocumento == "07" ? comp.iDAlmacen : null;
                        nMovimiento.tEmpresaRuc = data.tEmpresaRuc.ToString();
                        nMovimiento.iMTipoDocumento = Int64.Parse(comp.TipoDocumento.ToString());
                        nMovimiento.tSerieDoc = comp.Serie;
                        nMovimiento.tNumeroDoc = comp.Numero;
                        nMovimiento.iMProveedor = comp.iMCliente;
                        nMovimiento.tNumeroGuia = "";
                        nMovimiento.tNumeroGuia = "";
                        nMovimiento.tObservaciones = comp.Observacion1;
                        nMovimiento.fFechaMovimiento = DateTime.Parse(comp.FechaEmision.ToString());
                        nMovimiento.iUsuarioRegistro = Int32.Parse(data.UsuarioId.ToString());
                        nMovimiento.iOrigenRegistro = 4;
                        nMovimiento.iVenta = IdComprobante;
                        nMovimiento.tMoneda = comp.Moneda;
                        nMovimiento.nTipoCambio = decimal.Parse(comp.TipoCambio.ToString());
                        var resultado = cn2.DMovimiento_Registrar(nMovimiento);
                        if (resultado.MessageOut_ > 0)
                        {
                            iDMovimiento = resultado.MessageOut_;
                        }
                    }

                    if (empresa.lAlmacen && comp.lEstadoAnticipo == 0 && comp.iDAlmacen != null)
                    {
                        comp.Items.ForEach(delegate (DetalleDocumento nMovimientoDetalle_)
                        {
                            Movimiento_Detalle nMovimientoDetalle = new Movimiento_Detalle();

                            if (nMovimientoDetalle_.iDCotizacionPadreMov == 0)
                            {
                                nMovimientoDetalle.iDMovimiento = iDMovimiento;
                                nMovimientoDetalle.iMProducto = Int64.Parse(nMovimientoDetalle_.CodigoItem);
                                nMovimientoDetalle.iMProductoAgrupador = Int64.Parse(nMovimientoDetalle_.CodigoItem);
                                nMovimientoDetalle.nCantidad = nMovimientoDetalle_.Cantidad;
                                nMovimientoDetalle.tLote = "";
                                nMovimientoDetalle.iPresentacion = 1;
                                nMovimientoDetalle.UnidadMedida = nMovimientoDetalle_.UnidadMedida;
                                nMovimientoDetalle.nPrecioCompra = nMovimientoDetalle_.PrecioCompra;
                                nMovimientoDetalle.nPrecioVenta = nMovimientoDetalle_.PrecioUnitario;
                                nMovimientoDetalle.tObservaciones = nMovimientoDetalle_.Observacion;
                                nMovimientoDetalle.nPCBase = nMovimientoDetalle_.PCBase;
                                nMovimientoDetalle.nPCIgv = nMovimientoDetalle_.PCIgv;
                                nMovimientoDetalle.nPVBase = nMovimientoDetalle_.PrecioReferencial;
                                nMovimientoDetalle.nPVIgv = nMovimientoDetalle_.Impuesto;
                                nMovimientoDetalle.nPCTBase = nMovimientoDetalle_.PCTBase;
                                nMovimientoDetalle.nPCTIgv = nMovimientoDetalle_.PCTIgv;
                                nMovimientoDetalle.nPVTBase = nMovimientoDetalle_.TotalVenta;
                                nMovimientoDetalle.nPVTIgv = nMovimientoDetalle_.IgvVenta;
                                nMovimientoDetalle.nPCTotal = nMovimientoDetalle_.PCTotal;
                                nMovimientoDetalle.nPVTotal = nMovimientoDetalle_.Total;
                                nMovimientoDetalle.iDStock = nMovimientoDetalle_.iDStock;
                                nMovimientoDetalle.iDOrden = nMovimientoDetalle_.iDOrden;
                                nMovimientoDetalle.tMoneda = nMovimientoDetalle_.tMoneda;
                                nMovimientoDetalle.nTipoCambio = nMovimientoDetalle_.nTipoCambio;
                                nMovimientoDetalle.nPCBaseSoles = nMovimientoDetalle_.nPCBaseSoles;
                                nMovimientoDetalle.nPCIgvSoles = nMovimientoDetalle_.nPCIgvSoles;
                                nMovimientoDetalle.nPCompraSoles = nMovimientoDetalle_.nPCompraSoles;
                                nMovimientoDetalle.nPCTBaseSoles = nMovimientoDetalle_.nPCTBaseSoles;
                                nMovimientoDetalle.nPCTIgvSoles = nMovimientoDetalle_.nPCTIgvSoles;
                                nMovimientoDetalle.nPCTotalSoles = nMovimientoDetalle_.nPCTotalSoles;
                                nMovimientoDetalle.nPVBaseSoles = nMovimientoDetalle_.nPVBaseSoles;
                                nMovimientoDetalle.nPVIgvSoles = nMovimientoDetalle_.nPVIgvSoles;
                                nMovimientoDetalle.nPVentaSoles = nMovimientoDetalle_.nPVentaSoles;
                                nMovimientoDetalle.nPVTBaseSoles = nMovimientoDetalle_.nPVTBaseSoles;
                                nMovimientoDetalle.nPVTIgvSoles = nMovimientoDetalle_.nPVTIgvSoles;
                                nMovimientoDetalle.nPVTotalSoles = nMovimientoDetalle_.nPVTotalSoles;
                                nMovimientoDetalle.nPCompraInicial = nMovimientoDetalle_.nPCompraInicial;
                                cn2.DmovimientoDetalle_Registrar(nMovimientoDetalle);
                            }
                            else if (nMovimientoDetalle_.iDCotizacionPadreMov == 1)
                            {
                                Movimiento mMovimiento = new Movimiento();
                                mMovimiento.iMProveedor = comp.iMCliente;
                                mMovimiento.iMTipoDocumento = Int64.Parse(comp.TipoDocumento.ToString());
                                mMovimiento.tSerieDoc = comp.Serie;
                                mMovimiento.tNumeroDoc = comp.Numero;
                                mMovimiento.tObservaciones = comp.Observacion1;
                                mMovimiento.fFechaMovimiento = DateTime.Parse(comp.FechaEmision.ToString());
                                mMovimiento.iUsuarioRegistro = data.UsuarioId;
                                mMovimiento.iOrigenRegistro = 4;
                                mMovimiento.iVenta = IdComprobante;
                                mMovimiento.iDCotizacion = nMovimientoDetalle_.iDCotizacionPadre;//iDCotizacion;
                                AlmacenDb cn3 = new AlmacenDb();
                                var results = cn3.DMovimiento_Editar(mMovimiento);
                            }
                        });
                    }
                }

                if (comp.lEstadoAnticipo == 0)
                {
                    if (empresa.lOrdenVenta == true || empresa.lCotizacion == true)
                    {
                        cn.Comprobante_Cotizacion_Registrar_V1(IdComprobante, 1);
                    }
                }

                if (empresa.lVentasPromocion == true)
                {
                    cn.Comprobante_Verificar_Promocion(IdComprobante, empresa.iVentasPromocionCantidad);
                }

                if (flag != 0)
                {
                    list = cn.selectComprobantes(IdComprobante);
                }

                TallerDb cn4 = new TallerDb();
                comp.Items.ForEach(delegate (DetalleDocumento ActualizarOrden)
                {
                    Movimiento_Detalle nMovimientoDetalle = new Movimiento_Detalle();
                    if (ActualizarOrden.OrdenServicio != 0)
                    {
                        cn4.ActualizarOrdenServicio(ActualizarOrden.OrdenServicio);
                    }

                });
            }
            else
            {
                list = null;
            }

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

        [Route("GetSerieByTipo")]
        [HttpGet]
        public Models.Response MSerieByTipo(string TipoDoc, bool? lTransporte, string tEmpresaRuc, int iDSucursal, int UsuarioId)
        {
            Models.Response result = null;
            ComprobanteDb db = new ComprobanteDb();
            var list = db.selectDocumentoSerieByTipo(tEmpresaRuc, TipoDoc, iDSucursal, UsuarioId, lTransporte);
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

        [Route("GetNumeroDoc")]
        [HttpGet]
        public Models.Response selectNumeroDoc(string tEmpresaRuc, string TipoDoc, string SerieDoc)
        {
            Models.Response result = null;
            ComprobanteDb db = new ComprobanteDb();
            var list = db.selectNumeroDoc(TipoDoc, SerieDoc, tEmpresaRuc);
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

        [Route("GetComprobanteSendMail")]
        [HttpGet]
        public Models.Response comprobante_sendMail(int Comprobante, string Correo, string autoriza, string Mensaje)
        {
            Models.Response result = null;
            ComprobanteDb db = new ComprobanteDb();
            var list = db.comprobante_sendMail(Comprobante, Correo, autoriza, Mensaje);
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
    }
}
