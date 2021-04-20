/***********************************************************************
 * Module:  Karton.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Karton
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class Karton
    {
        public String NazivZdravstveneUstanove { get; set; }
        public String OdeljenjeNaPrijemu { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String ImeRoditelja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Pol Pol { get; set; }
        public String Telefon { get; set; }
        public String BrojKartona { get; set; }
        public BracniStatusE BracniStatus { get; set; }
        
        public Pacijent pacijent { get; set; }
        public Anamneza Anamneza { get; set; }

        public AdresaStanovanja adresaStanovanja { get; set; }
        public List<Recept> recepti { get; set; }

        public Karton()
        {
            Anamneza = new Anamneza();
            recepti=new List<Recept>();
        }
        public Karton(String odeljenje, String ime, String prezime, String imeRoditelja, DateTime datumRodjenja, Pol pol, String telefon, String brojKartona, BracniStatusE bracniStatus, Anamneza anamneza)
        {
            OdeljenjeNaPrijemu = odeljenje;
            Ime = ime;
            Prezime = prezime;
            ImeRoditelja = imeRoditelja;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            Telefon = telefon;
            BrojKartona = brojKartona;
            BracniStatus = bracniStatus;
            Anamneza = anamneza;
            recepti = new List<Recept>();

        }

        ///// <pdGenerated>default getter</pdGenerated>
        //public System.Collections.ArrayList GetRecept()
        //{
        //    if (recept == null)
        //        recept = new System.Collections.ArrayList();
        //    return recept;
        //}

        ///// <pdGenerated>default setter</pdGenerated>
        //public void SetRecept(System.Collections.ArrayList newRecept)
        //{
        //    RemoveAllRecept();
        //    foreach (Recept oRecept in newRecept)
        //        AddRecept(oRecept);
        //}

        ///// <pdGenerated>default Add</pdGenerated>
        //public void AddRecept(Recept newRecept)
        //{
        //    if (newRecept == null)
        //        return;
        //    if (this.recept == null)
        //        this.recept = new System.Collections.ArrayList();
        //    if (!this.recept.Contains(newRecept))
        //        this.recept.Add(newRecept);
        //}

        ///// <pdGenerated>default Remove</pdGenerated>
        //public void RemoveRecept(Recept oldRecept)
        //{
        //    if (oldRecept == null)
        //        return;
        //    if (this.recept != null)
        //        if (this.recept.Contains(oldRecept))
        //            this.recept.Remove(oldRecept);
        //}

        ///// <pdGenerated>default removeAll</pdGenerated>
        //public void RemoveAllRecept()
        //{
        //    if (recept != null)
        //        recept.Clear();
        //}


    }
}