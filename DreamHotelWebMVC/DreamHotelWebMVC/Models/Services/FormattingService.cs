using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebMVC.Models.Services
{
    public class FormattingService
    {
        public string AsReadableDate(DateTime date)
        {
            return date.ToString("ddd, MMMM dd");
        }
    }
}
