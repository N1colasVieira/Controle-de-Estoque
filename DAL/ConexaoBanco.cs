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

        public Boolean VerificarUsuario(string usuario)
        {
            us.usuario = usuario;
            MySqlCommand verificaUsuario = new MySqlCommand("select * from usuarios where usuario = @usuario", connection);
            verificaUsuario.Parameters.AddWithValue("@usuario", us.usuario);
            try
            {
                Conectar();
                MySqlDataReader dr = verificaUsuario.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    idUsuario = dr.GetInt32(0);
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

        public string ObtemHash(string usuario)
        {
            us.usuario = usuario;
            MySqlCommand select = new MySqlCommand("select senha from usuarios where usuario = @usuario", connection);
            select.Parameters.AddWithValue("@usuario", us.usuario);
            try
            {
                Conectar();
                MySqlDataReader dr = select.ExecuteReader();
                dr.Read();
                return dr.GetString(0);
            }
            catch (MySqlException ex)
            {
                string erro = ex.Message;
                return string.Empty;
            }
            finally
            {
                Desconectar();
            }
        }

        public DataTable CarregarGrid(int opcao, string nomeBusca)
        {
            DataTable dt = new DataTable();
            string comando = string.Empty;

            switch (opcao)
            {
                case 1:
                    comando = "select i.id, i.nomeItem, i.cor, i.marca, i.modelo, i.tamanho, i.quantidadeDisponivel,i.tipo, i.quantidadeRecomendada, i.cadastradoNoDia, u.nomeUsuario from itens i join movimentacao m on i.id = m.id_itens join usuarios u on u.id = m.id_usuario where i.nomeItem like @nome ";

                    break;
                case 2:
                    comando = "select i.id, i.nomeItem, i.cor, i.marca, i.modelo, i.tamanho, i.quantidadeDisponivel,i.tipo, m.requisicao, m.dataRequisicao, m.quantidadeRequisitada, m.reposicao, m.dataReposicao, m.quantidadeRepositada, m.observacao from itens i join movimentacao m on i.id = m.id_itens join usuarios u on u.id = m.id_usuario where i.nomeItem like @nome ";
                    break;
            }

            MySqlCommand cmd = new MySqlCommand(comando, connection);
            cmd.Parameters.AddWithValue("@nome", "%" + nomeBusca + "%");

            try
            {
                Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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

        public string Atualizar(List<List<int>> ID_Quantidade)
        {
            string atualizar = "Update Itens SET `quantidadeDisponivel` = @Quantidade WHERE (`id` = @ID);";

            for (int linha = 0; linha < ID_Quantidade.Count; linha++)
            {
                MySqlCommand cmd = new MySqlCommand(atualizar, connection);
                cmd.Parameters.AddWithValue("@ID", ID_Quantidade[linha][0]);
                cmd.Parameters.AddWithValue("@Quantidade", ID_Quantidade[linha][1]);

                if (!UpdateBool(cmd))
                {
                    return "Algo de errado não deu certo!";
                }
            }
            return "Atualizado com sucesso!";
        }
        
        public string CadastrarItens(List<string> dados)
        {
            it.nome = dados[0];
            it.cor = dados[1];
            it.marca = dados[2];
            it.modelo = dados[3];
            it.tamanho = dados[4];
            it.quantidadeDisponivel = Convert.ToInt32(dados[5]);
            it.tipo = dados[6];
            it.quantidadeRecomendada = Convert.ToInt32(dados[7]);
            it.cadastradoNoDia = DateTime.Today;
            us.idUsuario = idUsuario;

            MySqlCommand insertItem = new MySqlCommand("sp_InsertItens",connection);
            insertItem.CommandType = CommandType.StoredProcedure;
            insertItem.Parameters.AddWithValue("p_nomeItem", it.nome);
            insertItem.Parameters.AddWithValue("p_cor", it.cor);
            insertItem.Parameters.AddWithValue("p_marca", it.marca);
            insertItem.Parameters.AddWithValue("p_modelo", it.modelo);
            insertItem.Parameters.AddWithValue("p_tamanho", it.tamanho);
            insertItem.Parameters.AddWithValue("p_quantidadeDisponivel", it.quantidadeDisponivel);
            insertItem.Parameters.AddWithValue("p_tipo", it.tipo);
            insertItem.Parameters.AddWithValue("p_quantidadeRecomendada", it.quantidadeRecomendada);
            insertItem.Parameters.AddWithValue("p_cadastradoNoDia", it.cadastradoNoDia);
            insertItem.Parameters.AddWithValue("p_idUsuario", us.idUsuario);
            insertItem.Parameters.Add(new MySqlParameter("p_mensagem", MySqlDbType.VarChar));
            insertItem.Parameters["p_mensagem"].Direction = ParameterDirection.Output;

            return Insert(insertItem, "p_mensagem");      
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
                return true;
            }
            finally
            {
                Desconectar();
            }
        }

        private string Insert(MySqlCommand cmd, string outParameter)
        {
            try
            {                
                Conectar();
                cmd.ExecuteNonQuery();
                string Mensagem = (string)cmd.Parameters[""+outParameter+""].Value;
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

        private int SelectInt(MySqlCommand cmd)
        {
            if (SelectBool(cmd))
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
            return 0;
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
