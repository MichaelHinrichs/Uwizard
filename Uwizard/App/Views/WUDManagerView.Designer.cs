using System.Drawing;
using System.Windows.Forms;
using Uwizard.App.Models;
using Uwizard.Entities.Enums;
using Uwizard.Resources.Languages;

namespace Uwizard.App.Views
{
    partial class WUDManagerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            SuspendLayout();

            InitializeControls();

            Controls.Add(ShowGameListCheckBox);
            Controls.Add(WUDSplitter);
            Controls.Add(ScrubWUDButton);
            Controls.Add(ShowFullCoverCheckBox);
            Controls.Add(SaveGameInformationButton);
            Controls.Add(ExtractGameFilesButton);
            Controls.Add(GameInformationGroupBox);
            Controls.Add(TitleKeyGroupBox);
            Controls.Add(GameNameGroupBox);
            Controls.Add(GameIDGroupBox);
            Controls.Add(OpenWUDButton);
            Controls.Add(GameTBDPicture);
            Controls.Add(DownloadTextBox);

            WUDManagerViewLoad();

            Location = new Point(4, 22);
            Name = "WUDManagerPage";
            Padding = new Padding(3);
            Size = new Size(507, 495);
            TabIndex = 0;
            Text = Strings.WUDManager;
            UseVisualStyleBackColor = true;
            Visible = true;

