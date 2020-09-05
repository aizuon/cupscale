using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing;
using System.Windows.Forms;
using Cupscale.UI;
using Cyotek.Windows.Forms;
using Manina.Windows.Forms;
using TabControl = Manina.Windows.Forms.TabControl;
using ImageBox = Cyotek.Windows.Forms.ImageBox;
using Cupscale.Properties;
using System.Drawing.Drawing2D;

namespace Cupscale
{
	public class MainForm : Form
	{
		private IContainer components = null;

		private Panel leftPanel;

		private Panel panel2;

		private Panel panel1;

		private ImageBox img;

		private Panel rightPanel;

		private TabControl mainTabControl;

		private Tab upscaleTab;

		private Tab tab2;

		private Tab tab3;

		private Tab tab4;

		private TableLayoutPanel tableLayoutPanel1;

		private ImageBox previewImg;

		private Panel panel4;

		private Button upscalePreviewBtn;

		private TableLayoutPanel tableLayoutPanel2;

		private Panel panel3;

		private Label label2;

		private Button button1;

		private Label label1;

		private Panel panel5;

		private Label label3;

		private TabControl modelTabControl;

		private Tab basicMdlTab;

		private ComboBox singleModelBox;

		private Tab interpMdlTab;

		private Tab chainMdlTab;

		private Tab advancedMdlTab;

		private TableLayoutPanel tableLayoutPanel3;

		private Panel panel7;

		private Label label5;

		private Panel panel6;

		private Label label4;

		private ComboBox confTilesize;

		private Label label6;

		private CheckBox confAlpha;

		private Label label7;

		private Button upscalePrevBtn;

		private Button refreshPrevBtn;

		private Button confSaveBtn;

		private Button prevToggleFilterBtn;

		private TableLayoutPanel tableLayoutPanel4;

		private TextBox modelPathBox;

		private Label label8;

		private TextBox logTbox;

		private ProgressBar prevProgbar;

		private Label label10;

		private ComboBox prevOverwriteCombox;

		private Label label11;
        private GroupBox previewGroupbox;
        private ComboBox prevClipboardTypeCombox;
        private Button copyComparisonClipboardBtn;
        private Label label12;
        private GroupBox groupBox1;
        private Label previewInfoLabel;
        private TableLayoutPanel tableLayoutPanel5;
        private Label statusLabel;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private Button confAlphaBgColorBtn;
        private Label label13;
        private TextBox confAlphaBgColorTbox;
        private Label label9;
        private ColorDialog alphaBgColorDialog;
        private Button refreshPrevFullBtn;
        private ComboBox prevOutputFormatCombox;

		public MainForm()
		{
			EsrganData.ReloadModelList();
			Control.CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			ConfigTabHelper.LoadEsrganSettings(confTilesize, confAlpha, modelPathBox, confAlphaBgColorTbox);
			PreviewTabHelper.Init(previewImg, singleModelBox, prevOutputFormatCombox, prevOverwriteCombox);
			UIHelpers.FillModelComboBox(singleModelBox);
			Program.mainForm = this;
			base.WindowState = FormWindowState.Maximized;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Logger.textbox = logTbox;
            UIHelpers.InitCombox(prevOverwriteCombox, 0);
            UIHelpers.InitCombox(prevOutputFormatCombox, 0);
            UIHelpers.InitCombox(prevClipboardTypeCombox, 0);
        }

		public void SetPreviewProgress(float prog, string statusText = "")
		{
			prevProgbar.Value = (int)Math.Round(prog);
            if (!string.IsNullOrWhiteSpace(statusText))
                statusLabel.Text = statusText;
		}

		private void refreshModelsBtn_Click(object sender, EventArgs e)
		{
			EsrganData.ReloadModelList();
		}

		private void confSaveEsrganBtn_Click(object sender, EventArgs e)
		{
			ConfigTabHelper.SaveEsrganSettings(confTilesize, confAlpha, modelPathBox, confAlphaBgColorTbox);
		}

		private void refreshPrevBtn_Click(object sender, EventArgs e)
		{
			PreviewTabHelper.UpscalePreview();
		}

