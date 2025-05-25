using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.V1.Models
{
    public class WarehouseCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
    }

    public class WarehouseEditModel
    {
        [Required, HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
    }
}