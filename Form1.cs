using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float GetSizePrice()
        {
            if (rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }
            else if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium.Tag);
            }
            else
            {
                return Convert.ToSingle(rbLarg.Tag);
            }
        }

        float GetCrustTypePrice()
        {
            if (rbThinCrust.Checked)
            {
                return Convert.ToSingle(rbThinCrust.Tag);
            }
            else
            {
                return Convert.ToSingle(rbThinkCrust.Tag);
            }
        }
       
        float GetToppingsPrice()
        {

            float ToppingsPrice = 0f;

            if (chkExtraChees.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkExtraChees.Tag);
            }

            if (chkMushrooms.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkMushrooms.Tag);
            }

            if (chkTomatoes.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkTomatoes.Tag);
            }

            if (chkOnion.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkOnion.Tag);
            }

            if (chkOlives.Checked)
            {

                ToppingsPrice += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkGreenPeppers.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }

            return ToppingsPrice;
        }

        float GetTotalPrice()
        {
            return GetSizePrice() + GetCrustTypePrice() + GetToppingsPrice();
        }

        void UpdateTotalPrice()
        {
            lblPrice.Text = '$' + GetTotalPrice().ToString();
        }
        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
                lblSize.Text = rbSmall.Text;
            else if (rbMedium.Checked)
                lblSize.Text = rbMedium.Text;
            else
                lblSize.Text = rbLarg.Text;


        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            lblToppings.Text = "";

            if (chkExtraChees.Checked)
                lblToppings.Text +=  chkExtraChees.Text + " ,";

            if (chkMushrooms.Checked)
                lblToppings.Text +=  chkMushrooms.Text + " ,";

            if (chkTomatoes.Checked)
                lblToppings.Text +=  chkTomatoes.Text + " ,";

            if (chkOnion.Checked)
                lblToppings.Text +=  chkOnion.Text + " ,";

            if (chkOlives.Checked)
                lblToppings.Text +=  chkOlives.Text + " ,";

            if (chkGreenPeppers.Checked)
                lblToppings.Text +=  chkGreenPeppers.Text + " ,";

            if (lblToppings.Text.EndsWith(","))
            {
                lblToppings.Text = lblToppings.Text.Substring(0, lblToppings.Text.Length - 1).Trim();
            }

            if (lblToppings.Text == "")
            {
                lblToppings.Text = "No toppings";
            }
        }


        void UpdateCrustType()
        {
            UpdateTotalPrice();

            if (rbThinCrust.Checked)
                lblCrustType.Text = rbThinCrust.Text;
            else
                lblCrustType.Text = rbThinkCrust.Text;
        }

        void UpdateWhereToEat()
        {

            if (rbEatIn.Checked)
                lblWhereToEat.Text = rbEatIn.Text;
            else
                lblWhereToEat.Text = rbTakeOut.Text;

        }

       void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrustType();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        void OrderPizza()
        {
            if (MessageBox.Show("Confirm your order?" , "Confirm" , MessageBoxButtons.OKCancel ,
                MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 ) == DialogResult.OK)
            {
                MessageBox.Show("The request has been accepted.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                gbSize.Enabled = gbCrustType.Enabled = gbToppings.Enabled = 
                    gbWhereToEat.Enabled = btnOrderPizza.Enabled = false;

            }
        }

        void ResetForm()
        {
            gbSize.Enabled = gbCrustType.Enabled = gbToppings.Enabled =
                   gbWhereToEat.Enabled = btnOrderPizza.Enabled = true;

            rbMedium.Checked = rbThinCrust.Checked = rbTakeOut.Checked = true;

            chkExtraChees.Checked = chkMushrooms.Checked = chkTomatoes.Checked =
                chkOnion.Checked = chkOlives.Checked = chkGreenPeppers.Checked = false;

            lblSize.Text = rbMedium.Text;
            lblToppings.Text = "No toppings";
            lblCrustType.Text = rbThinCrust.Text;
            lblWhereToEat.Text = rbTakeOut.Text;
            lblPrice.Text = "$30"; 
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {

            UpdateSize();
        }

        private void rbLarg_CheckedChanged(object sender, EventArgs e)
        {

            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {

            UpdateWhereToEat();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            OrderPizza();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
