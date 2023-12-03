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
    /// Interaction logic for UserInformations.xaml
    /// </summary>
    public partial class UserInformations : Page
    {
        public TSalarie Salarie { get; set; }
        public UserInformations(TSalarie salarie)
        {
            InitializeComponent();
            Salarie = salarie;
            InitializeUserData();
        }

        private void InitializeUserData()
        {
            // Remplacez les valeurs ci-dessous par les données de l'utilisateur réelles
            NomTextBlock.Text = Salarie.Nom;
            PrenomTextBlock.Text = Salarie.Prenom;
            TelephoneFixeTextBlock.Text = Salarie.TelephoneFixe;
            TelephoneMobileTextBlock.Text = Salarie.TelephoneMobile;
            EmailTextBlock.Text = Salarie.Email;
            ServiceTextBlock.Text = Salarie.RefService.ToString();
            SiteTextBlock.Text = Salarie.RefSite.ToString();
        }
    }
}
