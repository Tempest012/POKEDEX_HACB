using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace POKEDEX_MVVM.Conexion
{
    public class Conexionn
    {
        public static FirebaseClient firebase = new FirebaseClient("https://poke-mvvm-6ae65-default-rtdb.firebaseio.com/");
    }
}
