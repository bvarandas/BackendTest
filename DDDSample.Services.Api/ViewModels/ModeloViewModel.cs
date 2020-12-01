using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.Services.Api.ViewModels
{
    public class ModeloViewModel
    {
        public int MakeID { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public ModeloViewModel(int makeid, int id, string name)
        {
            MakeID = makeid;
            ID = id;
            Name = name;
        }
    }
}
