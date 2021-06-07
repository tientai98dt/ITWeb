﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CategoryFeedbackID { get; set; }
        public virtual CategoryFeedback CategoryFeedback { get; set; }
    }
}
