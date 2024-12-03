using System;
using System.Collections.Generic;
using System.Text;
using POKEDEX_MVVM.Modelo;
using POKEDEX_MVVM.Conexion;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using Firebase.Database;
using POKEDEX_MVVM.Vista.Pokemon;

namespace POKEDEX_MVVM.Datos
{
     public class Dpokemon
    {//Alopez3535
        public async Task Insertarpokemon(Mpokemon parametros)
        {
            await Conexionn.firebase
                  .Child("Pokemon")
                  .PostAsync(new Mpokemon()
                  {
                      IdPokemonId = Guid.NewGuid(),
                      ColorFondo = parametros.ColorFondo,
                      Colorpoder = parametros.Colorpoder,
                      Icono = parametros.Icono,
                      Nombre = parametros.Nombre,
                      NroOrden = parametros.NroOrden,
                      Poder = parametros.Poder,
                  }
                  );
        }
        public async Task<ObservableCollection<Mpokemon>> MostrarPokemon()
        {

            //return (await Conexionn.firebase
            //    .Child("Pokemon")
            //    .OnceAsync<Mpokemon>())
            //    .Select(item => new Mpokemon
            //    {
            //        IdPokemon = item.Key,
            //        Nombre = item.Object.Nombre,
            //        ColorFondo = item.Object.ColorFondo,
            //        Colorpoder = item.Object.Colorpoder,
            //        Icono = item.Object.Icono,
            //        NroOrden = item.Object.NroOrden,
            //        Poder = item.Object.Poder,

            //    }).ToList();



             var data = await Task.Run(() => Conexionn.firebase
             .Child("Pokemon")
            .AsObservable<Mpokemon>()
            .AsObservableCollection());
            return data;

        }


        //public async Task<int> DeleteItemAsync(ToDoItem item)
        //{ 

        //    return await Connnection.DeleteAsync()

        //}

        //public async Task EditarPokemon(Mpokemon datosActualizados)
        //{
        //    var actualizar = (await Conexionn.firebase
        //        .Child("Pokemon")
        //        .OnceAsync<Mpokemon>())
        //        .Where(a => a.Object.IdPokemon == datosActualizados.IdPokemon).FirstOrDefault();

        //    await Conexionn.firebase
        //    .Child("Pkemon")
        //    .Child(actualizar.Key)
        //    .PutAsync(new Mpokemon()
        //    {
        //        IdPokemon = datosActualizados.IdPokemon,
        //        ColorFondo = datosActualizados.ColorFondo,
        //        Colorpoder = datosActualizados.Colorpoder,
        //        NroOrden = datosActualizados.NroOrden,
        //        Icono = datosActualizados.Icono,
        //        Nombre = datosActualizados.Nombre,
        //        Poder = datosActualizados.Poder,



        //    });
        //}


        public async Task ModificarPokemon(Mpokemon datosActualizados)
        {
            var actualizar = (await Conexionn.firebase
               .Child("Pokemon")
               .OnceAsync<Mpokemon>())
               .Where(a => a.Object.IdPokemonId == datosActualizados.IdPokemonId).FirstOrDefault();

            await Conexionn.firebase
                .Child("Pokemon")
                .Child(actualizar.Key)
                .PutAsync(new Mpokemon()
                {
                    IdPokemonId = datosActualizados.IdPokemonId,
                    ColorFondo = datosActualizados.ColorFondo,
                    Colorpoder = datosActualizados.Colorpoder,
                    NroOrden = datosActualizados.NroOrden,
                    Icono = datosActualizados.Icono,
                    Nombre = datosActualizados.Nombre,
                    Poder = datosActualizados.Poder
                });
        }

        public async Task BorrarPokemon(Guid idPokemon)
        {
            var pokemonABorrar = (await Conexionn.firebase
                .Child("Pokemon")
                .OnceAsync<Mpokemon>()).Where(a => a.Object.IdPokemonId == idPokemon).FirstOrDefault();

            await Conexionn.firebase.Child("Pokemon").Child(pokemonABorrar.Key).DeleteAsync();
        }
        public async Task<ObservableCollection<Mpokemon>> MostrarPokemons()
        {
            //return (await CConexion.firebase
            //    .Child("Pokemon")
            //    .OnceAsync<MPokemon>())
            //    .Select(item => new MPokemon
            //    {
            //        IdPokemon = item.Key,
            //        Nombre = item.Object.Nombre,
            //        ColorFondo = item.Object.ColorFondo,
            //        ColorPoder = item.Object.ColorPoder,
            //        Icono = item.Object.Icono,
            //        NroOrden = item.Object.NroOrden,
            //        Poder = item.Object.Poder
            //    }).ToList();

            var data = await Task.Run(() => Conexionn.firebase
                .Child("Pokemon")
                .AsObservable<Mpokemon>()
                .AsObservableCollection());
            return data;
        }
    }
}
