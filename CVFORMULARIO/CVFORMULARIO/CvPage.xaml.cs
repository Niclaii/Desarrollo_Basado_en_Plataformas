// CvPage.xaml.cs
using Microsoft.Maui.Controls;

namespace CVFORMULARIO
{
    public partial class CvPage : ContentPage
    {
        public CvPage(CurriculumVitae cv)
        {
            InitializeComponent();
            nombreLabel.Text = cv.Nombre;
            experienciaLabel.Text = cv.Experiencia;
            idiomaLabel.Text = cv.Idioma;
            aptitudLabel.Text = cv.Aptitud;
            habilidadLabel.Text = cv.Habilidad;
            interesLabel.Text = cv.Interés;

            // Asigna los demás campos aquí
        }
    }
}
