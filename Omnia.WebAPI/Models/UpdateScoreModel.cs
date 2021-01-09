using System;
using System.ComponentModel.DataAnnotations;

namespace Omnia.WebAPI.Models
{
    public class UpdateScoreModel
    {
        [Required]
        public Guid? PlayerId { get; set; }
        [Required]
        public int? NewScore { get; set; }
    }
}
