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
        Dictionary<string, double> metrica;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            metrica = new Dictionary<string, double>();
            metrica.Add("mm", 1);
            metrica.Add("cm", 10);
            metrica.Add("dm", 100);
            metrica.Add("m", 1000);
            metrica.Add("km", 1000000);
            metrica.Add("mile", 1609344);
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double m1 = metrica[cbFrom.Text];
            double m2 = metrica[cbTo.Text];
            double n = Convert.ToDouble(tbFrom.Text);
            tbTo.Text = (n*m1/m2).ToString();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string t = cbFrom.Text;
            cbFrom.Text = cbTo.Text;
            cbTo.Text = t;
        }

        private void cbMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMetric.Text)
            {
                case "Length":
                    metrica.Clear();
                    metrica.Add("mm", 1);
                    metrica.Add("cm", 10);
                    metrica.Add("dm", 100);
                    metrica.Add("m", 1000);
                    metrica.Add("km", 1000000);
                    metrica.Add("mile", 1609344);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("mm");
                    cbFrom.Items.Add("cm");
                    cbFrom.Items.Add("dm");
                    cbFrom.Items.Add("m");
                    cbFrom.Items.Add("km");
                    cbFrom.Items.Add("mile");
                    cbTo.Items.Clear();
                    cbTo.Items.Add("mm");
                    cbTo.Items.Add("cm");
                    cbTo.Items.Add("dm");
                    cbTo.Items.Add("m");
                    cbTo.Items.Add("km");
                    cbTo.Items.Add("mile");
                    cbFrom.Text = "mm";
                    cbTo.Text = "mm";
                    break;
                case "Weight":
                    metrica.Clear();
                    metrica.Add("g", 1);
                    metrica.Add("kg", 1000);
                    metrica.Add("t", 1000000);
                    metrica.Add("lb", 453.6);
                    metrica.Add("oz", 283);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("g");
                    cbFrom.Items.Add("kg");
                    cbFrom.Items.Add("t");
                    cbFrom.Items.Add("lb");
                    cbFrom.Items.Add("oz");
                    cbTo.Items.Clear();
                    cbTo.Items.Add("g");
                    cbTo.Items.Add("kg");
                    cbTo.Items.Add("t");
                    cbTo.Items.Add("lb");
                    cbTo.Items.Add("oz");
                    cbFrom.Text = "g";
                    cbTo.Text = "g";
                    break;
                default:
                    break;
            }
        }
    }
}
