using System.Data.SqlClient;

namespace ControleEstoque.Web.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            using (var conexao = new SqlConnection())
            {
                var ret = false;
                conexao.ConnectionString = @"Data Source=DESKTOP-19Q6CNI\SQLEXPRESS; Initial Catalog=controle-estoque; User Id=admin; Password=123";

                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select count(*) from usuario where login='{0}' and senha='{1}'", login, senha);
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
                return ret;
            }

        }
    }
}