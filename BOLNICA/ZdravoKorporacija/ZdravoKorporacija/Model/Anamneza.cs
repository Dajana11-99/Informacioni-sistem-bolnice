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
        public Anamneza()
        {
            Simptomi = "";
            IzvestajLekara = "";
        }
        public Anamneza(String simptomi, String izvestajLekara)
        {
            Simptomi = simptomi == null ? "" : simptomi;
            IzvestajLekara = izvestajLekara == null ? "" : izvestajLekara;
        }
    }
}
