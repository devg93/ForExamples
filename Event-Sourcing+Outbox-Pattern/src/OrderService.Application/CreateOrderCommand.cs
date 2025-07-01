using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace OrderService.Application
{
  public record CreateOrderCommand(string CustomerName, decimal Amount):IRequest<string>;
}