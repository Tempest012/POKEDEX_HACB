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
    internal class VMresgistropokemon : BaseViewModel
    {

        #region VARIABLES
        string _Txtcolorfondo;
        string _Txtcolorpoder;
        string _Txtnombre;
        string _Txtnro;
        string _Txtpoder;
        string _Txticono;
        #endregion
        #region CONTRUCTOR
        public VMresgistropokemon(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string TxtcolorFondo
        {
            get { return _Txtcolorfondo; }
            set { SetValue(ref _Txtcolorfondo, value); }
        }

        public string Txtcolorpoder
        {
            get { return _Txtcolorpoder; }
            set { SetValue(ref _Txtcolorpoder, value); }
        }

        public string Txtnombre
        {
            get { return _Txtnombre; }
            set { SetValue(ref _Txtnombre, value); }
        }

        public string Txtnro
        {
            get { return _Txtnro; }
            set { SetValue(ref _Txtnro, value); }
        }

        public string Txtpoder
        {
            get { return _Txtpoder; }
            set { SetValue(ref _Txtpoder, value); }
        }

        public string Txticono
        {
            get { return _Txticono; }
            set { SetValue(ref _Txticono, value); }
        }

        #endregion
        #region PROCESOS

        public async Task Insertar()
        {
            var funcion = new Dpokemon();
            var parametros = new Mpokemon();
            parametros.ColorFondo = _Txtcolorfondo;
            parametros.Colorpoder = _Txtcolorpoder;
            parametros.Icono = _Txticono;
            parametros.Nombre = _Txtnombre;
            parametros.NroOrden = _Txtnro;
            parametros.Poder = _Txtpoder;

            await funcion.Insertarpokemon(parametros);
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

        public ICommand Insertarcomand => new Command(async () => await Insertar());
        public ICommand Volvercomand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
