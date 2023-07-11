using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.Commands
{
    public class UpdateProduct : IRequest<Products>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string ManufactorEmail { get; set; }


    }
}
