using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects
{
    public sealed class EditDateTime
    {
        private readonly VoDate _date;
        private readonly VoTime _time;

        public EditDateTime(VoDate date, VoTime time)
        {
            _date = date;
            _time = time;
        }

        public VoDate EditDate => _date;

        public VoTime EditTime => _time;

    }
}