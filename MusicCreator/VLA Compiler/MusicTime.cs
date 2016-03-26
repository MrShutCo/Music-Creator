using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace VLA_Compiler {
    public class MusicTime {

        public int TimeMilli { get; private set; }
        public VLA Song { get; private set; }

        public MusicTime(VLA song) {
            TimeMilli = 0;
            Song = song;
        }

        public void StartTimer() {
            Timer _timer;
            List<DateTime> events = new List<DateTime>();
            _timer = new Timer(3000);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e) {
            
        }
    }
}
