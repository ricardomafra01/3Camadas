﻿using System;
using System.Data;
using MySql.Data.MySqlClient;



namespace Projeto3Camadas.CODE.DAL
{
	class AcessoBancoDados
	{
		private MySqlConnection conn;
		private DataTable data;
		private MySqlDataAdapter da;
		private MySqlDataReader dr;
		private MySqlCommandBuilder cb;

		private String server = "127.0.0.1";
		private String user = "root";
		private String database = "db_projeto3camadas";
		private String port = "3306";
		private String password = "root";

		public void Conectar()
		{
			//string connStr = "server=127.0.0.1;user=root;database=DB_Requerimento_Padrao;port=3306;password=root";
			string connStr = String.Format($"server={server}; User Id={user}; database={database}; port={port}; password={password}; pooling=false");
			try
			{
				if (conn != null)
				{
					conn.Close();
				}
				conn = new MySqlConnection(connStr);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Não foi possível realizar a conexão!");
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				conn.Close();
			}
		}

		public void ExecutarComandoSQL(string comandoSql)
		{

			try
			{
				conn.Open();

				if (conn.State == ConnectionState.Open)
				{

					MySqlCommand comando = new MySqlCommand(comandoSql, conn);
					comando.ExecuteNonQuery();
					Console.WriteLine("Comando SQL executado com sucesso!");
				}
				else
				{
					Console.WriteLine("conexao nao foi aberta, impossivel executar o comando sql");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("erro ao executar comando sql");
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				conn.Close();
			}
		}

		public DataTable RetDataTable(string sql)
		{
			data = new DataTable();
			da = new MySqlDataAdapter(sql, conn);
			cb = new MySqlCommandBuilder(da);
			da.Fill(data);
			return data;
		}

		public MySqlDataReader RetDataReader(string sql)
		{
			MySqlCommand comando = new MySqlCommand(sql, conn);
			MySqlDataReader dr = comando.ExecuteReader();
			dr.Read();
			return dr;
		}
	}
}

