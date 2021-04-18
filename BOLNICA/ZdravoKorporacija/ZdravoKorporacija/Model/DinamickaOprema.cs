using System;

namespace Model
{
    public class DinamickaOprema
    {
        public String Id { get; set; }
        public int kolicina { get; set; }
        public string naziv { get; set; }
        public DinamickaOprema(string id)
        {
            this.Id = id;
        }


        public DinamickaOprema() { }
    }

}
