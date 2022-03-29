﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Car.Manager
{
    internal class BrandManager
    {
        Brand[] data = new Brand[0];

        public void Add(Brand entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void Remove(Brand entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
                return;
            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
                Array.Resize(ref data, data.Length - 1);
        }
        //public Brand GetbyId(int id)
        //{

        //}
        public void Edit(Brand entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
                return;
            data[index] = entity;
        }
        public Brand[] GetAll()
        {
            return data;
        }
    }
}
