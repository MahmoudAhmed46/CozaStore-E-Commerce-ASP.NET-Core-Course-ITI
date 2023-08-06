using AutoMapper;
using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
    public class ImageServices : IImageServices
    {
        private readonly IMapper mapper;
        private readonly IImageReposatory imageRepo;

        public ImageServices(IMapper _Mapper, IImageReposatory _ImageRepo)
        {
            mapper = _Mapper;
            imageRepo = _ImageRepo;
        }
        public async Task<ImageDTO> CreateAsync(string name, int pid)
        {
            ImageDTO imageDTO = new ImageDTO()
            {
                Name = name,
                productId = pid

            };
            var image = mapper.Map<Image>(imageDTO);
           var res = await  imageRepo.CreateAsync(image);
            return mapper.Map<ImageDTO>(res); 
        }
        public async Task<List<ImageDTO>> ProductImages(int pid)
        {
            var img = await imageRepo.GetImagesByPrdId(pid);
            return mapper.Map<List<ImageDTO>>(img);
        }
    }

}
