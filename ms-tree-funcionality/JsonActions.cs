using ms_tree_funcionality.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ms_tree_funcionality
{
    public class JsonActions
    {
        public Root Getdata(string file)
        {
            var datajson = File.ReadAllText(file);

            try

            {
                
              var list = JsonConvert.DeserializeObject<Root>(datajson);
                
               
                return list;
            }
            catch (Exception )
            {
                throw;
            }


        }



    }


}
