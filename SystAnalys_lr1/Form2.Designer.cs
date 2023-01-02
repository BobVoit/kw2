namespace SystAnalys_lr1
{
    partial class CloseForm
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
            this.BackInMainMenu = new System.Windows.Forms.Button();
            this.CloseApp = new System.Windows.Forms.Button();
            this.CancelClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackInMainMenu
            // 
            this.BackInMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackInMainMenu.Location = new System.Drawing.Point(173, 95);
            this.BackInMainMenu.Name = "BackInMainMenu";
            this.BackInMainMenu.Size = new System.Drawing.Size(245, 40);
            this.BackInMainMenu.TabIndex = 0;
            this.BackInMainMenu.Text = "Вернуться в главное меню";
            this.BackInMainMenu.UseVisualStyleBackColor = true;
            this.BackInMainMenu.Click += new System.EventHandler(this.BackInMainMenu_Click);
            // 
            // CloseApp
            // 
            this.CloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseApp.Location = new System.Drawing.Point(12, 95);
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(140, 40);
            this.CloseApp.TabIndex = 1;
            this.CloseApp.Text = "Выход";
            this.CloseApp.UseVisualStyleBackColor = true;
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // CancelClose
            // 
            this.CancelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelClose.Location = new System.Drawing.Point(441, 95);
            this.CancelClose.Name = "CancelClose";
            this.CancelClose.Size = new System.Drawing.Size(140, 40);
            this.CancelClose.TabIndex = 2;
            this.CancelClose.Text = "Отмена";
            this.CancelClose.UseVisualStyleBackColor = true;
            this.CancelClose.Click += new System.EventHandler(this.CancelClose_Click);
            // 
            // CloseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 212);
            this.Controls.Add(this.CancelClose);
            this.Controls.Add(this.CloseApp);
            this.Controls.Add(this.BackInMainMenu);
            this.Name = "CloseForm";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackInMainMenu;
        private System.Windows.Forms.Button CloseApp;
        private System.Windows.Forms.Button CancelClose;
    }
}