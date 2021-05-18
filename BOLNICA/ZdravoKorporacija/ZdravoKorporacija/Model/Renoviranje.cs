using System;
using System.Collections.Generic;

namespace Model
{
    public class Renoviranje
    {
        public string Id { get; set; }
        public DateTime RenoviranjeOd { get; set; }
        public DateTime RenoviranjeDo { get; set; }
        public bool Spajanje { get; set; }
        public string NazivNovoSpojeneSale { get; set; }
        public Sala SalaZaSpajanje {get; set; }
        public bool Razdvajanje { get; set; }
        public string NazivPrveNoveSale { get; set; }
        public string NazivDrugeNoveSale { get; set; }
        public Renoviranje() { }
    }
}
