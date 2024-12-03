using POKEDEX_MVVM.VistaModelo.VMpokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POKEDEX_MVVM.Vista.Pokemon;

namespace POKEDEX_MVVM.Vista.Pokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPokemon : ContentPage
    {
        public ListaPokemon()
        {
            InitializeComponent();
            BindingContext = new VMlistapokemoncs(Navigation);
        }
    }
}