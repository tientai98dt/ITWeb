using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{
    public class CategoryFeedback
    {
        [Key]
        public int CategoryFeedbackID { get; set; }
        public string CategoryFeedbackName { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
