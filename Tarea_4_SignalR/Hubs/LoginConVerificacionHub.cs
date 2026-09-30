using Tarea_4_SignalR.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
namespace Tarea_4_SignalR.Hubs
{
    public class LoginConVerificacionHub  : Hub
    {
        private readonly ILogger<LoginConVerificacionHub> _logger;

        public LoginConVerificacionHub(ILogger<LoginConVerificacionHub> logger)
        {
            _logger = logger;
        }

        public void Login(String email, String pass) {
            _logger.LogInformation("SignalR identificacion del usuario: " + Context.ConnectionId);
            Usuario usr = new Usuario(email, pass);
            if (usr.EsUsuarioValido())
            {
                if (usr.NecesitarVerificacion())
                {
                    string usrId = Context.ConnectionId;
                    _logger.LogInformation($"**** Copiar la siguiente url para probar");
                    _logger.LogInformation($"curl https://localhost:7033/verificar/usuario/{usrId}");
                }
            };
        }

        public void EnviarVerificacionOk()
        {
            Clients.User(Context.UserIdentifier).SendAsync("VerificacionOk", "");
        }
    }
}
