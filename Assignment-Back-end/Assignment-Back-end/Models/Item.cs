using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Back_end.Models
{
   public class Item
   {
      [Key]
      public int ItemId { get; set; }

      [Column(TypeName = "nvarchar(100)" )]
      public string ItemName { get; set; }

      [Column(TypeName = "nvarchar(300)")]
      public string Description { get; set; }

      [Range(0, int.MaxValue, ErrorMessage = "Please enter an appropriate price")]
      public int ItemPrice { get; set; }

      [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid Quantity")]
      public int ItemQuantity { get; set; }

   }
}
