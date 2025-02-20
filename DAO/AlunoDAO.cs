using cadAluno.DATA;
using cadAluno.Interface;
using cadAluno.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cadAluno.DAO
{
    internal class AlunoDAO:IDAO<Aluno>
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

        public void Deletar(int id_alu)
        {
            try
            {
                string sql = "DELETE FROM alunos WHERE id_alu = @id_alu";
                MySqlCommand command = new MySqlCommand (sql, Conexao.Conectar());
                command.Parameters.AddWithValue("@id_alu", id_alu);
                command.ExecuteNonQuery();
                Console.WriteLine("Aluno excluido com sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public void Atualizar(Aluno aluno)
        {
            try
            {
                
                string sql = "UPDATE alunos SET nome_alu = @nome_alu, emai_alu = @email_alu, telefone_alu = @telefone_alu,dataNascimento_alu = @dataNascimento_alu WHERE id_alu = @id_alu";

                MySqlCommand command = new MySqlCommand(sql, Conexao.Conectar());
                
                command.Parameters.AddWithValue("@nome_alu", aluno.nome_alu);
                command.Parameters.AddWithValue("@email_alu", aluno.email_alu);
                command.Parameters.AddWithValue("@telefone_alu", aluno.telefone_alu);
                command.Parameters.AddWithValue("@dataNascimento_alu", aluno.dataNascimento_alu);
                command.Parameters.AddWithValue("@id_alu", aluno.id_alu);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Aluno> ListarTodos()
        {
            try
            {
                List<Aluno> alunos = new List<Aluno>();
                string sql = "SELECT * FROM alunos ORDER BY nome_alu";
                MySqlCommand command = new MySqlCommand( sql, Conexao.Conectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) { 
                    Aluno aluno = new Aluno();
                    aluno.id_alu = reader.GetInt32("id_alu");
                    aluno.nome_alu = reader.GetString("nome_alu");
                    aluno.email_alu = reader.GetString("email_alu");
                    aluno.telefone_alu = reader.GetString("telefone_alu");
                    aluno.dataNascimento_alu = Convert.ToDateTime(reader.GetDateTime("dataNascimento_alu"));
                    alunos.Add(aluno);
                }
                return alunos;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }

        }
    }
}
