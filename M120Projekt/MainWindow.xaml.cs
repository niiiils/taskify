using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Xml;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private Boolean darkmodeStatus = true;

        private UIElement[] elements;
        public MainWindow()
        {
            InitializeComponent();
            // Wichtig!
            Data.Global.context = new Data.Context();
            // Aufruf diverse APIDemo Methoden
            API.TaskCreate();
            API.TaskCreateShort();
            API.TaskRead();
            API.TaskUpdate();
            API.TaskRead();
            API.TaskDelete();

           nightmodebutton.Source = new BitmapImage(new Uri(@"./Properties/darkmode.png", UriKind.Relative));
        } 

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string BoundDMPath;

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Terminate(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dmButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (darkmodeStatus) {
                darkmodeStatus = false;
                darkModeConverter(darkmodeStatus);
            } else
            {
                darkmodeStatus = true;
                darkModeConverter(darkmodeStatus);
            }
        }

        private void darkModeConverter(Boolean status)
        {
            var bc = new BrushConverter();
            if (status)
            {
                //smallPartial.taskTitleTextbox.Foreground = (Brush)bc.ConvertFrom("#000000");
                smallPartial.gradientStop1.Color = (Color)ColorConverter.ConvertFromString("#FFFFFF");
                smallPartial.gradientStop2.Color = (Color)ColorConverter.ConvertFromString("#FFFFFF");
                TaskifyCanvas.Background = (Brush)bc.ConvertFrom("#ffffff");
                DragBar.Background = (Brush)bc.ConvertFrom("#FFFFFF");
                nightmodebutton.Source = null;
                nightmodebutton.Source = new BitmapImage(new Uri(@"./Properties/darkmode.png", UriKind.Relative));
                closebutton.Source = null;
                closebutton.Source = new BitmapImage(new Uri(@"./Properties/close-button.png", UriKind.Relative));
                settingsbutton.Source = null;
                settingsbutton.Source = new BitmapImage(new Uri(@"./Properties/settings.png", UriKind.Relative));
                inboxbutton.Source = null;
                inboxbutton.Source = new BitmapImage(new Uri(@"./Properties/inbox.png", UriKind.Relative));
                foreach (Label lb in FindVisualChildren<Label>(taskify))
                {
                    lb.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
                foreach (Button bt in FindVisualChildren<Button>(taskify))
                {
                    bt.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
                foreach (Label lb in FindVisualChildren<Label>(smallPartial))
                {
                    lb.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
                foreach (Button bt in FindVisualChildren<Button>(smallPartial))
                {
                    bt.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
            } else
            {
                //smallPartial.taskTitleTextbox.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                smallPartial.gradientStop1.Color = (Color)ColorConverter.ConvertFromString("#485563");
                smallPartial.gradientStop2.Color = (Color)ColorConverter.ConvertFromString("#29323C");
                TaskifyCanvas.Background = (Brush)bc.ConvertFrom("#29323C");
                DragBar.Background = (Brush)bc.ConvertFrom("#29323C");
                nightmodebutton.Source = null;
                nightmodebutton.Source = new BitmapImage(new Uri(@"./Properties/darkmode-on.png", UriKind.Relative));
                closebutton.Source = null;
                closebutton.Source = new BitmapImage(new Uri(@"./Properties/close-button-dm.png", UriKind.Relative));
                settingsbutton.Source = null;
                settingsbutton.Source = new BitmapImage(new Uri(@"./Properties/settings-dm.png", UriKind.Relative));
                inboxbutton.Source = null;
                inboxbutton.Source = new BitmapImage(new Uri(@"./Properties/inbox-dm.png", UriKind.Relative));
                foreach (Label lb in FindVisualChildren<Label>(taskify))
                {
                    lb.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                }
                foreach (Button bt in FindVisualChildren<Button>(taskify))
                {
                    bt.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                }
                foreach (Label lb in FindVisualChildren<Label>(smallPartial))
                {
                    lb.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                }
                foreach (Button bt in FindVisualChildren<Button>(smallPartial))
                {
                    bt.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                }
            }
        }

        private void DragBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            smallPartial.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
