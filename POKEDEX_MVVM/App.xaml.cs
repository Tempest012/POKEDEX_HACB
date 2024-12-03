using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POKEDEX_MVVM.Vista;
using POKEDEX_MVVM.Vista.Pokemon;

namespace POKEDEX_MVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaPokemon());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
