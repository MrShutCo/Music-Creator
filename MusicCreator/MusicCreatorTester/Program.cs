using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCreatorTester {
    class Program {
        static void Main(string[] args) {

            List<byte> musicBytes = MusicReader.ReadMidiFile("Glycerine");
            Console.WriteLine();
            List<string> musicNotes = MusicReader.ConvertToNotes(musicBytes);
            foreach(string s in musicNotes) {
                Console.Write(s + " ");
            }
            Console.ReadLine();

        }
    }
}
