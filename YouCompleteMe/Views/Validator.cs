using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouCompleteMe.Views
{
    class Validator
    {
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag.ToString() + " is a required field.");
                    textBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag.ToString() + " is a required field.");
                    comboBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        public static bool IsPhoneNumber(MaskedTextBox textBox)
        {
            string phoneChars = textBox.Text.Replace(".", "").Replace("(", "").Replace("_", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            try
            {
                Convert.ToInt64(phoneChars);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be in this format: " +
                    "(999) 999-9999");
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDate(MaskedTextBox textBox)
        {

            try
            {
                DateTime.Parse(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " is not a valid date.");
                textBox.Focus();
                return false;
            }
        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be an integer value.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDouble(TextBox textBox)
        {
            try
            {
                Convert.ToDouble(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be an double value.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
    }
}
