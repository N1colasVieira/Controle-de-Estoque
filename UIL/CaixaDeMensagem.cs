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
    public partial class CaixaDeMensagem : Form
    {
        Metodos mt = new Metodos();
        string icone;
        public CaixaDeMensagem()
        {
            InitializeComponent();
        }

        public void MostrarCaixaDeMensagem(string mensagem, string titulo, int opcaoIcone)
        {
            switch(opcaoIcone)
            {
                case 1:
                    icone = "Sucess.png";
                    break;
                case 2:
                    icone = "Warning.png";
                    break;
                case 3:
                    icone = "Error.png";
                    break;
            }
            if (mt.ArquivoExiste(Metodos.pathImagens, icone))
            {
                Image ico = Image.FromFile(Metodos.pathImagens + icone);
                pbIcone.BackgroundImage = ico;
            }
            txtMensagem.Text = mensagem;
            lblNameHeader.Text = titulo;

        }

        private void IMensagem_Load(object sender, EventArgs e)
        {
    
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
               
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
