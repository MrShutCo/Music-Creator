using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCreatorTester {
    class Program {
        static void Main(string[] args) {

            List<byte> MusicalBytes = MusicIO.ReadMidiFile("Glycerine");
            List<Note> MusicalNotes = MusicIO.ConvertToNotes(MusicalBytes);
            Dictionary<string, int> NoteCount = MusicAnalyzer.FindNoteCount(MusicalNotes);
            foreach(KeyValuePair<string, int> kvp in NoteCount) {
                Console.WriteLine("Note: {0} Times Occured: {1}", kvp.Key, kvp.Value);
                
            }
            foreach (Note n in MusicalNotes) {
                Console.Write(n.ToString() + " ");
            }

            Console.WriteLine();
            //foreach(string s in MusicalNotes) {
                //Console.Write(s + " ");
            //}
            Console.ReadLine();
        }
    }
}
