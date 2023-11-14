using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PDespesas0030482311016
{
    internal class Despesa
    {
        public int IDdespesa { get; set; }

        public double valorDespesa { get; set; }

        public DateTime dataDespesa { get; set; }

        public string obsDespesa { get; set; }

        public int tipoIDtipo { get; set; }

        public DataTable Listar()
        {
            SqlDataAdapter daDespesa;

            DataTable dtDespesa = new DataTable();

            try
            {
                daDespesa = new SqlDataAdapter("SELECT * FROM DESPESA", frmPrincipal.conexao);
                daDespesa.Fill(dtDespesa);
                daDespesa.FillSchema(dtDespesa, SchemaType.Source);
            }
            catch (Exception)
            {
                throw;
            }
            return dtDespesa;
        }


        public int Incluir() // INCLUSAO
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("INSERT INTO DESPESA VALUES (@valordespesa,@datadespesa,@obsdespesa," +
                "@tipo_idtipo)", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@valordespesa", SqlDbType.Decimal));
                mycommand.Parameters.Add(new SqlParameter("@datadespesa", SqlDbType.DateTime));
                mycommand.Parameters.Add(new SqlParameter("@obsdespesa", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@tipo_idtipo", SqlDbType.Int));

                mycommand.Parameters["@valordespesa"].Value = valorDespesa;
                mycommand.Parameters["@datadespesa"].Value = dataDespesa;
                mycommand.Parameters["@obsdespesa"].Value = obsDespesa;
                mycommand.Parameters["@tipo_idtipo"].Value = tipoIDtipo;

                retorno = mycommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public int Alterar() // alteração
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("UPDATE DESPESA SET VALORDESPESA=@valordespesa,DATADESPESA=@datadespesa," +
                "OBSDESPESA=@obsdespesa,TIPO_IDTIPO =@tipo_idtipo WHERE IDDESPESA = @iddespesa", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@iddespesa", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@valordespesa", SqlDbType.Decimal));
                mycommand.Parameters.Add(new SqlParameter("@datadespesa", SqlDbType.DateTime));
                mycommand.Parameters.Add(new SqlParameter("@obsdespesa", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@tipo_idtipo", SqlDbType.Int));

                mycommand.Parameters["@iddespesa"].Value = IDdespesa;
                mycommand.Parameters["@valordespesa"].Value = valorDespesa;
                mycommand.Parameters["@datadespesa"].Value = dataDespesa;
                mycommand.Parameters["@obsdespesa"].Value = obsDespesa;
                mycommand.Parameters["@tipo_idtipo"].Value = tipoIDtipo;

                retorno = mycommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public int Excluir() // EXCLUSÃO
        {
            int nReg = 0;

            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("DELETE FROM DESPESA WHERE IDDESPESA=@iddespesa", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@iddespesa", SqlDbType.Int));
                mycommand.Parameters["@iddespesa"].Value = IDdespesa;

                nReg = mycommand.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }

            return nReg;
        }
    }

}
