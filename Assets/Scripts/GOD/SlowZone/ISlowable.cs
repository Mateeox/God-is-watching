using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GOD.SlowZone
{
    interface ISlowable
    {
        void SetMaxSpeed();
        void SlowDown();
    }
}
