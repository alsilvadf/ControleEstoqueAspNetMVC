using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models
{
    public class PerfilUsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Perfil")]
        [Display(Name = "Perfil")]
        public string Nome { get; set; }
        public bool Status { get; set; }

        //Método que irá buscar os perfis cadastrados no banco de dados
        public static List<PerfilUsuarioModel> BuscarPefil()
        {
            //cria uma variavel do tipo da classe
            var ret = new List<PerfilUsuarioModel>();
            //cria uma variavel para executar os comandos do banco de dados
            using (var conexao = new SqlConnection())
            {
                //conectando a uma instancia do banco de dados
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                //abrindo a conexao com o banco de dados
                conexao.Open();
                //cria variavel para executar os comandos do banco de dados
                using (var comando = new SqlCommand())
                {
                    //variavel faz conexao com banco de dados
                    comando.Connection = conexao;
                    //executando o select na base de dados
                    comando.CommandText = String.Format("Select * from perfil_usuario order by nome");
                    //cria variavel que vai receber os valores retornados da consulta
                    var leia = comando.ExecuteReader();
                    //percorrendo a lista de registros retornados do banco de dados
                    while (leia.Read())
                    {
                        //adicionado os valores nas variaveis do modelo
                        ret.Add(new PerfilUsuarioModel
                        {
                            Id = (int)leia["id"],
                            Nome = (string)leia["nome"],
                            Status = (bool)leia["status"]
                        });
                    }
                }
            }
            return ret;
        }

        public static PerfilUsuarioModel BuscarPerilId(int id)
        {
            PerfilUsuarioModel ret = null;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = String.Format("Select * from perfil_usuario where id = {0}", id);
                    var leia = comando.ExecuteReader();
                    if (leia.Read())
                    {
                        ret = new PerfilUsuarioModel()
                        {
                            Id = (int)leia["id"],
                            Nome = (string)leia["nome"],
                            Status = (bool)leia["status"]
                        };
                    }
                }
            }
                return ret;           
        }


    }
}