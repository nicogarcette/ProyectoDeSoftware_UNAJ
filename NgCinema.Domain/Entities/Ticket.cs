﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Domain.Entities
{
    public class Ticket
    {
        public Guid IdTicket { get; set; }
        public int IdFunction { get; set; }
        public string User { get; set; }
        public Function Function { get; set; }
    }
}
