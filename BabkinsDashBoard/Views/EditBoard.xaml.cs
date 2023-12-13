using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Models;
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
    /// Логика взаимодействия для EditBoard.xaml
    /// </summary>
    public partial class EditBoard : Page
    {
        public static Board _context;
        private static DashBoardDataContext _boardDataContext;
        private DbContextOptions<DashBoardDataContext> options;
        
        public EditBoard(DashBoardDataContext context)
        {
            InitializeComponent();
            _boardDataContext = context;
            
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                _boardDataContext.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var cards = _boardDataContext.Cards.Where(x => x.BoardID == _context.BoardID).ToList();
                foreach (var card in cards)
                {
                    card.Rows = (_boardDataContext.Rows.Where(c => c.CardId == card.CardID).ToList());
                }
                KanbanBoardItemsControl.ItemsSource = cards;
            }
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var parent = (sender as Label).Parent as Grid;
            var tb = parent.Children[0] as TextBox;
            tb.IsEnabled = !tb.IsEnabled;
            if (!tb.IsEnabled)
            {
                Card currentcard = (sender as Button).DataContext as Card;
                var currentrow = new Row();
                var lvparent = parent.Parent as ListView;
                var id = lvparent.Uid;
                //currentrow.cardid = currentcard.cardid;
                //currentrow.rowtype = "text";
                //currentrow.rowcontent = textbox.text;
                //_boarddatacontext.rows.add(currentrow);
                //_boarddatacontext.savechanges();
            }
        }
    }
}