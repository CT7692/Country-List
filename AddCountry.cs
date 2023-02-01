using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COSC2110_AssiIX.frmIntnlRel;
using static COSC2110_AssiIX.Company;

namespace COSC2110_AssiIX
{
    public partial class frmAddCountry : Form
    {
        public frmAddCountry()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AddClearAll();
        }

        private void AddClearAll()
        {
            txtCountryName.Clear();
            txtPopulation.Clear();
            txtSize.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            char cCheck1;
            char cCheck2;
            char cCheck3;
            int iCheck;
            double dCheck1;
            decimal dCheck2;
            long lCheck;


            bool cFailSafe1 = Char.TryParse(txtCountryName.Text, out cCheck1);
            bool cFailSafe2 = Char.TryParse(txtPopulation.Text, out cCheck2);
            bool cFailSafe3 = Char.TryParse(txtSize.Text, out cCheck3);
            bool iFailSafe = Int32.TryParse(txtCountryName.Text, out iCheck);
            bool dFailSafe1 = Double.TryParse(txtCountryName.Text, out dCheck1);
            bool dFailSafe2 = Decimal.TryParse(txtSize.Text, out dCheck2);
            bool lFailSafe = long.TryParse(txtPopulation.Text, out lCheck);

            try
            {
                if (cFailSafe1 || iFailSafe || dFailSafe1)
                    MessageBox.Show("Please enter valid name.", "Entry Error");
                else if (txtPopulation.Text == "" || !lFailSafe)
                    MessageBox.Show("Please enter country's population.", "Entry Error");
                else if (txtSize.Text == "" || !dFailSafe2)
                    MessageBox.Show("Please enter country size.", "Entry Error");
                else
                {
                    Country obj = new Country();
                    obj.Name = txtCountryName.Text;
                    obj.Population = long.Parse(txtPopulation.Text);
                    obj.Size = Decimal.Parse(txtSize.Text);
                    Tag = obj;
                    Close();
                }
            }

            catch(OverflowException ex)
            {
                MessageBox.Show(ex.Message);
                AddClearAll();
            }

            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
                AddClearAll();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                AddClearAll();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
