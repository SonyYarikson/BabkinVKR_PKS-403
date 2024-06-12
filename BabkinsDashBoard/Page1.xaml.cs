using Models.DataContext;
using System.Linq;
using System.Windows.Controls;
using Models;

namespace BabkinsDashBoard
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private static DashBoardDataContext _boardDataContext;
        public Page1(DashBoardDataContext context)
        {
            InitializeComponent();
            _boardDataContext = context;
            LVV.ItemsSource = _boardDataContext.Rows.ToList();
        }
    }
}
