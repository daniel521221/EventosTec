﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosTec.Web.Models.ModelApi
{
    public class CityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slung { get; set; }
        public ICollection<EventResponse> Events { get; set; }
    }

}
