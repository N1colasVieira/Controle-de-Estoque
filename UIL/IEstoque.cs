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
    public partial class IEstoque : Form
    {
        public IEstoque()
        {
            InitializeComponent();
        }
        string botao;
        List<List<int>> ID_Quantidade = new List<List<int>>();
       // int numeroLinha = 0;
        Metodos mt = new Metodos();

        #region Resize Window
        //Resize Window
        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        #region Eventos do painel de botões
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Black;
        }
        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.White;
        }
        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void lblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.Black;
        }
        private void lblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.White;
        }
        private void lblMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void lblMaximize_MouseEnter(object sender, EventArgs e)
        {
            lblMaximize.ForeColor = Color.Black;
        }
        private void lblMaximize_MouseLeave(object sender, EventArgs e)
        {
            lblMaximize.ForeColor = Color.White;
        }
        #endregion

        private void IEstoque_Load(object sender, EventArgs e)
        {
            botao = "btnSearch_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnSearch.BackgroundImage = bt;
            }
            botao = "btnUpdate_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnUpdate.BackgroundImage = bt;
            }
            botao = "btnInsert_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnInsert.BackgroundImage = bt;
            }
            botao = "btnUpdate_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnUpdate.BackgroundImage = bt;
            }

            dgItens.DataSource = mt.CarregarGrid(1, txtSearch.Text);          
        }

        #region Eventos do botão Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdItem.Checked == true)
            {                
                dgItens.Visible = true;
                dgMovimentacao.Visible = false;
                dgItens.DataSource = mt.CarregarGrid(1, txtSearch.Text);                
            }
            else if (rdMovimentacao.Checked == true)
            {                
                dgItens.Visible = false;
                dgMovimentacao.Visible = true;
                dgMovimentacao.DataSource = mt.CarregarGrid(2, txtSearch.Text);             
            }
        }
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            botao = "btnSearch_focus.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnSearch.BackgroundImage = bt;
            }
        }
        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            botao = "btnSearch_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnSearch.BackgroundImage = bt;
            }
        }
        #endregion

        #region Eventos do botão Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IRequisicao_Reposicao rr = new IRequisicao_Reposicao();
            rr.Show();

            MessageBox.Show(mt.Atualizar(ID_Quantidade));
        }
        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            botao = "btnUpdate_focus.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnUpdate.BackgroundImage = bt;
            }
        }
        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            botao = "btnUpdate_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnUpdate.BackgroundImage = bt;
            }
        }
        #endregion

        #region Eventos do botão Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            ICadastroItem ci = new ICadastroItem();
            ci.Show();
        }
        private void btnInsert_MouseEnter(object sender, EventArgs e)
        {
            botao = "btnInsert_focus.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnInsert.BackgroundImage = bt;
            }
        }
        private void btnInsert_MouseLeave(object sender, EventArgs e)
        {
            botao = "btnInsert_normal.png";
            if (mt.ArquivoExiste(Metodos.pathBotao, botao))
            {
                Image bt = Image.FromFile(Metodos.pathBotao + botao);
                btnInsert.BackgroundImage = bt;
            }
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
        
        #region Restrição de entrada

        //Impede o usuario de digitar outra coisa além de números
        private void dgItens_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgItens.CurrentCell.ColumnIndex == 6)
            {
                e.Control.KeyPress -= dgItens_KeyPress;
                e.Control.KeyPress += dgItens_KeyPress;
            }
        }
        private void dgItens_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        #endregion

        private void dgAlmoxarifado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgItens.CurrentRow != null)
            {
                DataGridViewRow dgvRow = dgItens.CurrentRow;
                ID_Quantidade.Add(new List<int> { Convert.ToInt32(dgvRow.Cells["idItem"].Value), Convert.ToInt32(dgvRow.Cells["quantidadeDisponivel"].Value) });
               // numeroLinha++;
            }
        }
    }
}
