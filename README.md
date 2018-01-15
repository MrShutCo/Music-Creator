# Music-Generator

# VLA (Very Lossy Audio)
VLA is a new custom format for music that uses a structure similar to MIDI/Actual sheet music. 

### Structure

#### VLA
LoadVLA: takes a filename and reads it to this instance

#### VLA Compiler
SaveToMIDI: Takes in a VLA song and a fileName and writes a song to it (doesn't work).

PlayVLA: Same as above, but instead plays the notes right away (new thread for each channel, maybe change).

## Example 

###----VLA----###  
1000, 4  
1: Piano  
2: Piano  
3: Piano  
4: Piano  
5: Piano  
EndChannel  
#1, 0#  
A4 0.25 127,C4 0.25 127,E4 0.25 127  
A4 0.25 127,C4 0.25 127,E4 0.25 127  
A4 0.25 127,C4 0.25 127,E4 0.25 127  
A4 0.25 127,C4 0.25 127,E4 0.25 127  
#end#  

## Note
It can also read a midi file and convert the bytes to the corresponding note, ready to be analyzed (by nothing right now)

