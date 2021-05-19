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
    public partial class IMensagem : Form
    {
        public IMensagem()
        {
            InitializeComponent();
        }

        private void IMensagem_Load(object sender, EventArgs e)
        {

        }

        public void CaixaDeMensagem(string mensagem, string titulo, string botao, string icone)
            {
            lblNameHeader.Text = titulo;
            txtMensagem.Text = mensagem;
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
    }
}
