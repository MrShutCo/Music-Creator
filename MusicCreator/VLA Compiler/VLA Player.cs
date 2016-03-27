using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace VLA_Compiler {
    public class VLAPlayer {

        #region Public Methods

        public void PlaySong(VLA song) {
            
            Timer timer = new Timer();
            MidiOut midi = new MidiOut(0);
            List<Note> playingNotes = DumpNotesFromChannel(song, 1);
            int songTime = 0;
            //Just gets the last note to end song
            int songLength = playingNotes.Max(t => t.milliIntoSongEnd);
            //NEVER, EVER EVER DO THIS. THIS IS GROSS, AND THIS IS WRONG
            timer.Elapsed += (sender, e) => { PlayNote(midi, playingNotes, ref songTime, ref timer, songLength); };
            //Every 16 milliseconds, we check which notes are to be played
            timer.Interval = 5;
            timer.Start();

        }
        
        private void PlayNote(MidiOut midi, List<Note> song, ref int songTime, ref Timer t, int songL) {
            if (songTime == songL) {
                t.Stop();
            }
            Console.WriteLine("Interval: {0}", songTime);
            foreach(Note n in song) {
                if (songTime == n.milliIntoSongStart) {
                    //play note
                    midi.Send(MidiMessage.StartNote(Note.NoteToMIDI(n), n.Volume, 1).RawData);
                }
                if (songTime == n.milliIntoSongEnd) {
                    //Stop playing that note
                    midi.Send(MidiMessage.StopNote(Note.NoteToMIDI(n), 0, 1).RawData);
                }
            }
            songTime += 5;
        }


        #endregion

        #region Helper Methods

        private void AppendEndMarker(IList<MidiEvent> eventList) {
            long absoluteTime = 0;
            if (eventList.Count > 0) {
                absoluteTime = eventList[eventList.Count - 1].AbsoluteTime;
                eventList.Add(new MetaEvent(MetaEventType.EndTrack, 0, absoluteTime));
            }
        }

        private List<Note> DumpNotesFromChannel(VLA song, int channelID) {
            List<Note> Notes = new List<Note>();
            Channel dumpedChannel = song.GetChannel(channelID);
            foreach (Bar b in dumpedChannel.Bars) {
                //Time taken for whole note to play
                int barTimeIntoSong = b.BarNo * 400;
                int timeIntoBar = 0;
                foreach (List<Note> noteList in b.notes) {
                    foreach (Note n in noteList) {
                        n.milliIntoSongStart = barTimeIntoSong + timeIntoBar;
                        n.milliIntoSongEnd = n.milliIntoSongStart + Convert.ToInt32(n.Length * 400);
                        Notes.Add(n);
                        
                    }
                    timeIntoBar += Convert.ToInt32(noteList[0].Length * 400);
                }
            }

            return Notes;
        }

        #endregion

    }
}
