using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.Services.Api.ViewModels
{
    public class VersionViewModel
    {
        public int ModelID { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public VersionViewModel(int modelid, int id, string name)
        {
            ModelID = modelid;
            ID = id;
            Name = name;

        }
    }
}
