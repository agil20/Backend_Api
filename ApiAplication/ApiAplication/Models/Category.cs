﻿using ApiAplication.Dtos.ProductDtos;

namespace ApiAplication.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
