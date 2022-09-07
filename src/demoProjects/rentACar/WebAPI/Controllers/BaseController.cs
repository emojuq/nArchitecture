using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

        //Bir base controller oluştuuryoruz.Çünkü aslında tüm controllerlarda mediator kullanıcağız.Bu da sürekli oluşturulacak ve kontorl edilemeyeceği için bir şartlandırma koyuyoruz
        // Ve bu şekilde mediator nesnesi varsa yenisi oluşturulmuyor.
    }
}
