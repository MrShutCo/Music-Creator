using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VLA_Compiler
{
    public class VLA
    {

        public int Tempo;
        public float Signature;
        public List<Channel> Channels;

        /// <summary>
        /// We need to have a list of channels, each that contain Bars of data.
        /// Once the song is executed, it goes through each channel, checks if the bar is there
        /// 
        /// </summary>

        public VLA() {
            Channels = new List<Channel>();
        } 

        public void LoadVLA(string fileName) {
            StreamReader file = new StreamReader(fileName + ".vla");
            string MagicHeader = file.ReadLine();
            if (MagicHeader != "###----VLA----###") return; //Oops, not valid file
            //Good to go, let's read this bad boy up
            string TempSig = file.ReadLine();
            Tempo = Convert.ToInt32(TempSig.Split(',')[0]);
            Signature = Convert.ToSingle(TempSig.Split(',')[1]);
            //Woohoo, got Tempo and Signature

            //Now lets load up our channels
            LoadChannels(file);

            //Read until something is hit

            //Make assumption that it's a channel
            //Also make assumption that that's all there is to read
            while (!file.EndOfStream) {
                ReadBar(file);
            }
            Console.WriteLine("Success!");
        }

        private void LoadChannels(StreamReader file) {
            string line;
            Channel ch;
            while ((line = file.ReadLine()) != "EndChannel") {

                int chN = Convert.ToInt32(line.Split(':')[0]);
                string instrumentName = line.Split(':')[1];
                ch = new Channel(chN, instrumentName);
                Channels.Add(ch);
            }
        }

        private void ReadBar(StreamReader file) {
            Bar bar = new Bar();
            bar.notes = new List<Note>();
            int barID = 0;
            string line = file.ReadLine();
            if (line.Contains('#')) {
                string temp = StripHash(line);
                bar.BarNo = Convert.ToInt32(temp.Split(',')[1]);
                barID = Convert.ToInt32(temp.Split(',')[0]);
            }
            while ((line = file.ReadLine()) != "#end#") {
                Note n = Note.ConvertToNote(line.Split(' ')[0]);
                n.Length = Convert.ToSingle(line.Split(' ')[1]);
                n.Volume = Convert.ToInt32(line.Split(' ')[2]);
                
                bar.notes.Add(n);
            }
            GetChannel(barID).Bars.Add(bar);
            //ReadUntilNewLine(file);
        }

        private void ReadUntilNewLine(StreamReader file) {
            string line;
            while((line = file.ReadLine()) == "\n") {
                continue;
            }
        }

        private string StripHash(string s) {
            string strip = "";
            foreach(char c in s) {
                if (c != '#') strip += c;
            }
            return strip;
        }

        public Channel GetChannel(int id) {
            foreach (Channel ch in Channels) {
                if (ch.ChannelNo == id)
                    return ch;
            }
            return null;
        }

    }
}
