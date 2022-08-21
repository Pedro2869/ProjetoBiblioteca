using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        // ACTION PARA REGISTRAR USUÁRIO
        // ACTION QUE RECEBA OS REGISTROS
        public IActionResult CadastrarUsuario()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario user)
        {
            user.Senha = Criptografia.TextoCriptografado(user.Senha);
            new UsuarioService().Inserir(user);
            return RedirectToAction("ListaUsuarios");
        }

        // ACTION LISTAR
        public IActionResult ListaUsuarios()
        {
            // FAZER LOGO ESSA LISTA DE USUÁRIOS
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View(new UsuarioService().Listar());
        }

        // ACTION DE EDITAR

        // ACTION DE DADOS RECEBIDOS
        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            Usuario u = new UsuarioService().Listar(id);
            return View(u);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario userEditado)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            new UsuarioService().Editar(userEditado);
            return RedirectToAction("ListaUsuarios");
        }

        // ACTION DE EXCLUSÃO

        public IActionResult ExcluirUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            new UsuarioService().Excluir(id);
            return RedirectToAction("ListaUsuarios");
        }


        // SAIR E PERMISSÃO
        public IActionResult Permissão()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}