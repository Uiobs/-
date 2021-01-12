using System;
using System.Windows.Forms;
using ContactApp;
using System.Linq;

namespace ContactAppUI
{

    /// <summary>
    /// Логика взаимодействия для MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        private Project _project;
        
        public MainForm()
        {
            InitializeComponent();
            //Десериализация
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultfilePath);
            CheckForBirthday();
            _project._contactlist = _project.SortList();
            if (_project != null)
            {
                ListBoxUpdate();
            }
            else 
            {
                _project = new Project();
            } 
        }
        /// <summary>
        /// Добавить запись
        /// </summary>
        private void Add()
        {
            var form = new ContactForm();
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var contact = form.Contact;
                _project._contactlist.Add(contact);

                ResetListBox();
                CheckForBirthday();
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultfilePath);
            }
            _project._contactlist = _project.SortList();
        }
        /// <summary>
        /// Поиск
        /// </summary>
        private void FindTextBoxCheck()
        {
            ContactsListBox.DataSource = _project.SortList(FindTextBox.Text);
        }
        /// <summary>
        /// Обновление списка контактов
        /// </summary>
        private void ListBoxUpdate()
        {
            ContactsListBox.Items.Clear();

            foreach (var contact in _project._contactlist)
            {
                ContactsListBox.Items.Add(contact.Surname);
            }
        }

        /// <summary>
        /// Отредактировать контакт
        /// </summary>
        private void Edit()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите запись для редактирования", "Отсутствие записи");
                return;
            }
            var selectedContact = _project._contactlist[selectedIndex];
            var form = new ContactForm();
            form.Contact = selectedContact;
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var updatedContact = form.Contact;
                _project._contactlist.RemoveAt(selectedIndex);
                _project._contactlist.Insert(selectedIndex, updatedContact);
                CheckForBirthday();
                ResetListBox();
                _project._contactlist = _project.SortList();
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultfilePath);
                ContactsListBox.SetSelected(selectedIndex, true);
            }
        }
        
        /// <summary>
        /// Удалить запись
        /// </summary>
        private void Remove()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите запись для удаления", "Отсутствие записи");
            }
            else
            {
                var dialogResult = MessageBox.Show("Удалить эту запись?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    _project._contactlist.RemoveAt(selectedIndex);
                    
                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultfilePath);
                    CheckForBirthday();
                    ResetListBox();
                }
            }
        }
        /// <summary>
        /// Обновление списка именнинков
        /// </summary>
        private void CheckForBirthday()
        {
            var birthdayBoys = _project.BirthdayBoy(DateTime.Today);
            var labelText = "";
            if (birthdayBoys.Count != 0)
            {
                labelText = "\n";
                foreach (var birthdayBoy in birthdayBoys)
                {
                    labelText += $@"{birthdayBoy.Name}{birthdayBoy.Surname} " + "\r\n";
                }
            }
            else
            {
                labelText = @"Сегодня именинников нет.";
            }

            BirthdayGroupBox.Text = labelText;
        }
        /// <summary>
        /// Обновление списка контактов
        /// </summary>
        private void ResetListBox()
        {
            _project._contactlist = _project.SortList();
            ContactsListBox.DataSource = _project._contactlist;
            ContactsListBox.DisplayMember = "Surname";
        }
        
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Contact contact = _project._contactlist[selectedIndex];
                ChangeSelectContact(contact);
            }
            else
            {
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                BirthdayTimePicker.Value = DateTime.Today;
                PhoneTextBox.Text = "";
                EmailTextBox.Text = "";
                VKTextBox.Text = "";
            }
            
        }

        private void ChangeSelectContact(Contact contact)
        {
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayTimePicker.Value = contact.Date;
            PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = contact.Email;
            VKTextBox.Text = contact.Vkid;
        }
        private void OKbutton_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            Remove();
        }
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            FindTextBoxCheck();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addContactToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Add();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Edit();
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var newForm = new AboutForm();
            newForm.Show();
        }

        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Remove();
            }
        }

        private void BirthdayGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}