		private void prevToggleFilterBtn_Click(object sender, EventArgs e)
		{
			if (previewImg.InterpolationMode != InterpolationMode.NearestNeighbor)
			{
				previewImg.InterpolationMode = InterpolationMode.NearestNeighbor;
			}
			else
			{
				previewImg.InterpolationMode = InterpolationMode.HighQualityBicubic;
			}
		}

		private void modelTabControl_PageChanged(object sender, PageChangedEventArgs e)
		{
			PreviewTabHelper.UpdateMode(modelTabControl.SelectedIndex);
		}

		private void previewImg_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void previewImg_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
            previewImg.Text = "";
			PreviewMerger.ResetCachedImages();
			//previewImg.Image = Image.FromFile(array[0]);
            previewImg.Image = IOUtils.GetImage(array[0]);
            Program.lastFilename = array[0];
			previewImg.ZoomToFit();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Logger.Log("AutoScrollPosition: " + previewImg.AutoScrollPosition.X + "x" + previewImg.AutoScrollPosition.Y);
			Logger.Log("AutoScrollPosition / Zoom: " + (double)previewImg.AutoScrollPosition.X / previewImg.ZoomFactor + "x" + (double)previewImg.AutoScrollPosition.Y / previewImg.ZoomFactor);
		}

		private void previewImg_MouseDown(object sender, MouseEventArgs e)
		{
			PreviewMerger.ShowOriginal();
		}

		private void previewImg_MouseUp(object sender, MouseEventArgs e)
		{
			PreviewMerger.ShowOutput();
		}

