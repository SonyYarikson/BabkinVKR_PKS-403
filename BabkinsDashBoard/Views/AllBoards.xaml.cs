using Microsoft.EntityFrameworkCore;
using Models;
using Models.DataContext;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BabkinsDashBoard.Views
{
    /// <summary>
    /// Логика взаимодействия для AllBoards.xaml
    /// </summary>
    public partial class AllBoards : Page
    {
        private DashBoardDataContext _boardDataContext;
        public AllBoards(DashBoardDataContext context)
        {
            InitializeComponent();
            _boardDataContext = context;
            initDG();
        }
        private void initDG()
        {
            DGPublicBoards.ItemsSource = _boardDataContext.Boards.Include(Board => Board.User).Where(x => x.Privacy == "Public").ToList();
        }

        private void EditBoardBttn_Click(object sender, RoutedEventArgs e)
        {
            Board board = (sender as Button).DataContext as Board;
            EditBoard._context = board;
            AllBoardsFrame.Navigate(new EditBoard(_boardDataContext));
        }
    }
}
