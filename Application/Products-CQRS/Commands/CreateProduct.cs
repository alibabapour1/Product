using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.Commands
{
    public class CreateProduct : IRequest<Products>
    {
        public bool IsAvilable { get; set; }
        public string ManufactureEmail { get; set; } = string.Empty;
        public string ManufacturePhone { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;


        

    }
}
