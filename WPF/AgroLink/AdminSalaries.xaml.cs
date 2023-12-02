using AgroLink.Interfaces;
using AgroLink.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using WpfNegosud.Services;

namespace AgroLink
{
    /// <summary>
    /// Interaction logic for AdminSalaries.xaml
    /// </summary>
    public partial class AdminSalaries : Page
    {
        public SalariesService _salaries { get; set; }
        public List<TSalarie> ListSalaries { get; set; }
        public AdminSalaries()
        {
            InitializeComponent();
            _salaries = new SalariesService();

            ListSalaries = _salaries.GetSalaries().Result;
            SalariesGrid.ItemsSource = ListSalaries;
        }

        private async void Salaries_AddItem(object sender, DataGridRowEditEndingEventArgs e)
        {
            TSalarie nouveauSalarie = e.Row.Item as TSalarie;
            if (nouveauSalarie != null)
            {
                if
                (
                    nouveauSalarie.Nom == null ||
                    nouveauSalarie.Prenom == null ||
                    nouveauSalarie.TelephoneFixe == null ||
                    nouveauSalarie.TelephoneMobile == null ||
                    nouveauSalarie.Email == null ||
                    nouveauSalarie.RefService == null ||
                    nouveauSalarie.RefSite == null ||
                    nouveauSalarie.RefRole == null
                )
                {
                    return;
                }
                if (e.EditAction == DataGridEditAction.Commit && !e.Row.IsNewItem)
                {

                    //Si en édition 
                    await _salaries.UpdateSalarie(nouveauSalarie);
                    Task<List<TSalarie>> listSalaries = _salaries.GetSalaries();
                    SalariesGrid.ItemsSource = await listSalaries;
                    SalariesGrid.Items.Refresh();
                }
                else
                {
                    //Si en création
                    await _salaries.AddSalarie(nouveauSalarie);
                    Task<List<TSalarie>> listSalaries = _salaries.GetSalaries();
                    SalariesGrid.ItemsSource = await listSalaries;
                    SalariesGrid.Items.Refresh();
                }
            }
        }
        /// <summary>
        /// Supprime un salarié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteSalarie(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).Tag;
            await _salaries.DeleteSalarie(Id);
            Task<List<TSalarie>> listSalaries = _salaries.GetSalaries();
            SalariesGrid.ItemsSource = await listSalaries;
            SalariesGrid.Items.Refresh();
        }
    }
}
