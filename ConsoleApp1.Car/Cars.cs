using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Car
{
    internal class Cars
    {
        static int counter = 0;
        public Cars()
        {
            this.Id = ++counter;
        }
        public int Id { get; private set; }

        public int ModelId { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public FuelType TypeFuel { get; set; }
        public enum FuelType : byte
        {
            Diesel = 1,
            Petrol,
            Gas,
            Hybrid,
            Hydrogen
        }
        public override string ToString()
        {
            return $"{Id}. ModelId: {ModelId} \n avtomobilin ili: {Year} \n avtomobilin qiymeti: {Price} \n " +
                $"avtomobilin rengi: {Color} \n avtomobilin muherriki: {Engine} " +
                $"\n avtomobilin yanacaq novu: {TypeFuel}";
        }
    }
}
