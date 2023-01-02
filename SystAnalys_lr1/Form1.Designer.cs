namespace SystAnalys_lr1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxMatrix = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.backInMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.Button();
            this.vertexСonnectivity = new System.Windows.Forms.Button();
            this.saveInCurrent = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxMatrix
            // 
            this.listBoxMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxMatrix.FormattingEnabled = true;
            this.listBoxMatrix.ItemHeight = 25;
            this.listBoxMatrix.Location = new System.Drawing.Point(1100, 99);
            this.listBoxMatrix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxMatrix.Name = "listBoxMatrix";
            this.listBoxMatrix.Size = new System.Drawing.Size(329, 554);
            this.listBoxMatrix.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about,
            this.backInMainMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1468, 33);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // about
            // 
            this.about.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(141, 32);
            this.about.Text = "О программе";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // backInMainMenu
            // 
            this.backInMainMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.backInMainMenu.Name = "backInMainMenu";
            this.backInMainMenu.Size = new System.Drawing.Size(247, 32);
            this.backInMainMenu.Text = "Вернуться в главное меню";
            this.backInMainMenu.Click += new System.EventHandler(this.backInMainMenu_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1269, 741);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 35);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Сохранить как...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // vertexСonnectivity
            // 
            this.vertexСonnectivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vertexСonnectivity.Location = new System.Drawing.Point(1100, 660);
            this.vertexСonnectivity.Name = "vertexСonnectivity";
            this.vertexСonnectivity.Size = new System.Drawing.Size(329, 73);
            this.vertexСonnectivity.TabIndex = 14;
            this.vertexСonnectivity.Text = "Вершинная связность";
            this.vertexСonnectivity.UseVisualStyleBackColor = true;
            this.vertexСonnectivity.Click += new System.EventHandler(this.vertexСonnectivity_Click);
            // 
            // saveInCurrent
            // 
            this.saveInCurrent.Location = new System.Drawing.Point(1100, 741);
            this.saveInCurrent.Name = "saveInCurrent";
            this.saveInCurrent.Size = new System.Drawing.Size(162, 35);
            this.saveInCurrent.TabIndex = 15;
            this.saveInCurrent.Text = "Сохранить";
            this.saveInCurrent.UseVisualStyleBackColor = true;
            this.saveInCurrent.Click += new System.EventHandler(this.saveInCurrent_Click);
            // 
            // filePath
            // 
            this.filePath.Enabled = false;
            this.filePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filePath.Location = new System.Drawing.Point(105, 47);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(951, 30);
            this.filePath.TabIndex = 16;
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Image = global::SystAnalys_lr1.Properties.Resources.deleteAll;
            this.deleteALLButton.Location = new System.Drawing.Point(20, 255);
            this.deleteALLButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(68, 69);
            this.deleteALLButton.TabIndex = 5;
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::SystAnalys_lr1.Properties.Resources.delete;
            this.deleteButton.Location = new System.Drawing.Point(20, 176);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(68, 69);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Image = global::SystAnalys_lr1.Properties.Resources.edge;
            this.drawEdgeButton.Location = new System.Drawing.Point(20, 97);
            this.drawEdgeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(68, 69);
            this.drawEdgeButton.TabIndex = 2;
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Image = global::SystAnalys_lr1.Properties.Resources.vertex;
            this.drawVertexButton.Location = new System.Drawing.Point(20, 18);
            this.drawVertexButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(68, 69);
            this.drawVertexButton.TabIndex = 1;
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Location = new System.Drawing.Point(105, 99);
            this.sheet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(951, 674);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 787);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.saveInCurrent);
            this.Controls.Add(this.vertexСonnectivity);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.listBoxMatrix);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "vscode.ru";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.ListBox listBoxMatrix;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button vertexСonnectivity;
        private System.Windows.Forms.Button saveInCurrent;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.ToolStripMenuItem backInMainMenu;
    }
}

