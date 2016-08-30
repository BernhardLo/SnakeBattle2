﻿using System.Drawing;

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
            this.labelXY = new System.Windows.Forms.Label();
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
            this.showCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOpponent7 = new System.Windows.Forms.Label();
            this.buttonOpponent7 = new System.Windows.Forms.Button();
            this.textBoxConnect = new System.Windows.Forms.TextBox();
            this.labelConnect = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonUserName = new System.Windows.Forms.Button();
            this.buttonEnterServer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewSP
            // 
            this.buttonNewSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewSP.Location = new System.Drawing.Point(422, 307);
            this.buttonNewSP.Name = "buttonNewSP";
            this.buttonNewSP.Size = new System.Drawing.Size(154, 72);
            this.buttonNewSP.TabIndex = 0;
            this.buttonNewSP.Text = "Single Player";
            this.buttonNewSP.UseVisualStyleBackColor = true;
            this.buttonNewSP.Click += new System.EventHandler(this.buttonNewSP_Click);
            // 
            // buttonNewMP
            // 
            this.buttonNewMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewMP.Location = new System.Drawing.Point(422, 385);
            this.buttonNewMP.Name = "buttonNewMP";
            this.buttonNewMP.Size = new System.Drawing.Size(154, 72);
            this.buttonNewMP.TabIndex = 1;
            this.buttonNewMP.Text = "Multi Player";
            this.buttonNewMP.UseVisualStyleBackColor = true;
            this.buttonNewMP.Click += new System.EventHandler(this.buttonNewMP_Click);
            // 
            // comboBoxPlayers
            // 
            this.comboBoxPlayers.BackColor = System.Drawing.Color.White;
            this.comboBoxPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlayers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxPlayers.FormattingEnabled = true;
            this.comboBoxPlayers.Location = new System.Drawing.Point(590, 332);
            this.comboBoxPlayers.Name = "comboBoxPlayers";
            this.comboBoxPlayers.Size = new System.Drawing.Size(56, 24);
            this.comboBoxPlayers.TabIndex = 2;
            // 
            // labelNumberOfPlayers
            // 
            this.labelNumberOfPlayers.AutoSize = true;
            this.labelNumberOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPlayers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNumberOfPlayers.Location = new System.Drawing.Point(342, 336);
            this.labelNumberOfPlayers.Name = "labelNumberOfPlayers";
            this.labelNumberOfPlayers.Size = new System.Drawing.Size(119, 16);
            this.labelNumberOfPlayers.TabIndex = 3;
            this.labelNumberOfPlayers.Text = "Number of Players";
            // 
            // comboBoxFieldSize
            // 
            this.comboBoxFieldSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFieldSize.FormattingEnabled = true;
            this.comboBoxFieldSize.Location = new System.Drawing.Point(590, 375);
            this.comboBoxFieldSize.Name = "comboBoxFieldSize";
            this.comboBoxFieldSize.Size = new System.Drawing.Size(56, 24);
            this.comboBoxFieldSize.TabIndex = 4;
            // 
            // labelFieldSize
            // 
            this.labelFieldSize.AutoSize = true;
            this.labelFieldSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFieldSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFieldSize.Location = new System.Drawing.Point(342, 378);
            this.labelFieldSize.Name = "labelFieldSize";
            this.labelFieldSize.Size = new System.Drawing.Size(67, 16);
            this.labelFieldSize.TabIndex = 5;
            this.labelFieldSize.Text = "Field Size";
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(339, 432);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(308, 45);
            this.buttonStartGame.TabIndex = 6;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // labelXY
            // 
            this.labelXY.AutoSize = true;
            this.labelXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelXY.Location = new System.Drawing.Point(898, 38);
            this.labelXY.Name = "labelXY";
            this.labelXY.Size = new System.Drawing.Size(35, 13);
            this.labelXY.TabIndex = 7;
            this.labelXY.Text = "label1";
            // 
            // comboBoxMyColor
            // 
            this.comboBoxMyColor.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxMyColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxMyColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMyColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMyColor.FormattingEnabled = true;
            this.comboBoxMyColor.Location = new System.Drawing.Point(548, 290);
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
            this.labelMyColor.Location = new System.Drawing.Point(342, 293);
            this.labelMyColor.Name = "labelMyColor";
            this.labelMyColor.Size = new System.Drawing.Size(61, 16);
            this.labelMyColor.TabIndex = 9;
            this.labelMyColor.Text = "My Color";
            // 
            // buttonQuitGame
            // 
            this.buttonQuitGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitGame.Location = new System.Drawing.Point(847, 913);
            this.buttonQuitGame.Name = "buttonQuitGame";
            this.buttonQuitGame.Size = new System.Drawing.Size(126, 36);
            this.buttonQuitGame.TabIndex = 13;
            this.buttonQuitGame.Text = "Quit Game";
            this.buttonQuitGame.UseVisualStyleBackColor = true;
            this.buttonQuitGame.Click += new System.EventHandler(this.buttonQuitGame_Click);
            // 
            // buttonOpponent0
            // 
            this.buttonOpponent0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpponent0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpponent0.Location = new System.Drawing.Point(31, 865);
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
            this.labelOpponent0.Location = new System.Drawing.Point(84, 875);
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
            this.labelOpponent1.Location = new System.Drawing.Point(84, 920);
            this.labelOpponent1.Name = "labelOpponent1";
            this.labelOpponent1.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent1.TabIndex = 17;
            this.labelOpponent1.Text = "OpponentName";
            // 
            // buttonOpponent1
            // 
            this.buttonOpponent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent1.Location = new System.Drawing.Point(31, 910);
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
            this.labelOpponent3.Location = new System.Drawing.Point(286, 920);
            this.labelOpponent3.Name = "labelOpponent3";
            this.labelOpponent3.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent3.TabIndex = 21;
            this.labelOpponent3.Text = "OpponentName";
            // 
            // buttonOpponent3
            // 
            this.buttonOpponent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent3.Location = new System.Drawing.Point(233, 910);
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
            this.labelOpponent2.Location = new System.Drawing.Point(286, 875);
            this.labelOpponent2.Name = "labelOpponent2";
            this.labelOpponent2.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent2.TabIndex = 19;
            this.labelOpponent2.Text = "OpponentName";
            // 
            // buttonOpponent2
            // 
            this.buttonOpponent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent2.Location = new System.Drawing.Point(233, 865);
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
            this.labelOpponent5.Location = new System.Drawing.Point(486, 920);
            this.labelOpponent5.Name = "labelOpponent5";
            this.labelOpponent5.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent5.TabIndex = 25;
            this.labelOpponent5.Text = "OpponentName";
            // 
            // buttonOpponent5
            // 
            this.buttonOpponent5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent5.Location = new System.Drawing.Point(434, 910);
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
            this.labelOpponent4.Location = new System.Drawing.Point(486, 875);
            this.labelOpponent4.Name = "labelOpponent4";
            this.labelOpponent4.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent4.TabIndex = 23;
            this.labelOpponent4.Text = "OpponentName";
            // 
            // buttonOpponent4
            // 
            this.buttonOpponent4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent4.Location = new System.Drawing.Point(434, 865);
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
            this.labelOpponent6.Location = new System.Drawing.Point(688, 875);
            this.labelOpponent6.Name = "labelOpponent6";
            this.labelOpponent6.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent6.TabIndex = 27;
            this.labelOpponent6.Text = "OpponentName";
            // 
            // buttonOpponent6
            // 
            this.buttonOpponent6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent6.Location = new System.Drawing.Point(636, 865);
            this.buttonOpponent6.Name = "buttonOpponent6";
            this.buttonOpponent6.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent6.TabIndex = 26;
            this.buttonOpponent6.UseVisualStyleBackColor = true;
            // 
            // buttonWin
            // 
            this.buttonWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Bold);
            this.buttonWin.Location = new System.Drawing.Point(934, 332);
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
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConsoleToolStripMenuItem,
            this.showCoordinatesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.showConsoleToolStripMenuItem.Text = "Show Console";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.showConsoleToolStripMenuItem_Click);
            // 
            // showCoordinatesToolStripMenuItem
            // 
            this.showCoordinatesToolStripMenuItem.Name = "showCoordinatesToolStripMenuItem";
            this.showCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.showCoordinatesToolStripMenuItem.Text = "Show Coordinates";
            this.showCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.showCoordinatesToolStripMenuItem_Click);
            // 
            // labelOpponent7
            // 
            this.labelOpponent7.AutoSize = true;
            this.labelOpponent7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOpponent7.Location = new System.Drawing.Point(688, 920);
            this.labelOpponent7.Name = "labelOpponent7";
            this.labelOpponent7.Size = new System.Drawing.Size(104, 16);
            this.labelOpponent7.TabIndex = 32;
            this.labelOpponent7.Text = "OpponentName";
            // 
            // buttonOpponent7
            // 
            this.buttonOpponent7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpponent7.Location = new System.Drawing.Point(636, 910);
            this.buttonOpponent7.Name = "buttonOpponent7";
            this.buttonOpponent7.Size = new System.Drawing.Size(45, 39);
            this.buttonOpponent7.TabIndex = 31;
            this.buttonOpponent7.UseVisualStyleBackColor = true;
            // 
            // textBoxConnect
            // 
            this.textBoxConnect.Location = new System.Drawing.Point(434, 101);
            this.textBoxConnect.Name = "textBoxConnect";
            this.textBoxConnect.Size = new System.Drawing.Size(116, 21);
            this.textBoxConnect.TabIndex = 33;
            // 
            // labelConnect
            // 
            this.labelConnect.AutoSize = true;
            this.labelConnect.Location = new System.Drawing.Point(345, 104);
            this.labelConnect.Name = "labelConnect";
            this.labelConnect.Size = new System.Drawing.Size(63, 16);
            this.labelConnect.TabIndex = 34;
            this.labelConnect.Text = "Server IP";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Webdings", 12F);
            this.buttonConnect.ForeColor = System.Drawing.Color.Red;
            this.buttonConnect.Location = new System.Drawing.Point(561, 100);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(29, 23);
            this.buttonConnect.TabIndex = 35;
            this.buttonConnect.Text = "~";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(434, 129);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(116, 21);
            this.textBoxUserName.TabIndex = 36;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(345, 131);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(77, 16);
            this.labelUserName.TabIndex = 37;
            this.labelUserName.Text = "User Name";
            // 
            // buttonUserName
            // 
            this.buttonUserName.Font = new System.Drawing.Font("Webdings", 8F);
            this.buttonUserName.ForeColor = System.Drawing.Color.Red;
            this.buttonUserName.Location = new System.Drawing.Point(561, 129);
            this.buttonUserName.Name = "buttonUserName";
            this.buttonUserName.Size = new System.Drawing.Size(29, 23);
            this.buttonUserName.TabIndex = 38;
            this.buttonUserName.Text = "n";
            this.buttonUserName.UseVisualStyleBackColor = true;
            this.buttonUserName.Click += new System.EventHandler(this.buttonUserName_Click);
            // 
            // buttonEnterServer
            // 
            this.buttonEnterServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.buttonEnterServer.Location = new System.Drawing.Point(434, 187);
            this.buttonEnterServer.Name = "buttonEnterServer";
            this.buttonEnterServer.Size = new System.Drawing.Size(116, 41);
            this.buttonEnterServer.TabIndex = 39;
            this.buttonEnterServer.Text = "Enter Server";
            this.buttonEnterServer.UseVisualStyleBackColor = true;
            // 
            // SnakeBattle2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 962);
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
            this.Controls.Add(this.labelXY);
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
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
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
        private System.Windows.Forms.Label labelXY;
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
        private System.Windows.Forms.ToolStripMenuItem showCoordinatesToolStripMenuItem;
        private System.Windows.Forms.Label labelOpponent7;
        private System.Windows.Forms.Button buttonOpponent7;
        private System.Windows.Forms.TextBox textBoxConnect;
        private System.Windows.Forms.Label labelConnect;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonUserName;
        private System.Windows.Forms.Button buttonEnterServer;
    }
}
