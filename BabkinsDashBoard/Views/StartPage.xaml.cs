using Models.DataContext;
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

namespace BabkinsDashBoard.Views
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
       private DashBoardDataContext _dashboardDataContext;
        public StartPage(DashBoardDataContext context)
        {
            InitializeComponent();
            _dashboardDataContext = context;
            StartPageFrame.Navigate(new UserBoards(_dashboardDataContext));
        }
        
        private void UserBoardsBttn_Click(object sender, RoutedEventArgs e)
        {
            StartPageFrame.Navigate(new UserBoards(_dashboardDataContext));
        }

        private void AllBoardsBttn_Click(object sender, RoutedEventArgs e)
        {
            StartPageFrame.Navigate(new AllBoards(_dashboardDataContext));
        }

        private void PluginsBttn_Click(object sender, RoutedEventArgs e)
        {
            StartPageFrame.Navigate(new Page1(_dashboardDataContext));
        }
    }
}