		private void upscalePrevBtn_Click(object sender, EventArgs e)
		{
			PreviewTabHelper.UpscaleImage();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.leftPanel = new Panel();
            this.panel2 = new Panel();
            this.panel1 = new Panel();
            this.img = new Cyotek.Windows.Forms.ImageBox();
            this.rightPanel = new Panel();
            this.mainTabControl = new Manina.Windows.Forms.TabControl();
            this.upscaleTab = new Manina.Windows.Forms.Tab();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.panel5 = new Panel();
            this.modelTabControl = new Manina.Windows.Forms.TabControl();
            this.basicMdlTab = new Manina.Windows.Forms.Tab();
            this.singleModelBox = new ComboBox();
            this.interpMdlTab = new Manina.Windows.Forms.Tab();
            this.chainMdlTab = new Manina.Windows.Forms.Tab();
            this.advancedMdlTab = new Manina.Windows.Forms.Tab();
            this.label3 = new Label();
            this.panel3 = new Panel();
            this.groupBox1 = new GroupBox();
            this.previewInfoLabel = new Label();
            this.previewGroupbox = new GroupBox();
            this.copyComparisonClipboardBtn = new Button();
            this.label12 = new Label();
            this.prevClipboardTypeCombox = new ComboBox();
            this.prevToggleFilterBtn = new Button();
            this.refreshPrevBtn = new Button();
            this.button1 = new Button();
            this.label1 = new Label();
            this.tableLayoutPanel4 = new TableLayoutPanel();
            this.previewImg = new Cyotek.Windows.Forms.ImageBox();
            this.tableLayoutPanel5 = new TableLayoutPanel();
            this.prevProgbar = new ProgressBar();
            this.statusLabel = new Label();
            this.tableLayoutPanel6 = new TableLayoutPanel();
            this.panel4 = new Panel();
            this.label11 = new Label();
            this.prevOutputFormatCombox = new ComboBox();
            this.label10 = new Label();
            this.prevOverwriteCombox = new ComboBox();
            this.upscalePrevBtn = new Button();
            this.label2 = new Label();
            this.upscalePreviewBtn = new Button();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.tab3 = new Manina.Windows.Forms.Tab();
            this.tableLayoutPanel7 = new TableLayoutPanel();
            this.logTbox = new TextBox();
            this.tab4 = new Manina.Windows.Forms.Tab();
            this.tableLayoutPanel3 = new TableLayoutPanel();
            this.panel7 = new Panel();
            this.confAlphaBgColorBtn = new Button();
            this.label13 = new Label();
            this.confAlphaBgColorTbox = new TextBox();
            this.label9 = new Label();
            this.confAlpha = new CheckBox();
            this.label7 = new Label();
            this.confTilesize = new ComboBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.panel6 = new Panel();
            this.modelPathBox = new TextBox();
            this.label8 = new Label();
            this.label4 = new Label();
            this.confSaveBtn = new Button();
            this.alphaBgColorDialog = new ColorDialog();
            this.refreshPrevFullBtn = new Button();
            this.mainTabControl.SuspendLayout();
            this.upscaleTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.modelTabControl.SuspendLayout();
            this.basicMdlTab.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.previewGroupbox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tab3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tab4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.AutoSize = true;
            this.leftPanel.BorderStyle = BorderStyle.Fixed3D;
            this.leftPanel.Location = new System.Drawing.Point(3, 3);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 532);
            this.leftPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 94);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(3, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 94);
            this.panel1.TabIndex = 2;
            // 
            // img
            // 
            this.img.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.img.Location = new System.Drawing.Point(259, 3);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(568, 556);
            this.img.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.BorderStyle = BorderStyle.Fixed3D;
            this.rightPanel.Location = new System.Drawing.Point(833, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(239, 552);
            this.rightPanel.TabIndex = 2;
            // 
            // mainTabControl
            // 
            this.mainTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.mainTabControl.Controls.Add(this.upscaleTab);
            this.mainTabControl.Controls.Add(this.tab2);
            this.mainTabControl.Controls.Add(this.tab3);
            this.mainTabControl.Controls.Add(this.tab4);
            this.mainTabControl.Dock = DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1153, 626);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.Tabs.Add(this.upscaleTab);
            this.mainTabControl.Tabs.Add(this.tab2);
            this.mainTabControl.Tabs.Add(this.tab3);
            this.mainTabControl.Tabs.Add(this.tab4);
            // 
            // upscaleTab
            // 
            this.upscaleTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.upscaleTab.Controls.Add(this.tableLayoutPanel1);
            this.upscaleTab.ForeColor = System.Drawing.Color.White;
            this.upscaleTab.Location = new System.Drawing.Point(1, 21);
            this.upscaleTab.Name = "upscaleTab";
            this.upscaleTab.Size = new System.Drawing.Size(1151, 604);
            this.upscaleTab.Text = "Upscale Preview";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1151, 604);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Dock = DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(344, 598);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.modelTabControl);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(338, 293);
            this.panel5.TabIndex = 1;
            // 
            // modelTabControl
            // 
            this.modelTabControl.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.modelTabControl.Controls.Add(this.basicMdlTab);
            this.modelTabControl.Controls.Add(this.interpMdlTab);
            this.modelTabControl.Controls.Add(this.chainMdlTab);
            this.modelTabControl.Controls.Add(this.advancedMdlTab);
            this.modelTabControl.Location = new System.Drawing.Point(3, 89);
            this.modelTabControl.Name = "modelTabControl";
            this.modelTabControl.SelectedIndex = 0;
            this.modelTabControl.Size = new System.Drawing.Size(330, 200);
            this.modelTabControl.TabIndex = 2;
            this.modelTabControl.Tabs.Add(this.basicMdlTab);
            this.modelTabControl.Tabs.Add(this.interpMdlTab);
            this.modelTabControl.Tabs.Add(this.chainMdlTab);
            this.modelTabControl.Tabs.Add(this.advancedMdlTab);
            this.modelTabControl.PageChanged += new System.EventHandler<Manina.Windows.Forms.PageChangedEventArgs>(this.modelTabControl_PageChanged);
            // 
            // basicMdlTab
            // 
            this.basicMdlTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.basicMdlTab.Controls.Add(this.singleModelBox);
            this.basicMdlTab.Location = new System.Drawing.Point(1, 21);
            this.basicMdlTab.Name = "basicMdlTab";
            this.basicMdlTab.Size = new System.Drawing.Size(328, 178);
            this.basicMdlTab.Text = "Basic";
            // 
            // singleModelBox
            // 
            this.singleModelBox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.singleModelBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.singleModelBox.FlatStyle = FlatStyle.Flat;
            this.singleModelBox.ForeColor = System.Drawing.Color.White;
            this.singleModelBox.FormattingEnabled = true;
            this.singleModelBox.Location = new System.Drawing.Point(8, 8);
            this.singleModelBox.Margin = new Padding(8);
            this.singleModelBox.Name = "singleModelBox";
            this.singleModelBox.Size = new System.Drawing.Size(312, 21);
            this.singleModelBox.TabIndex = 1;
            this.singleModelBox.DropDown += new System.EventHandler(this.singleModelBox_DropDown);
            // 
            // interpMdlTab
            // 
            this.interpMdlTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.interpMdlTab.Location = new System.Drawing.Point(0, 0);
            this.interpMdlTab.Name = "interpMdlTab";
            this.interpMdlTab.Size = new System.Drawing.Size(0, 0);
            this.interpMdlTab.Text = "Interpolate";
            // 
            // chainMdlTab
            // 
            this.chainMdlTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chainMdlTab.Location = new System.Drawing.Point(0, 0);
            this.chainMdlTab.Name = "chainMdlTab";
            this.chainMdlTab.Size = new System.Drawing.Size(0, 0);
            this.chainMdlTab.Text = "Chain";
            // 
            // advancedMdlTab
            // 
            this.advancedMdlTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.advancedMdlTab.Location = new System.Drawing.Point(0, 0);
            this.advancedMdlTab.Name = "advancedMdlTab";
            this.advancedMdlTab.Size = new System.Drawing.Size(0, 0);
            this.advancedMdlTab.Text = "Advanced";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ESRGAN Options";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.refreshPrevFullBtn);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.previewGroupbox);
            this.panel3.Controls.Add(this.prevToggleFilterBtn);
            this.panel3.Controls.Add(this.refreshPrevBtn);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 302);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 293);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.previewInfoLabel);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 38);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview Info";
            // 
            // previewInfoLabel
            // 
            this.previewInfoLabel.AutoSize = true;
            this.previewInfoLabel.Location = new System.Drawing.Point(6, 16);
            this.previewInfoLabel.Name = "previewInfoLabel";
            this.previewInfoLabel.Size = new System.Drawing.Size(66, 13);
            this.previewInfoLabel.TabIndex = 6;
            this.previewInfoLabel.Text = "Zoom: 100%";
            // 
            // previewGroupbox
            // 
            this.previewGroupbox.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.previewGroupbox.Controls.Add(this.copyComparisonClipboardBtn);
            this.previewGroupbox.Controls.Add(this.label12);
            this.previewGroupbox.Controls.Add(this.prevClipboardTypeCombox);
            this.previewGroupbox.ForeColor = System.Drawing.Color.White;
            this.previewGroupbox.Location = new System.Drawing.Point(3, 122);
            this.previewGroupbox.Name = "previewGroupbox";
            this.previewGroupbox.Size = new System.Drawing.Size(330, 93);
            this.previewGroupbox.TabIndex = 5;
            this.previewGroupbox.TabStop = false;
            this.previewGroupbox.Text = "Copy Comparison To Clipboard";
            // 
            // copyComparisonClipboardBtn
            // 
            this.copyComparisonClipboardBtn.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.copyComparisonClipboardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.copyComparisonClipboardBtn.FlatStyle = FlatStyle.Flat;
            this.copyComparisonClipboardBtn.Location = new System.Drawing.Point(6, 53);
            this.copyComparisonClipboardBtn.Name = "copyComparisonClipboardBtn";
            this.copyComparisonClipboardBtn.Size = new System.Drawing.Size(318, 30);
            this.copyComparisonClipboardBtn.TabIndex = 7;
            this.copyComparisonClipboardBtn.Text = "Copy Comparison To Clipboard";
            this.copyComparisonClipboardBtn.UseVisualStyleBackColor = false;
            this.copyComparisonClipboardBtn.Click += new System.EventHandler(this.copyComparisonClipboardBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Comparison Type";
            // 
            // prevClipboardTypeCombox
            // 
            this.prevClipboardTypeCombox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.prevClipboardTypeCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevClipboardTypeCombox.FlatStyle = FlatStyle.Flat;
            this.prevClipboardTypeCombox.ForeColor = System.Drawing.Color.White;
            this.prevClipboardTypeCombox.FormattingEnabled = true;
            this.prevClipboardTypeCombox.Items.AddRange(new object[] {
            "Upscaled Cutout - Side By Side",
            "Upscaled Cutout - 50/50 View"});
            this.prevClipboardTypeCombox.Location = new System.Drawing.Point(117, 24);
            this.prevClipboardTypeCombox.Margin = new Padding(8);
            this.prevClipboardTypeCombox.Name = "prevClipboardTypeCombox";
            this.prevClipboardTypeCombox.Size = new System.Drawing.Size(207, 21);
            this.prevClipboardTypeCombox.TabIndex = 5;
            // 
            // prevToggleFilterBtn
            // 
            this.prevToggleFilterBtn.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.prevToggleFilterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevToggleFilterBtn.FlatStyle = FlatStyle.Flat;
            this.prevToggleFilterBtn.Location = new System.Drawing.Point(3, 221);
            this.prevToggleFilterBtn.Name = "prevToggleFilterBtn";
            this.prevToggleFilterBtn.Size = new System.Drawing.Size(330, 30);
            this.prevToggleFilterBtn.TabIndex = 4;
            this.prevToggleFilterBtn.Text = "Toggle Filtering Mode (Bilinear/Nearest)";
            this.prevToggleFilterBtn.UseVisualStyleBackColor = false;
            this.prevToggleFilterBtn.Click += new System.EventHandler(this.prevToggleFilterBtn_Click);
            // 
            // refreshPrevBtn
            // 
            this.refreshPrevBtn.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.refreshPrevBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.refreshPrevBtn.FlatStyle = FlatStyle.Flat;
            this.refreshPrevBtn.Location = new System.Drawing.Point(171, 257);
            this.refreshPrevBtn.Name = "refreshPrevBtn";
            this.refreshPrevBtn.Size = new System.Drawing.Size(162, 30);
            this.refreshPrevBtn.TabIndex = 3;
            this.refreshPrevBtn.Text = "Refresh Preview (Cutout)";
            this.refreshPrevBtn.UseVisualStyleBackColor = false;
            this.refreshPrevBtn.Click += new System.EventHandler(this.refreshPrevBtn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(397, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh Preview";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preview Options";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.previewImg, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Dock = DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(353, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 96.99611F));
            this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 3.003888F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(495, 598);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // previewImg
            // 
            this.previewImg.AllowDrop = true;
            this.previewImg.BorderStyle = BorderStyle.FixedSingle;
            this.previewImg.Dock = DockStyle.Fill;
            this.previewImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewImg.ForeColor = System.Drawing.Color.White;
            this.previewImg.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.previewImg.GridColorAlternate = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.previewImg.GridScale = Cyotek.Windows.Forms.ImageBoxGridScale.Medium;
            this.previewImg.Location = new System.Drawing.Point(3, 3);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(489, 574);
            this.previewImg.TabIndex = 0;
            this.previewImg.TabStop = false;
            this.previewImg.Text = "Drag And Drop An Image Into This Area";
            this.previewImg.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.previewImg_Zoomed);
            this.previewImg.DragDrop += new DragEventHandler(this.previewImg_DragDrop);
            this.previewImg.DragEnter += new DragEventHandler(this.previewImg_DragEnter);
            this.previewImg.MouseDown += new MouseEventHandler(this.previewImg_MouseDown);
            this.previewImg.MouseUp += new MouseEventHandler(this.previewImg_MouseUp);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.prevProgbar, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.statusLabel, 0, 0);
            this.tableLayoutPanel5.Dock = DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 583);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(489, 12);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // prevProgbar
            // 
            this.prevProgbar.Dock = DockStyle.Fill;
            this.prevProgbar.Location = new System.Drawing.Point(153, 3);
            this.prevProgbar.MarqueeAnimationSpeed = 20;
            this.prevProgbar.Name = "prevProgbar";
            this.prevProgbar.Size = new System.Drawing.Size(333, 6);
            this.prevProgbar.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 12);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "Ready.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel6.Dock = DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(854, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(294, 598);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.prevOutputFormatCombox);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.prevOverwriteCombox);
            this.panel4.Controls.Add(this.upscalePrevBtn);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.upscalePreviewBtn);
            this.panel4.Dock = DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 592);
            this.panel4.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 443);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Output Format";
            // 
            // prevOutputFormatCombox
            // 
            this.prevOutputFormatCombox.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.prevOutputFormatCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevOutputFormatCombox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.prevOutputFormatCombox.FlatStyle = FlatStyle.Flat;
            this.prevOutputFormatCombox.ForeColor = System.Drawing.Color.White;
            this.prevOutputFormatCombox.FormattingEnabled = true;
            this.prevOutputFormatCombox.Items.AddRange(new object[] {
            "PNG",
            "Same As Input",
            "JPEG - High",
            "JPEG - Medium",
            "WEBP - High",
            "WEBP - Medium"});
            this.prevOutputFormatCombox.Location = new System.Drawing.Point(3, 464);
            this.prevOutputFormatCombox.Margin = new Padding(8);
            this.prevOutputFormatCombox.Name = "prevOutputFormatCombox";
            this.prevOutputFormatCombox.Size = new System.Drawing.Size(280, 21);
            this.prevOutputFormatCombox.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Overwrite Mode";
            // 
            // prevOverwriteCombox
            // 
            this.prevOverwriteCombox.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.prevOverwriteCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevOverwriteCombox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.prevOverwriteCombox.FlatStyle = FlatStyle.Flat;
            this.prevOverwriteCombox.ForeColor = System.Drawing.Color.White;
            this.prevOverwriteCombox.FormattingEnabled = true;
            this.prevOverwriteCombox.Items.AddRange(new object[] {
            "No - Add Suffix To Upscaled Images",
            "Yes - Always Replace Input Image",
            "Yes - Overwrite Only If File Extension Matches"});
            this.prevOverwriteCombox.Location = new System.Drawing.Point(3, 414);
            this.prevOverwriteCombox.Margin = new Padding(8);
            this.prevOverwriteCombox.Name = "prevOverwriteCombox";
            this.prevOverwriteCombox.Size = new System.Drawing.Size(280, 21);
            this.prevOverwriteCombox.TabIndex = 2;
            // 
            // upscalePrevBtn
            // 
            this.upscalePrevBtn.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.upscalePrevBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.upscalePrevBtn.FlatStyle = FlatStyle.Flat;
            this.upscalePrevBtn.Location = new System.Drawing.Point(3, 559);
            this.upscalePrevBtn.Name = "upscalePrevBtn";
            this.upscalePrevBtn.Size = new System.Drawing.Size(280, 30);
            this.upscalePrevBtn.TabIndex = 2;
            this.upscalePrevBtn.Text = "Process And Save";
            this.upscalePrevBtn.UseVisualStyleBackColor = false;
            this.upscalePrevBtn.Click += new System.EventHandler(this.upscalePrevBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Saving Options";
            // 
            // upscalePreviewBtn
            // 
            this.upscalePreviewBtn.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.upscalePreviewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.upscalePreviewBtn.FlatStyle = FlatStyle.Flat;
            this.upscalePreviewBtn.ForeColor = System.Drawing.Color.White;
            this.upscalePreviewBtn.Location = new System.Drawing.Point(3, 758);
            this.upscalePreviewBtn.Name = "upscalePreviewBtn";
            this.upscalePreviewBtn.Size = new System.Drawing.Size(289, 30);
            this.upscalePreviewBtn.TabIndex = 0;
            this.upscalePreviewBtn.Text = "Upscale And Save";
            this.upscalePreviewBtn.UseVisualStyleBackColor = false;
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab2.ForeColor = System.Drawing.Color.White;
            this.tab2.Location = new System.Drawing.Point(0, 0);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(0, 0);
            this.tab2.Text = "Batch Upscale";
            // 
            // tab3
            // 
            this.tab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab3.Controls.Add(this.tableLayoutPanel7);
            this.tab3.ForeColor = System.Drawing.Color.White;
            this.tab3.Location = new System.Drawing.Point(0, 0);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(0, 0);
            this.tab3.Text = "Log Output";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 98F));
            this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            this.tableLayoutPanel7.Controls.Add(this.logTbox, 1, 1);
            this.tableLayoutPanel7.Dock = DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 0.990099F));
            this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 98.0198F));
            this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 0.990099F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // logTbox
            // 
            this.logTbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.logTbox.Dock = DockStyle.Fill;
            this.logTbox.ForeColor = System.Drawing.Color.Silver;
            this.logTbox.Location = new System.Drawing.Point(24, 24);
            this.logTbox.Margin = new Padding(24);
            this.logTbox.Multiline = true;
            this.logTbox.Name = "logTbox";
            this.logTbox.ScrollBars = ScrollBars.Vertical;
            this.logTbox.Size = new System.Drawing.Size(1, 1);
            this.logTbox.TabIndex = 11;
            // 
            // tab4
            // 
            this.tab4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab4.Controls.Add(this.tableLayoutPanel3);
            this.tab4.ForeColor = System.Drawing.Color.White;
            this.tab4.Location = new System.Drawing.Point(1, 21);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(1151, 604);
            this.tab4.Text = "Settings";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.confSaveBtn, 1, 1);
            this.tableLayoutPanel3.Dock = DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1151, 604);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.panel7.BorderStyle = BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.confAlphaBgColorBtn);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.confAlphaBgColorTbox);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.confAlpha);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.confTilesize);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(569, 558);
            this.panel7.TabIndex = 4;
            // 
            // confAlphaBgColorBtn
            // 
            this.confAlphaBgColorBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confAlphaBgColorBtn.FlatStyle = FlatStyle.Flat;
            this.confAlphaBgColorBtn.ForeColor = System.Drawing.Color.White;
            this.confAlphaBgColorBtn.Location = new System.Drawing.Point(242, 135);
            this.confAlphaBgColorBtn.Name = "confAlphaBgColorBtn";
            this.confAlphaBgColorBtn.Size = new System.Drawing.Size(28, 23);
            this.confAlphaBgColorBtn.TabIndex = 10;
            this.confAlphaBgColorBtn.Text = "...";
            this.confAlphaBgColorBtn.UseVisualStyleBackColor = false;
            this.confAlphaBgColorBtn.Click += new System.EventHandler(this.confAlphaBgColorBtn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label13.Location = new System.Drawing.Point(288, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(250, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "If Alpha is disabled, this color will fill the background";
            // 
            // confAlphaBgColorTbox
            // 
            this.confAlphaBgColorTbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confAlphaBgColorTbox.ForeColor = System.Drawing.Color.White;
            this.confAlphaBgColorTbox.Location = new System.Drawing.Point(170, 137);
            this.confAlphaBgColorTbox.Name = "confAlphaBgColorTbox";
            this.confAlphaBgColorTbox.Size = new System.Drawing.Size(66, 20);
            this.confAlphaBgColorTbox.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Background Color";
            // 
            // confAlpha
            // 
            this.confAlpha.AutoSize = true;
            this.confAlpha.Location = new System.Drawing.Point(170, 110);
            this.confAlpha.Name = "confAlpha";
            this.confAlpha.Size = new System.Drawing.Size(15, 14);
            this.confAlpha.TabIndex = 5;
            this.confAlpha.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Enable Alpha";
            // 
            // confTilesize
            // 
            this.confTilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confTilesize.FlatStyle = FlatStyle.Flat;
            this.confTilesize.ForeColor = System.Drawing.Color.White;
            this.confTilesize.FormattingEnabled = true;
            this.confTilesize.Items.AddRange(new object[] {
            "2048",
            "1536",
            "1024",
            "768",
            "512",
            "384",
            "256",
            "192",
            "128"});
            this.confTilesize.Location = new System.Drawing.Point(170, 77);
            this.confTilesize.Margin = new Padding(8);
            this.confTilesize.Name = "confTilesize";
            this.confTilesize.Size = new System.Drawing.Size(100, 21);
            this.confTilesize.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tile Size (HR)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "ESRGAN Settings";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.panel6.BorderStyle = BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.modelPathBox);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(578, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(570, 558);
            this.panel6.TabIndex = 3;
            // 
            // modelPathBox
            // 
            this.modelPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modelPathBox.ForeColor = System.Drawing.Color.White;
            this.modelPathBox.Location = new System.Drawing.Point(197, 77);
            this.modelPathBox.Name = "modelPathBox";
            this.modelPathBox.Size = new System.Drawing.Size(338, 20);
            this.modelPathBox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Models Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cupscale Settings";
            // 
            // confSaveBtn
            // 
            this.confSaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confSaveBtn.Dock = DockStyle.Fill;
            this.confSaveBtn.FlatStyle = FlatStyle.Flat;
            this.confSaveBtn.Location = new System.Drawing.Point(578, 567);
            this.confSaveBtn.Name = "confSaveBtn";
            this.confSaveBtn.Size = new System.Drawing.Size(570, 34);
            this.confSaveBtn.TabIndex = 3;
            this.confSaveBtn.Text = "Save All Settings";
            this.confSaveBtn.UseVisualStyleBackColor = false;
            this.confSaveBtn.Click += new System.EventHandler(this.confSaveEsrganBtn_Click);
            // 
            // refreshPrevFullBtn
            // 
            this.refreshPrevFullBtn.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.refreshPrevFullBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.refreshPrevFullBtn.FlatStyle = FlatStyle.Flat;
            this.refreshPrevFullBtn.Location = new System.Drawing.Point(3, 257);
            this.refreshPrevFullBtn.Name = "refreshPrevFullBtn";
            this.refreshPrevFullBtn.Size = new System.Drawing.Size(162, 30);
            this.refreshPrevFullBtn.TabIndex = 7;
            this.refreshPrevFullBtn.Text = "Refresh Preview (Full Image)";
            this.refreshPrevFullBtn.UseVisualStyleBackColor = false;
            this.refreshPrevFullBtn.Click += new System.EventHandler(this.refreshPrevFullBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1153, 626);
            this.Controls.Add(this.mainTabControl);
            this.Icon = global::Cupscale.Properties.Resources.CupscaleLogo1;
            this.Name = "MainForm";
            this.Text = "Cupscale GUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.upscaleTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.modelTabControl.ResumeLayout(false);
            this.basicMdlTab.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.previewGroupbox.ResumeLayout(false);
            this.previewGroupbox.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tab3.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tab4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

		}

        private void singleModelBox_DropDown(object sender, EventArgs e)
        {
            UIHelpers.FillModelComboBox(singleModelBox);
        }

        private void copyComparisonClipboardBtn_Click(object sender, EventArgs e)
        {
            if(prevClipboardTypeCombox.SelectedIndex == 0) ClipboardPreview.CopyToClipboardSideBySide();
            if(prevClipboardTypeCombox.SelectedIndex == 1) ClipboardPreview.CopyToClipboardSlider();
        }

        private void previewImg_Zoomed(object sender, ImageBoxZoomEventArgs e)
        {
            UpdatePreviewInfo();
        }

        void UpdatePreviewInfo ()
        {
            previewInfoLabel.Text = "Zoom: " + previewImg.Zoom + "%";
        }

        private void confAlphaBgColorBtn_Click(object sender, EventArgs e)
        {
            alphaBgColorDialog.ShowDialog();
            string colorStr = ColorTranslator.ToHtml(Color.FromArgb(alphaBgColorDialog.Color.ToArgb())).Replace("#", "") + "FF";
            confAlphaBgColorTbox.Text = colorStr;
            Config.Set("alphaBgColor", colorStr);
        }

        private void refreshPrevFullBtn_Click(object sender, EventArgs e)
        {
            PreviewTabHelper.UpscalePreview(true);
        }
    }
}
