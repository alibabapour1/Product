using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.Queries
{
    public class GetAllProducts :IRequest<ICollection<Products>>
    {
    }
}
