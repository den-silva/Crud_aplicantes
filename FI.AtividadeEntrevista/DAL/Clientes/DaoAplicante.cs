using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FI.AtividadeEntrevista.DML;

namespace FI.AtividadeEntrevista.DAL
{

    internal class DaoAplicante : AcessoDados
    {

        internal int Incluir(DML.Aplicante aplicante)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", aplicante.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("NomeCidade", aplicante.NomeCidade));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Nota", aplicante.Nota));
            int ret = 0;
            DataSet ds = base.Consultar("SP_IncluirAplicante", parametros); 
            if (ds.Tables[0].Rows.Count > 0)
                int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);
            return ret;
        }

        internal DML.Aplicante Consultar(int Id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", Id));

            DataSet ds = base.Consultar("SP_ConsultarAplicante", parametros);
            List<DML.Aplicante> cli = Converter(ds);

            return cli.FirstOrDefault();
        }

        internal string ConsultarCpf(string cpf)
        {
            //string sp = "SELECT  FROM CLIENTES WITH(NOLOCK) WHERE cpf = " + cpf;

            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", cpf));

            DataSet ds = base.Consultar("FI_SP_ConsCpf", parametros);

            string result = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Columns.ToString();
                return result;
            }
            //List<DML.Cliente> cli = Converter(ds);
            return result;
        }



        internal int VerificarExistencia(string CPF)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", CPF));

            DataSet ds = base.Consultar("FI_SP_VerificaCliente", parametros);

            int i = 0;            

            i = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);

            return i;
        }

        internal List<Aplicante> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("iniciarEm", iniciarEm));
            parametros.Add(new System.Data.SqlClient.SqlParameter("quantidade", quantidade));
            parametros.Add(new System.Data.SqlClient.SqlParameter("campoOrdenacao", campoOrdenacao));
            parametros.Add(new System.Data.SqlClient.SqlParameter("crescente", crescente));

            DataSet ds = base.Consultar("SP_PesquisarAplicante", parametros);
            List<DML.Aplicante> apl = Converter(ds);

            int iQtd = 0;

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                int.TryParse(ds.Tables[1].Rows[0][0].ToString(), out iQtd);

            qtd = iQtd;

            return apl;
        }

        internal List<DML.Aplicante> Listar()
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", 0));

            DataSet ds = base.Consultar("SP_ConsultarAplicante", parametros);
            List<DML.Aplicante> cli = Converter(ds);

            return cli;
        }

        internal void Alterar(DML.Aplicante aplicante)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", aplicante.Nome)); 
            parametros.Add(new System.Data.SqlClient.SqlParameter("NomeCidade", aplicante.NomeCidade)); 
            parametros.Add(new System.Data.SqlClient.SqlParameter("Nota", aplicante.Nota));
            parametros.Add(new System.Data.SqlClient.SqlParameter("ID", aplicante.Id));

            base.Executar("SP_AlterarAplicante", parametros);                         
        }

        internal void Excluir(int Id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", Id));

            base.Executar("SP_ExcluirAplicante", parametros);                          // ################################### ALTERAR ###################################
        }

        private List<DML.Aplicante> Converter(DataSet ds)
        {
            List<DML.Aplicante> lista = new List<DML.Aplicante>();
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DML.Aplicante apl = new DML.Aplicante();
                    apl.Id = row.Field<int>("ID");
                    apl.NomeCidade = row.Field<string>("NomeCidade");
                    apl.Nome = row.Field<string>("Nome");
                    apl.Nota = row.Field<string>("Nota").ToString();
                    lista.Add(apl);
                }
            }
            return lista;
        }
    }
}
