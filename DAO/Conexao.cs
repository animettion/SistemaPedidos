using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class Conexao
    {


        //private SqlConnection AbrirConexao()
        //{
        //    SqlConnection con;

        //    con = new SqlConnection();
        //    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonardo\Downloads\SistemaPedidos\SistemaPedidos\DAO\Banco.mdf;Integrated Security=True;Connect Timeout=30";
        //    con.Open();

        //    return con;
        //}

        private static SqlConnection con;

        public static SqlConnection AbrirConexao()
        {

            var path = AppDomain.CurrentDomain.BaseDirectory.Replace("Web","DAO");
            //var path = @"C:\Users\Leonardo\Downloads\SistemaPedidos\SistemaPedidos\DAO\";
           
            if (con == null)
            {
                //con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonardo\Downloads\SistemaPedidos\SistemaPedidos\DAO\Banco.mdf;Integrated Security=True;Connect Timeout=30"); }
                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "Banco.mdf;Integrated Security=True;Connect Timeout=30");
            }

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            return con;
        }

        public static void FecharConexao()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            { con.Close(); }
        }

        public static void ExecutarComandoSQL(string strComando)
        {
            SqlConnection con = AbrirConexao();

            using (SqlCommand command = new SqlCommand(strComando, con))
            { command.ExecuteNonQuery(); }

            FecharConexao();
        }

        public static List<Dictionary<string, string>> ExecutarComandoLeituraSQL(string tabela, string where)
        {

            List<Dictionary<string, string>> registros = new List<Dictionary<string, string>>();

            SqlConnection con = AbrirConexao();
            string strComando = "Select * from " + tabela;

            if (where != "")
            {
                strComando += where;
            }
            using (SqlCommand command = new SqlCommand(strComando, con))

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Dictionary<string, string> registro = new Dictionary<string, string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    { registro.Add(reader.GetName(i), reader[reader.GetName(i)].ToString()); }
                    registros.Add(registro);
                }
            }

            FecharConexao();

            return registros;
        }
    }


}