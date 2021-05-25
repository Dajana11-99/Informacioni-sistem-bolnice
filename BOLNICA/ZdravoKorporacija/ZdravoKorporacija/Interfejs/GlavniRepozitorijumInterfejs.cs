using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ZdravoKorporacija.Interfejs
{
   public interface GlavniRepozitorijumInterfejs<T>
    {
        
            List<T> DobaviSve();

            T PretraziPoId(String obrazacPretrage);
          List<T> PretraziPoIdObjekta(String obrazacPretrage);

        T KonvertujCvorUObjekat(XmlNode cvor);

            List<T> KonvertujSveCvoroveUObjekte(XmlNodeList cvorovi);

            void Obrisi(String obrazacZaBrisanje);

            void Dodaj(T objekatZaDodavanje);
        
    }
}
