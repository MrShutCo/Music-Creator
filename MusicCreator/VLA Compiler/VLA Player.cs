using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VLA_Compiler {
    public class VLAPlayer {

        float time;

        /// <summary>
        /// This will work by 
        /// </summary>
        /// <param name="song"></param>
        public void SaveToMIDI(VLA song, string fileName) {
            //Load up all notes, assuming they are in order
            Dictionary<Note, float> Notes = LoadNotes(song);

            using (MidiOut midi = new MidiOut(0)) {
                foreach (KeyValuePair<Note, float> kvp in Notes) {
                    midi.Volume = 65535;
                    midi.Send(MidiMessage.StartNote(Note.NoteToMIDI(kvp.Key), kvp.Key.Volume, 1).RawData);
                    Thread.Sleep(Convert.ToInt32(kvp.Value * 4000));
                    midi.Send(MidiMessage.StopNote(Note.NoteToMIDI(kvp.Key), 0, 1).RawData);
                }

            }
            
            /*MidiEventCollection events = new MidiEventCollection(1, 96);
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
            MidiFile.Export(fileName, events);*/
        }

        public void TestMidi(string fileName) {
            int AbsoluteTime = 1000; // 1 Second in on the track 
            int Channel = 1; // Channel needs to be between 1 and 16 
            int NoteNumber = 54;
            int Velocity = 127; // Velocity is from 0 which is considered off, to 127 which is the maximum 
            int Duration = 250;
            NoteOnEvent note1On = new NoteOnEvent(AbsoluteTime, Channel, NoteNumber, Velocity, Duration);
            NoteOnEvent note1Off = new NoteOnEvent(AbsoluteTime + Duration, Channel, NoteNumber, 0, 0);
            MidiEventCollection events = new MidiEventCollection(1, 120);
            int outputTrackCount = 2;
            for (int track = 0; track < outputTrackCount; track++) {
                events.AddTrack();
            }
            events[1].Add(note1On);
            events[1].Add(note1Off);
            AppendEndMarker(events[0]);
            AppendEndMarker(events[1]);
            MidiFile.Export(fileName, events);
        }

        private void AppendEndMarker(IList<MidiEvent> eventList) {
            long absoluteTime = 0;
            if (eventList.Count > 0) {
                absoluteTime = eventList[eventList.Count - 1].AbsoluteTime;
                eventList.Add(new MetaEvent(MetaEventType.EndTrack, 0, absoluteTime));
            }
        }

        private Dictionary<Note, float> LoadNotes(VLA song) {
            Dictionary<Note, float> executionTime = new Dictionary<Note, float>();
            float barsPerMinute = song.Tempo / song.Signature;
            float timePerBar = barsPerMinute / 60;
            foreach(Channel ch in song.Channels) {
                foreach(Bar b in ch.Bars) {
                    foreach(Note n in b.notes) {
                        executionTime.Add(n, n.Length * timePerBar);
                    }
                }
            }
            return executionTime;
        }

       

    }
}
