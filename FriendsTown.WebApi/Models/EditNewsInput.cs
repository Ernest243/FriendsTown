﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTown.WebApi.Models
{
    public class EditNewsInput
    {
        [Required(ErrorMessage="The id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Description is required")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage ="Description must have between 10 and 100 characters")]
        public string Description { get; set; }
    }
}
