﻿using Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Commands
{
    public class GetOrdersByStatusResponse
    {
        [JsonProperty("orders")]
        public IEnumerable<OrderModel> Orders { get; set; }
    }
}