using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VLA_Compiler {
    public class VLAPlayer {

        #region Public Methods

        public void SaveToMIDI(VLA song, string fileName) {
            Dictionary<Note, float> Notes = LoadNotes(song, 1);

            MidiEventCollection events = new MidiEventCollection(1, 96);
            int outputTrackCount = 2;
            for (int track = 0; track < outputTrackCount; track++) {
                events.AddTrack();
            }

            //For note length, just multiply the length of note by TPB
            long songAbs = 0;

            foreach (KeyValuePair<Note, float> kvp in Notes) {
                int key = Note.NoteToMIDI(kvp.Key);
                NoteOnEvent noteStart = new NoteOnEvent(songAbs, 1, key, kvp.Key.Volume, Convert.ToInt32(kvp.Value * 1000));
                Console.WriteLine("Time: {0} Channel: {1} Key: {2} Volume: {3} Length: {4}", songAbs, 1, key, kvp.Key.Volume, Convert.ToInt32(kvp.Value * 1000));
                songAbs += Convert.ToInt64(kvp.Value * 1000);
                NoteOnEvent noteEnd = new NoteOnEvent(songAbs, 1, key, 0, 0);
                Console.WriteLine("Time: {0} Channel: {1} Key: {2} Volume: {3} Length: {4}", songAbs, 1, key, 0, 0);
                events[1].Add(noteStart);
                events[1].Add(noteEnd);

            }
            AppendEndMarker(events[0]);
            AppendEndMarker(events[1]);
            MidiFile.Export(fileName, events);
        }

        private void PlayVLAChannel(VLA song, int channel, MidiOut midi) {
            Dictionary<Note, float> Notes = LoadNotes(song, channel);
            foreach (KeyValuePair<Note, float> kvp in Notes) {
                midi.Volume = 65535;
                midi.Send(MidiMessage.StartNote(Note.NoteToMIDI(kvp.Key), kvp.Key.Volume, 1).RawData);
                Console.WriteLine("");
                Thread.Sleep(Convert.ToInt32(kvp.Value * 4000));
                midi.Send(MidiMessage.StopNote(Note.NoteToMIDI(kvp.Key), 0, 1).RawData);
            }
        }

        public void PlayVLA(VLA song) {
            MidiOut midi = new MidiOut(0);
            foreach (Channel ch in song.Channels) {
                Thread thread = new Thread(() => PlayVLAChannel(song, ch.ChannelNo, midi));
                thread.Start();
            }
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

        private Dictionary<Note, float> LoadNotes(VLA song, int channelID) {
            Dictionary<Note, float> executionTime = new Dictionary<Note, float>();
            float barsPerMinute = song.Tempo / song.Signature;
            float timePerBar = barsPerMinute / 60;
            Channel ch = song.GetChannel(channelID);
            foreach (Bar b in ch.Bars) {
                foreach (Note n in b.notes) {
                    executionTime.Add(n, n.Length * timePerBar);
                }
            }
            return executionTime;
        }

        #endregion

    }
}
