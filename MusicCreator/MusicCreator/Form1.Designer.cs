namespace MusicCreator {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.NoteType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Octave = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ChordType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NoteLength = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NoteType
            // 
            this.NoteType.FormattingEnabled = true;
            this.NoteType.Items.AddRange(new object[] {
            "A",
            "A#",
            "B",
            "B#",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "E#",
            "F",
            "F#",
            "G",
            "G#"});
            this.NoteType.Location = new System.Drawing.Point(50, 12);
            this.NoteType.Name = "NoteType";
            this.NoteType.Size = new System.Drawing.Size(42, 21);
            this.NoteType.TabIndex = 0;
            this.NoteType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Note";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Octave";
            // 
            // Octave
            // 
            this.Octave.Location = new System.Drawing.Point(50, 78);
            this.Octave.Name = "Octave";
            this.Octave.Size = new System.Drawing.Size(33, 20);
            this.Octave.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add note";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChordType
            // 
            this.ChordType.FormattingEnabled = true;
            this.ChordType.Items.AddRange(new object[] {
            "Major",
            "Minor",
            "Diminshed",
            "Augmented",
            "Major 7th",
            "Min 7th",
            "Dominant 7th",
            "Diminshed 7th"});
            this.ChordType.Location = new System.Drawing.Point(50, 47);
            this.ChordType.Name = "ChordType";
            this.ChordType.Size = new System.Drawing.Size(121, 21);
            this.ChordType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chord";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Notes So Far";
            // 
            // NoteLength
            // 
            this.NoteLength.FormattingEnabled = true;
            this.NoteLength.Items.AddRange(new object[] {
            "1",
            "1/2",
            "1/4",
            "1/8"});
            this.NoteLength.Location = new System.Drawing.Point(50, 110);
            this.NoteLength.Name = "NoteLength";
            this.NoteLength.Size = new System.Drawing.Size(121, 21);
            this.NoteLength.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Length";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 474);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NoteLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChordType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Octave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NoteType);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox NoteType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Octave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ChordType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox NoteLength;
        private System.Windows.Forms.Label label4;
    }
}

