using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Domain.Interfaces
{
    interface ITackleBoxRepository
    {
        TackleBoxDO AddTackleBox(TackleBoxDO newTackleBox);
        bool DeleteTackleBox(TackleBoxDO tackleBoxToDelete);
        TackleBoxDO GetTackleBox(int id);

    }
}
