namespace SAPN_Calculator
{
    partial class SAPN_Calculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_inputFile = new System.Windows.Forms.GroupBox();
            this.textBox_inputFile = new System.Windows.Forms.TextBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.button_run = new System.Windows.Forms.Button();
            this.groupBox_options = new System.Windows.Forms.GroupBox();
            this.comboBox_loglevel = new System.Windows.Forms.ComboBox();
            this.comboBox_schedule = new System.Windows.Forms.ComboBox();
            this.comboBox_duration = new System.Windows.Forms.ComboBox();
            this.groupBox_output = new System.Windows.Forms.GroupBox();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.groupBox_inputFile.SuspendLayout();
            this.groupBox_options.SuspendLayout();
            this.groupBox_output.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_inputFile
            // 
            this.groupBox_inputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_inputFile.Controls.Add(this.textBox_inputFile);
            this.groupBox_inputFile.Controls.Add(this.button_browse);
            this.groupBox_inputFile.Controls.Add(this.button_run);
            this.groupBox_inputFile.Location = new System.Drawing.Point(20, 10);
            this.groupBox_inputFile.Name = "groupBox_inputFile";
            this.groupBox_inputFile.Size = new System.Drawing.Size(945, 50);
            this.groupBox_inputFile.TabIndex = 0;
            this.groupBox_inputFile.TabStop = false;
            this.groupBox_inputFile.Text = "Input File";
            // 
            // textBox_inputFile
            // 
            this.textBox_inputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_inputFile.Location = new System.Drawing.Point(15, 18);
            this.textBox_inputFile.Name = "textBox_inputFile";
            this.textBox_inputFile.Size = new System.Drawing.Size(725, 20);
            this.textBox_inputFile.TabIndex = 0;
            this.textBox_inputFile.Text = "C:\\_SAPN_DETAILED.csv";
            // 
            // button_browse
            // 
            this.button_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browse.Location = new System.Drawing.Point(755, 18);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(80, 21);
            this.button_browse.TabIndex = 1;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // button_run
            // 
            this.button_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_run.Location = new System.Drawing.Point(850, 18);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(80, 21);
            this.button_run.TabIndex = 2;
            this.button_run.Text = "Run";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // groupBox_options
            // 
            this.groupBox_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_options.Controls.Add(this.comboBox_loglevel);
            this.groupBox_options.Controls.Add(this.comboBox_schedule);
            this.groupBox_options.Controls.Add(this.comboBox_duration);
            this.groupBox_options.Location = new System.Drawing.Point(20, 65);
            this.groupBox_options.Name = "groupBox_options";
            this.groupBox_options.Size = new System.Drawing.Size(945, 50);
            this.groupBox_options.TabIndex = 1;
            this.groupBox_options.TabStop = false;
            this.groupBox_options.Text = "Options";
            // 
            // comboBox_loglevel
            // 
            this.comboBox_loglevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_loglevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_loglevel.FormattingEnabled = true;
            this.comboBox_loglevel.Location = new System.Drawing.Point(780, 18);
            this.comboBox_loglevel.Name = "comboBox_loglevel";
            this.comboBox_loglevel.Size = new System.Drawing.Size(150, 21);
            this.comboBox_loglevel.TabIndex = 2;
            // 
            // comboBox_schedule
            // 
            this.comboBox_schedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_schedule.FormattingEnabled = true;
            this.comboBox_schedule.Location = new System.Drawing.Point(185, 18);
            this.comboBox_schedule.Name = "comboBox_schedule";
            this.comboBox_schedule.Size = new System.Drawing.Size(150, 21);
            this.comboBox_schedule.TabIndex = 1;
            // 
            // comboBox_duration
            // 
            this.comboBox_duration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_duration.FormattingEnabled = true;
            this.comboBox_duration.Location = new System.Drawing.Point(15, 18);
            this.comboBox_duration.Name = "comboBox_duration";
            this.comboBox_duration.Size = new System.Drawing.Size(150, 21);
            this.comboBox_duration.TabIndex = 0;
            // 
            // groupBox_output
            // 
            this.groupBox_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_output.Controls.Add(this.textBox_output);
            this.groupBox_output.Location = new System.Drawing.Point(20, 120);
            this.groupBox_output.Name = "groupBox_output";
            this.groupBox_output.Size = new System.Drawing.Size(945, 505);
            this.groupBox_output.TabIndex = 2;
            this.groupBox_output.TabStop = false;
            this.groupBox_output.Text = "Output";
            // 
            // textBox_output
            // 
            this.textBox_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_output.Location = new System.Drawing.Point(15, 20);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_output.Size = new System.Drawing.Size(915, 470);
            this.textBox_output.TabIndex = 0;
            this.textBox_output.Text = "Load a detailed summary and click run.";
            // 
            // SAPN_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.groupBox_options);
            this.Controls.Add(this.groupBox_output);
            this.Controls.Add(this.groupBox_inputFile);
            this.MinimumSize = new System.Drawing.Size(570, 300);
            this.Name = "SAPN_Calculator";
            this.Text = "SAPN Calculator";
            this.groupBox_inputFile.ResumeLayout(false);
            this.groupBox_inputFile.PerformLayout();
            this.groupBox_options.ResumeLayout(false);
            this.groupBox_output.ResumeLayout(false);
            this.groupBox_output.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_inputFile;
        private System.Windows.Forms.TextBox textBox_inputFile;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button button_run;

        private System.Windows.Forms.GroupBox groupBox_options;
        private System.Windows.Forms.ComboBox comboBox_schedule;
        private System.Windows.Forms.ComboBox comboBox_duration;
        private System.Windows.Forms.ComboBox comboBox_loglevel;

        private System.Windows.Forms.GroupBox groupBox_output;
        private System.Windows.Forms.TextBox textBox_output;
    }
}

