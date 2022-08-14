using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.ToList();
            }
        }

        public void Inserir(Usuario usuario)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(usuario);
                bc.SaveChanges();
            }
        }

        public void Editar(Usuario usuario)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuarios = bc.Usuarios.Find(usuario.Id);

                usuarios.Nome = usuario.Nome;
                usuarios.Login = usuario.Login;
                usuarios.Senha = usuario.Senha;
                usuarios.Tipo = usuario.Tipo;

                bc.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Remove(bc.Usuarios.Find(id));
                bc.SaveChanges();
            }
        }
    }
}