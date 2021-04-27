/***********************************************************************
 * Module:  Lek.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Lek
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
    public class Lek
    {
        public String IdLeka { get; set; }
        public String ImeLeka { get; set; }

        public List<Sastojak> ListaSastojaka { get; set; }
        public List<Lek> ListaZamenaZaLek { get; set; }


        public Lek() { }

        public Lek(String id,String ime)
        {
            IdLeka = id;
            ImeLeka = ime;
        }

        public static explicit operator Lek(int v)
        {
            throw new NotImplementedException();
        }
    }
}