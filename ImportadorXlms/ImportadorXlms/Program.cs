using ImportadorXlms.Models;
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

		public static SqlConnection conn;
		public static SqlCommand cmdsql;
		public static SqlDataReader reader;//APRENDER
										   //ESTUDAR LINQ
										   //SELECT COM DATAREADER PRA MOSTRAR NO CONSOLE
										   //http://www.macoratti.net/10/08/c_dr1.htm
										   //https://stackoverflow.com/questions/4018114/read-data-from-sqldatareader

		static public void Main(string[] args)
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
				conn.Open();

				cmdsql = new SqlCommand();
				cmdsql.Connection = conn;

				StringBuilder insertLine = new StringBuilder();
				foreach (DataRow linha in ds.Tables[0].Rows)
				{

					insertLine.AppendLine(string.Format("INSERT INTO importacao (id, " +
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
					"motivo_cancelamento, " +
					"tipo_ordem_servico, " +
					"proximo_dia) " +
					"VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', convert(datetime,'{8}', 103), convert(datetime,'{9}', 103), '{10}', '{11}', '{12}', '{13}', '{14}', {15});"
					, linha[0], linha[1], linha[2], linha[3], linha[4], linha[5], string.IsNullOrEmpty(linha[6].ToString()) ? 1 : linha[6], linha[7], DateTime.Now, DateTime.Now, linha[10], linha[11], linha[12], linha[13], linha[14], string.IsNullOrEmpty(linha[15].ToString()) ? 0 : linha[15]));


				}
				//cmdsql.CommandText = insertLine.ToString();
				//cmdsql.ExecuteNonQuery();
				Console.WriteLine("Inserido");
				conn.Dispose();
				conn.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			try
			{
				conn = new SqlConnection(dbconnection);
				conn.Open();
				SqlCommand command = new SqlCommand("SELECT * FROM importacao", conn);

				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10} - {11} - {12} - {13} - {14} - {15} "
							, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6)
							, reader.GetString(7), reader.GetDateTime(8), reader.GetDateTime(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetBoolean(15));
					}
					
				}
				else
				{
					Console.WriteLine("No rows found");
				}
			}
			catch (Exception es)
			{
				Console.WriteLine(es.Message);
			}

			Console.ReadKey();
		}

		//public static void InsertWithEntity()
		//{
		//using (DataContext dbcontext = new DataContext())
		//{

		//var alldata = dbcontext.importacao.Where(x => x.id > 500).ToList();

		//var alldatalinq = from x in dbcontext.importacao where x.id > 500 select x;

		//foreach (var item in alldata)
		//{	
		//}

		//importacao _importacao = new importacao() {
		//aeronave_id = 5,
		//data_cancelamento = DateTime.Now,

		//};
		//dbcontext.importacao.Add(_importacao);

		//dbcontext.importacao.Remove(_importacao);


		//var importacaoupdate = dbcontext.importacao.Find(1500); // SELECT * FROM IMPORTACAO WHERE ID = 1500
		//importacaoupdate.aeronave_id = 15;
		//importacaoupdate.data_conclusao = DateTime.Now;
		//dbcontext.SaveChanges();

		//dbcontext.SaveChanges();


		//var _importacaoentity = dbcontext.Database.SqlQuery<importacao>("SELECT * FROM IMPORTACAO WHERE ID > 500").ToList();

		//Console.WriteLine(_importacaoentity);
		//}

		//}

	}
}
