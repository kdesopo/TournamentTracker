using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text,
                    prizeAmtValue.Text, 
                    prizePrctValue.Text);

                 GlobalConfig.Connection.CreatePrize(model);

                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmtValue.Text = "0";
                prizePrctValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }

        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;

            if (!int.TryParse(placeNumberValue.Text, out placeNumber))
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmt = 0;
            double prizePercnt = 0;

            if (!decimal.TryParse(prizeAmtValue.Text, out prizeAmt) ||
                !double.TryParse(prizePrctValue.Text, out prizePercnt))
            {
                output = false;
            }

            if (prizeAmt <= 0 && (prizePercnt <= 0 || prizePercnt > 100))
            {
                output = false;
            }

            return output;
        }
    }
}
