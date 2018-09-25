using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
  public class Feature
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<ProductFeature> ProductFeatures { get; set; } = new List<ProductFeature>();
  }
}