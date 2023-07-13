using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
   class Nesnelerim
    {
    }
    class lStandart : Label //sınıfımıza label özelliği kazandırdık miras almada diyebiliriz
    {
        public lStandart()
        {
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Text = "lStandart";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "lStandart";
        }

    }
    class bStandart : Button //ctor fsatis dizaynımızdan butonun kodlarını kopyaladık
    {
        public bStandart()
        {
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.Dock = System.Windows.Forms.DockStyle.None;
            this.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Image = global::BarkodluSatis.Properties.Resources.tl_48;
            this.Location = new System.Drawing.Point(1, 1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "bNakit";
            this.Size = new System.Drawing.Size(199, 108);
            this.TabIndex = 0;
            this.Text = "NAKİT\r\n(F1)";
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UseVisualStyleBackColor = false;         
        }
    }
    class tStandart :TextBox
    {
        public tStandart()
        {
            this.Size = new System.Drawing.Size(250, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            
        }
    }
    class tNumeric : TextBox
    {
        public tNumeric()
        {
            this.Size = new System.Drawing.Size(115, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Name = "tNumeric";
            this.TextAlign=System.Windows.Forms.HorizontalAlignment.Right;
            this.Click += TNumeric_Click; //tıklamada üzerindeki karakterlerin tamamanı seçeceğiz
            this.KeyPress += TNumeric_KeyPress;
        }

        private void TNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08 && e.KeyChar!=(char)44)
            {
                e.Handled = true; 
            }
        }

        private void TNumeric_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }
    }
    class gridOzel : DataGridView
    {
        public gridOzel() 
        {
            this.AllowUserToAddRows = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DefaultCellStyle.BackColor = System.Drawing.Color.DimGray;
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = this.DefaultCellStyle;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableHeadersVisualStyles = false;
            this.Location = new System.Drawing.Point(3, 123);
            this.Name = "gridSatisListesi";
            this.RowHeadersVisible = false;
            this.RowHeadersWidth = 51;
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.RowsDefaultCellStyle = this.DefaultCellStyle;
            this.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.RowTemplate.Height = 32;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Size = new System.Drawing.Size(600, 422);
        }
    }
}

