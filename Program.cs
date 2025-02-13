using cadAluno.DAO;
using cadAluno.DATA;
using cadAluno.Models;


//Conexao.Conectar();

try
{
    Aluno a = new Aluno();
    a.nome_alu = "Fernando";
    a.email_alu = "Fernando@gmail.com";
    a.telefone_alu = "(69)999322421";
    a.dataNascimento_alu = new DateTime(2025, 02, 12);

    AlunoDAO alunoDAO = new AlunoDAO();
    alunoDAO.Salvar(a);
}
catch (Exception ex)
{

    throw new Exception("erro!" + ex.Message);
}
