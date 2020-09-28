namespace simulacionAspiradora
{
    partial class formaSalida
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
            this.textoDisplay = new System.Windows.Forms.TextBox();
            this.listBoxAmbiente = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textoDisplay
            // 
            this.textoDisplay.Location = new System.Drawing.Point(13, 13);
            this.textoDisplay.Multiline = true;
            this.textoDisplay.Name = "textoDisplay";
            this.textoDisplay.ReadOnly = true;
            this.textoDisplay.ShortcutsEnabled = false;
            this.textoDisplay.Size = new System.Drawing.Size(259, 236);
            this.textoDisplay.TabIndex = 0;
            // 
            // listBoxAmbiente
            // 
            this.listBoxAmbiente.FormattingEnabled = true;
            this.listBoxAmbiente.Location = new System.Drawing.Point(278, 37);
            this.listBoxAmbiente.Name = "listBoxAmbiente";
            this.listBoxAmbiente.Size = new System.Drawing.Size(223, 212);
            this.listBoxAmbiente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista de estados";
            // 
            // formaSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAmbiente);
            this.Controls.Add(this.textoDisplay);
            this.Name = "formaSalida";
            this.Text = "Simulación";
            this.Load += new System.EventHandler(this.formaSalida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoDisplay;
        private System.Windows.Forms.ListBox listBoxAmbiente;
        private System.Windows.Forms.Label label1;
    }
}