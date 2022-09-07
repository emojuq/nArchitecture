using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Dtos
{
    public class CreatedBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Bu Dto sayesinde Brand database'imizden sadece id ve name'i göstererek diğer kolonları göstermemiş oluyoruz
}
