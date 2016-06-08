using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;
        char[] special_chars = new char[] {'#','$','%','@','&','*'};
    
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }
        #region Menu

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Utilities program contains a number of small programs that can be useful in life.\nAuthor: Berdyshev Igor", "About programme");
        }

        #endregion
        #region Counter
        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCount.Text = Convert.ToString (count);
        }
        #endregion
        #region Generator
        private void btnRandom_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value)+1);
            lblRandom.Text = n.ToString();
            if (cbRandom.Checked)
            {
                int i = 0;

                while (tbRandom.Text.IndexOf(n.ToString()) != -1)
                {
                    n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) + 1);
                    i++;
                    if (i > 1000) break;
                }
                if (i<=1000) tbRandom.AppendText(n + "\n");
            }
            else tbRandom.AppendText(n + "\n");
        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void btnRandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }
        #endregion
        #region Notebook
        private void tsmiInsertDate_Click(object sender, EventArgs e)
        {
            rtbNotebook.AppendText(DateTime.Now.ToShortDateString() + "\n");
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            rtbNotebook.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotebook.SaveFile("Notebook.rtf");
            }
            catch
            {
                MessageBox.Show("Saving Error");
            }
            
        }
        void LoadNotebook()
        {
            try
            {
                rtbNotebook.LoadFile("Notebook.rtf");
            }
            catch
            {
                MessageBox.Show("Loading Error");
            }
        }

        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            LoadNotebook();
        }
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNotebook();
            clbPassword.SetItemChecked(0, true);
            clbPassword.SetItemChecked(1, true);
        }
        #region Passwords
        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) return;
            string Password = "";
            for (int i = 0; i <nudPasswordLength.Value;i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string s = clbPassword.CheckedItems[n].ToString();
                switch (s)
                {
                    case "Figures": Password += rnd.Next(10).ToString();
                        break;
                    case "Upper case letters": Password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    case "Lower case letters": Password += Convert.ToChar(rnd.Next(97,122));
                        break;
                    default:
                        Password += special_chars[rnd.Next(special_chars.Length)];
                        break;
                }
                tbPassword.Text = Password;
                Clipboard.SetText(Password);
            }
        }
        #endregion

    }
}
