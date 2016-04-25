using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InputValidation
{
    public partial class ValidatorForm : Form
    {
        public ValidatorForm()
        {
            InitializeComponent();
        }

        private void sabeButton_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(nameBox.Text, @"^([A-Za-z]*\s*)*$")) {
                MessageBox.Show(@"The name must contain only letters!", Name, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            if (!Regex.IsMatch(phoneBox.Text, @"^((\+?36)?|(06)?)[ -]?(\d{1,2}|(\(\d{1,2}\)))/?([ -]?\d){6,7}$"))
                MessageBox.Show(@"The phone number is not a valid Hungarian phone number");

            if (!Regex.IsMatch(mailBox.Text, @"^([a-zA-Z0-9_\-” + @”\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) 
            {
                MessageBox.Show(@"The e-mail address is not valid.");
            }
            phoneBox.Text = PhoneFormatter(phoneBox.Text);
        }

        private string PhoneFormatter(string phoneNumber) {
            Match reg = Regex.Match(phoneNumber, @"(\d{1,2}|(\(\d{1,2}\)))/?((\d){3})\-?((\d){3,4})$");
            return String.Format(@"(+36) {0} {1}-{2}", reg.Groups[1], reg.Groups[3], reg.Groups[5]);
        }
    }
}
