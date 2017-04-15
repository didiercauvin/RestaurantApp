using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Domain
{
    public class UserProposedRestaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime ProposedDate { get; set; }
    }
}
