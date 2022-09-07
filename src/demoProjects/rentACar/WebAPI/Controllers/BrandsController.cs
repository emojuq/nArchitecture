using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
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
    }
}
