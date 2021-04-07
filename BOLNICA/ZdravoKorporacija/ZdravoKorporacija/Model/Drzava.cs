/***********************************************************************
 * Module:  Drzava.cs
 * Author:  dajan
 * Purpose: Definition of the Class Model.Drzava
 ***********************************************************************/

using System;

namespace Model
{
    public class Drzava
    {
        public String NazivDrzave;
        public String Skracenica;

        public System.Collections.ArrayList mesto;

        public Drzava() { }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetMesto()
        {
            if (mesto == null)
                mesto = new System.Collections.ArrayList();
            return mesto;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetMesto(System.Collections.ArrayList newMesto)
        {
            RemoveAllMesto();
            foreach (Mesto oMesto in newMesto)
                AddMesto(oMesto);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddMesto(Mesto newMesto)
        {
            if (newMesto == null)
                return;
            if (this.mesto == null)
                this.mesto = new System.Collections.ArrayList();
            if (!this.mesto.Contains(newMesto))
            {
                this.mesto.Add(newMesto);
                newMesto.SetDrzava(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveMesto(Mesto oldMesto)
        {
            if (oldMesto == null)
                return;
            if (this.mesto != null)
                if (this.mesto.Contains(oldMesto))
                {
                    this.mesto.Remove(oldMesto);
                    oldMesto.SetDrzava((Drzava)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllMesto()
        {
            if (mesto != null)
            {
                System.Collections.ArrayList tmpMesto = new System.Collections.ArrayList();
                foreach (Mesto oldMesto in mesto)
                    tmpMesto.Add(oldMesto);
                mesto.Clear();
                foreach (Mesto oldMesto in tmpMesto)
                    oldMesto.SetDrzava((Drzava)null);
                tmpMesto.Clear();
            }
        }

    }
}