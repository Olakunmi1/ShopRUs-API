﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.Helpers
{
    //Outer face Api Response ----
    public class APIGenericResponseDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; } 
        public T Results { get; set; }
    }
}
