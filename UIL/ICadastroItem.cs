using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UIL
{
    public partial class ICadastroItem : Form
    {
        public ICadastroItem()
        {
            InitializeComponent();
        }

        Metodos mt = new Metodos();
        string botao;

        private void ICadastroItem_Load(object sender, EventArgs e)
        {
            botao = "btnSave_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnSave.BackgroundImage = bt;
            }
        }

        #region Eventos do painel de botões
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Black;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.White;
        }
        #endregion

        #region Mouse Move
        private int mov, movX, movY;
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        #endregion

        #region Eventos do botão Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> itens = new List<string>();
            itens.Add(mt.PrimeiraLetraMaiuscula(txtNome.Text.ToLower()));
            itens.Add(mt.PrimeiraLetraMaiuscula(txtCor.Text.ToLower()));
            itens.Add(mt.PrimeiraLetraMaiuscula(txtMarca.Text.ToLower()));
            itens.Add(mt.PrimeiraLetraMaiuscula(txtModelo.Text.ToLower()));
            itens.Add(mt.PrimeiraLetraMaiuscula(txtTamanho.Text.ToLower()));
            itens.Add(mt.PrimeiraLetraMaiuscula(txtQuantidadeDisponivel.Text.ToLower()));
            itens.Add(mt.PrimeiraLetraMaiuscula(cbTipo.Text.ToLower()));
            itens.Add(mt.PrimeiraLetraMaiuscula(txtQuantidadeRecomendada.Text.ToLower()));

            IMensagem ms = new IMensagem();
            ms.CaixaDeMensagem(mt.CadastrarItem(itens), "Atenção", "sd", "sd");
            ms.Show();

            //MessageBox.Show(mt.CadastrarItem(itens));
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            botao = "btnSave_focus.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnSave.BackgroundImage = bt;
            }
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            botao = "btnSave_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnSave.BackgroundImage = bt;
            }
        }
        #endregion

        #region Restrições de entrada
        private void txtQuantidadeDisponivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtQuantidadeRecomendada_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion
    }
}
