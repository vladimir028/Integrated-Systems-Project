﻿using Eshop.DomainEntities.PetAdoptionCenter.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DomainEntities.PetAdoptionCenter
{
    public class Pet : BaseEntity
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public PetType? PetType { get; set; }
        public string? Breed { get; set; }
        public string? Sex { get; set; }
        public string? Description { get; set; }
        public bool IsHouseTrained { get; set; }
        public string? FavouriteThings { get; set; }
        public string? HomeRequirements { get; set; }
        public string? PhotoUrl { get; set; }
        public PetStatus? PetStatus { get; set; }
        public string? ShelterId { get; set; }
        public int Price { get; set; } = 20;
        public PetAdoptionCenterUser? Shelter { get; set; }
    }
}
