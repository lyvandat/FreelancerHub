namespace DeToiServer.Dtos.ServiceRequirementDtos
{
    public class PostServiceRequirementDto : PostServiceDto
    {
        public string AddressLine { get; set; } = string.Empty;
        public string CleanningType { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public bool HasPets { get; set; }
        public bool HasElectronics { get; set; }
        public bool FreelancerBringTools { get; set; }

        // --
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }

        // --
        // public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        // public double Price { get; set; }
        public string ShoppingItems { get; set; } = string.Empty;
        
    }
}
