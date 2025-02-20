using cadAluno.DAO;
using cadAluno.DATA;
using cadAluno.Models;


//Conexao.Conectar();
bool continuar = true;
while (continuar)
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Para realizar um cadastro.");
    Console.WriteLine("2 - Para excluir um cadastro.");
    Console.WriteLine("3 - Para Atualizar um cadastro.");
    Console.WriteLine("4 - Litar todos");
    Console.WriteLine("5 - Opção 5");
    Console.WriteLine("0 - Para Sair");


    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:

            try
            {
                Console.WriteLine("Cadastro realizado");
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
            break;
        case 2:
            try
            {
                Console.WriteLine("Qual id deseja excluir?");
                int id_alu = Convert.ToInt32(Console.ReadLine());
                AlunoDAO aluno = new AlunoDAO();
                aluno.Deletar(id_alu);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


            break;
        case 3:
            Console.WriteLine("3 - Para Atualizar um cadastro.");

            break;
        case 4:
            try
            {
                Console.WriteLine("4 - Lista de todos os alunos");
                AlunoDAO b = new AlunoDAO();
                foreach (var item in b.ListarTodos())
                {
                    Console.WriteLine($" id:{item.id_alu}, nome:{item.nome_alu}, email:{item.email_alu}, telefone:{item.telefone_alu}, data nascimento:{item.dataNascimento_alu}");
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception ("erro!." + ex.Message);
            }

            break;
        case 5:
            Console.WriteLine("");
            break;
        case 0:
            Console.WriteLine("Saindo do sistema...");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}





        


