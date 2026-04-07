using crudcomdb.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace crudcomdb.Services
{
    public class AuthService
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public AuthService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public Usuario? UsuarioLogado { get; private set; }

        // Evento que notifica quando o login mudou
        public event Action? OnLogin;

        public async Task Login(Usuario usuario)
        {
            UsuarioLogado = usuario;
            await _sessionStorage.SetAsync("usuarioLogado", usuario);
            OnLogin?.Invoke(); // dispara o evento
        }

        public async Task Logout()
        {
            //UsuarioLogado = null;
            await _sessionStorage.DeleteAsync("usuarioLogado");
            // opcional: poderia ter um evento OnLogout
        }

        public async Task Inicializar()
        {
            var result = await _sessionStorage.GetAsync<Usuario>("usuarioLogado");
            if (result.Success && result.Value != null && !string.IsNullOrWhiteSpace(result.Value.Username))
            {
                UsuarioLogado = result.Value;
            }
            else
            {
                UsuarioLogado = null;
            }
        }

        public bool EstaLogado() => UsuarioLogado != null;
    }
}