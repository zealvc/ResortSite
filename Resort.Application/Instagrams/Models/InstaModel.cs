using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Instagrams.Models
{
    public class InstaModel
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        //public IFormFile filePayload;
        public string ImageUrl { get; set; }
    }
}
