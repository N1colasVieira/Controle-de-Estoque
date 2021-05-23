using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIL
{
    public partial class Requisicao : Form
    {
        Metodos mt = new Metodos();       
        string botao;
        public Requisicao()
        {
            InitializeComponent();
        }
        
        private void IRequisicao_Reposicao_Load(object sender, EventArgs e)
        {
            botao = "btnSave_normal.png";
            if (mt.ArquivoExiste(Metodos.pathImagens, botao))
            {
                Image bt = Image.FromFile(Metodos.pathImagens + botao);
                btnSave.BackgroundImage = bt;
            }
        }

        #region Eventos do painel de botões
        private void lblClose_Click(object sender, EventArgs e)
        {
            if (txtObservacao.Text == string.Empty)
            {
                CaixaDeMensagem cm = new CaixaDeMensagem();
                cm.MostrarCaixaDeMensagem("É necessário preencher os campos obrigatórios!", "Atenção", 2);
                cm.Show();
            }
            else
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
            if(txtRequisitadoPor.Text != string.Empty)
            {
            Estoque.requisicao = txtRequisitadoPor.Text;
            Estoque.observacao = txtObservacao.Text;
            this.Close();
            }
            else
            {
                CaixaDeMensagem cm = new CaixaDeMensagem();
                cm.MostrarCaixaDeMensagem("É necessário preencher os campos obrigatórios!", "Atenção", 2);
                cm.Show();
            }
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            botao = "btnSave_focus.png";
            if (mt.ArquivoExiste(Metodos.pathImagens, botao))
            {
                Image bt = Image.FromFile(Metodos.pathImagens + botao);
                btnSave.BackgroundImage = bt;
            }
        }
        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            botao = "btnSave_normal.png";
            if (mt.ArquivoExiste(Metodos.pathImagens, botao))
            {
                Image bt = Image.FromFile(Metodos.pathImagens + botao);
                btnSave.BackgroundImage = bt;
            }
        }
        #endregion

    }
}
