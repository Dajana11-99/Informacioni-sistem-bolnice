using System;

namespace Model
{
    public class StatickaOprema
    {
        public String Id { get; set; }
        public int kolicina { get; set; }
        public string naziv { get; set; }
        public StatickaOprema(string id)
        {
            this.Id = id;
        }


        public StatickaOprema() { }
    }

}
