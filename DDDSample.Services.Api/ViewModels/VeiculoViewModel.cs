using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.Services.Api.ViewModels
{
    public class VeiculoViewModel
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public string KM { get; set; }
        public string Price { get; set; }
        public string YearModel { get; set; }
        public string YearFab { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        public VeiculoViewModel(int id, string make, string model, string version, string km, string price, string yearmodel, string yearfab, string color, string image)
        {
            ID = id;
            Make = make;
            Model = model;
            Version = version;
            KM = km;
            Price = price;
            YearModel = yearmodel;
            YearFab = yearfab;
            Color = color;
            Image = image;
        }
            
    }
}
