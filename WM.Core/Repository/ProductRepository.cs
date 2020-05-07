﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Entities;

namespace WM.Core.Repository
{
    public interface IProductRepository
    {
    }
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDBContext _storeDBContext;
        public ProductRepository(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }

    }
}
