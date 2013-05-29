namespace RSS
{
    partial class MainForm
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
            this.btnLoadFeed = new System.Windows.Forms.Button();
            this.ddlRssFeeds = new System.Windows.Forms.ComboBox();
            this.lstFeeds = new System.Windows.Forms.ListBox();
            this.tabRss = new System.Windows.Forms.TabControl();
            this.tabRssItems = new System.Windows.Forms.TabPage();
            this.tabBrowse = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tabRss.SuspendLayout();
            this.tabRssItems.SuspendLayout();
            this.tabBrowse.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFeed
            // 
            this.btnLoadFeed.Location = new System.Drawing.Point(571, 26);
            this.btnLoadFeed.Name = "btnLoadFeed";
            this.btnLoadFeed.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFeed.TabIndex = 1;
            this.btnLoadFeed.Text = "Load Feed";
            this.btnLoadFeed.UseVisualStyleBackColor = true;
            this.btnLoadFeed.Click += new System.EventHandler(this.btnLoadFeed_Click);
            // 
            // ddlRssFeeds
            // 
            this.ddlRssFeeds.FormattingEnabled = true;
            this.ddlRssFeeds.Location = new System.Drawing.Point(12, 26);
            this.ddlRssFeeds.Name = "ddlRssFeeds";
            this.ddlRssFeeds.Size = new System.Drawing.Size(537, 21);
            this.ddlRssFeeds.TabIndex = 2;
            // 
            // lstFeeds
            // 
            this.lstFeeds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFeeds.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstFeeds.FormattingEnabled = true;
            this.lstFeeds.Location = new System.Drawing.Point(6, 6);
            this.lstFeeds.Name = "lstFeeds";
            this.lstFeeds.Size = new System.Drawing.Size(718, 342);
            this.lstFeeds.TabIndex = 3;
            this.lstFeeds.DoubleClick += new System.EventHandler(this.lstFeeds_DoubleClick);
            // 
            // tabRss
            // 
            this.tabRss.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRss.Controls.Add(this.tabRssItems);
            this.tabRss.Controls.Add(this.tabBrowse);
            this.tabRss.Location = new System.Drawing.Point(12, 68);
            this.tabRss.Name = "tabRss";
            this.tabRss.SelectedIndex = 0;
            this.tabRss.Size = new System.Drawing.Size(735, 380);
            this.tabRss.TabIndex = 4;
            // 
            // tabRssItems
            // 
            this.tabRssItems.Controls.Add(this.lstFeeds);
            this.tabRssItems.Location = new System.Drawing.Point(4, 22);
            this.tabRssItems.Name = "tabRssItems";
            this.tabRssItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabRssItems.Size = new System.Drawing.Size(727, 354);
            this.tabRssItems.TabIndex = 0;
            this.tabRssItems.Text = "Titles";
            this.tabRssItems.UseVisualStyleBackColor = true;
            // 
            // tabBrowse
            // 
            this.tabBrowse.Controls.Add(this.webBrowser);
            this.tabBrowse.Location = new System.Drawing.Point(4, 22);
            this.tabBrowse.Name = "tabBrowse";
            this.tabBrowse.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowse.Size = new System.Drawing.Size(727, 354);
            this.tabBrowse.TabIndex = 1;
            this.tabBrowse.Text = "Browse";
            this.tabBrowse.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(721, 348);
            this.webBrowser.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 460);
            this.Controls.Add(this.tabRss);
            this.Controls.Add(this.ddlRssFeeds);
            this.Controls.Add(this.btnLoadFeed);
            this.Name = "MainForm";
            this.Text = "RSS Reader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabRss.ResumeLayout(false);
            this.tabRssItems.ResumeLayout(false);
            this.tabBrowse.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFeed;
        private System.Windows.Forms.ComboBox ddlRssFeeds;
        private System.Windows.Forms.ListBox lstFeeds;
        private System.Windows.Forms.TabControl tabRss;
        private System.Windows.Forms.TabPage tabRssItems;
        private System.Windows.Forms.TabPage tabBrowse;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

