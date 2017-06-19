using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike.Application.Interfaces
{
    public class IFishService
    {
        public int Id { get; set; }
        public string Length { get; set; }
        public string Weight { get; set; }
    }
}
