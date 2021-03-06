using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RpgMvc.Models;

namespace RpgMvc.Controllers
{
    public class UsuariosController : Controller
    {
        public string uriBase = "http://www.KaPemi.somee.com/RpgApi/Usuarios/";

        [HttpGet]
        public ActionResult Index()
        {
            return View ("CadastrarUsuario");
        }
        [HttpPost]
        public async Task<ActionResult> RegistrarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";
                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("apllication/json");

                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = string.Format("Usuario {0} Registrado. Faça o login", u.Username);  
                    return View ("AutenticarUsuario");      
                }
                else
                {
                    TempData ["MensagemErro"] = serialized;
                    return RedirectToAction ("Index");        
                }

            } 
            catch (System.Exception ex)
            {
                TempData ["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        
    }
}