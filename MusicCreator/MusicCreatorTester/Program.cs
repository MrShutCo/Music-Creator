using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCreatorTester {
    class Program {
        static void Main(string[] args) {

            Dictionary<string, int> MusicalNotes = MusicReader.ReadMusicFile("MusicFile");

            foreach(KeyValuePair<string, int> kvp in MusicalNotes) {
                Console.WriteLine("Note {0}: {1}", kvp.Key, kvp.Value);
            }
            Console.ReadLine();

        }
    }
}
