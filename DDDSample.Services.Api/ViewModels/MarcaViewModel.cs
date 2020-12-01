using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.Services.Api.ViewModels
{
    public class MarcaViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public MarcaViewModel(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
