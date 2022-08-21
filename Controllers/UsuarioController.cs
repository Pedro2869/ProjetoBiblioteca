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
            return View("ListaUsuarios");
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
        public IActionResult EditarUsuario(int idUser)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            Usuario u = new UsuarioService().Listar(idUser);
            return View(u);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario userEditado)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            new UsuarioService().Editar(userEditado);
            return View("ListaUsuarios");
        }

        // ACTION DE EXCLUSÃO

        public IActionResult ExcluirUsuario(int idUser)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            new UsuarioService().Excluir(idUser);
            return View("ListaUsuarios");
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