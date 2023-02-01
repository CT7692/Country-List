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
using System.Collections;

namespace COSC2110_AssiIX
{
    public partial class frmIntnlRel : Form
    {

        public class Country
        {
            private string name;
            private long population;
            private decimal size;

            public Country()
            {

            }

            public Country(string n, long p, decimal s)
            {
                name = n;
                population = p;
                size = s;
            }

            public string Name { get { return name; } set { name = value; } }

            public long Population { get { return population; } set { population = value; } }

            public decimal Size { get { return size; } set { size = value; } }

            public string GetDisplayText()
            {
                return String.Format(Name.PadRight(15) + "\t" + Population.ToString("n0").PadRight(15) 
                    + "\t" + Size.ToString("n2").PadRight(15) + "\n");
            }

            public bool LessThan(Country c)
            {
                if (c == null)
                    return false;
                if (Decimal.Compare(this.size, c.size) < 0)
                    return true;
                else
                    return false;
            }

            public static bool operator < (Country c1, Country c2)
            {
                if (Object.Equals(c1, null))
                {
                    if (Object.Equals(c2, null))
                        return true;
                    else
                        return false;
                }

                else
                    return c1.LessThan(c2);
            }

            public static bool operator > (Country c1, Country c2)
            {
                return !((c1 < c2) || (c1 == c2));
            }
        }

        Company first = new Company("JoJo Airlines");

        public frmIntnlRel()
        {
            InitializeComponent();

            CompSetup(ref first);

            cboCompanies.Items.Add(first.CoName);

            cboSortedList.Items.Add("Name");
            cboSortedList.Items.Add("Population");
            cboSortedList.Items.Add("Size");
        }
        
        private void ClearAll()
        {
            cboCompanies.Text = "Select Company";
            cboSortedList.Text = "Show List Sorted By";
            txtSearchCountry.Clear();
        }

        private void CompSetup(ref Company j)
        {
            j.Add("United Kingdom", 67530172, 93410);
            j.Add("Thailand", 69037513, 197260);
            j.Add("China", 1433783686, 3600950);
            j.Add("United States", 329064917, 3531923);
            j.Add("Japan", 126860301, 140752);
            j.Add("France", 65129728, 247270);
            j.Add("South Africa", 58558270, 468910);
            j.Add("Canada", 37411047, 3511023);
            j.Add("Australia", 25203198, 2947366);
            j.Add("Ghana", 31072940, 87851);
            j.Add("Uzbekistan", 33469203, 172700);
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnLargest_Click(object sender, EventArgs e)
        {
            if (cboCompanies.SelectedIndex == -1)
                MessageBox.Show("Please select company.", "Entry Error");
            else
            {
                Country obj = first.HighestPerSqMile();

                MessageBox.Show("Name: \t\t" + obj.Name + 
                    "\nPopulation: \t" + obj.Population.ToString("n0") +
                    "\nSize: \t\t" + obj.Size.ToString("n0"), "Largest Country");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cboCompanies.SelectedIndex == -1)
                MessageBox.Show("Please select company.", "Entry Error");
            else if (txtSearchCountry.Text == "")
                MessageBox.Show("Please enter a country.", "Entry Error");
            else
            {
                first.RemoveCountry(txtSearchCountry.Text);
                txtSearchCountry.Clear();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboCompanies.SelectedIndex == -1)
                MessageBox.Show("Please select company.", "Entry Error");
            else if (txtSearchCountry.Text == "")
                MessageBox.Show("Please enter a country.", "Entry Error");
            else
            {
                first.Search(txtSearchCountry.Text);
                txtSearchCountry.Clear();
            }
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            if (cboCompanies.SelectedIndex == -1)
                MessageBox.Show("Please select company.", "Entry Error");
            else if (cboSortedList.SelectedIndex == -1)
                MessageBox.Show("Please select how the countries are to be sorted.", "Entry Error");
            else
                first.SortCountries(cboSortedList.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboCompanies.SelectedIndex == -1)
                MessageBox.Show("Please select company.", "Entry Error");
            else
                first.AddCountry();

        }
    }
}
