/***********************************************************************
 * Module:  Lek.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Lek
 ***********************************************************************/

using System;

namespace Model
{
    public class Lek
    {
        public String IdLeka { get; set; }
        public String ImeLeka { get; set; }

        public Lek() { }

        public Lek(String id,String ime)
        {
            IdLeka = id;
            ImeLeka = ime;
        }

    }
}