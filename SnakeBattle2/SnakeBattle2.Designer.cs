using System.Drawing;

namespace SnakeBattle2
{
    partial class SnakeBattle2
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
            this.components = new System.ComponentModel.Container();
            this.buttonNewSP = new System.Windows.Forms.Button();
            this.buttonNewMP = new System.Windows.Forms.Button();
            this.comboBoxPlayers = new System.Windows.Forms.ComboBox();
            this.labelNumberOfPlayers = new System.Windows.Forms.Label();
            this.comboBoxFieldSize = new System.Windows.Forms.ComboBox();
            this.labelFieldSize = new System.Windows.Forms.Label();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.comboBoxMyColor = new System.Windows.Forms.ComboBox();
            this.labelMyColor = new System.Windows.Forms.Label();
            this.buttonQuitGame = new System.Windows.Forms.Button();
            this.buttonOpponent0 = new System.Windows.Forms.Button();
            this.labelOpponent0 = new System.Windows.Forms.Label();
            this.labelOpponent1 = new System.Windows.Forms.Label();
            this.buttonOpponent1 = new System.Windows.Forms.Button();
            this.labelOpponent3 = new System.Windows.Forms.Label();
            this.buttonOpponent3 = new System.Windows.Forms.Button();
            this.labelOpponent2 = new System.Windows.Forms.Label();
            this.buttonOpponent2 = new System.Windows.Forms.Button();
            this.labelOpponent5 = new System.Windows.Forms.Label();
            this.buttonOpponent5 = new System.Windows.Forms.Button();
            this.labelOpponent4 = new System.Windows.Forms.Label();
            this.buttonOpponent4 = new System.Windows.Forms.Button();
            this.labelOpponent6 = new System.Windows.Forms.Label();
            this.buttonOpponent6 = new System.Windows.Forms.Button();
            this.buttonWin = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOpponent7 = new System.Windows.Forms.Label();
            this.buttonOpponent7 = new System.Windows.Forms.Button();
            this.textBoxConnect = new System.Windows.Forms.TextBox();
            this.labelConnect = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonUserName = new System.Windows.Forms.Button();
            this.buttonEnterServer = new System.Windows.Forms.Button();
            this.labelConnectMessage = new System.Windows.Forms.Label();
            this.labelUserNameMessage = new System.Windows.Forms.Label();
            this.buttonConnectCancel = new System.Windows.Forms.Button();
            this.buttonStartGameCancel = new System.Windows.Forms.Button();
            this.listBoxMPavailableGames = new System.Windows.Forms.ListBox();
            this.labelMPavailableGames = new System.Windows.Forms.Label();
            this.buttonMPjoinGame = new System.Windows.Forms.Button();
            this.buttonMPshowChat = new System.Windows.Forms.Button();
            this.buttonMPcreateGame = new System.Windows.Forms.Button();
            this.labelMPfieldSize = new System.Windows.Forms.Label();
            this.comboBoxMPfieldSize = new System.Windows.Forms.ComboBox();
            this.listBoxMPplayerLobby = new System.Windows.Forms.ListBox();
            this.buttonMPstartGame = new System.Windows.Forms.Button();
            this.buttonMPleaveLobby = new System.Windows.Forms.Button();
            this.labelMPlobby = new System.Windows.Forms.Label();
            this.buttonMPrefresh = new System.Windows.Forms.Button();
            this.buttonMPleaveServer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewSP
            // 
            this.buttonNewSP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNewSP.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewSP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNewSP.Location = new System.Drawing.Point(378, 307);
            this.buttonNewSP.Name = "buttonNewSP";
            this.buttonNewSP.Size = new System.Drawing.Size(154, 72);
            this.buttonNewSP.TabIndex = 0;
            this.buttonNewSP.Text = "Single Player";
            this.buttonNewSP.UseVisualStyleBackColor = false;
            this.buttonNewSP.Click += new System.EventHandler(this.buttonNewSP_Click);
            // 
            // buttonNewMP
            // 
            this.buttonNewMP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNewMP.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewMP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNewMP.Location = new System.Drawing.Point(378, 385);
            this.buttonNewMP.Name = "buttonNewMP";
            this.buttonNewMP.Size = new System.Drawing.Size(154, 72);
            this.buttonNewMP.TabIndex = 1;
            this.buttonNewMP.Text = "Multi Player";
            this.buttonNewMP.UseVisualStyleBackColor = false;
            this.buttonNewMP.Click += new System.EventHandler(this.buttonNewMP_Click);
            // 
            // comboBoxPlayers
            // 
            this.comboBoxPlayers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBoxPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlayers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxPlayers.FormattingEnabled = true;
            this.comboBoxPlayers.Location = new System.Drawing.Point(546, 332);
            this.comboBoxPlayers.Name = "comboBoxPlayers";
            this.comboBoxPlayers.Size = new System.Drawing.Size(56, 24);
            this.comboBoxPlayers.TabIndex = 2;
            // 
            // labelNumberOfPlayers
            // 
            this.labelNumberOfPlayers.AutoSize = true;
            this.labelNumberOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPlayers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNumberOfPlayers.Location = new System.Drawing.Point(298, 336);
            this.labelNumberOfPlayers.Name = "labelNumberOfPlayers";
            this.labelNumberOfPlayers.Size = new System.Drawing.Size(119, 16);
            this.labelNumberOfPlayers.TabIndex = 3;
            this.labelNumberOfPlayers.Text = "Number of Players";
            // 
            // comboBoxFieldSize
            // 
            this.comboBoxFieldSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBoxFieldSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFieldSize.FormattingEnabled = true;
            this.comboBoxFieldSize.Location = new System.Drawing.Point(546, 375);
            this.comboBoxFieldSize.Name = "comboBoxFieldSize";
            this.comboBoxFieldSize.Size = new System.Drawing.Size(56, 24);
            this.comboBoxFieldSize.TabIndex = 4;
            // 
            // labelFieldSize
            // 
            this.labelFieldSize.AutoSize = true;
            this.labelFieldSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFieldSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFieldSize.Location = new System.Drawing.Point(298, 378);
            this.labelFieldSize.Name = "labelFieldSize";
            this.labelFieldSize.Size = new System.Drawing.Size(67, 16);
            this.labelFieldSize.TabIndex = 5;
            this.labelFieldSize.Text = "Field Size";
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonStartGame.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStartGame.Location = new System.Drawing.Point(295, 432);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(251, 45);
            this.buttonStartGame.TabIndex = 6;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // comboBoxMyColor
            // 
            this.comboBoxMyColor.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxMyColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxMyColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMyColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMyColor.FormattingEnabled = true;
            this.comboBoxMyColor.Location = new System.Drawing.Point(504, 290);
            this.comboBoxMyColor.Name = "comboBoxMyColor";
            this.comboBoxMyColor.Size = new System.Drawing.Size(98, 23);
            this.comboBoxMyColor.TabIndex = 8;
            this.comboBoxMyColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxMyColor_DrawItem);
            // 
            // labelMyColor
            // 
            this.labelMyColor.AutoSize = true;
            this.labelMyColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMyColor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMyColor.Location = new System.Drawing.Point(298, 293);
            this.labelMyColor.Name = "labelMyColor";
            this.labelMyColor.Size = new System.Drawing.Size(61, 16);
            this.labelMyColor.TabIndex = 9;
            this.labelMyColor.Text = "My Color";
            // 
            // buttonQuitGame
            // 
            this.buttonQuitGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonQuitGame.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonQuitGame.Location = new System.Drawing.Point(753, 815);
            this.buttonQuitGame.Name = "buttonQuitGame";
            this.buttonQuitGame.Size = new System.Drawing.Size(126, 36);
            this.buttonQuitGame.TabIndex = 13;
            this.buttonQuitGame.Text = "Quit Game";
            this.buttonQuitGame.UseVisualStyleBackColor = false;
            this.buttonQuitGame.Click += new System.EventHandler(this.buttonQuitGame_Click);
            // 
            // buttonOpponent0
            // 
            this.buttonOpponent0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpponent0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent0.Location = new System.Drawing.Point(12, 769);
            this.buttonOpponent0.Name = "buttonOpponent0";
            this.buttonOpponent0.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent0.TabIndex = 14;
            this.buttonOpponent0.UseVisualStyleBackColor = true;
            // 
            // labelOpponent0
            // 
            this.labelOpponent0.AutoSize = true;
            this.labelOpponent0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent0.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent0.Location = new System.Drawing.Point(65, 779);
            this.labelOpponent0.Name = "labelOpponent0";
            this.labelOpponent0.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent0.TabIndex = 15;
            this.labelOpponent0.Text = "OpponentName";
            // 
            // labelOpponent1
            // 
            this.labelOpponent1.AutoSize = true;
            this.labelOpponent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent1.Location = new System.Drawing.Point(65, 824);
            this.labelOpponent1.Name = "labelOpponent1";
            this.labelOpponent1.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent1.TabIndex = 17;
            this.labelOpponent1.Text = "OpponentName";
            // 
            // buttonOpponent1
            // 
            this.buttonOpponent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent1.Location = new System.Drawing.Point(12, 814);
            this.buttonOpponent1.Name = "buttonOpponent1";
            this.buttonOpponent1.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent1.TabIndex = 16;
            this.buttonOpponent1.UseVisualStyleBackColor = true;
            // 
            // labelOpponent3
            // 
            this.labelOpponent3.AutoSize = true;
            this.labelOpponent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent3.Location = new System.Drawing.Point(252, 824);
            this.labelOpponent3.Name = "labelOpponent3";
            this.labelOpponent3.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent3.TabIndex = 21;
            this.labelOpponent3.Text = "OpponentName";
            // 
            // buttonOpponent3
            // 
            this.buttonOpponent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent3.Location = new System.Drawing.Point(199, 814);
            this.buttonOpponent3.Name = "buttonOpponent3";
            this.buttonOpponent3.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent3.TabIndex = 20;
            this.buttonOpponent3.UseVisualStyleBackColor = true;
            // 
            // labelOpponent2
            // 
            this.labelOpponent2.AutoSize = true;
            this.labelOpponent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent2.Location = new System.Drawing.Point(252, 779);
            this.labelOpponent2.Name = "labelOpponent2";
            this.labelOpponent2.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent2.TabIndex = 19;
            this.labelOpponent2.Text = "OpponentName";
            // 
            // buttonOpponent2
            // 
            this.buttonOpponent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent2.Location = new System.Drawing.Point(199, 769);
            this.buttonOpponent2.Name = "buttonOpponent2";
            this.buttonOpponent2.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent2.TabIndex = 18;
            this.buttonOpponent2.UseVisualStyleBackColor = true;
            // 
            // labelOpponent5
            // 
            this.labelOpponent5.AutoSize = true;
            this.labelOpponent5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent5.Location = new System.Drawing.Point(438, 824);
            this.labelOpponent5.Name = "labelOpponent5";
            this.labelOpponent5.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent5.TabIndex = 25;
            this.labelOpponent5.Text = "OpponentName";
            // 
            // buttonOpponent5
            // 
            this.buttonOpponent5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent5.Location = new System.Drawing.Point(386, 814);
            this.buttonOpponent5.Name = "buttonOpponent5";
            this.buttonOpponent5.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent5.TabIndex = 24;
            this.buttonOpponent5.UseVisualStyleBackColor = true;
            // 
            // labelOpponent4
            // 
            this.labelOpponent4.AutoSize = true;
            this.labelOpponent4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent4.Location = new System.Drawing.Point(438, 779);
            this.labelOpponent4.Name = "labelOpponent4";
            this.labelOpponent4.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent4.TabIndex = 23;
            this.labelOpponent4.Text = "OpponentName";
            // 
            // buttonOpponent4
            // 
            this.buttonOpponent4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent4.Location = new System.Drawing.Point(386, 769);
            this.buttonOpponent4.Name = "buttonOpponent4";
            this.buttonOpponent4.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent4.TabIndex = 22;
            this.buttonOpponent4.UseVisualStyleBackColor = true;
            // 
            // labelOpponent6
            // 
            this.labelOpponent6.AutoSize = true;
            this.labelOpponent6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent6.Location = new System.Drawing.Point(624, 779);
            this.labelOpponent6.Name = "labelOpponent6";
            this.labelOpponent6.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent6.TabIndex = 27;
            this.labelOpponent6.Text = "OpponentName";
            // 
            // buttonOpponent6
            // 
            this.buttonOpponent6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent6.Location = new System.Drawing.Point(572, 769);
            this.buttonOpponent6.Name = "buttonOpponent6";
            this.buttonOpponent6.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent6.TabIndex = 26;
            this.buttonOpponent6.UseVisualStyleBackColor = true;
            // 
            // buttonWin
            // 
            this.buttonWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonWin.Font = new System.Drawing.Font("Sitka Text", 99.74998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonWin.Location = new System.Drawing.Point(817, 332);
            this.buttonWin.Name = "buttonWin";
            this.buttonWin.Size = new System.Drawing.Size(926, 247);
            this.buttonWin.TabIndex = 28;
            this.buttonWin.Text = "YOU WIN !";
            this.buttonWin.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConsoleToolStripMenuItem,
            this.runServerToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showConsoleToolStripMenuItem.Text = "Show Console";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.showConsoleToolStripMenuItem_Click);
            // 
            // runServerToolStripMenuItem
            // 
            this.runServerToolStripMenuItem.Name = "runServerToolStripMenuItem";
            this.runServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runServerToolStripMenuItem.Text = "Run Server";
            this.runServerToolStripMenuItem.Click += new System.EventHandler(this.runServerToolStripMenuItem_Click);
            // 
            // labelOpponent7
            // 
            this.labelOpponent7.AutoSize = true;
            this.labelOpponent7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent7.Location = new System.Drawing.Point(624, 824);
            this.labelOpponent7.Name = "labelOpponent7";
            this.labelOpponent7.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent7.TabIndex = 32;
            this.labelOpponent7.Text = "OpponentName";
            // 
            // buttonOpponent7
            // 
            this.buttonOpponent7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent7.Location = new System.Drawing.Point(572, 814);
            this.buttonOpponent7.Name = "buttonOpponent7";
            this.buttonOpponent7.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent7.TabIndex = 31;
            this.buttonOpponent7.UseVisualStyleBackColor = true;
            // 
            // textBoxConnect
            // 
            this.textBoxConnect.Location = new System.Drawing.Point(390, 101);
            this.textBoxConnect.Name = "textBoxConnect";
            this.textBoxConnect.Size = new System.Drawing.Size(116, 21);
            this.textBoxConnect.TabIndex = 33;
            this.textBoxConnect.TextChanged += new System.EventHandler(this.textBoxConnect_TextChanged);
            // 
            // labelConnect
            // 
            this.labelConnect.AutoSize = true;
            this.labelConnect.Location = new System.Drawing.Point(301, 104);
            this.labelConnect.Name = "labelConnect";
            this.labelConnect.Size = new System.Drawing.Size(63, 16);
            this.labelConnect.TabIndex = 34;
            this.labelConnect.Text = "Server IP";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonConnect.Font = new System.Drawing.Font("Webdings", 12F);
            this.buttonConnect.ForeColor = System.Drawing.Color.Red;
            this.buttonConnect.Location = new System.Drawing.Point(517, 100);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(29, 23);
            this.buttonConnect.TabIndex = 35;
            this.buttonConnect.Text = "~";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(390, 129);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(116, 21);
            this.textBoxUserName.TabIndex = 36;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(301, 131);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(77, 16);
            this.labelUserName.TabIndex = 37;
            this.labelUserName.Text = "User Name";
            // 
            // buttonUserName
            // 
            this.buttonUserName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonUserName.Font = new System.Drawing.Font("Webdings", 8F);
            this.buttonUserName.ForeColor = System.Drawing.Color.Red;
            this.buttonUserName.Location = new System.Drawing.Point(517, 129);
            this.buttonUserName.Name = "buttonUserName";
            this.buttonUserName.Size = new System.Drawing.Size(29, 23);
            this.buttonUserName.TabIndex = 38;
            this.buttonUserName.Text = "n";
            this.buttonUserName.UseVisualStyleBackColor = false;
            this.buttonUserName.Click += new System.EventHandler(this.buttonUserName_Click);
            // 
            // buttonEnterServer
            // 
            this.buttonEnterServer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEnterServer.Font = new System.Drawing.Font("Sitka Text", 12F);
            this.buttonEnterServer.ForeColor = System.Drawing.Color.Green;
            this.buttonEnterServer.Location = new System.Drawing.Point(378, 187);
            this.buttonEnterServer.Name = "buttonEnterServer";
            this.buttonEnterServer.Size = new System.Drawing.Size(116, 41);
            this.buttonEnterServer.TabIndex = 39;
            this.buttonEnterServer.Text = "Enter Server";
            this.buttonEnterServer.UseVisualStyleBackColor = false;
            this.buttonEnterServer.Click += new System.EventHandler(this.buttonEnterServer_Click);
            // 
            // labelConnectMessage
            // 
            this.labelConnectMessage.AutoSize = true;
            this.labelConnectMessage.Font = new System.Drawing.Font("Sitka Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectMessage.Location = new System.Drawing.Point(553, 102);
            this.labelConnectMessage.Name = "labelConnectMessage";
            this.labelConnectMessage.Size = new System.Drawing.Size(41, 18);
            this.labelConnectMessage.TabIndex = 40;
            this.labelConnectMessage.Text = "label1";
            // 
            // labelUserNameMessage
            // 
            this.labelUserNameMessage.AutoSize = true;
            this.labelUserNameMessage.Font = new System.Drawing.Font("Sitka Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserNameMessage.Location = new System.Drawing.Point(553, 129);
            this.labelUserNameMessage.Name = "labelUserNameMessage";
            this.labelUserNameMessage.Size = new System.Drawing.Size(41, 18);
            this.labelUserNameMessage.TabIndex = 41;
            this.labelUserNameMessage.Text = "label1";
            // 
            // buttonConnectCancel
            // 
            this.buttonConnectCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonConnectCancel.Font = new System.Drawing.Font("Webdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonConnectCancel.ForeColor = System.Drawing.Color.Red;
            this.buttonConnectCancel.Location = new System.Drawing.Point(505, 187);
            this.buttonConnectCancel.Name = "buttonConnectCancel";
            this.buttonConnectCancel.Size = new System.Drawing.Size(50, 41);
            this.buttonConnectCancel.TabIndex = 42;
            this.buttonConnectCancel.Text = "r";
            this.buttonConnectCancel.UseVisualStyleBackColor = false;
            this.buttonConnectCancel.Click += new System.EventHandler(this.buttonConnectCancel_Click);
            // 
            // buttonStartGameCancel
            // 
            this.buttonStartGameCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonStartGameCancel.Font = new System.Drawing.Font("Webdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonStartGameCancel.ForeColor = System.Drawing.Color.Red;
            this.buttonStartGameCancel.Location = new System.Drawing.Point(552, 432);
            this.buttonStartGameCancel.Name = "buttonStartGameCancel";
            this.buttonStartGameCancel.Size = new System.Drawing.Size(50, 45);
            this.buttonStartGameCancel.TabIndex = 43;
            this.buttonStartGameCancel.Text = "r";
            this.buttonStartGameCancel.UseVisualStyleBackColor = false;
            this.buttonStartGameCancel.Click += new System.EventHandler(this.buttonStartGameCancel_Click);
            // 
            // listBoxMPavailableGames
            // 
            this.listBoxMPavailableGames.FormattingEnabled = true;
            this.listBoxMPavailableGames.ItemHeight = 15;
            this.listBoxMPavailableGames.Location = new System.Drawing.Point(47, 87);
            this.listBoxMPavailableGames.Name = "listBoxMPavailableGames";
            this.listBoxMPavailableGames.Size = new System.Drawing.Size(277, 469);
            this.listBoxMPavailableGames.TabIndex = 44;
            // 
            // labelMPavailableGames
            // 
            this.labelMPavailableGames.AutoSize = true;
            this.labelMPavailableGames.Location = new System.Drawing.Point(44, 68);
            this.labelMPavailableGames.Name = "labelMPavailableGames";
            this.labelMPavailableGames.Size = new System.Drawing.Size(112, 16);
            this.labelMPavailableGames.TabIndex = 45;
            this.labelMPavailableGames.Text = "Available Games";
            // 
            // buttonMPjoinGame
            // 
            this.buttonMPjoinGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMPjoinGame.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMPjoinGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMPjoinGame.Location = new System.Drawing.Point(47, 573);
            this.buttonMPjoinGame.Name = "buttonMPjoinGame";
            this.buttonMPjoinGame.Size = new System.Drawing.Size(109, 36);
            this.buttonMPjoinGame.TabIndex = 46;
            this.buttonMPjoinGame.Text = "Join";
            this.buttonMPjoinGame.UseVisualStyleBackColor = false;
            this.buttonMPjoinGame.Click += new System.EventHandler(this.buttonMPjoinGame_Click);
            // 
            // buttonMPshowChat
            // 
            this.buttonMPshowChat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMPshowChat.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonMPshowChat.ForeColor = System.Drawing.Color.Green;
            this.buttonMPshowChat.Location = new System.Drawing.Point(817, 33);
            this.buttonMPshowChat.Name = "buttonMPshowChat";
            this.buttonMPshowChat.Size = new System.Drawing.Size(69, 61);
            this.buttonMPshowChat.TabIndex = 47;
            this.buttonMPshowChat.Text = "_";
            this.buttonMPshowChat.UseVisualStyleBackColor = false;
            this.buttonMPshowChat.Click += new System.EventHandler(this.buttonMPshowChat_Click);
            // 
            // buttonMPcreateGame
            // 
            this.buttonMPcreateGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMPcreateGame.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMPcreateGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMPcreateGame.Location = new System.Drawing.Point(215, 573);
            this.buttonMPcreateGame.Name = "buttonMPcreateGame";
            this.buttonMPcreateGame.Size = new System.Drawing.Size(109, 36);
            this.buttonMPcreateGame.TabIndex = 48;
            this.buttonMPcreateGame.Text = "Create Game";
            this.buttonMPcreateGame.UseVisualStyleBackColor = false;
            this.buttonMPcreateGame.Click += new System.EventHandler(this.buttonMPcreateGame_Click);
            // 
            // labelMPfieldSize
            // 
            this.labelMPfieldSize.AutoSize = true;
            this.labelMPfieldSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMPfieldSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMPfieldSize.Location = new System.Drawing.Point(575, 480);
            this.labelMPfieldSize.Name = "labelMPfieldSize";
            this.labelMPfieldSize.Size = new System.Drawing.Size(67, 16);
            this.labelMPfieldSize.TabIndex = 50;
            this.labelMPfieldSize.Text = "Field Size";
            // 
            // comboBoxMPfieldSize
            // 
            this.comboBoxMPfieldSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBoxMPfieldSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMPfieldSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMPfieldSize.FormattingEnabled = true;
            this.comboBoxMPfieldSize.Location = new System.Drawing.Point(664, 477);
            this.comboBoxMPfieldSize.Name = "comboBoxMPfieldSize";
            this.comboBoxMPfieldSize.Size = new System.Drawing.Size(56, 24);
            this.comboBoxMPfieldSize.TabIndex = 49;
            // 
            // listBoxMPplayerLobby
            // 
            this.listBoxMPplayerLobby.FormattingEnabled = true;
            this.listBoxMPplayerLobby.ItemHeight = 15;
            this.listBoxMPplayerLobby.Location = new System.Drawing.Point(578, 211);
            this.listBoxMPplayerLobby.Name = "listBoxMPplayerLobby";
            this.listBoxMPplayerLobby.Size = new System.Drawing.Size(301, 214);
            this.listBoxMPplayerLobby.TabIndex = 51;
            // 
            // buttonMPstartGame
            // 
            this.buttonMPstartGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMPstartGame.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMPstartGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMPstartGame.Location = new System.Drawing.Point(578, 432);
            this.buttonMPstartGame.Name = "buttonMPstartGame";
            this.buttonMPstartGame.Size = new System.Drawing.Size(142, 36);
            this.buttonMPstartGame.TabIndex = 52;
            this.buttonMPstartGame.Text = "Start Game";
            this.buttonMPstartGame.UseVisualStyleBackColor = false;
            this.buttonMPstartGame.Click += new System.EventHandler(this.buttonMPstartGame_Click);
            // 
            // buttonMPleaveLobby
            // 
            this.buttonMPleaveLobby.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMPleaveLobby.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMPleaveLobby.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMPleaveLobby.Location = new System.Drawing.Point(737, 432);
            this.buttonMPleaveLobby.Name = "buttonMPleaveLobby";
            this.buttonMPleaveLobby.Size = new System.Drawing.Size(142, 36);
            this.buttonMPleaveLobby.TabIndex = 53;
            this.buttonMPleaveLobby.Text = "Leave Lobby";
            this.buttonMPleaveLobby.UseVisualStyleBackColor = false;
            this.buttonMPleaveLobby.Click += new System.EventHandler(this.buttonMPleaveLobby_Click);
            // 
            // labelMPlobby
            // 
            this.labelMPlobby.AutoSize = true;
            this.labelMPlobby.Location = new System.Drawing.Point(578, 187);
            this.labelMPlobby.Name = "labelMPlobby";
            this.labelMPlobby.Size = new System.Drawing.Size(46, 16);
            this.labelMPlobby.TabIndex = 54;
            this.labelMPlobby.Text = "Lobby";
            // 
            // buttonMPrefresh
            // 
            this.buttonMPrefresh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMPrefresh.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonMPrefresh.ForeColor = System.Drawing.Color.Green;
            this.buttonMPrefresh.Location = new System.Drawing.Point(295, 52);
            this.buttonMPrefresh.Name = "buttonMPrefresh";
            this.buttonMPrefresh.Size = new System.Drawing.Size(29, 29);
            this.buttonMPrefresh.TabIndex = 55;
            this.buttonMPrefresh.Text = "q";
            this.buttonMPrefresh.UseVisualStyleBackColor = false;
            this.buttonMPrefresh.Click += new System.EventHandler(this.buttonMPrefresh_Click);
            // 
            // buttonMPleaveServer
            // 
            this.buttonMPleaveServer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMPleaveServer.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMPleaveServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMPleaveServer.Location = new System.Drawing.Point(726, 770);
            this.buttonMPleaveServer.Name = "buttonMPleaveServer";
            this.buttonMPleaveServer.Size = new System.Drawing.Size(153, 36);
            this.buttonMPleaveServer.TabIndex = 56;
            this.buttonMPleaveServer.Text = "Leave Server";
            this.buttonMPleaveServer.UseVisualStyleBackColor = false;
            this.buttonMPleaveServer.Click += new System.EventHandler(this.buttonMPleaveServer_Click);
            // 
            // SnakeBattle2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 866);
            this.Controls.Add(this.buttonMPleaveServer);
            this.Controls.Add(this.buttonMPrefresh);
            this.Controls.Add(this.labelMPlobby);
            this.Controls.Add(this.buttonMPleaveLobby);
            this.Controls.Add(this.buttonMPstartGame);
            this.Controls.Add(this.listBoxMPplayerLobby);
            this.Controls.Add(this.labelMPfieldSize);
            this.Controls.Add(this.comboBoxMPfieldSize);
            this.Controls.Add(this.buttonMPcreateGame);
            this.Controls.Add(this.buttonMPshowChat);
            this.Controls.Add(this.buttonMPjoinGame);
            this.Controls.Add(this.labelMPavailableGames);
            this.Controls.Add(this.listBoxMPavailableGames);
            this.Controls.Add(this.buttonStartGameCancel);
            this.Controls.Add(this.buttonConnectCancel);
            this.Controls.Add(this.labelUserNameMessage);
            this.Controls.Add(this.labelConnectMessage);
            this.Controls.Add(this.buttonEnterServer);
            this.Controls.Add(this.buttonUserName);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelConnect);
            this.Controls.Add(this.textBoxConnect);
            this.Controls.Add(this.labelOpponent7);
            this.Controls.Add(this.buttonOpponent7);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonWin);
            this.Controls.Add(this.labelOpponent6);
            this.Controls.Add(this.buttonOpponent6);
            this.Controls.Add(this.labelOpponent5);
            this.Controls.Add(this.buttonOpponent5);
            this.Controls.Add(this.labelOpponent4);
            this.Controls.Add(this.buttonOpponent4);
            this.Controls.Add(this.labelOpponent3);
            this.Controls.Add(this.buttonOpponent3);
            this.Controls.Add(this.labelOpponent2);
            this.Controls.Add(this.buttonOpponent2);
            this.Controls.Add(this.labelOpponent1);
            this.Controls.Add(this.buttonOpponent1);
            this.Controls.Add(this.labelOpponent0);
            this.Controls.Add(this.buttonOpponent0);
            this.Controls.Add(this.buttonQuitGame);
            this.Controls.Add(this.labelMyColor);
            this.Controls.Add(this.comboBoxMyColor);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.labelFieldSize);
            this.Controls.Add(this.comboBoxFieldSize);
            this.Controls.Add(this.labelNumberOfPlayers);
            this.Controls.Add(this.comboBoxPlayers);
            this.Controls.Add(this.buttonNewMP);
            this.Controls.Add(this.buttonNewSP);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SnakeBattle2";
            this.Text = "Snake Battle 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.SnakeBattle2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button buttonNewSP;
        private System.Windows.Forms.Button buttonNewMP;
        private System.Windows.Forms.ComboBox comboBoxPlayers;
        private System.Windows.Forms.Label labelNumberOfPlayers;
        private System.Windows.Forms.ComboBox comboBoxFieldSize;
        private System.Windows.Forms.Label labelFieldSize;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.ComboBox comboBoxMyColor;
        private System.Windows.Forms.Label labelMyColor;
        private System.Windows.Forms.Button buttonQuitGame;
        private System.Windows.Forms.Button buttonOpponent0;
        private System.Windows.Forms.Label labelOpponent0;
        private System.Windows.Forms.Label labelOpponent1;
        private System.Windows.Forms.Button buttonOpponent1;
        private System.Windows.Forms.Label labelOpponent3;
        private System.Windows.Forms.Button buttonOpponent3;
        private System.Windows.Forms.Label labelOpponent2;
        private System.Windows.Forms.Button buttonOpponent2;
        private System.Windows.Forms.Label labelOpponent5;
        private System.Windows.Forms.Button buttonOpponent5;
        private System.Windows.Forms.Label labelOpponent4;
        private System.Windows.Forms.Button buttonOpponent4;
        private System.Windows.Forms.Label labelOpponent6;
        private System.Windows.Forms.Button buttonOpponent6;
        private System.Windows.Forms.Button buttonWin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showConsoleToolStripMenuItem;
        private System.Windows.Forms.Label labelOpponent7;
        private System.Windows.Forms.Button buttonOpponent7;
        private System.Windows.Forms.TextBox textBoxConnect;
        private System.Windows.Forms.Label labelConnect;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonUserName;
        private System.Windows.Forms.Button buttonEnterServer;
        private System.Windows.Forms.ToolStripMenuItem runServerToolStripMenuItem;
        public System.Windows.Forms.Label labelConnectMessage;
        private System.Windows.Forms.Label labelUserNameMessage;
        private System.Windows.Forms.Button buttonConnectCancel;
        private System.Windows.Forms.Button buttonStartGameCancel;
        private System.Windows.Forms.ListBox listBoxMPavailableGames;
        private System.Windows.Forms.Label labelMPavailableGames;
        private System.Windows.Forms.Button buttonMPjoinGame;
        private System.Windows.Forms.Button buttonMPshowChat;
        private System.Windows.Forms.Button buttonMPcreateGame;
        private System.Windows.Forms.Label labelMPfieldSize;
        private System.Windows.Forms.ComboBox comboBoxMPfieldSize;
        private System.Windows.Forms.ListBox listBoxMPplayerLobby;
        private System.Windows.Forms.Button buttonMPstartGame;
        private System.Windows.Forms.Button buttonMPleaveLobby;
        private System.Windows.Forms.Label labelMPlobby;
        private System.Windows.Forms.Button buttonMPrefresh;
        private System.Windows.Forms.Button buttonMPleaveServer;
    }
}

