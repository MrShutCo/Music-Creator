using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCreatorTester {
    public static class MusicIO {

        #region IO

        public static List<byte> ReadMidiFile(string fileName) {
            byte[] MIDI = File.ReadAllBytes(fileName + ".mid");
            List<byte> MIDINotes = new List<byte>();
            for (int i = 0; i < MIDI.Length; i++) {

                if (MIDI[i] == 144) {
                    //Console.Write(MIDI[i + 1] + " ");  //This is the note value
                    MIDINotes.Add(MIDI[i + 1]);
                }

            }
            return MIDINotes;
        }

        #endregion

        #region Conversions

        public static List<Note> ConvertToNotes(List<byte> noteBytes) {
            List<Note> Notes = new List<Note>();
            string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string[] noteOctaves = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            foreach(byte b in noteBytes) {
                //Determine Row:
                int rowNo = b / 12;
                //Determine Column:
                int colNo = b % 12;
               
                Notes.Add(new Note(noteNames[colNo], Convert.ToInt32(noteOctaves[rowNo])));
            }
            return Notes;
        }

        #endregion

    }
}
