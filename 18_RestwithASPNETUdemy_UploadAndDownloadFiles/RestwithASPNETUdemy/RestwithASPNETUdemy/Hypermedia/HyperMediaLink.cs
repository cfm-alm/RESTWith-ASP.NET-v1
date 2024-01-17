using System.Text;

namespace RestwithASPNETUdemy.Hypermedia
{
    public class HyperMediaLink
    {
        public string href;

        public string Rel { get; set; }
        public string Href { 
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();

                }
            }
            set
            {
                href = value;
            }
        } // quando tem uma barra na url, o .NET converte ela para %2f, o link funciona, mas fica estranho
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
