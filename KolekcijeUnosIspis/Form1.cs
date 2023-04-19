using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolekcijeUnosIspis
{
    public partial class Form1 : Form
    {
        List<Vozilo> voziloList = new List<Vozilo>();
        public Form1()
        {
            InitializeComponent();
        }
        class Vozilo
        {
            string marka, model, vrsta;
            string voziPo;

            public string Marka { get => marka; set => marka = value; }
            public string Model { get => model; set => model = value; }
            public string Vrsta { get => vrsta; set => vrsta = value; }
            public string VoziPo { get => voziPo; set => voziPo = value; }

            public Vozilo(string marka, string model, string vrsta)
            {
                this.marka = marka;
                this.model = model;
                this.vrsta = vrsta;
            }

            public override string ToString()
            {
                return "Marka: " + this.marka + "\tModel: " + this.model + "\tVrsta: " + this.vrsta + "\tVozi po: " + this.voziPo + "\r\n\r\n";
            }
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBox1.Text == "" || txtBox2.Text == "" || cmbBox.Text == "")
                {
                    MessageBox.Show("Pogrešan unos. Molimo pokušajte ponovo.", "Pogrešan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBox1.Clear();
                    txtBox2.Clear();
                    cmbBox.Focus();
                }
                else
                {
                    Vozilo vozilo = new Vozilo(txtBox1.Text, txtBox2.Text, cmbBox.Text);
                    voziloList.Add(vozilo);
                    txtBox1.Clear();
                    txtBox2.Clear();
                    cmbBox.Focus();
                }
                
            }
            catch
            {
                MessageBox.Show("Pogrešan unos. Molimo pokušajte ponovo.", "Pogrešan unos",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                txtBox1.Clear();
                txtBox2.Clear();
                cmbBox.Focus();
            }
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            foreach (Vozilo v in voziloList) 
            {
                txtBox3.AppendText(v.ToString());
            }
            
        }

        private void btnObrada_Click(object sender, EventArgs e)
        {
            foreach (Vozilo v in voziloList)
            { 
                if (v.Vrsta == "Avion")
                {
                    v.VoziPo = "Zrak";
                }
                else if (v.Vrsta == "Automobil")
                {
                    v.VoziPo = "Cesta";
                }
                else
                {
                    v.VoziPo = "Voda";
                }
            }
        }
    }
}
