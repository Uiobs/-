using System;
using System.Drawing;
using System.Windows.Forms;
using ContactApp;

namespace ContactAppUI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Поле для хранения всех контактов во время работы
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Загрузка формы добавления контактов
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает/задёт редактируемый или создаваемый объект
        /// </summary>
        public Contact Contact
        {
            get { return _contact;}

            set
            {
                _contact = (Contact)value.Clone();
                UpdateContact();
            }
        }

        private void UpdateContact()
        {
            if (_contact != null)
            {
                SurnameTextBox.Text = _contact.Surname;
                NameTextBox.Text = _contact.Name;
                BirthdayTimePicker.Value = _contact.Date; 
                PhoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
                EmailTextBox.Text = _contact.Email;
                VKTextBox.Text = _contact.Vkid;
            }
        }

        /// <summary>
        /// Считывает дату рождения контакта с TimePicker
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            long number;
            bool valuechecker;
            try
            {
                valuechecker = true;
                _contact.Surname = SurnameTextBox.Text;
                _contact.Name = NameTextBox.Text;
                _contact.Date = BirthdayTimePicker.Value;
                long.TryParse(PhoneTextBox.Text, out number);
                _contact.PhoneNumber.Number = number;
                _contact.Email = EmailTextBox.Text;
                _contact.Vkid = VKTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
                valuechecker = false;
            }
            if (valuechecker)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Считывает имя контакта с TextBox
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                NameTextBox.BackColor = Color.LightSalmon;
            }

        }
        
        /// <summary>
        /// Считывает фамилию контакта с TextBox
        /// </summary>
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
        }

        /// <summary>
        /// Считывает Birthday контакта с TextBox
        /// </summary>
        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Date = BirthdayTimePicker.Value;
                BirthdayTimePicker.BackColor = Color.White;
            }
            catch (Exception)
            {
                BirthdayTimePicker.BackColor = Color.LightSalmon;
            }
        }

        /// <summary>
        /// Считывает VkId контакта с TextBox
        /// </summary>
        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Vkid = VKTextBox.Text;
                VKTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                VKTextBox.BackColor = Color.LightSalmon;
            }
        }
        
        /// <summary>
        /// Считывает Phone с TextBox
        /// </summary>
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneTextBox.Text, out number);
                _contact.PhoneNumber.Number = number;
                PhoneTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
        }
        
        /// <summary>
        /// Считывает e-mail контакта с TextBox
        /// </summary>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}
