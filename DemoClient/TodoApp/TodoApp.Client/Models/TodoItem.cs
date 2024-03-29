﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Client.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
