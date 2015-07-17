using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    class Persoon
    {
        string voornaam;
        string tussenvoegsels;
        string achternaam;
        string initialen;
        public delegate String GetNaamMethod();
    }
}
