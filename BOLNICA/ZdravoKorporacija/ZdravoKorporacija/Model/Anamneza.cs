/***********************************************************************
 * Module:  Anamneza.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Anamneza
 ***********************************************************************/

using System;

namespace Model
{
    public class Anamneza
    {
        public String Simptomi { get; set; }
        public String IzvestajLekara { get; set; }
        public String idPacijenta;

        public String IdPacijenta
        {
            get { return idPacijenta; }
        }
           

        public Anamneza()
        {
            Simptomi = "";
            IzvestajLekara = "";
            idPacijenta = "P1";
        }
        public Anamneza(String simptomi, String izvestajLekara)
        {
            Simptomi = simptomi == null ? "" : simptomi;
            IzvestajLekara = izvestajLekara == null ? "" : izvestajLekara;
        }
    }
}
