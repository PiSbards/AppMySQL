using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using AppMySQL.Models;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppMySQL.Controller
{
    public class MySQLConn
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb_pietro_tds10;user id=freedb_pips96;password=Pv7NP7Y&qB%n!R3;charset=utf8";
        public static List<Pessoas> ListarPessoas()
        {
            List<Pessoas> listapessoas = new List<Pessoas>();
            string sql = "SELECT * FROM pessoa";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pessoas pessoa = new Pessoas()
                            {
                                id = reader.GetInt32(0),
                                nome = reader.GetString(1),
                                idade = reader.GetString(2),
                                cidade = reader.GetString(3)
                            };
                            listapessoas.Add(pessoa);
                        }
                    }
                }
                con.Close();
                return listapessoas;
            }
        }

        public static void InserirPessoa(string nome,string idade,string cidade)
        {
            string sql = "INSERT INTO pessoa(nome,idade,cidade) VALUES (@nome,@idade,@cidade)";
            using(MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = idade;
                    cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cidade;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void AtualizarPessoa(Pessoas pessoa)
        {
            string sql = "UPDATE pessoa SET nome=@nome,idade=@idade,cidade=@cidade WHERE id=@id";
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = pessoa.nome;
                        cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = pessoa.idade;
                        cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = pessoa.cidade;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = pessoa.id;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));

            }
            
        }
        public static void ExcluirPessoa(Pessoas pessoa)
        {
            string sql = "DELETE FROM pessoa WHERE id=@id";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = pessoa.id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
