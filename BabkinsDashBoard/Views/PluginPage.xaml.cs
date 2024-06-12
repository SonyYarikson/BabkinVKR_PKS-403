using System.Linq;
using System.Windows.Controls;
using PluginLoaderLib;

namespace BabkinsDashBoard.Views
{
    /// <summary>
    /// Логика взаимодействия для PluginPage.xaml
    /// </summary>
    public partial class PluginPage : Page
    {
        public PluginPage()
        {
            InitializeComponent();
            PluginListDG.ItemsSource = PluginLoader.Plugins;
        }
    }
}
