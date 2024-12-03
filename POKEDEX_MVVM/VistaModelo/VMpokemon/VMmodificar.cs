using POKEDEX_MVVM.Datos;
using POKEDEX_MVVM.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace POKEDEX_MVVM.VistaModelo.VMpokemon
{
    public class VMmodificar : BaseViewModel
    {
        #region VARIABLES
        string _ColorFondo;
        string _Colorpoder;
        string _Icono;
        string _Nombre;
        string _NroOrden;
        string _Poder;
        Mpokemon _PokeSeleccionado;
        #endregion
        #region CONSTRUCTOR
        public VMmodificar(Mpokemon pokeSeleccion, INavigation navigation)
        {
            Navigation = navigation;
            _ColorFondo = pokeSeleccion.ColorFondo.ToString();
            _Colorpoder = pokeSeleccion.Colorpoder.ToString();
            _Icono = pokeSeleccion.Icono.ToString();
            _Nombre = pokeSeleccion.Nombre.ToString();
            _NroOrden = pokeSeleccion.NroOrden.ToString();
            _Poder = pokeSeleccion.Poder.ToString();
            _PokeSeleccionado = pokeSeleccion;
        }
        #endregion
        #region OBJETOS
        public string ColorFondo
        {
            get { return _ColorFondo; }
            set { SetValue(ref _ColorFondo, value); }
        }
        public string Colorpoder
        {
            get { return _Colorpoder; }
            set { SetValue(ref _Colorpoder, value); }
        }
        public string Icono
        {
            get { return _Icono; }
            set { SetValue(ref _Icono, value); }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
        public string NroOrden
        {
            get { return _NroOrden; }
            set { SetValue(ref _NroOrden, value); }
        }
        public string Poder
        {
            get { return _Poder; }
            set { SetValue(ref _Poder, value); }
        }
        public Mpokemon PokeSeleccionado
        {
            get { return _PokeSeleccionado; }
            set { SetValue(ref _PokeSeleccionado, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ModificarPokemon()
        {
            var funcion = new Dpokemon();
            PokeSeleccionado.Nombre = Nombre;
            PokeSeleccionado.Poder = Poder;
            PokeSeleccionado.NroOrden = NroOrden;
            PokeSeleccionado.Icono = Icono;
            PokeSeleccionado.ColorFondo = ColorFondo;
            PokeSeleccionado.Colorpoder = Colorpoder;
            await funcion.ModificarPokemon(PokeSeleccionado);
            await Volver();
        }
        public async Task EliminarPokemon()
        {
            var funcion = new Dpokemon();
            await funcion.BorrarPokemon(PokeSeleccionado.IdPokemonId);
            await DisplayAlert("Eliminado", $"El Pókemon {PokeSeleccionado.Nombre} ah sido eliminado", "OK");
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand ModificarPokemoncomand => new Command(async () => await ModificarPokemon());
        public ICommand EliminarPokemoncomand => new Command(async () => await EliminarPokemon());
        #endregion



    }
}
