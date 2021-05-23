using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ConexaoBanco
    {
        private MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["stringConexaoBanco"].ConnectionString);
        private static int idUsuario = 0;

        Itens it = new Itens();
        Movimentacao mo = new Movimentacao();
        Usuarios us = new Usuarios();

        private void Conectar()
        {
            connection.Open();
        }
        private void Desconectar()
        {
            connection.Close();
        }
        public int ObterIdUsuario()
        {
            return idUsuario;
        }
        public Boolean VerificarUsuario(string usuario)
        {
            us.usuario = usuario;
            MySqlCommand verificarUsuario = new MySqlCommand("sp_VerificarUsuario", connection);
            verificarUsuario.CommandType = CommandType.StoredProcedure;
            verificarUsuario.Parameters.AddWithValue("p_usuario", us.usuario);       

            if (SelectBool(verificarUsuario))
            {
                idUsuario = SelectInt(verificarUsuario);                
                return true;
            }
            return false;
        }
        public string ObterNomeUsuario()
        {
            MySqlCommand obterNomeUsuario = new MySqlCommand("sp_ObterNomeUsuario", connection);
            obterNomeUsuario.CommandType = CommandType.StoredProcedure;
            obterNomeUsuario.Parameters.AddWithValue("p_idUsuario", idUsuario);
            return SelectString(obterNomeUsuario);
        }
        public string ObterHash(string usuario)
        {
            us.usuario = usuario;
            MySqlCommand obterHash = new MySqlCommand("sp_ObterHash", connection);
            obterHash.CommandType = CommandType.StoredProcedure;
            obterHash.Parameters.AddWithValue("p_usuario", us.usuario);
            return SelectString(obterHash);
        }
        public DataTable CarregarGridView(int opcao, string filtro)
        {            
            string cmd = string.Empty;
            // Opção 1 - Itens, Opção 2 - Movimentação
            switch (opcao)
            {                
                case 1:
                    cmd = "sp_CarregarGridViewItens";
                    break;
                case 2:
                    cmd = "sp_CarregarGridViewMovimentacao";
                    break;
            }

            DataTable dt = new DataTable();
            MySqlCommand carregarGridView = new MySqlCommand(cmd, connection);
            carregarGridView.CommandType = CommandType.StoredProcedure;
            carregarGridView.Parameters.AddWithValue("p_filtro", "%" + filtro + "%");

            try
            {
                Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(carregarGridView);
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                string erro = ex.Message;
                return dt;
            }
            finally
            {
                Desconectar();
            }
        }
        public int ObterQuantidadeDisponivel(int idItem)
        {
            it.idItem = idItem;
            MySqlCommand obterQuantidadeDisponivel = new MySqlCommand("sp_ObterQuantidadeDisponivel",connection);
            obterQuantidadeDisponivel.CommandType = CommandType.StoredProcedure;
            obterQuantidadeDisponivel.Parameters.AddWithValue("p_idItem",it.idItem);            
            return SelectInt(obterQuantidadeDisponivel);
        }
        public string Atualizar(List<List<string>> update)
        {           
            for (int linha = 0; linha < update.Count; linha++)
            {
                //Encapsulando variaveis
                mo.id_itens = Convert.ToInt32(update[linha][0]);
                mo.id_usuario = Convert.ToInt32(update[linha][2]);
                mo.requisicao = update[linha][3];
                mo.dataRequisicao = Convert.ToDateTime(update[linha][4]);
                mo.quantidadeRequisitada = Convert.ToInt32(update[linha][5]);
                mo.reposicao = update[linha][6];
                mo.dataReposicao = Convert.ToDateTime(update[linha][7]);
                mo.quantidadeRepositada = Convert.ToInt32(update[linha][8]);
                mo.observacao = update[linha][9];

                MySqlCommand reposicaoOuRequisicao = new MySqlCommand("sp_ReposicaoOuRequisicao", connection);
                reposicaoOuRequisicao.CommandType = CommandType.StoredProcedure;
                reposicaoOuRequisicao.Parameters.AddWithValue("p_idItem", mo.id_itens);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_novaQuantidade", Convert.ToInt32(update[linha][1]));
                reposicaoOuRequisicao.Parameters.AddWithValue("p_idUsuario", mo.id_usuario);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_requisicao", mo.requisicao);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_dataRequisicao", mo.dataRequisicao);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_quantidadeRequisitada", mo.quantidadeRequisitada);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_reposicao", mo.reposicao);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_dataReposicao", mo.dataReposicao);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_quantidadeRepositada", mo.quantidadeRepositada);
                reposicaoOuRequisicao.Parameters.AddWithValue("p_observacao", mo.observacao);

                if (!UpdateBool(reposicaoOuRequisicao))
                {
                    return "Algo de errado não deu certo!";
                }
            }
            return "Dados atualizados com sucesso!";
        }
        public string CadastrarItem(List<string> novoItem)
        {
            it.nome = novoItem[0];
            it.cor = novoItem[1];
            it.marca = novoItem[2];
            it.modelo = novoItem[3];
            it.tamanho = novoItem[4];
            it.quantidadeDisponivel = Convert.ToInt32(novoItem[5]);
            it.tipo = novoItem[6];
            it.quantidadeRecomendada = Convert.ToInt32(novoItem[7]);
            it.cadastradoNoDia = DateTime.Today;
            us.idUsuario = idUsuario;

            MySqlCommand cadastrarItem = new MySqlCommand("sp_CadastrarItem", connection);
            cadastrarItem.CommandType = CommandType.StoredProcedure;
            cadastrarItem.Parameters.AddWithValue("p_nomeItem", it.nome);
            cadastrarItem.Parameters.AddWithValue("p_cor", it.cor);
            cadastrarItem.Parameters.AddWithValue("p_marca", it.marca);
            cadastrarItem.Parameters.AddWithValue("p_modelo", it.modelo);
            cadastrarItem.Parameters.AddWithValue("p_tamanho", it.tamanho);
            cadastrarItem.Parameters.AddWithValue("p_quantidadeDisponivel", it.quantidadeDisponivel);
            cadastrarItem.Parameters.AddWithValue("p_tipo", it.tipo);
            cadastrarItem.Parameters.AddWithValue("p_quantidadeRecomendada", it.quantidadeRecomendada);
            cadastrarItem.Parameters.AddWithValue("p_cadastradoNoDia", it.cadastradoNoDia);
            cadastrarItem.Parameters.AddWithValue("p_idUsuario", us.idUsuario);
            // Out Parameter \/
            cadastrarItem.Parameters.Add(new MySqlParameter("p_mensagem", MySqlDbType.VarChar));
            cadastrarItem.Parameters["p_mensagem"].Direction = ParameterDirection.Output;

            return Insert(cadastrarItem, "p_mensagem");
        }
        private Boolean SelectBool(MySqlCommand cmd)
        {
            try
            {
                Conectar();
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                string erro = ex.Message;
                return false;
            }
            finally
            {
                Desconectar();
            }
        }
        public int SelectInt(MySqlCommand cmd)
        {
            try
            {
                Conectar();
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return dr.GetInt32(0);
            }
            catch (MySqlException ex)
            {
                string erro = ex.Message;
                return 0;
            }
            finally
            {
                Desconectar();
            }
        }
        public string SelectString(MySqlCommand cmd)
        {
            try
            {
                Conectar();
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return dr.GetString(0);
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                Desconectar();
            }
        }
        private string Insert(MySqlCommand cmd, string outParameterName)
        {
            try
            {
                Conectar();
                cmd.ExecuteNonQuery();
                string Mensagem = (string)cmd.Parameters["" + outParameterName + ""].Value;
                return Mensagem;
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                Desconectar();
            }
        }
        private Boolean UpdateBool(MySqlCommand cmd)
        {
            try
            {
                Conectar();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                string erro = ex.Message;
                return false;
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
