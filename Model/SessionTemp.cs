using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SessionTemp
    {
        public string fullUrl { get; set; }
        public string body { get; set; } 

        public Dictionary<string, string> headers { get; set; } = new Dictionary<string, string>();
    }
}
