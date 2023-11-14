using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace PDespesas0030482311016
{
    internal class Tipo
    {
        public int idTipo;
        public string descricaoTipo;

        public int Idtipo
        {
            get
            {
                return idTipo;
            }
            set
            {
                idTipo = value;
            }
        }

        public string Descricaotipo
        {

            get
            {
                return descricaoTipo;
            }
            set
            {
                descricaoTipo = value;
            }
        }
        public DataTable Listar()
        {
            SqlDataAdapter daTipo;

            DataTable dtTipo = new DataTable();

            try
            {
                daTipo = new SqlDataAdapter("SELECT * FROM TIPO", frmPrincipal.conexao);
                daTipo.Fill(dtTipo);
                daTipo.FillSchema(dtTipo, SchemaType.Source);
            }
            catch (Exception)
            {
                throw;
            }
            return dtTipo;
        }
    }
    
}
