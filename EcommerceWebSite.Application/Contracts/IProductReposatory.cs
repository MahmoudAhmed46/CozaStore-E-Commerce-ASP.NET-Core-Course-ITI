﻿using EcommerceWebSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Contracts
{
    public interface IProductReposatory:IReposatory<Product,int>
    {
    }
}