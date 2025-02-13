using cadAluno.DATA;
using cadAluno.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadAluno.DAO
{
    internal class AlunoDAO
    {
        public void Salvar(Aluno aluno)
        {
			try
			{
                string data = aluno.dataNascimento_alu.ToString("yyyy-mm-dd");
                string sql = "INSERT INTO Alunos (nome_alu,email_alu,telefone_alu,dataNascimento_alu)" +
                "VALUES (@nome_alu, @email_alu, @telefone_alu, @dataNascimento_alu)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_alu", aluno.nome_alu);
                comando.Parameters.AddWithValue("@email_alu", aluno.email_alu);
                comando.Parameters.AddWithValue("@telefone_alu", aluno.telefone_alu);
                comando.Parameters.AddWithValue("@dataNascimento_alu", data);

                comando.ExecuteNonQuery();

                Console.WriteLine("Cadastrado com Sucesso");
            }
			catch (Exception ex)
			{
                throw new Exception("Erro ao cadastrar o aluno" + ex.Message);
			}
        }
    }
}
