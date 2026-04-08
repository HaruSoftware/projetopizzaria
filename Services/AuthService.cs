using crudcomdb.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text.Json;

namespace crudcomdb.Services
{
    public class AuthService
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public Usuario? UsuarioLogado { get; private set; }

        public event Action? OnLogin;

        public AuthService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task Login(Usuario usuario)
        {
            UsuarioLogado = usuario;

            await _sessionStorage.SetAsync("UsuarioLogado", JsonSerializer.Serialize(usuario));
            OnLogin?.Invoke();
        }

        public async Task Logout()
        {
            UsuarioLogado = null;
            await _sessionStorage.DeleteAsync("UsuarioLogado");
            OnLogin?.Invoke();
        }

        public async Task Inicializar()
        {
            var result = await _sessionStorage.GetAsync<string>("UsuarioLogado");
            if (result.Success && !string.IsNullOrEmpty(result.Value))
            {
                UsuarioLogado = JsonSerializer.Deserialize<Usuario>(result.Value);
                OnLogin?.Invoke();
            }
        }

        public bool EstaLogado() => UsuarioLogado != null;
    }
}