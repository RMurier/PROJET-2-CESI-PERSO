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
using System.Windows.Shapes;

namespace AgroLink
{
    public partial class DemandeMotDePasse : Window
    {
        public string MotDePasse { get; private set; }

        public DemandeMotDePasse()
        {
            InitializeComponent();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            MotDePasse = MotDePasseBox.Password;

            // Exemple : Vérification basique, remplacez par votre propre logique de vérification
            if (MotDePasse == "AgroLink2023")
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Mot de passe incorrect. Veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
