using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLA_Compiler {
    public class Note {

        public string NoteName;
        public int Octave;
        public float Length;
        public int Volume;

        public Note(string note, int octave) {
            NoteName = note;
            Octave = octave;
        }

        public Note() {

        }

        public static int NoteToMIDI(Note note) {
            List<string> noteNames = new List<string>() { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            int index = noteNames.IndexOf(note.NoteName);
            return (note.Octave * 12) + index;
        }

        public static Note ConvertToNote(string s) {
            string note = "";
            string octave = "";
            if (s.Contains('#')) {
                note += s[0];
                note += s[1];
                if (s.Contains('-')) {
                    octave += s[2];
                    octave += s[3];
                }
                else {
                    octave += s[2];
                }
            }
            else {
                note += s[0];
                if (s.Contains('-')) {
                    octave += s[1];
                    octave += s[2];
                }
                else {
                    octave += s[1];
                }
            }
            return new Note(note, Convert.ToInt32(octave));
        }

        public override string ToString() {
            return NoteName + Octave.ToString();
        }

    }
}
