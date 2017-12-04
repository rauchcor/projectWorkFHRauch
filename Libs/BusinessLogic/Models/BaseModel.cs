using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.Models
{
    public abstract class BaseModel
    {
        public object Id { get; set; }
    }
}
