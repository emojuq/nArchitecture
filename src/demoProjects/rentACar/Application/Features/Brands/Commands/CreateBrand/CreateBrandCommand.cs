using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand:IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }


        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
           private readonly IBrandRepository _brandRepository;
           private readonly IMapper _mapper;

            
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand mappedBrand = _mapper.Map<Brand>(request); //gelen request brande çevrildi
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand); //veritabanına gidip ekledim,brand verdi.
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand); //mapleyerek branddto verdim

                return createdBrandDto;
            }
        }
    } 
}

//automapper 2 nesneyi birbirine eşleyen karmaşık koddan kurtulmak için oluşturulan basit bir kütüphanedir.
//Brand ve BrandDto gibi