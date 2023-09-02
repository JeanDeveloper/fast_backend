using ApiRestaurante.DbHandle;
using ApiRestaurante.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        public IConfiguration _configuration;
        public SeguridadController(IConfiguration config)
        {
            _configuration = config;
        }
        [AllowAnonymous]
        [Route("Token")]
        [HttpPost]
        public Response Token(string usuario, string clave)
        {
            Response result = null;
            result = new Response();
            if (usuario != null && usuario.Length > 0 && clave != null && clave.Length > 0)
            {
                SeguridadDb db = new SeguridadDb();
                var user = db.UsuarioApi_Validar(usuario, clave);
                if (user.iEstado == 0)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("iUsuarioApi", user.iUsuarioApi.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(500),
                        signingCredentials: signIn);

                    result = new Response()
                    {
                        code = user.iEstado,
                        message = user.tMessage,
                        data = new
                        {
                            _token = Ok(new JwtSecurityTokenHandler().WriteToken(token)).Value,
                            tVersionAndroid = user.tVersionAndroid,
                            tVersionIOS = user.tVersionIOS
                        }
                    };
                }
                else
                {
                    result = new Response()
                    {
                        code = user.iEstado,
                        message = user.tMessage,
                        data = new { }
                    };
                }
            }
            else
            {
                result = new Response()
                {
                    code = -1,
                    message = "Error, No se enviaron las credenciales",
                    data = new { }
                };
            }
            return result;
        }
        [Route("IniciarSesion")]
        [HttpPost]
        public Response IniciarSesion(string usuario, string clave)
        {
            Response result = null;
            result = new Response();
            if (usuario != null && usuario.Length > 0 && clave != null && clave.Length > 0)
            {
                SeguridadDb db = new SeguridadDb();
                if (clave != "") clave = Cryptography.Encrypt(clave);
                var user = db.Usuario_IniciarSession(usuario, clave);
                if (user != null)
                {
                    result = new Response()
                    {
                        code = 0,
                        message = "Credenciales Válidas",
                        data = user
                    };
                }
                else
                {
                    result = new Response()
                    {
                        code = -1,
                        message = "Error de datos, Credenciales Inválidas",
                        data = new { }
                    };
                }
            }
            else
            {
                result = new Response()
                {
                    code = -1,
                    message = "Error, No se enviaron las credenciales",
                    data = new { }
                };
            }
            return result;
        }
    }
}
