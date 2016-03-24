# Music-Generator

#VLA (Very Lossy Audio)
VLA is a new custom format for music that uses a structure similar to MIDI/Actual sheet music. 

###Structure

####VLA
LoadVLA: takes a filename and reads it to this instance

####VLA Compiler
SaveToMIDI: Takes in a VLA song and a fileName and writes a song to it (doesn't work).

PlayVLA: Same as above, but instead plays the notes right away (new thread for each channel, maybe change).

