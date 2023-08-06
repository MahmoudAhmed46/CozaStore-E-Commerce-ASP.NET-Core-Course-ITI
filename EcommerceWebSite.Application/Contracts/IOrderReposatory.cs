using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Contracts
{
    public interface IOrderReposatory:IReposatory<Order, int>
    {
    }
}
