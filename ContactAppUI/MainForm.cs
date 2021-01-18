using System;
using System.Windows.Forms;
using ContactApp;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace ContactAppUI
{
    /// <summary>
    /// Логика взаимодействия для MainForm
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// Поле для хранения списка контактов, отображамых в левой панели
        /// </summary>
        private List<Contact> _displayedContacts;

        /// <summary>
        /// Начальная фраза в панели именинников
        /// </summary>
        const string BIRTDAYS_STRING_START = "";

        /// <summary>
        /// Поле для хранения всех контактов во время работы
        /// </summary>
        private Project _project;

        public MainForm()
        {
            InitializeComponent();
            //Десериализация
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultfilePath);
            CheckForBirthday();
            _project._contactlist = _project.SortList();
            _displayedContacts = _project._contactlist;
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
            FindTextBox.Clear();
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

            var selectedContact = _displayedContacts[selectedIndex];
            int index = _project._contactlist.IndexOf(selectedContact); 
            var form = new ContactForm { Contact = selectedContact };
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var updatedContact = form.Contact;
                _displayedContacts[selectedIndex] = updatedContact;    
                _project._contactlist[index] = updatedContact;         
                CheckForBirthday();
                ResetListBox();
                _project._contactlist = _project.SortList();
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultfilePath);
                ContactsListBox.SetSelected(selectedIndex, true);
                FindTextBox.Clear();
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
                    CheckIndex();
                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultfilePath);
                    CheckForBirthday();
                    ResetListBox();
                }
            }
            FindTextBox.Clear();
        }

        /// <summary>
        /// Поиск индекса для контактов слева
        /// </summary>
        private void CheckIndex()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            var selectedContact = _displayedContacts[selectedIndex];
            int index = _project._contactlist.IndexOf(selectedContact);
            var form = new ContactForm { Contact = selectedContact };
            _displayedContacts.RemoveAt(selectedIndex);
            _project._contactlist.RemoveAt(index);
        }
        /// <summary>
        /// Обновление списка именнинков
        /// </summary>
        private void CheckForBirthday()
        {
            var birthdays = from contact in _project._contactlist
                            where (contact.Date.Month == DateTime.Now.Month)
                            && (contact.Date.Day == DateTime.Now.Day)
                            select contact;
            var birthdayData = _project.BirthdayData(DateTime.Today);
            if (birthdayData.Count != 0)
            {
                foreach (var birthdayDat in birthdayData)
                {
                    var birthdaysSurnames = from contact in birthdays
                                            select contact.Surname;

                    BirthdayTextBox.Text = BIRTDAYS_STRING_START + string.Join(", ", birthdaysSurnames);
                    BirthdayPanel.Visible = true;
                }
            }
            else
            {
                BirthdayPanel.Visible = false;
            } 
        }

        /// <summary>
        /// Обновление списка контактов
        /// </summary>
        private void ResetListBox()
        {
            _project._contactlist = _project.SortList();
            _displayedContacts = _project._contactlist;
            ContactsListBox.DataSource = _project._contactlist;
            ContactsListBox.DisplayMember = "Surname";
        }

        /// <summary>
        /// Отображает выбранный в списке контакт в правой части
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Contact contact = _displayedContacts[selectedIndex];
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

        /// <summary>
        /// Вывод контаков в левую панель
        /// </summary>
        private void ShowListBoxItems(List<Contact> contacts)
        {
            ContactsListBox.DataSource = null;
            ContactsListBox.Items.Clear();

            for (int i = 0; i < contacts.Count; i++)
            {
                ContactsListBox.Items.Add(contacts[i].Surname);
            }
        }

        /// <summary>
        /// Ввод подстроки в текстовое поле для поиска
        /// </summary>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            _displayedContacts = _project.SortList(FindTextBox.Text);

            if (_displayedContacts.Count == _project._contactlist.Count)
            {
                _displayedContacts = _project.SortList();
            }
            ShowListBoxItems(_displayedContacts);
            SelectFirstContact();
        }

        private void SelectFirstContact()
        {
            if (_displayedContacts.Count > 0)
            {
                ContactsListBox.SelectedIndex = 0;
                ChangeSelectContact(_displayedContacts[0]);
            }
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

        private void BirthdayGroupBox_Enter(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e) { }

        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e) { }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}