using POKEDEX_MVVM.Datos;
using POKEDEX_MVVM.Modelo;
using POKEDEX_MVVM.Vista.Pokemon;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace POKEDEX_MVVM.VistaModelo.VMpokemon
{
    public class VMdetallesPokemon : BaseViewModel
    {

        #region VARIABLES
        string _Texto;
        string _ColorFondo;
        string _Colorpoder;
        string _Icono;
        string _Nombre;
        string _NroOrden;
        string _Poder;
        string _IdPokemon;
        Mpokemon _SelecionarPokemon;
        public Mpokemon parametrosRecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMdetallesPokemon(INavigation navigation, Mpokemon parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
        }

        public VMdetallesPokemon(Mpokemon selecionarPokemon, INavigation navigation)
        {

            Navigation = navigation;

            _ColorFondo = selecionarPokemon.ColorFondo.ToString();
            _ColorFondo = selecionarPokemon.Colorpoder.ToString();
            _Icono = selecionarPokemon.Icono.ToString();
            _Nombre = selecionarPokemon.Nombre.ToString();
            _NroOrden = selecionarPokemon.NroOrden.ToString();
            _Poder = selecionarPokemon.Poder.ToString();
            _SelecionarPokemon = selecionarPokemon;



        }



        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }

        public string ColorFondo
        {
            get { return _ColorFondo; }
            set { SetValue(ref _ColorFondo, value); }
        }
        public string ColorPoder
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
        public Mpokemon SelecionarPokemon
        {
            get { return _SelecionarPokemon; }
            set { SetValue(ref _SelecionarPokemon, value); }
        }


        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }

        public async Task ModificarPokemon()
        {
            var funcion = new Dpokemon();
            SelecionarPokemon.Nombre = Nombre;
            SelecionarPokemon.Poder = Poder;
            SelecionarPokemon.NroOrden = NroOrden;
            SelecionarPokemon.Icono = Icono;
            SelecionarPokemon.ColorFondo = ColorFondo;
            SelecionarPokemon.Colorpoder = ColorPoder;
            await funcion.ModificarPokemon(SelecionarPokemon);
            await Volver();

        }
        public async Task EliminarPokemon()
        {
            /* var funcion = new Dpokemon();
             await funcion.BorrarPokemon(SelecionarPokemon.IdPokemon);
             await DisplayAlert("Eliminado", $"El Pókemon {SelecionarPokemon.Nombre} ah sido eliminado", "OK");
             await Volver();*/
        }


        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new Registarpokemon());

        }

        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);

        public ICommand ModificarPokemoncomand => new Command(async () => await ModificarPokemon());
        public ICommand EliminarPokemoncomand => new Command(async () => await EliminarPokemon());
        public ICommand Iraregistrocommand => new Command(async () => await Iraregistro());


        //public ICommand EditarCommand => new  Command(async () => await EditarPokemon());
        #endregion
    }
}
