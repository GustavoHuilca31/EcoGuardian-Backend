using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest.Resources
{
    public record QuestionResource
    {

        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PlantId { get; set; }

        // For future Sprints This should also return some of the plant's data like the statistics in order for a better assessment of the question        
        
    }
}