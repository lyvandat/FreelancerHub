﻿using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.ServiceCategoryDtos
{
    public class GetServiceCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<string> Keys { get; set; } = null!;
        public string ServiceClassName { get; set; } = string.Empty;
        public bool IsActivated { get; set; }
        public int ServiceTypeCount { get; set; } = 0;
    }

    public class GetServiceCategoryWithChildDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<string> Keys { get; set; } = null!;
        public string ServiceClassName { get; set; } = string.Empty;
        public bool IsActivated { get; set; }
        public int ServiceTypeCount { get; set; } = 0;
        public ICollection<GetServiceTypeDto>? ServiceTypes { get; set; }
    }
}
