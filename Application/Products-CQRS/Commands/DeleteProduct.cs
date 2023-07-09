using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.Commands
{
    public class DeleteProduct:IRequest
    {
        public int Id { get; set; }
    }
}
