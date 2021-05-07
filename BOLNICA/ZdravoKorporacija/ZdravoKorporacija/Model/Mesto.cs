/***********************************************************************
 * Module:  Mesto.cs
 * Author:  dajan
 * Purpose: Definition of the Class Model.Mesto
 ***********************************************************************/

using System;

namespace Model
{
    public class Mesto
    {
        public String NazivMesta;
        public String PostanskiBroj;

     
        public System.Collections.ArrayList adresaStanovanja;
        public Mesto() { }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetAdresaStanovanja()
        {
            if (adresaStanovanja == null)
                adresaStanovanja = new System.Collections.ArrayList();
            return adresaStanovanja;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAdresaStanovanja(System.Collections.ArrayList newAdresaStanovanja)
        {
            RemoveAllAdresaStanovanja();
            foreach (AdresaStanovanja oAdresaStanovanja in newAdresaStanovanja)
                AddAdresaStanovanja(oAdresaStanovanja);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddAdresaStanovanja(AdresaStanovanja newAdresaStanovanja)
        {
            if (newAdresaStanovanja == null)
                return;
            if (this.adresaStanovanja == null)
                this.adresaStanovanja = new System.Collections.ArrayList();
            if (!this.adresaStanovanja.Contains(newAdresaStanovanja))
                this.adresaStanovanja.Add(newAdresaStanovanja);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAdresaStanovanja(AdresaStanovanja oldAdresaStanovanja)
        {
            if (oldAdresaStanovanja == null)
                return;
            if (this.adresaStanovanja != null)
                if (this.adresaStanovanja.Contains(oldAdresaStanovanja))
                    this.adresaStanovanja.Remove(oldAdresaStanovanja);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAdresaStanovanja()
        {
            if (adresaStanovanja != null)
                adresaStanovanja.Clear();
        }
        public Drzava drzava;

        /// <pdGenerated>default parent getter</pdGenerated>
        public Drzava GetDrzava()
        {
            return drzava;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDrzava</param>
        public void SetDrzava(Drzava newDrzava)
        {
            if (this.drzava != newDrzava)
            {
                if (this.drzava != null)
                {
                    Drzava oldDrzava = this.drzava;
                    this.drzava = null;
                    oldDrzava.RemoveMesto(this);
                }
                if (newDrzava != null)
                {
                    this.drzava = newDrzava;
                    this.drzava.AddMesto(this);
                }
            }
        }

    }
}