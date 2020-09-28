namespace simulacionAspiradora
{
    partial class formaEntrada
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
            this.iniciarSimulacion = new System.Windows.Forms.Button();
            this.inputEspacios = new System.Windows.Forms.TextBox();
            this.inputSuciedad = new System.Windows.Forms.TextBox();
            this.inputPosicion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // iniciarSimulacion
            // 
            this.iniciarSimulacion.Location = new System.Drawing.Point(97, 136);
            this.iniciarSimulacion.Name = "iniciarSimulacion";
            this.iniciarSimulacion.Size = new System.Drawing.Size(75, 23);
            this.iniciarSimulacion.TabIndex = 0;
            this.iniciarSimulacion.Text = "Iniciar";
            this.iniciarSimulacion.UseVisualStyleBackColor = true;
            this.iniciarSimulacion.Click += new System.EventHandler(this.iniciarSimulacion_Click);
            // 
            // inputEspacios
            // 
            this.inputEspacios.Location = new System.Drawing.Point(84, 25);
            this.inputEspacios.Name = "inputEspacios";
            this.inputEspacios.Size = new System.Drawing.Size(100, 20);
            this.inputEspacios.TabIndex = 1;
            this.inputEspacios.TextChanged += new System.EventHandler(this.inputEspacios_TextChanged);
            // 
            // inputSuciedad
            // 
            this.inputSuciedad.Location = new System.Drawing.Point(84, 64);
            this.inputSuciedad.Name = "inputSuciedad";
            this.inputSuciedad.Size = new System.Drawing.Size(100, 20);
            this.inputSuciedad.TabIndex = 2;
            // 
            // inputPosicion
            // 
            this.inputPosicion.Location = new System.Drawing.Point(84, 103);
            this.inputPosicion.Name = "inputPosicion";
            this.inputPosicion.Size = new System.Drawing.Size(100, 20);
            this.inputPosicion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantidad de posiciones";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cantidad de posiciones con suciedad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Posición donde empezara la aspiradora (inicio: 1)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // formaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 171);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputPosicion);
            this.Controls.Add(this.inputSuciedad);
            this.Controls.Add(this.inputEspacios);
            this.Controls.Add(this.iniciarSimulacion);
            this.Name = "formaEntrada";
            this.Text = "Simulación aspiradora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button iniciarSimulacion;
        private System.Windows.Forms.TextBox inputEspacios;
        private System.Windows.Forms.TextBox inputSuciedad;
        private System.Windows.Forms.TextBox inputPosicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

