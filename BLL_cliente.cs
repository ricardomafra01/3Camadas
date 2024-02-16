using System;
using System.Data;
using System.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto3Camadas.CODE.DTO;
using Projeto3Camadas.CODE.DAL;

namespace Projeto3Camadas.CODE.BLL
{
    class BLL_cliente
    {
        AcessoBancoDados db;

        public void inserir(DTO_cliente dto)
        {
            db = new AcessoBancoDados();
            db.Conectar();
            string comando = $"call inserir_cliente('{dto.Nome}','{dto.Email}');";
            db.ExecutarComandoSQL(comando);
        }

        public void alterar(DTO_cliente dto)
        {
            db = new AcessoBancoDados();
            db.Conectar();
            string comando = $"call alterar_cliente('{dto.Id_cliente}','{dto.Nome}','{dto.Email}');";
            db.ExecutarComandoSQL(comando);
        }

        public void excluir(DTO_cliente dto)
        {
            db = new AcessoBancoDados();
            db.Conectar();
            string comando = $"call excluir_cliente('{dto.Id_cliente}');";
            db.ExecutarComandoSQL(comando);
        }

        public DataTable selecionar()
        {
            DataTable dataTable = new DataTable();
            db = new AcessoBancoDados();
            db.Conectar();
            string comando = $"call selecionar_todos_clientes();";
            dataTable = db.RetDataTable(comando);
            return dataTable;
        }
    }
}
