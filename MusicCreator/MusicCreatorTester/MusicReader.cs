using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCreatorTester {
    public static class MusicReader {

        public static List<byte> ReadMidiFile(string fileName) {
            byte[] MIDI = File.ReadAllBytes(fileName + ".mid");
            List<byte> MIDINotes = new List<byte>();
            for (int i = 0; i < MIDI.Length; i++) {

                if (MIDI[i] == 144) {
                    Console.Write(MIDI[i + 1] + " ");  //This is the note value
                    MIDINotes.Add(MIDI[i + 1]);
                }

            }
            return MIDINotes;
        }

        public static List<string> ConvertToNotes(List<byte> noteBytes) {
            List<string> Notes = new List<string>();
            string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string[] noteOctaves = { "-2", "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            foreach(byte b in noteBytes) {
                //Determine Row:
                int rowNo = b / 12;
                //Determine Column:
                int colNo = b % 12;
                string note = noteNames[colNo] + noteOctaves[rowNo];
                Notes.Add(note);
            }
            return Notes;
        }

    }
}
