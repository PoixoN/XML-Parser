namespace Lab3
{
    partial class PlaylistReader
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
            this.rtbSearchResults = new System.Windows.Forms.RichTextBox();
            this.rbtnLinq = new System.Windows.Forms.RadioButton();
            this.rbtnSax = new System.Windows.Forms.RadioButton();
            this.rbtnDom = new System.Windows.Forms.RadioButton();
            this.dlCompany = new System.Windows.Forms.ComboBox();
            this.cbCompany = new System.Windows.Forms.CheckBox();
            this.dlYear = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.CheckBox();
            this.dlGenre = new System.Windows.Forms.ComboBox();
            this.cbGenre = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.forgeHtmlBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dlRating = new System.Windows.Forms.ComboBox();
            this.cbRating = new System.Windows.Forms.CheckBox();
            this.dlPrice = new System.Windows.Forms.ComboBox();
            this.cbPrice = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbSearchResults
            // 
            this.rtbSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbSearchResults.Location = new System.Drawing.Point(299, 11);
            this.rtbSearchResults.Margin = new System.Windows.Forms.Padding(2);
            this.rtbSearchResults.Name = "rtbSearchResults";
            this.rtbSearchResults.Size = new System.Drawing.Size(400, 326);
            this.rtbSearchResults.TabIndex = 0;
            this.rtbSearchResults.Text = "";
            // 
            // rbtnLinq
            // 
            this.rbtnLinq.AutoSize = true;
            this.rbtnLinq.Checked = true;
            this.rbtnLinq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnLinq.Location = new System.Drawing.Point(12, 182);
            this.rbtnLinq.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnLinq.Name = "rbtnLinq";
            this.rbtnLinq.Size = new System.Drawing.Size(64, 24);
            this.rbtnLinq.TabIndex = 10;
            this.rbtnLinq.TabStop = true;
            this.rbtnLinq.Text = "LINQ";
            this.rbtnLinq.UseVisualStyleBackColor = true;
            // 
            // rbtnSax
            // 
            this.rbtnSax.AutoSize = true;
            this.rbtnSax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSax.Location = new System.Drawing.Point(219, 182);
            this.rbtnSax.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnSax.Name = "rbtnSax";
            this.rbtnSax.Size = new System.Drawing.Size(60, 24);
            this.rbtnSax.TabIndex = 9;
            this.rbtnSax.Text = "SAX";
            this.rbtnSax.UseVisualStyleBackColor = true;
            // 
            // rbtnDom
            // 
            this.rbtnDom.AutoSize = true;
            this.rbtnDom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbtnDom.Location = new System.Drawing.Point(108, 182);
            this.rbtnDom.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnDom.Name = "rbtnDom";
            this.rbtnDom.Size = new System.Drawing.Size(64, 24);
            this.rbtnDom.TabIndex = 8;
            this.rbtnDom.Text = "DOM";
            this.rbtnDom.UseVisualStyleBackColor = true;
            // 
            // dlCompany
            // 
            this.dlCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dlCompany.Enabled = false;
            this.dlCompany.FormattingEnabled = true;
            this.dlCompany.Location = new System.Drawing.Point(140, 91);
            this.dlCompany.Margin = new System.Windows.Forms.Padding(2);
            this.dlCompany.Name = "dlCompany";
            this.dlCompany.Size = new System.Drawing.Size(140, 21);
            this.dlCompany.Sorted = true;
            this.dlCompany.TabIndex = 7;
            // 
            // cbCompany
            // 
            this.cbCompany.AutoSize = true;
            this.cbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbCompany.Location = new System.Drawing.Point(15, 91);
            this.cbCompany.Margin = new System.Windows.Forms.Padding(2);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(95, 24);
            this.cbCompany.TabIndex = 6;
            this.cbCompany.Text = "Company";
            this.cbCompany.UseVisualStyleBackColor = true;
            this.cbCompany.CheckedChanged += new System.EventHandler(this.labelCheckBox_CheckedChanged);
            // 
            // dlYear
            // 
            this.dlYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dlYear.Enabled = false;
            this.dlYear.FormattingEnabled = true;
            this.dlYear.Location = new System.Drawing.Point(140, 63);
            this.dlYear.Margin = new System.Windows.Forms.Padding(2);
            this.dlYear.Name = "dlYear";
            this.dlYear.Size = new System.Drawing.Size(140, 21);
            this.dlYear.Sorted = true;
            this.dlYear.TabIndex = 5;
            // 
            // cbYear
            // 
            this.cbYear.AutoSize = true;
            this.cbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbYear.Location = new System.Drawing.Point(15, 63);
            this.cbYear.Margin = new System.Windows.Forms.Padding(2);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(62, 24);
            this.cbYear.TabIndex = 4;
            this.cbYear.Text = "Year";
            this.cbYear.UseVisualStyleBackColor = true;
            this.cbYear.CheckedChanged += new System.EventHandler(this.yearCheckBox_CheckedChanged);
            // 
            // dlGenre
            // 
            this.dlGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dlGenre.Enabled = false;
            this.dlGenre.FormattingEnabled = true;
            this.dlGenre.Location = new System.Drawing.Point(140, 35);
            this.dlGenre.Margin = new System.Windows.Forms.Padding(2);
            this.dlGenre.Name = "dlGenre";
            this.dlGenre.Size = new System.Drawing.Size(140, 21);
            this.dlGenre.Sorted = true;
            this.dlGenre.TabIndex = 3;
            // 
            // cbGenre
            // 
            this.cbGenre.AutoSize = true;
            this.cbGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbGenre.Location = new System.Drawing.Point(15, 35);
            this.cbGenre.Margin = new System.Windows.Forms.Padding(2);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(73, 24);
            this.cbGenre.TabIndex = 2;
            this.cbGenre.Text = "Genre";
            this.cbGenre.UseVisualStyleBackColor = true;
            this.cbGenre.CheckedChanged += new System.EventHandler(this.genreCheckBox_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(11, 225);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(268, 44);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // forgeHtmlBtn
            // 
            this.forgeHtmlBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.forgeHtmlBtn.Location = new System.Drawing.Point(12, 286);
            this.forgeHtmlBtn.Margin = new System.Windows.Forms.Padding(2);
            this.forgeHtmlBtn.Name = "forgeHtmlBtn";
            this.forgeHtmlBtn.Size = new System.Drawing.Size(110, 31);
            this.forgeHtmlBtn.TabIndex = 3;
            this.forgeHtmlBtn.Text = "Transform to HTML";
            this.forgeHtmlBtn.UseVisualStyleBackColor = true;
            this.forgeHtmlBtn.Click += new System.EventHandler(this.forgeHtmlBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(170, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dlRating
            // 
            this.dlRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dlRating.Enabled = false;
            this.dlRating.FormattingEnabled = true;
            this.dlRating.Location = new System.Drawing.Point(140, 116);
            this.dlRating.Margin = new System.Windows.Forms.Padding(2);
            this.dlRating.Name = "dlRating";
            this.dlRating.Size = new System.Drawing.Size(140, 21);
            this.dlRating.Sorted = true;
            this.dlRating.TabIndex = 12;
            // 
            // cbRating
            // 
            this.cbRating.AutoSize = true;
            this.cbRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbRating.Location = new System.Drawing.Point(15, 116);
            this.cbRating.Margin = new System.Windows.Forms.Padding(2);
            this.cbRating.Name = "cbRating";
            this.cbRating.Size = new System.Drawing.Size(75, 24);
            this.cbRating.TabIndex = 11;
            this.cbRating.Text = "Rating";
            this.cbRating.UseVisualStyleBackColor = true;
            this.cbRating.CheckedChanged += new System.EventHandler(this.cbRating_CheckedChanged);
            // 
            // dlPrice
            // 
            this.dlPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dlPrice.Enabled = false;
            this.dlPrice.FormattingEnabled = true;
            this.dlPrice.Location = new System.Drawing.Point(140, 141);
            this.dlPrice.Margin = new System.Windows.Forms.Padding(2);
            this.dlPrice.Name = "dlPrice";
            this.dlPrice.Size = new System.Drawing.Size(140, 21);
            this.dlPrice.Sorted = true;
            this.dlPrice.TabIndex = 14;
            // 
            // cbPrice
            // 
            this.cbPrice.AutoSize = true;
            this.cbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbPrice.Location = new System.Drawing.Point(15, 141);
            this.cbPrice.Margin = new System.Windows.Forms.Padding(2);
            this.cbPrice.Name = "cbPrice";
            this.cbPrice.Size = new System.Drawing.Size(63, 24);
            this.cbPrice.TabIndex = 13;
            this.cbPrice.Text = "Price";
            this.cbPrice.UseVisualStyleBackColor = true;
            this.cbPrice.CheckedChanged += new System.EventHandler(this.cbPrice_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProgram,
            this.tsmiHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiProgram
            // 
            this.tsmiProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.tsmiProgram.Name = "tsmiProgram";
            this.tsmiProgram.Size = new System.Drawing.Size(37, 20);
            this.tsmiProgram.Text = "File";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "Help";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // PlaylistReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 348);
            this.Controls.Add(this.dlPrice);
            this.Controls.Add(this.cbPrice);
            this.Controls.Add(this.dlRating);
            this.Controls.Add(this.cbRating);
            this.Controls.Add(this.dlCompany);
            this.Controls.Add(this.rbtnLinq);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dlYear);
            this.Controls.Add(this.rbtnSax);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.dlGenre);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.rbtnDom);
            this.Controls.Add(this.forgeHtmlBtn);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rtbSearchResults);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlaylistReader";
            this.Text = "XML Database";
            this.Load += new System.EventHandler(this.PlaylistReader_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSearchResults;
        private System.Windows.Forms.RadioButton rbtnLinq;
        private System.Windows.Forms.RadioButton rbtnSax;
        private System.Windows.Forms.RadioButton rbtnDom;
        private System.Windows.Forms.ComboBox dlCompany;
        private System.Windows.Forms.CheckBox cbCompany;
        private System.Windows.Forms.ComboBox dlYear;
        private System.Windows.Forms.CheckBox cbYear;
        private System.Windows.Forms.ComboBox dlGenre;
        private System.Windows.Forms.CheckBox cbGenre;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button forgeHtmlBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox dlRating;
        private System.Windows.Forms.CheckBox cbRating;
        private System.Windows.Forms.ComboBox dlPrice;
        private System.Windows.Forms.CheckBox cbPrice;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiProgram;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
    }
}

