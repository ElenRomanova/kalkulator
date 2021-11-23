using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        decimal  ProcStav, ViplatMonht, SummaVip, SummaPereplat, Kredit;
        int KolMonth;

        private void txtProc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }


            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (txtProc.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }


            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку 
                    Chetbtn.Focus();
                return;
            }

            //остальные символы запрещены
            e.Handled = true;
        }

        private void txtYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку 
                    Chetbtn.Focus();
                return;
            }

            //остальные символы запрещены
            e.Handled = true;

        }

        private void txtKredit_KeyPress(object sender, KeyPressEventArgs e)
        {
         

                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    // цифра
                    return;
                }
 

            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (txtKredit.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }
    

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку 
                    Chetbtn.Focus();
                return;
            }

            //остальные символы запрещены
                e.Handled = true;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Visible = false;
            txtProc.Clear();
            txtYears.Clear();
            txtKredit.Clear();

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }


        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Loan_details loan_Details = new Loan_details(KolMonth, ProcStav, ViplatMonht, Kredit);
            loan_Details.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void PodchetSrokMonth()
        {
            if (txtProc.Text != "" && txtYears.Text != "" && txtKredit.Text != "")
            {
                Kredit= Convert.ToDecimal(txtKredit.Text);
                ProcStav =(Convert.ToDecimal(txtProc.Text)/100/12);//проц. ставка в месяц
            KolMonth = Convert.ToInt32(txtYears.Text)*12;//срок выплат в  месяцах

            double procstav = 1 + Convert.ToDouble(ProcStav);
            decimal pr = Convert.ToDecimal(Math.Pow(procstav, KolMonth));
            decimal kr = Convert.ToDecimal(txtKredit.Text);
            decimal result = -kr * (ProcStav * pr) / (pr - 1);
            ViplatMonht =Math.Round(result,2);
            SummaVip = ViplatMonht * KolMonth;
            SummaPereplat = SummaVip - Convert.ToDecimal(txtKredit.Text);

          
                guna2Panel1.Visible = true;
                KolvoMonth.Text = Convert.ToString(KolMonth);
                ViplatMonth.Text = Convert.ToString(ViplatMonht);
                SummaViplat.Text= Convert.ToString(Math.Round(SummaVip,2));
                SummPereplat.Text= Convert.ToString(Math.Round(SummaPereplat,2));
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PodchetSrokMonth();
        }
    }
}
