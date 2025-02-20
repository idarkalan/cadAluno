using cadAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadAluno.Interface
{
    internal interface IDAO<T>
    {
        void Salvar(T a);

        void Deletar(int id_alu);

        void Atualizar(T aluno);
    }
}
