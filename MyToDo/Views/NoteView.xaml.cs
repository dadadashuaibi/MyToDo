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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlankApp1.Views
{
    /// <summary>
    /// NoteView.xaml 的交互逻辑
    /// </summary>
    public partial class NoteView : UserControl
    {
        public NoteView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = addview.Width;
            da.To = 220;
            da.Duration = TimeSpan.FromSeconds(0.3);
            addview.BeginAnimation(WidthProperty, da);
            addview.Visibility = Visibility.Visible;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = addview.Width;
            da.To = 0;
            da.Duration = TimeSpan.FromSeconds(0.3);
            addview.BeginAnimation(WidthProperty, da);
            txtTittle.Text = "";
            txtContent.Text = "";
            addview.Visibility = Visibility.Collapsed;
        }
    }
}
