using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCreatorTester {
    public static class MusicReader {

        public static Dictionary<string, int> ReadMusicFile(string fileName) {
            string line;
            Dictionary<string, int> Notes = new Dictionary<string, int>();
            StreamReader file = new StreamReader(fileName + ".txt");
            while ((line = file.ReadLine()) != null){
                string[] notesLine = line.Split(' ');
                foreach (string s in notesLine) {
                    if (!Notes.Keys.Contains(s)){
                        Notes.Add(s, 1);
                    }
                    else {
                        Notes[s] += 1;
                    }
                }
            }
            return Notes;
        }

        public 

    }
}
