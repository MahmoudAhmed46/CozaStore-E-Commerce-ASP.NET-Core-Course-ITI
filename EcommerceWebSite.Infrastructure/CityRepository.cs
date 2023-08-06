using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastructure
{
    public class CityRepository : Reposatory<City, int>,ICityReposatory
    {
        private readonly SiteContext _context;

        public CityRepository(SiteContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<City>> GetAll()
        {
           return Task.FromResult( _context.Cities.ToList());
        }
    }
}
