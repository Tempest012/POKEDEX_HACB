using POKEDEX_MVVM.Modelo;
using POKEDEX_MVVM.VistaModelo.VMpokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POKEDEX_MVVM.Vista.Pokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modificar : ContentPage
    {
        public Modificar(Mpokemon pokemon)
        {
            InitializeComponent();
            BindingContext = new VMmodificar(pokemon, Navigation);
        }
    }
}