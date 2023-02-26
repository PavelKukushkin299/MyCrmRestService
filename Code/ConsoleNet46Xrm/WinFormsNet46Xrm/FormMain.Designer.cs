
namespace WinFormsNet46Xrm
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.btnGo2 = new System.Windows.Forms.Button();
            this.btnGo3 = new System.Windows.Forms.Button();
            this.btnGo4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(93, 66);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(96, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnGo2
            // 
            this.btnGo2.Location = new System.Drawing.Point(93, 104);
            this.btnGo2.Name = "btnGo2";
            this.btnGo2.Size = new System.Drawing.Size(96, 23);
            this.btnGo2.TabIndex = 1;
            this.btnGo2.Text = "Go2";
            this.btnGo2.UseVisualStyleBackColor = true;
            this.btnGo2.Click += new System.EventHandler(this.btnGo2_Click);
            // 
            // btnGo3
            // 
            this.btnGo3.Location = new System.Drawing.Point(215, 66);
            this.btnGo3.Name = "btnGo3";
            this.btnGo3.Size = new System.Drawing.Size(96, 23);
            this.btnGo3.TabIndex = 2;
            this.btnGo3.Text = "Go3";
            this.btnGo3.UseVisualStyleBackColor = true;
            this.btnGo3.Click += new System.EventHandler(this.btnGo3_Click);
            // 
            // btnGo4
            // 
            this.btnGo4.Location = new System.Drawing.Point(215, 104);
            this.btnGo4.Name = "btnGo4";
            this.btnGo4.Size = new System.Drawing.Size(96, 23);
            this.btnGo4.TabIndex = 3;
            this.btnGo4.Text = "Go4";
            this.btnGo4.UseVisualStyleBackColor = true;
            this.btnGo4.Click += new System.EventHandler(this.btnGo4_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGo4);
            this.Controls.Add(this.btnGo3);
            this.Controls.Add(this.btnGo2);
            this.Controls.Add(this.btnGo);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnGo2;
        private System.Windows.Forms.Button btnGo3;
        private System.Windows.Forms.Button btnGo4;
    }
}

