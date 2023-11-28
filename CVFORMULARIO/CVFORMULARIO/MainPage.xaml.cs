// MainPage.xaml.cs
using System;
using Microsoft.Maui.Controls;

namespace CVFORMULARIO
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCrearCvClicked(object sender, EventArgs e)
        {
            var cv = new CurriculumVitae
            {
                Nombre = nombreEntry.Text,
                Experiencia = experienciaEntry.Text,
                Idioma = idiomaEntry.Text,
                Aptitud = aptitudEntry.Text,
                Habilidad = habilidadEntry.Text,
                Interés = interesEntry.Text

                // Asigna el resto de los campos aquí
            };

            // Navega a una nueva página para mostrar el CV
            await Navigation.PushAsync(new CvPage(cv));
        }
    }

    public class CurriculumVitae
    {
        public string Nombre { get; set; }
        public string Experiencia { get; set; }
        public string Idioma { get; set; }
        public string Aptitud { get; set; }
        public string Habilidad { get; set; }
        public string Interés { get; set; }

        // Otros campos...
    }
}
