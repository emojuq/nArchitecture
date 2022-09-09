using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            var result = await Mediator.Send(createBrandCommand); // bu command geldiğinde mediator bununla berbaer
                                                                  // çalışan handlerı bulup işlemleri yaptıracak


            return Created("", result);//kullanıcıya geri dönüş olarak istersek tırnak içine api adresinide verebiliriz.
                                       //Result olarakta dto yani response için verilen bilgiler döner.
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest) // GET OPERASYONLARINDA QUERYDEN OKUDUGUMUZ İÇİN FROMQUERY
        {
            //İlk önce pagerequest olarak aldık sonrasında gelen sonucu getlistbrandqueye döndürdük..
            GetListBrandQuery getListBrandQuery = new() { pageRequest = pageRequest };
            BrandListModel result=await Mediator.Send(getListBrandQuery);
            return Ok(result);
           
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery) // direk url üzerinden okuma yapılacağı için fromroute
        {
            BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdBrandQuery);
            return Ok(brandGetByIdDto);
        } 

    }
}
