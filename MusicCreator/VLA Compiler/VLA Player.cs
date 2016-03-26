using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

namespace VLA_Compiler {
    public class VLAPlayer {

        #region Public Methods

        public void SaveToMIDI(VLA song, string fileName) {
            List<Dictionary<Note, float>> Notes = LoadNotes(song, 1);

            MidiEventCollection events = new MidiEventCollection(1, 96);
            int outputTrackCount = 2;
            for (int track = 0; track < outputTrackCount; track++) {
                events.AddTrack();
            }

            //For note length, just multiply the length of note by TPB
            long songAbs = 0;

            /*foreach (KeyValuePair<Note, float> kvp in Notes) {
                int key = Note.NoteToMIDI(kvp.Key);
                NoteOnEvent noteStart = new NoteOnEvent(songAbs, 1, key, kvp.Key.Volume, Convert.ToInt32(kvp.Value * 1000));
                Console.WriteLine("Time: {0} Channel: {1} Key: {2} Volume: {3} Length: {4}", songAbs, 1, key, kvp.Key.Volume, Convert.ToInt32(kvp.Value * 1000));
                songAbs += Convert.ToInt64(kvp.Value * 1000);
                NoteOnEvent noteEnd = new NoteOnEvent(songAbs, 1, key, 0, 0);
                Console.WriteLine("Time: {0} Channel: {1} Key: {2} Volume: {3} Length: {4}", songAbs, 1, key, 0, 0);
                events[1].Add(noteStart);
                events[1].Add(noteEnd);

            }*/
            AppendEndMarker(events[0]);
            AppendEndMarker(events[1]);
            MidiFile.Export(fileName, events);
        }
        
        public void Play(VLA song, int channelId) {
            MidiOut midi = new MidiOut(0);
            foreach(Bar b in song.Channels[channelId].Bars) {
                foreach(List<Note> nl in b.notes) {
                    System.Timers.Timer a = new System.Timers.Timer();
                    a.Elapsed += new ElapsedEventHandler(OnTimedEvent)
                }
            }
            
        }

        private void OnTimedEvent(object source, EventArgs e) {
            PlayNote();
        }
        
        private void PlayNote(MidiOut midi, Note n, float freq) {
            midi.Send(MidiMessage.StartNote(Note.NoteToMIDI(n), n.Volume, 1).RawData);
            //Thread.Sleep(Convert.ToInt32(freq * 4000));

        }

        /*private void PlayVLAChannel(VLA song, int channel, MidiOut midi) {
            midi.Volume = 65535;
            List<Dictionary<Note, float>> Notes = LoadNotes(song, channel);
            foreach (Dictionary<Note, float> d in Notes) {
                Thread th = new Thread(() => Blah(midi, d));
                
                

            }
        }

        private void Blah(MidiOut midi, Dictionary<Note, float> d) {
            foreach (KeyValuePair<Note, float> kvp in d) {
                Thread thread = new Thread(() => PlayNote(midi, kvp.Key, kvp.Value));
                Console.WriteLine("Key: {0} Length: {1}", kvp.Key, kvp.Value * 4000);
                thread.Start();
            }
            foreach (KeyValuePair<Note, float> kvp in d) {
                Thread.Sleep(Convert.ToInt32(kvp.Value * 4000));
                midi.Send(MidiMessage.StopNote(Note.NoteToMIDI(kvp.Key), 0, 1).RawData);
            }
        }*/

       

        public void PlayTest() {
            MidiOut midi = new MidiOut(0);
            midi.Volume = 65535;
            midi.Send(MidiMessage.StartNote((57), 127, 1).RawData);
            midi.Send(MidiMessage.StartNote((59), 127, 1).RawData);
            midi.Send(MidiMessage.StartNote((61), 127, 1).RawData);
            Thread.Sleep(1000);
            midi.Send(MidiMessage.StopNote((57), 0, 1).RawData);
            midi.Send(MidiMessage.StopNote((59), 0, 1).RawData);
            midi.Send(MidiMessage.StopNote((61), 0, 1).RawData);
        }

        /*public void PlayVLA(VLA song) {
            MidiOut midi = new MidiOut(0);
            foreach (Channel ch in song.Channels) {
                Thread thread = new Thread(() => PlayVLAChannel(song, ch.ChannelNo, midi));
                thread.Start();
            }
        }*/

        #endregion

        #region Helper Methods

        private void AppendEndMarker(IList<MidiEvent> eventList) {
            long absoluteTime = 0;
            if (eventList.Count > 0) {
                absoluteTime = eventList[eventList.Count - 1].AbsoluteTime;
                eventList.Add(new MetaEvent(MetaEventType.EndTrack, 0, absoluteTime));
            }
        }

        private List<Dictionary<Note, float>> LoadNotes(VLA song, int channelID) {
            List<Dictionary<Note, float>> executionTime = new List<Dictionary<Note, float>>();
            float barsPerMinute = song.Tempo / song.Signature;
            float timePerBar = barsPerMinute / 60;
            Channel ch = song.GetChannel(channelID);
            foreach (Bar b in ch.Bars) {
                foreach (List<Note> note in b.notes) {
                    Dictionary<Note, float> notesNow = new Dictionary<Note, float>();
                    foreach(Note n in note) {
                        notesNow.Add(n, n.Length * timePerBar);
                    }
                    executionTime.Add(notesNow);
                }
            }
            return executionTime;
        }

        #endregion

    }
}