            ResumeLayout(false);
        }

        #endregion

        private void InitializeControls()
        {
            #region CheckBoxes
            // 
            // ShowGameListCheckBox
            // 
            ShowGameListCheckBox.Anchor = AnchorStyles.Bottom;
            ShowGameListCheckBox.AutoSize = true;
            ShowGameListCheckBox.DataBindings.Add("Checked", ViewModel, "ShowGameList");
            ShowGameListCheckBox.Location = new Point(64, 429);
            ShowGameListCheckBox.Checked = true;
            ViewModel.ShowGameList = true;
            ShowGameListCheckBox.Name = "ShowGameListCheckBox";
            ShowGameListCheckBox.Size = new Size(103, 17);
            ShowGameListCheckBox.TabIndex = 13;
            ShowGameListCheckBox.Text = Strings.ShowGameList;
            ShowGameListCheckBox.UseVisualStyleBackColor = true;
            ShowGameListCheckBox.CheckedChanged += new System.EventHandler(ShowGameListCheckedChanged);

            // 
            // ShowFullCoverCheckBox
            // 
            ShowFullCoverCheckBox.Anchor = AnchorStyles.Bottom;
            ShowFullCoverCheckBox.AutoSize = true;
            ShowFullCoverCheckBox.Location = new Point(64, 411);
            ShowFullCoverCheckBox.Name = "ShowFullCoverCheckBox";
            ShowFullCoverCheckBox.Size = new Size(103, 17);
            ShowFullCoverCheckBox.TabIndex = 10;
            ShowFullCoverCheckBox.Text = Strings.ShowFullCover;
            ShowFullCoverCheckBox.UseVisualStyleBackColor = true;
            ShowFullCoverCheckBox.CheckedChanged += new System.EventHandler(this.ShowFullCoverChecked);
            #endregion

            #region Buttons
            // 
            // ScrubWUDButton
            // 
            ScrubWUDButton.Anchor = AnchorStyles.None | AnchorStyles.Right | AnchorStyles.Top;
            ScrubWUDButton.Location = new Point(297, 35);
            ScrubWUDButton.Name = "ScrubWUDButton";
            ScrubWUDButton.Size = new Size(207, 23);
            ScrubWUDButton.TabIndex = 11;
            ScrubWUDButton.Text = Strings.WiiUGameScrub;
            WUDManagerButtonToolTip.SetToolTip(ScrubWUDButton, Strings.WiiUGameScrubInformation);
            ScrubWUDButton.UseVisualStyleBackColor = true;
            ScrubWUDButton.Click += new System.EventHandler(ScrubWUDButtonClicked);

            // 
            // SaveGameInformationButton
            // 
            SaveGameInformationButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            SaveGameInformationButton.Enabled = false;
            SaveGameInformationButton.Location = new Point(297, 433);
            SaveGameInformationButton.Name = "SaveGameInformationButton";
            SaveGameInformationButton.Size = new Size(207, 23);
            SaveGameInformationButton.TabIndex = 8;
            SaveGameInformationButton.Text = Strings.GameInformationSave;
            WUDManagerButtonToolTip.SetToolTip(SaveGameInformationButton, Strings.GameInformationSaveInformation);
            SaveGameInformationButton.UseVisualStyleBackColor = true;
            SaveGameInformationButton.Click += new System.EventHandler(SaveGameInformationButtonClicked);

            // 
            // ExtractGameFilesButton
            // 
            ExtractGameFilesButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ExtractGameFilesButton.Enabled = false;
            ExtractGameFilesButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExtractGameFilesButton.Location = new Point(297, 462);
            ExtractGameFilesButton.Name = "ExtractGameFilesButton";
            ExtractGameFilesButton.Size = new Size(207, 30);
            ExtractGameFilesButton.TabIndex = 7;
            ExtractGameFilesButton.Text = Strings.GameFilesExtract;
            ExtractGameFilesButton.UseVisualStyleBackColor = true;
            ExtractGameFilesButton.Click += new System.EventHandler(ExtractGameFilesButtonClicked);

            // 
            // ImportGameKeySHA1Button
            // 
            ImportGameKeySHA1Button.Enabled = false;
            ImportGameKeySHA1Button.Font = new Font("Microsoft Sans Serif", ((LanguagesEnum)Properties.Settings.Default.Language == LanguagesEnum.English) ? 7F : 6F);
            ImportGameKeySHA1Button.Location = new Point(6, 37);
            ImportGameKeySHA1Button.Name = "ImportGameKeySHA1Button";
            ImportGameKeySHA1Button.Size = new Size(46, 20);
            ImportGameKeySHA1Button.TabIndex = 1;
            ImportGameKeySHA1Button.Text = Strings.Import;
            ImportGameKeySHA1Button.UseVisualStyleBackColor = true;
            ImportGameKeySHA1Button.Click += new System.EventHandler(ImportSHA1ButtonClicked);

            // 
            // OpenWUDButton
            // 
            OpenWUDButton.Anchor = AnchorStyles.None | AnchorStyles.Right | AnchorStyles.Top;
            OpenWUDButton.Location = new Point(297, 6);
            OpenWUDButton.Name = "OpenWUDButton";
            OpenWUDButton.Size = new Size(207, 23);
            OpenWUDButton.TabIndex = 2;
            OpenWUDButton.Text = Strings.WiiUGameOpen;
            OpenWUDButton.UseVisualStyleBackColor = true;
            OpenWUDButton.Click += new System.EventHandler(OpenWUDButtonClicked);

            #endregion

            // 
            // GameInformationGroupBox
            // 
            GameInformationGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GameInformationGroupBox.Controls.Add(GameDescriptionTextBox);
            GameInformationGroupBox.Location = new Point(297, 244);
            GameInformationGroupBox.Name = "GameInformationGroupBox";
            GameInformationGroupBox.Size = new Size(207, 184);
            GameInformationGroupBox.TabIndex = 6;
            GameInformationGroupBox.TabStop = false;
            GameInformationGroupBox.Text = Strings.GameInformation;
            // 
            // GameDescriptionTextBox
            // 
            GameDescriptionTextBox.BackColor = SystemColors.Control;
            GameDescriptionTextBox.Location = new Point(6, 19);
            GameDescriptionTextBox.Multiline = true;
            GameDescriptionTextBox.Name = "GameDescriptionTextBox";
            GameDescriptionTextBox.ReadOnly = true;
            GameDescriptionTextBox.ScrollBars = ScrollBars.Both;
            GameDescriptionTextBox.Size = new Size(195, 159);
            GameDescriptionTextBox.TabIndex = 0;
            // 
            // TitleKeyGroupBox
            // 
            TitleKeyGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TitleKeyGroupBox.Controls.Add(GameTitleKeySHA1Status);
            TitleKeyGroupBox.Controls.Add(ImportGameKeySHA1Button);
            TitleKeyGroupBox.Controls.Add(GameTitleKeyTextBox);
            TitleKeyGroupBox.Location = new Point(297, 179);
            TitleKeyGroupBox.Name = "TitleKeyGroupBox";
            TitleKeyGroupBox.Size = new Size(207, 63);
            TitleKeyGroupBox.TabIndex = 5;
            TitleKeyGroupBox.TabStop = false;
            TitleKeyGroupBox.Text = Strings.TitleKey;
            // 
            // GameTitleKeySHA1Status
            // 
            GameTitleKeySHA1Status.BackColor = SystemColors.Control;
            GameTitleKeySHA1Status.Font = new Font("Microsoft Sans Serif", 7.5F);
            GameTitleKeySHA1Status.ForeColor = Color.Black;
            GameTitleKeySHA1Status.Location = new Point(55, 39);
            GameTitleKeySHA1Status.Name = "GameTitleKeySHA1Status";
            GameTitleKeySHA1Status.Size = new Size(149, 18);
            GameTitleKeySHA1Status.TabIndex = 10;
            GameTitleKeySHA1Status.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // GameTitleKeyTextBox
            // 
            GameTitleKeyTextBox.BackColor = SystemColors.Control;
            GameTitleKeyTextBox.CharacterCasing = CharacterCasing.Upper;
            GameTitleKeyTextBox.Font = new Font("Lucida Console", 7.5F);
            GameTitleKeyTextBox.ForeColor = SystemColors.WindowText;
            GameTitleKeyTextBox.Location = new Point(3, 19);
            GameTitleKeyTextBox.MaxLength = 32;
            GameTitleKeyTextBox.Name = "GameTitleKeyTextBox";
            GameTitleKeyTextBox.ReadOnly = true;
            GameTitleKeyTextBox.Size = new Size(201, 17);
            GameTitleKeyTextBox.TabIndex = 0;
            GameTitleKeyTextBox.TextChanged += new System.EventHandler(GameTitleKeyTextBoxTextChanged);
            GameTitleKeyTextBox.Leave += new System.EventHandler(GameTitleKeyTextBoxLeave);
            GameTitleKeyTextBox.Enter += new System.EventHandler(GameTitleKeyTextBoxEnter);
            // 
            // GameNameGroupBox
            // 
            GameNameGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GameNameGroupBox.Controls.Add(GameRegionTextBox);
            GameNameGroupBox.Controls.Add(GameNameTextBox);
            GameNameGroupBox.Location = new Point(297, 108);
            GameNameGroupBox.Name = "GameNameGroupBox";
            GameNameGroupBox.Size = new Size(207, 70);
            GameNameGroupBox.TabIndex = 4;
            GameNameGroupBox.TabStop = false;
            GameNameGroupBox.Text = Strings.WiiUGameName;
            // 
            // GameRegionTextBox
            // 
            GameRegionTextBox.BackColor = SystemColors.Control;
            GameRegionTextBox.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GameRegionTextBox.Location = new Point(6, 43);
            GameRegionTextBox.Name = "gregion";
            GameRegionTextBox.ReadOnly = true;
            GameRegionTextBox.Size = new Size(195, 20);
            GameRegionTextBox.TabIndex = 1;
            GameRegionTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // GameNameTextBox
            // 
            GameNameTextBox.BackColor = SystemColors.Control;
            GameNameTextBox.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GameNameTextBox.Location = new Point(6, 14);
            GameNameTextBox.Name = "GameNameTextBox";
            GameNameTextBox.ReadOnly = true;
            GameNameTextBox.Size = new Size(195, 23);
            GameNameTextBox.TabIndex = 0;
            GameNameTextBox.TextAlign = HorizontalAlignment.Center;
            GameNameTextBox.TextChanged += new System.EventHandler(GameNameTextBoxTextChanged);
            // 
            // GameIDGroupBox
            // 
            GameIDGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GameIDGroupBox.Controls.Add(GameIDTextBox);
            GameIDGroupBox.Location = new Point(297, 64);
            GameIDGroupBox.Name = "GameIDGroupBox";
            GameIDGroupBox.Size = new Size(207, 43);
            GameIDGroupBox.TabIndex = 3;
            GameIDGroupBox.TabStop = false;
            GameIDGroupBox.Text = Strings.WiiUGameID;
            // 
            // GameIDTextBox
            // 
            GameIDTextBox.BackColor = SystemColors.Control;
            GameIDTextBox.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GameIDTextBox.Location = new Point(6, 14);
            GameIDTextBox.Name = "GameIDTextBox";
            GameIDTextBox.ReadOnly = true;
            GameIDTextBox.Size = new Size(195, 23);
            GameIDTextBox.TabIndex = 0;
            GameIDTextBox.TextAlign = HorizontalAlignment.Center;

            // 
            // GameTBDPicture
            // 
            GameTBDPicture.Anchor = AnchorStyles.Bottom;
            GameTBDPicture.Cursor = Cursors.Hand;
            GameTBDPicture.Image = Properties.Resources.GameTDB;
            GameTBDPicture.Location = new Point(6, 448);
            GameTBDPicture.Name = "GameTBDPicture";
            GameTBDPicture.Size = new Size(285, 44);
            GameTBDPicture.SizeMode = PictureBoxSizeMode.Zoom;
            GameTBDPicture.TabIndex = 1;
            GameTBDPicture.TabStop = false;
            GameTBDPicture.Click += new System.EventHandler(GameTBDPictureClicked);
            // 
            // DownloadTextBox
            // 
            DownloadTextBox.BackColor = SystemColors.Control;
            DownloadTextBox.Location = new Point(6, 6);
            DownloadTextBox.Multiline = true;
            DownloadTextBox.Name = "DownloadTextBox";
            DownloadTextBox.ReadOnly = true;
            DownloadTextBox.Size = new Size(285, 401);
            DownloadTextBox.TabIndex = 9;
            DownloadTextBox.Visible = false;
            DownloadTextBox.WordWrap = false;

            // 
            // WUDSplitter
            // 
            WUDSplitter.Location = new Point(6, 6);
            WUDSplitter.Name = "WUDSplitter";
            WUDSplitter.Orientation = Orientation.Horizontal;
            // 
            // WUDSplitter.Panel1
            // 
            WUDSplitter.Panel1.Controls.Add(value: WUDListClearFoldersButton);
            WUDSplitter.Panel1.Controls.Add(WUDListAddFolderButton);
            WUDSplitter.Panel1.Controls.Add(WUDList);
            WUDSplitter.Panel1MinSize = 75;
            // 
            // wud_splitter.Panel2
            // 
            WUDSplitter.Panel2.Controls.Add(GameCoverPicture);
            WUDSplitter.Size = new Size(285, 401);
            WUDSplitter.SplitterDistance = 200;
            WUDSplitter.TabIndex = 12;
            WUDSplitter.SplitterMoved += new SplitterEventHandler(WUDSplitterSplitterMoved);
            // 
            // WUDListClearFoldersButton
            // 
            WUDListClearFoldersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            WUDListClearFoldersButton.Location = new Point(141, 175);
            WUDListClearFoldersButton.Name = "WUDListClearFoldersButton";
            WUDListClearFoldersButton.Size = new Size(144, 23);
            WUDListClearFoldersButton.TabIndex = 2;
            WUDListClearFoldersButton.Text = Strings.CreateFolderList;
            WUDManagerButtonToolTip.SetToolTip(WUDListClearFoldersButton, Strings.DirectoryRemoveAll);
            WUDListClearFoldersButton.UseVisualStyleBackColor = true;
            WUDListClearFoldersButton.Click += new System.EventHandler(WUDListClearFoldersButtonClicked);
            // 
            // WUDListAddFolderButton
            // 
            WUDListAddFolderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            WUDListAddFolderButton.Location = new Point(0, 175);
            WUDListAddFolderButton.Name = "WUDListAddFolderButton";
            WUDListAddFolderButton.Size = new Size(135, 23);
            WUDListAddFolderButton.TabIndex = 1;
            WUDListAddFolderButton.Text = "Add Folder";
            WUDManagerButtonToolTip.SetToolTip(WUDListAddFolderButton, Strings.DirectoryAdd);
            WUDListAddFolderButton.UseVisualStyleBackColor = true;
            WUDListAddFolderButton.Click += new System.EventHandler(WUDListAddFolderButtonClicked);
            // 
            // WUDList
            // 
            WUDList.Dock = DockStyle.Top;
            WUDList.FormattingEnabled = true;
            WUDList.Location = new Point(0, 0);
            WUDList.Name = "WUDList";
            WUDList.Size = new Size(285, 173);
            WUDList.TabIndex = 0;
            WUDList.SelectedIndexChanged += new System.EventHandler(WUDListSelectedIndexChanged);
            WUDList.DataSource = ViewModel.GameDatabase;
            WUDList.DisplayMember = "DisplayName";
            // 
            // GameCoverPicture
            // 
            GameCoverPicture.BorderStyle = BorderStyle.Fixed3D;
            GameCoverPicture.Dock = DockStyle.Fill;
            GameCoverPicture.Location = new Point(0, 0);
            GameCoverPicture.Name = "GameCoverPicture";
            GameCoverPicture.Size = new Size(285, 197);
            GameCoverPicture.SizeMode = PictureBoxSizeMode.Zoom;
            GameCoverPicture.TabIndex = 0;
            GameCoverPicture.TabStop = false;

            WUDSplitter.Panel1.ResumeLayout(false);
            WUDSplitter.Panel2.ResumeLayout(false);
            WUDSplitter.ResumeLayout(false);
        }

        private Button AddFolderButton = new Button();
        private Button ScrubWUDButton = new Button();
        private Button SaveGameInformationButton = new Button();
        private Button WUDListClearFoldersButton = new Button();
        private Button WUDListAddFolderButton = new Button();
        private Button ExtractGameFilesButton = new Button();
        private Button ImportGameKeySHA1Button = new Button();
        private Button OpenWUDButton = new Button();
        private CheckBox ShowGameListCheckBox = new CheckBox();
        private CheckBox ShowFullCoverCheckBox = new CheckBox();
        private GroupBox GameInformationGroupBox = new GroupBox();
        private GroupBox TitleKeyGroupBox = new GroupBox();
        private GroupBox GameNameGroupBox = new GroupBox();
        private GroupBox GameIDGroupBox = new GroupBox();
        private Label GameTitleKeySHA1Status = new Label();
        private ListBox WUDList = new ListBox();
        private PictureBox GameTBDPicture = new PictureBox();
        private PictureBox GameCoverPicture = new PictureBox();
        private SplitContainer WUDSplitter = new SplitContainer();
        private TextBox DownloadTextBox = new TextBox();
        private TextBox GameIDTextBox = new TextBox();
        private TextBox GameTitleKeyTextBox = new TextBox();
        private TextBox GameRegionTextBox = new TextBox();
        private TextBox GameNameTextBox = new TextBox();
        private TextBox GameDescriptionTextBox = new TextBox();
        private ToolTip WUDManagerButtonToolTip = new ToolTip();
    }
}