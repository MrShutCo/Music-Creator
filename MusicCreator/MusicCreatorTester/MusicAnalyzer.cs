using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCreatorTester {
    public static class MusicAnalyzer {

        public static Dictionary<string, int> FindNoteCount(List<Note> NoteList) {
            Dictionary<string, int> NoteFreq = new Dictionary<string, int>();
            foreach(Note n in NoteList) {
                if (!NoteFreq.Keys.Contains(n.ToString())) {
                    NoteFreq.Add(n.ToString(), 1);
                }
                else {
                    NoteFreq[n.ToString()] += 1;
                }
            }
            return NoteFreq;
        }

    }
}
