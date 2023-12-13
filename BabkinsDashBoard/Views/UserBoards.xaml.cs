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
    /// Логика взаимодействия для UserBoards.xaml
    /// </summary>
    public partial class UserBoards : Page
    {
        private DashBoardDataContext _dasboarddatacontext;
        public UserBoards(DashBoardDataContext context)
        {
            InitializeComponent();
            _dasboarddatacontext = context;
            initDG();
        }
        private void initDG()
        {
            DgridUserBoards.ItemsSource = _dasboarddatacontext.Boards.Where(x => x.UserID == MainWindow.user.UserID).ToList();
        }
    }
}
