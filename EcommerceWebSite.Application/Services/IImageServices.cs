using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
    public interface IImageServices
    {
        Task<ImageDTO> CreateAsync(string name,int pid);
        Task<List<ImageDTO>> ProductImages(int pid);
    }
}
