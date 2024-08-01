using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.AboutDtos
{
    public class CreateAboutDto
    {
        //ID otomatik geleceği için ona gerek yok
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
