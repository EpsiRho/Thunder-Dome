using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunder_Dome_Pro.Classes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Buy
    {
        public int display_priority { get; set; }
        public string logo_path { get; set; }
        public int provider_id { get; set; }
        public string provider_name { get; set; }
    }

    public class Rent
    {
        public int display_priority { get; set; }
        public string logo_path { get; set; }
        public int provider_id { get; set; }
        public string provider_name { get; set; }
    }

    public class AT
    {
        public string link { get; set; }
        public List<Buy> buy { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class Flatrate
    {
        public int display_priority { get; set; }
        public string logo_path { get; set; }
        public int provider_id { get; set; }
        public string provider_name { get; set; }
    }

    public class CA
    {
        public string link { get; set; }
        public List<Flatrate> flatrate { get; set; }
        public List<Rent> rent { get; set; }
        public List<Buy> buy { get; set; }
    }

    public class CH
    {
        public string link { get; set; }
        public List<Rent> rent { get; set; }
        public List<Buy> buy { get; set; }
    }

    public class DE
    {
        public string link { get; set; }
        public List<Buy> buy { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class DK
    {
        public string link { get; set; }
        public List<Flatrate> flatrate { get; set; }
        public List<Rent> rent { get; set; }
        public List<Buy> buy { get; set; }
    }

    public class FI
    {
        public string link { get; set; }
        public List<Rent> rent { get; set; }
        public List<Buy> buy { get; set; }
        public List<Flatrate> flatrate { get; set; }
    }

    public class FR
    {
        public string link { get; set; }
        public List<Buy> buy { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class Ad
    {
        public int display_priority { get; set; }
        public string logo_path { get; set; }
        public int provider_id { get; set; }
        public string provider_name { get; set; }
    }

    public class GB
    {
        public string link { get; set; }
        public List<Ad> ads { get; set; }
        public List<Buy> buy { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class IE
    {
        public string link { get; set; }
        public List<Buy> buy { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class KR
    {
        public string link { get; set; }
        public List<Flatrate> flatrate { get; set; }
        public List<Buy> buy { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class NL
    {
        public string link { get; set; }
        public List<Buy> buy { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class NO
    {
        public string link { get; set; }
        public List<Buy> buy { get; set; }
        public List<Flatrate> flatrate { get; set; }
        public List<Rent> rent { get; set; }
    }

    public class NZ
    {
        public string link { get; set; }
        public List<Rent> rent { get; set; }
        public List<Buy> buy { get; set; }
    }

    public class SE
    {
        public string link { get; set; }
        public List<Flatrate> flatrate { get; set; }
        public List<Rent> rent { get; set; }
        public List<Buy> buy { get; set; }
    }

    public class US
    {
        public string link { get; set; }
        public List<Rent> rent { get; set; }
        public List<Flatrate> flatrate { get; set; }
        public List<Buy> buy { get; set; }
    }

    public class Results
    {
        public AT AT { get; set; }
        public CA CA { get; set; }
        public CH CH { get; set; }
        public DE DE { get; set; }
        public DK DK { get; set; }
        public FI FI { get; set; }
        public FR FR { get; set; }
        public GB GB { get; set; }
        public IE IE { get; set; }
        public KR KR { get; set; }
        public NL NL { get; set; }
        public NO NO { get; set; }
        public NZ NZ { get; set; }
        public SE SE { get; set; }
        public US US { get; set; }
    }

    public class Providers
    {
        public int id { get; set; }
        public Results results { get; set; }
    }

}
