using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace taskify
{
    /// <summary>
    /// Interaction logic for SmallPartial.xaml
    /// </summary>
    public partial class SmallPartial : UserControl
    {
        public SmallPartial()
        {
            InitializeComponent();
        }

        private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (numberOfCharacters != null) { numberOfCharacters.Content = $"{descriptionTextBox.Text.Length}/200"; }
            if (descriptionTextBox.Text.Length >= 200)
            {
                descriptionTextBox.BorderBrush = Brushes.Red;
            } else
            {
                descriptionTextBox.BorderBrush = Brushes.Black;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (categoryPicker.SelectedItem == null) { categoryErrorLabel.Foreground = Brushes.Red; }
            else { categoryErrorLabel.Foreground = Brushes.White; }
            if (rb1.IsChecked == false & rb2.IsChecked == false & rb3.IsChecked == false & rb4.IsChecked == false & rb5.IsChecked == false) { importanceErrorLabel.Foreground = Brushes.Red; }
            else { importanceErrorLabel.Foreground = Brushes.White; }
            if (dateOfTasks.SelectedDate == null) { dateErrorLabel.Foreground = Brushes.Red; }
            else { dateErrorLabel.Foreground = Brushes.White; }
            Match result = Regex.Match(taskTitleTextbox.Text, @"^[a-zA-Z0-9_.-]*$");
            if (!result.Success) { taskTitleError.Foreground = Brushes.Red; }
            else { taskTitleError.Foreground = Brushes.White; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
