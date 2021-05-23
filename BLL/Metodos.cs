using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static System.Net.Mime.MediaTypeNames;

namespace BLL
{
    public class Metodos
    {
        ConexaoBanco cb = new ConexaoBanco();
        public static string pathImagens = AppDomain.CurrentDomain.BaseDirectory + @"Imagens\";
        private int contadordeLinha = 0;

        public Boolean ExisteCampoVazio(List<string> campo)
        {
            int campoPreenchido = 0;
            for (int i = 0; i < campo.Count; i++)
            {
                if (campo[i] != string.Empty)
                {
                    campoPreenchido++;
                }
            }
            if (campoPreenchido != campo.Count)
            {
                return true;
            }
            return false;
        }
        public string Autenticacao(List<string> login)
        {
            if (!ExisteCampoVazio(login))
            {
                if (cb.VerificarUsuario(login[0]))
                {
                    if (SenhaValida(login[1], cb.ObterHash(login[0])))
                    {
                        return string.Empty;
                    }
                    return "Usuário ou senha incorretos!";
                }
                return "Usuário ou senha incorretos!";
            }
            return "Favor, preencher todos os campos!";
        }
        public Boolean ArquivoExiste(string path, string nomeArquivo)
        {
            if (System.IO.File.Exists(path + nomeArquivo))
            {
                return true;
            }
            return false;
        }        
        public string ObterNomeUsuario()
        {
            return cb.ObterNomeUsuario();
        }
        public int ObterIdUsuario()
        {
            return cb.ObterIdUsuario();
        }
        public int ObterQuantidade(int idItem)
        {
            return cb.ObterQuantidadeDisponivel(idItem);
        }
        public Boolean SenhaValida(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
        public string CadastrarItem(List<string> itens)
        {
            List<string> camposNecessarios = new List<string>() { itens[0], itens[5], itens[6], itens[7] };
            if (!ExisteCampoVazio(camposNecessarios))
            {
                return cb.CadastrarItem(itens);
            }
            return "Favor preencher os campos necessários!";
        }
        public DataTable CarregarGrid(int opcao, string nomeBusca)
        {
            return cb.CarregarGridView(opcao, nomeBusca);
        }
        public string Atualizar(List<List<string>> update)
        {
            if (update.Count > contadordeLinha)
            {
                contadordeLinha = update.Count;
                return cb.Atualizar(update);
            }
            return "Não foi realizada nenhuma atualização! É necessário apertar 'enter' após editar uma linha.";
        }
        public string PrimeiraLetraMaiuscula(string palavra)
        {
            if (string.IsNullOrEmpty(palavra))
                return string.Empty;

            char[] a = palavra.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
