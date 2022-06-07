using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace WakeApp
{
    internal class SoundHandler
    {
        public SoundPlayer Run()
        {
            SoundPlayer Alarm = new SoundPlayer(@"SoundHandler\alarm-clock.wav");
            Alarm.Load();
            Alarm.PlayLooping();
            return Alarm;
        }
    }
}
