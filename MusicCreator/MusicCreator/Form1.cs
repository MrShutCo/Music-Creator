using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLA_Compiler;

namespace MusicCreator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            NotesToWrite = new List<Note>();
        }

        public List<Note> NotesToWrite;

        private void button1_Click(object sender, EventArgs e) {
            string name = "";
            if (NoteType.Text != "" && Octave.Text != "" && ChordType.Text == "") {
                Note n = new Note();
                n.Volume = 127;
                n.Octave = Convert.ToInt32(Octave.Text);
                n.NoteName = NoteType.Text;
                if (NoteLength.Text == "1") {
                    n.Length = 1;
                }
                if (NoteLength.Text == "1/2") {
                    n.Length = 0.5f;
                }
                if (NoteLength.Text == "1/4") {
                    n.Length = 0.25f;
                }
                if (NoteLength.Text == "1/8") {
                    n.Length = 0.125f;
                }
                
                NotesToWrite.Add(n);
                label5.Text += '\n' + n.ToString() + " " + n.Length;
            }
            else {

            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        
    }
}
