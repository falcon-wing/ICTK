﻿namespace SecIotAgent.Forms
{
    partial class RegistrarotionUserForm
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
            this.PW_textBox = new MaterialSkin.Controls.MaterialTextBox();
            this.ID_textBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // PW_textBox
            // 
            this.PW_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PW_textBox.Depth = 0;
            this.PW_textBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PW_textBox.Hint = "Password";
            this.PW_textBox.LeadingIcon = null;
            this.PW_textBox.Location = new System.Drawing.Point(18, 183);
            this.PW_textBox.MaxLength = 50;
            this.PW_textBox.MouseState = MaterialSkin.MouseState.OUT;
            this.PW_textBox.Multiline = false;
            this.PW_textBox.Name = "PW_textBox";
            this.PW_textBox.Size = new System.Drawing.Size(321, 50);
            this.PW_textBox.TabIndex = 11;
            this.PW_textBox.Text = "";
            this.PW_textBox.TrailingIcon = null;
            // 
            // ID_textBox
            // 
            this.ID_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ID_textBox.Depth = 0;
            this.ID_textBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ID_textBox.Hint = "Username";
            this.ID_textBox.LeadingIcon = null;
            this.ID_textBox.Location = new System.Drawing.Point(18, 103);
            this.ID_textBox.MaxLength = 50;
            this.ID_textBox.MouseState = MaterialSkin.MouseState.OUT;
            this.ID_textBox.Multiline = false;
            this.ID_textBox.Name = "ID_textBox";
            this.ID_textBox.Size = new System.Drawing.Size(321, 50);
            this.ID_textBox.TabIndex = 10;
            this.ID_textBox.Text = "";
            this.ID_textBox.TrailingIcon = null;
            // 
            // materialButton1
            // 
            this.materialButton1.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(221, 344);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton1.Size = new System.Drawing.Size(125, 44);
            this.materialButton1.TabIndex = 9;
            this.materialButton1.Text = "REGISTRATION";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(18, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 2);
            this.label2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(18, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 2);
            this.label1.TabIndex = 7;
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox1.Depth = 0;
            this.materialTextBox1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox1.Hint = "Confirm Password";
            this.materialTextBox1.LeadingIcon = null;
            this.materialTextBox1.Location = new System.Drawing.Point(18, 251);
            this.materialTextBox1.MaxLength = 50;
            this.materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.Size = new System.Drawing.Size(321, 50);
            this.materialTextBox1.TabIndex = 12;
            this.materialTextBox1.Text = "";
            this.materialTextBox1.TrailingIcon = null;
            // 
            // RegistrarotionUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 450);
            this.Controls.Add(this.materialTextBox1);
            this.Controls.Add(this.PW_textBox);
            this.Controls.Add(this.ID_textBox);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarotionUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrarotionUserForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox PW_textBox;
        private MaterialSkin.Controls.MaterialTextBox ID_textBox;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private Label label2;
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
    }
}