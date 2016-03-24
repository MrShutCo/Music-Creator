using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLA_Compiler {

    public struct Bar {
        public float TimeSig;
        public int BarNo;
        public List<Note> notes;
    }

    public class Channel {

        public int ChannelNo;
        public List<Bar> Bars;
        public string Instrument;

        public Channel(int channelNo, string ins) {
            ChannelNo = channelNo;
            Instrument = ins;
            Bars = new List<Bar>();
        }

        

    }
}
