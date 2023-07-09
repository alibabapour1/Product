using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.QueryHandler
{
    public class GetProdoctById :IRequest<Products>
    {
        public int Id { get; set; }
    }
}
