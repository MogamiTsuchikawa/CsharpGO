namespace MainEditor
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.すべてのファイルを保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.インポートToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.保存して終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ビルドToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ビルドして実行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ビルドのみToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exeがある場所を開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.デバックToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.未実装ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ツールToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.プロジェクトToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsフォームの追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.クラスの追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.プロジェクト設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.インストーラー作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.azukiControl1 = new Sgry.Azuki.WinForms.AzukiControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.windowsフォームの追加ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.クラスの追加ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.ビルドToolStripMenuItem,
            this.デバックToolStripMenuItem,
            this.ツールToolStripMenuItem,
            this.プロジェクトToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.すべてのファイルを保存ToolStripMenuItem,
            this.インポートToolStripMenuItem,
            this.toolStripSeparator3,
            this.保存して終了ToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル( *ﾟ▽ﾟ*  っ)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // すべてのファイルを保存ToolStripMenuItem
            // 
            this.すべてのファイルを保存ToolStripMenuItem.Name = "すべてのファイルを保存ToolStripMenuItem";
            this.すべてのファイルを保存ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.すべてのファイルを保存ToolStripMenuItem.Text = "すべてのファイルを保存";
            // 
            // インポートToolStripMenuItem
            // 
            this.インポートToolStripMenuItem.Name = "インポートToolStripMenuItem";
            this.インポートToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.インポートToolStripMenuItem.Text = "インポート";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // 保存して終了ToolStripMenuItem
            // 
            this.保存して終了ToolStripMenuItem.Name = "保存して終了ToolStripMenuItem";
            this.保存して終了ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.保存して終了ToolStripMenuItem.Text = "保存して終了";
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.終了ToolStripMenuItem.Text = "終了ヽ(；▽；)ノ";
            // 
            // ビルドToolStripMenuItem
            // 
            this.ビルドToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ビルドして実行ToolStripMenuItem,
            this.ビルドのみToolStripMenuItem,
            this.toolStripSeparator4,
            this.exeがある場所を開くToolStripMenuItem});
            this.ビルドToolStripMenuItem.Name = "ビルドToolStripMenuItem";
            this.ビルドToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.ビルドToolStripMenuItem.Text = "ビルド＼(^o^)／";
            // 
            // ビルドして実行ToolStripMenuItem
            // 
            this.ビルドして実行ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ビルドして実行ToolStripMenuItem.Image")));
            this.ビルドして実行ToolStripMenuItem.Name = "ビルドして実行ToolStripMenuItem";
            this.ビルドして実行ToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.ビルドして実行ToolStripMenuItem.Text = "ビルドして実行(((o(*ﾟ▽ﾟ*っ)っ-=三";
            this.ビルドして実行ToolStripMenuItem.Click += new System.EventHandler(this.ビルドして実行ToolStripMenuItem_Click);
            // 
            // ビルドのみToolStripMenuItem
            // 
            this.ビルドのみToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ビルドのみToolStripMenuItem.Image")));
            this.ビルドのみToolStripMenuItem.Name = "ビルドのみToolStripMenuItem";
            this.ビルドのみToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.ビルドのみToolStripMenuItem.Text = "ビルドのみ( *ﾟ▽ﾟ*  っ)З ";
            this.ビルドのみToolStripMenuItem.Click += new System.EventHandler(this.ビルドのみToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
            // 
            // exeがある場所を開くToolStripMenuItem
            // 
            this.exeがある場所を開くToolStripMenuItem.Name = "exeがある場所を開くToolStripMenuItem";
            this.exeがある場所を開くToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.exeがある場所を開くToolStripMenuItem.Text = "exeがある場所を開く";
            // 
            // デバックToolStripMenuItem
            // 
            this.デバックToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.未実装ToolStripMenuItem});
            this.デバックToolStripMenuItem.Name = "デバックToolStripMenuItem";
            this.デバックToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.デバックToolStripMenuItem.Text = "デバック";
            // 
            // 未実装ToolStripMenuItem
            // 
            this.未実装ToolStripMenuItem.Name = "未実装ToolStripMenuItem";
            this.未実装ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.未実装ToolStripMenuItem.Text = "未実装Σ（・□・；）";
            // 
            // ツールToolStripMenuItem
            // 
            this.ツールToolStripMenuItem.Name = "ツールToolStripMenuItem";
            this.ツールToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.ツールToolStripMenuItem.Text = "ツールΣ（・□・；）";
            // 
            // プロジェクトToolStripMenuItem
            // 
            this.プロジェクトToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsフォームの追加ToolStripMenuItem,
            this.クラスの追加ToolStripMenuItem,
            this.toolStripSeparator1,
            this.プロジェクト設定ToolStripMenuItem,
            this.toolStripSeparator5,
            this.インストーラー作成ToolStripMenuItem});
            this.プロジェクトToolStripMenuItem.Name = "プロジェクトToolStripMenuItem";
            this.プロジェクトToolStripMenuItem.Size = new System.Drawing.Size(178, 20);
            this.プロジェクトToolStripMenuItem.Text = "プロジェクト( *ﾟ▽ﾟ*  っ)З ぽぽー！";
            // 
            // windowsフォームの追加ToolStripMenuItem
            // 
            this.windowsフォームの追加ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("windowsフォームの追加ToolStripMenuItem.Image")));
            this.windowsフォームの追加ToolStripMenuItem.Name = "windowsフォームの追加ToolStripMenuItem";
            this.windowsフォームの追加ToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.windowsフォームの追加ToolStripMenuItem.Text = "Windowsフォームの追加( *ﾟ▽ﾟ*  っ)З ";
            this.windowsフォームの追加ToolStripMenuItem.Click += new System.EventHandler(this.windowsフォームの追加ToolStripMenuItem_Click);
            // 
            // クラスの追加ToolStripMenuItem
            // 
            this.クラスの追加ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("クラスの追加ToolStripMenuItem.Image")));
            this.クラスの追加ToolStripMenuItem.Name = "クラスの追加ToolStripMenuItem";
            this.クラスの追加ToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.クラスの追加ToolStripMenuItem.Text = "クラスの追加";
            this.クラスの追加ToolStripMenuItem.Click += new System.EventHandler(this.クラスの追加ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // プロジェクト設定ToolStripMenuItem
            // 
            this.プロジェクト設定ToolStripMenuItem.Name = "プロジェクト設定ToolStripMenuItem";
            this.プロジェクト設定ToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.プロジェクト設定ToolStripMenuItem.Text = "プロジェクト設定";
            this.プロジェクト設定ToolStripMenuItem.Click += new System.EventHandler(this.プロジェクト設定ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(258, 6);
            // 
            // インストーラー作成ToolStripMenuItem
            // 
            this.インストーラー作成ToolStripMenuItem.Name = "インストーラー作成ToolStripMenuItem";
            this.インストーラー作成ToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.インストーラー作成ToolStripMenuItem.Text = "インストーラー作成";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeView1.Location = new System.Drawing.Point(0, 51);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(260, 375);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(264, 51);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 375);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.azukiControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(451, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "main.cs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // azukiControl1
            // 
            this.azukiControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.azukiControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.azukiControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azukiControl1.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.azukiControl1.FirstVisibleLine = 0;
            this.azukiControl1.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            fontInfo1.Name = "MS UI Gothic";
            fontInfo1.Size = 9;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.azukiControl1.FontInfo = fontInfo1;
            this.azukiControl1.ForeColor = System.Drawing.Color.Red;
            this.azukiControl1.Location = new System.Drawing.Point(0, 0);
            this.azukiControl1.Name = "azukiControl1";
            this.azukiControl1.ScrollPos = new System.Drawing.Point(0, 0);
            this.azukiControl1.Size = new System.Drawing.Size(451, 349);
            this.azukiControl1.TabIndex = 0;
            this.azukiControl1.ViewWidth = 4129;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(723, 27);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "保存";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "すべて保存";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsフォームの追加ToolStripMenuItem1,
            this.クラスの追加ToolStripMenuItem1});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(36, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // windowsフォームの追加ToolStripMenuItem1
            // 
            this.windowsフォームの追加ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("windowsフォームの追加ToolStripMenuItem1.Image")));
            this.windowsフォームの追加ToolStripMenuItem1.Name = "windowsフォームの追加ToolStripMenuItem1";
            this.windowsフォームの追加ToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.windowsフォームの追加ToolStripMenuItem1.Text = "Windowsフォームの追加";
            this.windowsフォームの追加ToolStripMenuItem1.Click += new System.EventHandler(this.windowsフォームの追加ToolStripMenuItem1_Click);
            // 
            // クラスの追加ToolStripMenuItem1
            // 
            this.クラスの追加ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("クラスの追加ToolStripMenuItem1.Image")));
            this.クラスの追加ToolStripMenuItem1.Name = "クラスの追加ToolStripMenuItem1";
            this.クラスの追加ToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.クラスの追加ToolStripMenuItem1.Text = "クラスの追加";
            this.クラスの追加ToolStripMenuItem1.Click += new System.EventHandler(this.クラスの追加ToolStripMenuItem1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.textBox1.Location = new System.Drawing.Point(4, 431);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(715, 137);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "( *ﾟ▽ﾟ*  っ)З ぽぽー！";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(723, 571);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "C#_GO chomadoEdition( *ﾟ▽ﾟ*  っ)З ぽぽー！";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ビルドToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem デバックToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ツールToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Sgry.Azuki.WinForms.AzukiControl azukiControl1;
        private System.Windows.Forms.ToolStripMenuItem ビルドして実行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ビルドのみToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem プロジェクトToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsフォームの追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem クラスの追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem 未実装ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem windowsフォームの追加ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem クラスの追加ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem プロジェクト設定ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem すべてのファイルを保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem インポートToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 保存して終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exeがある場所を開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem インストーラー作成ToolStripMenuItem;
    }
}

