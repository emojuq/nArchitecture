using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
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

        //Tüm handlerlarımızı IRequestHandler ile bir listeye ekliyoruz. İstediği request ve response sınıflarını sırasıyla veriyoruz.
        //Böyle bir command sıraya koyulursa bu handlerve içindeki gerekli kodlar çalışacak diye belirtiyoruz.
        //Handler sınıfı istenilirse ayrı bir sınıfta da oluşturulabilinir.
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
           private readonly IBrandRepository _brandRepository;
           private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules= brandBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);


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