using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_tree_funcionality.Models
{
    public class Data
    {
        public string channel { get; set; }
        public string method { get; set; }

        public string path { get; set; }
        public Availability availability { get; set; }
        public Config config { get; set; }
    }
    public class Include
    {
        public string weekday { get; set; }
        public string from_hour { get; set; }
        public string to_hour { get; set; }
    }
    public class Message
    {
        public string title { get; set; }
        public object detail { get; set; }
    }
    public class Config
    {
        public Security security { get; set; }

    }
    public class BusinessHours
    {
        public bool includes_holidays { get; set; }
        public List<Include> includes { get; set; }
        public Message message { get; set; }
    }
    public class Security
    {
        public string scope_level { get; set; }
    }
    public class Availability
    {
        public BusinessHours business_hours { get; set; }
    }
}
