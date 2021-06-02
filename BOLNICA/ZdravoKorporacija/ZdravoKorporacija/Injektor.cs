using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.GrafZavisnosti
{
    public class Injektor
    {
        Dictionary<string, object> registrovaneKomponente = new Dictionary<string, object>();


        private static Injektor instance;

        public static Injektor Instance
        {
            get { 
                   if (instance == null)
                {
                    instance = new Injektor();
                }    
                return instance; 
            
            }
            private set { instance = value; }
        }

        private Injektor()
        {

        }

        public T Get<T>(Type interfejsZavisnosti)
        {
            if(!interfejsZavisnosti.IsInterface)
            {
                throw new ArgumentException($"Graf zavisnosti se, postovajuci SOLID principe, moze razresiti samo navodjenjem interfejsa kompoonente, sa kojim se ona registruje");
            }
            string key = interfejsZavisnosti.AssemblyQualifiedName;

            if (!registrovaneKomponente.ContainsKey(key))
            {
                throw new ArgumentException($"tip ${key} nije registrovan, registrovati ga prvo putem Get");
            }

            return (T)registrovaneKomponente[key];
        }

        public Injektor Add(Type interfejsZavinosti, Type komponenta)
        {
            if (!interfejsZavinosti.IsInterface)
            {
                throw new ArgumentException($"Graf zavisnosti se, postovajuci SOLID principe, moze razresiti samo navodjenjem interfejsa kompoonente, sa kojim se ona registruje");
            }
            string key = interfejsZavinosti.AssemblyQualifiedName;

            bool implementiranInterfejs = komponenta.GetInterfaces().Contains(interfejsZavinosti);
            if (!implementiranInterfejs)
            {
                throw new ArgumentException($"Graf zavisnosti se, postovajuci SOLID principe, ne dozvoljava da se komponenta doda u graf zavisnosti bez da implementira svoj interfejs koji izdvaja samo njene korisne metode: {komponenta.Name} mora implementirati interfejs {interfejsZavinosti.Name}");
            }
            if (registrovaneKomponente.ContainsKey(key))
            {
                throw new ArgumentException($"tip ${key} je vec registrovan, ne mozete ga registrovati dva puta");
            }
            object instance = Activator.CreateInstance(komponenta);
            registrovaneKomponente[key] = instance;
            return this;
        }
    }
}
