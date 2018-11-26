using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportadorXlms
{
	class Program
	{
		private static SqlConnection conn;
		private static SqlCommand cmdsql;

		static void Main(string[] args)
		{
			string dbconnection = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();

			OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ariel.passador\Desktop\ImportadorPlanilha.xlsx;Extended Properties='Excel 12.0 Xml; HDR = YES; IMEX = 1';");
			//Provider = Microsoft.JET.OLEDB.12.0; Data Source = C:\Users\ariel.passador\Desktop\ImportadorXlms\EXEMPLOIMPORTACAO.xlsx; Extended Properties = Exel;
			OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [importador$]", conexao);
			DataSet ds = new DataSet();

			try
			{
				conexao.Open();
				adapter.Fill(ds);
				conn = new SqlConnection(dbconnection);
				cmdsql = new SqlCommand();

				conn.Open();
				cmdsql.Connection = conn;

				StringBuilder insertLine = new StringBuilder();
				foreach (DataRow linha in ds.Tables[0].Rows)

				{
					insertLine.AppendLine(string.Format("INSERT INTO importacao(id, " +
					"cliente_id, " +
					"origem_id, " +
					"destino_id, " +
					"aeronave_id, " +
					"filial_id, " +
					"schedule_mensal_detalhe_id, " +
					"usuario_id, " +
					"data_conclusao, " +
					"data_cancelamento, " +
					"voo, " +
					"prefixo, " +
					"observacao, " +
					"motivo_cancelamento," +
					"tipo_ordem_servico, " +
					"proximo_dia" +
					"VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15})", linha[0], linha[1], linha[2], linha[3], linha[4], linha[5], linha[6], linha[7], linha[8], linha[9], linha[10], linha[11], linha[12], linha[13], linha[14], linha[15]));	
				}
				cmdsql.CommandText = insertLine.ToString();
				cmdsql.ExecuteNonQuery();
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
			
			Console.WriteLine("Inserido");
			conn.Dispose();
			conn.Close();

			Console.ReadKey();
		}
	}
}
