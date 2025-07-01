using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.domain
{
    public class OutboxMessage
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
        public DateTime OccurredOn { get; set; }
        public DateTime? ProcessedOn { get; set; }
    }
}