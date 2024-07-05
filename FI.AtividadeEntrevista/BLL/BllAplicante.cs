using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BllAplicante
    {
 
        public int Incluir(DML.Aplicante aplicante)
        {
            DAL.DaoAplicante apl = new DAL.DaoAplicante();
            return apl.Incluir(aplicante);
        }

        public void Alterar(DML.Aplicante aplicante)
        {
            DAL.DaoAplicante apl = new DAL.DaoAplicante();
            apl.Alterar(aplicante);
        }


        public DML.Aplicante Consultar(int id)
        {
            DAL.DaoAplicante apl = new DAL.DaoAplicante();
            return apl.Consultar(id);
        }

        public void Excluir(int id)
        {
            DAL.DaoAplicante apl = new DAL.DaoAplicante();
            apl.Excluir(id);
        }

        public List<DML.Aplicante> Listar()
        {
            DAL.DaoAplicante apl = new DAL.DaoAplicante();
            return apl.Listar();
        }

        public List<DML.Aplicante> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoAplicante apl = new DAL.DaoAplicante();
            return apl.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
        }

        //public int VerificarExistencia(string CPF)
        //{
        //    DAL.DaoAplicante apl = new DAL.DaoAplicante();
        //    return apl.VerificarExistencia(CPF);
        //}
    }
}
