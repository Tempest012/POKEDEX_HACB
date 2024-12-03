using POKEDEX_MVVM.Datos;
using POKEDEX_MVVM.Modelo;
using POKEDEX_MVVM.Vista.Pokemon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace POKEDEX_MVVM.VistaModelo.VMpokemon
{
    public class VMlistapokemoncs : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<Mpokemon> _listaPokemons;
        Mpokemon _PokemonSeleccionado;
        #endregion
        #region CONSTRUCTOR
        public VMlistapokemoncs(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPokemons();
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public ObservableCollection<Mpokemon> ListaPokemons
        {
            get { return _listaPokemons; }
            set
            {
                SetValue(ref _listaPokemons, value);
                OnpropertyChanged();
            }
        }
        public Mpokemon PokemonSeleccionado
        {
            get { return _PokemonSeleccionado; }
            set
            {
                if (_PokemonSeleccionado != value)
                {
                    _PokemonSeleccionado = value;
                }
            }
        }
        #endregion
        #region PROCESOS
        public async Task MostrarPokemons()
        {
            var funcion = new Dpokemon();
            ListaPokemons = await funcion.MostrarPokemons();
        }
        public async Task IrARegistro()
        {
            await Navigation.PushAsync(new Registarpokemon());
        }
        public void ProcesoSimple()
        {

        }
        public async Task AbrirVistaModificar()
        {
            await Navigation.PushAsync(new Modificar(PokemonSeleccionado));
        }
        #endregion
        #region COMANDOS
        public ICommand IrARegistrocommand => new Command(async () => await IrARegistro());
        public ICommand AbrirVistaModificarcommand => new Command(async () => await AbrirVistaModificar());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion

    }
}
