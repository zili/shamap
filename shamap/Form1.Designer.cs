namespace shamap
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.mp = new SharpMap.Forms.MapBox();
            this.grd = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // mp
            // 
            this.mp.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this.mp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mp.FineZoomFactor = 10D;
            this.mp.Location = new System.Drawing.Point(27, 61);
            this.mp.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mp.Name = "mp";
            this.mp.QueryGrowFactor = 5F;
            this.mp.QueryLayerIndex = 0;
            this.mp.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mp.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mp.ShowProgressUpdate = false;
            this.mp.Size = new System.Drawing.Size(608, 254);
            this.mp.TabIndex = 0;
            this.mp.Text = "mapBox1";
            this.mp.WheelZoomMagnitude = -2D;
            this.mp.MouseDown += new SharpMap.Forms.MapBox.MouseEventHandler(this.mp_MouseDown);
            // 
            // grd
            // 
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Location = new System.Drawing.Point(27, 332);
            this.grd.Name = "grd";
            this.grd.RowTemplate.Height = 31;
            this.grd.Size = new System.Drawing.Size(608, 317);
            this.grd.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(647, 661);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.mp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpMap.Forms.MapBox mp;
        private System.Windows.Forms.DataGridView grd;
    }
}
