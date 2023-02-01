using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COSC2110_AssiIX.frmIntnlRel;
using static COSC2110_AssiIX.frmAddCountry;

namespace COSC2110_AssiIX
{

    internal class Company
    {
        private string coName;
        private List<Country> affilNat;

        public Company(string n)
        {
            affilNat = new List<Country>();
            coName = n;
        }

        public string CoName { get { return coName; } set { coName = value; } }

        public int Count => affilNat.Count;

        public void Add(string n, long p, decimal s)
        {
            Country c = new Country(n, p, s);
            affilNat.Add(c);
        }

        public Country this[string countryName]
        {
            get
            {
                foreach(Country c in affilNat)
                {
                    if (c.Name == countryName)
                        return c;
                }

                return null;
            }
        }

        public Country this[int i]
        {
            get { return affilNat[i]; }
            set { affilNat[i] = value; }
        }

        public void AddCountry()
        {
            Form addCountry = new frmAddCountry();
            addCountry.ShowDialog();

            if (addCountry.Tag != null)
            {
                affilNat.Add((Country)addCountry.Tag);
                MessageBox.Show("Country added.");
            }
        }

        public bool RemoveCountry(string remCountry)
        {
            bool removed = false;

            Country c = new Country();

            foreach(Country i in affilNat)
            {
                if (i.Name == remCountry)
                    c = i;
            }

            bool exists = affilNat.Contains(c);

            if (!exists)
                MessageBox.Show("No match found.");
            else
            {
                affilNat.Remove(c);
                removed = true;
                MessageBox.Show("Country removed.");
            }

            return removed;
        }

        public Country HighestPerSqMile()
        {
            Country max = new Country();

            foreach(Country i in affilNat)
            {
                if (i > max)
                    max = i;
            }

            return max;
        }

        public void SortCountries(string value)
        {
            try
            {
                int counter = 0;
                
                if (value == "Name")
                    affilNat.Sort((a, b) => a.Name.CompareTo(b.Name));


                if (value == "Population")
                    affilNat.Sort((a, b) => b.Population.CompareTo(a.Population));


                if (value == "Size")
                    affilNat.Sort((a, b) => b.Size.CompareTo(a.Size));

                string viewList = "Company: \t" + CoName + "\n\n"
                        + "Name: \t\tPopulation: \tSize: \n";

                foreach (Country i in affilNat)
                {
                    viewList += i.GetDisplayText();
                    counter++;
                }

                viewList += "\nAffiliated Countries: " + counter;
                MessageBox.Show(viewList);
            }

            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Search(string searchName)
        {
            Country c = new Country();

            foreach(Country i in affilNat)
            {
                if (i.Name == searchName)
                    c = i;
            }

            bool exists = affilNat.Contains(c);

            if (!exists)
                MessageBox.Show("No match found.");
            else
            {
                MessageBox.Show("Name: \t\t" + c.Name +
                    "\nPopulation: \t" + c.Population.ToString("n0") +
                    "\nSize: \t\t" + c.Size.ToString("n0"), "Found");
            }
        }
    }
}
