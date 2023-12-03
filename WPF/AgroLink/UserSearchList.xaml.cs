using AgroLink.Models;
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

namespace AgroLink
{
    /// <summary>
    /// Interaction logic for UserSearchList.xaml
    /// </summary>
    public partial class UserSearchList : Page
    {
        private List<TSalarie> listeSalarie;

        public UserSearchList(List<TSalarie> salarieList)
        {
            InitializeComponent();
            listeSalarie = salarieList;

            salarieDataGrid.ItemsSource = listeSalarie;
        }

        private void OnSelectButtonClick(object sender, RoutedEventArgs e)
        {
            // Récupérez le salarié associé au bouton sélectionné
            Button button = (Button)sender;
            TSalarie selectedSalarie = (TSalarie)button.Tag;

            // Faites quelque chose avec le salarié sélectionné, par exemple, affichez un message
            NavigationService.Navigate(new UserInformations(selectedSalarie));
        }
    }
}
