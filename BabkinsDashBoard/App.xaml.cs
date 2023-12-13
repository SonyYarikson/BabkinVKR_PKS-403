using Models.DataContext;
using Models.Repositories.RepositoryImpl;
using Models.Services.Implementation;
using Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BabkinsDashBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DashBoardDataContext DbContext = new DashBoardContextDesignTimeFactory().CreateDbContext(new string[] { "" });
        public static IAuthoriseService AuthoriseService = new AuthoriseService(new UserRepository(DbContext));
    }
}
