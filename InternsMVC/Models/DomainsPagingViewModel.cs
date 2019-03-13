﻿using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Models
{
    public class DomainsPagingViewModel
    {
        public IEnumerable<Domain> Domains { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}