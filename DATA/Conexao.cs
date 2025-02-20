using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace cadAluno.DATA
{
    internal static class Conexao
    {
        static MySqlConnection? _conexao;
        static string url = "server=localhost;port=3360;uid=root;pwd=root;database=aulaPOO; Convert Zero Datetime=True";

        public static MySqlConnection Conectar()
        {
            try
            {
                _conexao = new MySqlConnection(url);
                _conexao.Open();

                return _conexao;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao conectar" + ex.Message);
            }
        }
    }
}
