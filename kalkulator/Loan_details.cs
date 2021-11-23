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
    public partial class Loan_details : Form
    {
        int kol;
        decimal Proc, ViplatMonht, Kredit;
        public Loan_details(int KolMonth, decimal ProcStav, decimal ViplatMec, decimal kred)
        {
            InitializeComponent();

            kol = KolMonth;
            Proc = ProcStav;
            ViplatMonht = ViplatMec;
            Kredit = kred;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Loan_details_Load(object sender, EventArgs e)
        {
            decimal procres = 1 + Proc;
            double pr = Convert.ToDouble(procres);

            decimal Procress = 1 + 0 * Proc;
            decimal resProc = Proc / Procress;

            decimal resulkl = ViplatMonht - 0 * resProc;

            DataliTable.Columns[0].Width = 100;
            DataliTable.Columns[2].Width=160;
            DataliTable.Columns[4].Width=170;


            int rowIndex = DataliTable.Rows.Add(kol);

            for (int i = 0; i < kol; i++)
            {
                DataliTable.Rows[i].Cells[0].Value = i+1;


                //Выплата кредита
                int kolres = (i + 1) - 1 - kol;
                double sqv = Math.Pow(pr, kolres);
                double resultVip = sqv * Convert.ToDouble(resulkl);
                double resVipLat = Math.Round(resultVip, 2);
                DataliTable.Rows[i].Cells[1].Value = resVipLat;//Выплата кредита


                //Выплата процентов 
                int kolperiod = (i + 1) - 1;
                double sqvres = Math.Pow(pr, kolperiod);
                double d = sqvres - 1;
                decimal kr = Kredit * Convert.ToDecimal(sqvres);
                double resV = (Convert.ToDouble(ViplatMonht) * d)/ Convert.ToDouble(Proc);
                decimal resprocc = -((kr + Convert.ToDecimal(resV)) * (Proc));
                DataliTable.Rows[i].Cells[2].Value = Math.Round(resprocc,2);//Выплата процентов 


                //Общая выплата 
                decimal obchvip =Convert.ToDecimal(resVipLat) + resprocc;
                DataliTable.Rows[i].Cells[3].Value = Math.Round(obchvip, 2);//Общая выплата 
                double ressum=0;


                //Осталось выплатить
                double sum = 0;
                double[,] dArr = new double[i,1];

                foreach (DataGridViewRow row in this.DataliTable.Rows)
                {
                    sum+= Convert.ToDouble(row.Cells[1].Value);
                    ressum = Math.Round(sum);
                }
               double dann = Convert.ToDouble(Kredit) + ressum;
                DataliTable.Rows[i].Cells[4].Value = dann; //Осталось выплатить
            }
        }
    }
}
