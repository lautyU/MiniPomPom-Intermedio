using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_security_token.Models 
{
    public class InputBody 
    {
        public string  Method { get; set; }

        public string Channel { get; set; }
        public string Path { get; set; }
    }
}
