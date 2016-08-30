using System.Windows.Forms;

namespace SnakeBattle2
{
    partial class ChatWindow
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
            this.textBoxMainChat = new System.Windows.Forms.TextBox();
            this.textBoxWrite = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMainChat
            // 
            this.textBoxMainChat.Location = new System.Drawing.Point(13, 13);
            this.textBoxMainChat.Multiline = true;
            this.textBoxMainChat.Name = "textBoxMainChat";
            this.textBoxMainChat.Size = new System.Drawing.Size(398, 477);
            this.textBoxMainChat.TabIndex = 0;
            // 
            // textBoxWrite
            // 
            this.textBoxWrite.Location = new System.Drawing.Point(13, 515);
            this.textBoxWrite.Multiline = true;
            this.textBoxWrite.Name = "textBoxWrite";
            this.textBoxWrite.Size = new System.Drawing.Size(322, 58);
            this.textBoxWrite.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Wingdings", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonSend.Location = new System.Drawing.Point(345, 515);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(66, 58);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "*";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 585);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxWrite);
            this.Controls.Add(this.textBoxMainChat);
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosing += new FormClosingEventHandler(this.ChatWindow_FormClosing);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMainChat;
        private System.Windows.Forms.TextBox textBoxWrite;
        private System.Windows.Forms.Button buttonSend;
    }
}