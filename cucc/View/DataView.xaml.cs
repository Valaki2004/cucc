using Data.Content;
using DB.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cucc.View
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : UserControl
    {
        public readonly Context _context;
        public User _selectedUser;

        public DataView()
        {
            InitializeComponent();
            _context = new Context();
            LoadData();
        }

        public void LoadData()
        {
            var users = _context.User.ToList();
            listBox.ItemsSource = users;
        }

        public void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                _selectedUser = (User)listBox.SelectedItem;
                nameTextBox.Text = _selectedUser.Name;
                ageTextBox.Text = _selectedUser.Age;
                cityTextBox.Text = _selectedUser.City;
                jobTextBox.Text = _selectedUser.Job;
                incomeTextBox.Text = _selectedUser.Income;
            }
        }

        public async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _selectedUser.Name = nameTextBox.Text;
                _selectedUser.Age = ageTextBox.Text;
                _selectedUser.City = cityTextBox.Text;
                _selectedUser.Job = jobTextBox.Text;
                _selectedUser.Income = incomeTextBox.Text;

                _context.User.Update(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
            }
        }

        public async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _context.User.Remove(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
                ClearFields();
            }
        }

        public void ClearFields()
        {
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            cityTextBox.Text = "";
            jobTextBox.Text = "";
            incomeTextBox.Text = "";
        }
    }
}
