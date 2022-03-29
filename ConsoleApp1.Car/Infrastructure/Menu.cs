using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Car.Infrastructure
{
    internal enum Menu : byte
    {
        BrandAdd = 1,
        BrandEdit,
        BrandRemove,
        BrandSingle,
        BrandsAll,

        ModelAdd,
        ModelEdit,
        ModelRemove,
        ModelSingle,
        ModelsAll,

        CarsAdd,
        CarsEdit,
        CarsRemove,
        CarsSingle,
        CarsAll,
        Exit
    }
}
