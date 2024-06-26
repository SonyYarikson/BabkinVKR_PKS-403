﻿using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Models;
using Models.DataContext;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Card = Models.Card;


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
        private byte[] image;
        
        public EditBoard(DashBoardDataContext context)
        {
            InitializeComponent();
            _boardDataContext = context;
            
        }

        private async void AddRow_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var parent = (sender as Label).Parent as Grid;
            var tb = parent.Children[0] as TextBox;
            tb.IsEnabled = !tb.IsEnabled;
            if (!tb.IsEnabled)
            {
                var rowIdLabel = parent.Children[2] as Label;
                if (rowIdLabel != null)
                {
                    var rowId = Guid.Parse(rowIdLabel.Content.ToString());
                    var currentrow = _boardDataContext.Rows.FirstOrDefault(r => r.RowID == rowId);
                    if (currentrow != null)
                    {
                        currentrow.RowContent =Encoding.ASCII.GetBytes(tb.Text);
                        _boardDataContext.Rows.Update(currentrow);
                        await _boardDataContext.SaveChangesAsync();
                    }
                }
            }
        }

        private void AddColumnBttn_Click(object sender, RoutedEventArgs e)
        {
            var card = new Card
            {
                CardName = "",
                BoardID = _context.BoardID
            };
            _boardDataContext.Cards.Add(card);
            _boardDataContext.SaveChanges();
        }

        private void CardNametb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var parent = (sender as Label).Parent as Grid;
            var tb = parent.Children[1] as TextBox;
            tb.IsEnabled = !tb.IsEnabled;
            if (!tb.IsEnabled)
            {
                var cardIdLabel = parent.Children[0] as Label;
                if (cardIdLabel != null)
                {
                    var cardId = Guid.Parse(cardIdLabel.Content.ToString());
                    var card = _boardDataContext.Cards.FirstOrDefault(c => c.CardID == cardId);
                    if (card != null)
                    {
                        card.CardName = tb.Text;
                        _boardDataContext.Cards.Update(card);
                        _boardDataContext.SaveChanges();
                        
                    }
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                _boardDataContext.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var cards = _boardDataContext.Cards.AsNoTracking().Where(x => x.BoardID == _context.BoardID).ToList();
                foreach (var card in cards)
                {
                    card.Rows = _boardDataContext.Rows.AsNoTracking().Where(c => c.CardId == card.CardID).ToList();
                }
                KanbanBoardItemsControl.ItemsSource = cards;
                
            }
        }

        private async void AddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваше Изображение|*.jpg;*.jpeg;*.png";
            var card = (sender as Button).DataContext as Card;
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                image = File.ReadAllBytes(imagePath);
            }
            var currentrow = new Row
            {
                CardId = card.CardID,
                RowType = "picture",
                RowContent = image
            };
            _boardDataContext.Rows.Add(currentrow);
            await _boardDataContext.SaveChangesAsync();
        }

        private async void AddText_Click(object sender, RoutedEventArgs e)
        {
            var card = (sender as Button).DataContext as Card;
            if (card != null)
            {
                var currentrow = new Row
                {
                    CardId = card.CardID,
                    RowType = "Text",
                    RowContent = Encoding.ASCII.GetBytes("")
                };
                _boardDataContext.Rows.Add(currentrow);
                await _boardDataContext.SaveChangesAsync();
            }
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}