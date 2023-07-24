namespace Main
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataBase = new System.Windows.Forms.GroupBox();
            this.CountMyProductNum = new System.Windows.Forms.Label();
            this.CountMyProductTable = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1MyProduct = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLarge = new System.Windows.Forms.Button();
            this.buttonSmall = new System.Windows.Forms.Button();
            this.buttonMiddle = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBoxSmall = new System.Windows.Forms.ComboBox();
            this.comboBoxLarge = new System.Windows.Forms.ComboBox();
            this.labelSmall = new System.Windows.Forms.Label();
            this.labelLarge = new System.Windows.Forms.Label();
            this.labelMiddle = new System.Windows.Forms.Label();
            this.comboBoxMIddle = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7ShowProductPriceNaver = new System.Windows.Forms.Label();
            this.SearchProductButton1 = new System.Windows.Forms.Button();
            this.textBox1SearchProduct = new System.Windows.Forms.TextBox();
            this.label1ProductName = new System.Windows.Forms.Label();
            this.pictureBox1ProductImage = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.DataBase.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1MyProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1ProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1801, 962);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1793, 930);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DataBase);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1793, 930);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "통계";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataBase
            // 
            this.DataBase.Controls.Add(this.CountMyProductNum);
            this.DataBase.Controls.Add(this.CountMyProductTable);
            this.DataBase.Location = new System.Drawing.Point(16, 14);
            this.DataBase.Name = "DataBase";
            this.DataBase.Size = new System.Drawing.Size(285, 44);
            this.DataBase.TabIndex = 15;
            this.DataBase.TabStop = false;
            this.DataBase.Text = "DataBase";
            // 
            // CountMyProductNum
            // 
            this.CountMyProductNum.AutoSize = true;
            this.CountMyProductNum.Location = new System.Drawing.Point(69, 23);
            this.CountMyProductNum.Name = "CountMyProductNum";
            this.CountMyProductNum.Size = new System.Drawing.Size(30, 18);
            this.CountMyProductNum.TabIndex = 11;
            this.CountMyProductNum.Text = "^^";
            // 
            // CountMyProductTable
            // 
            this.CountMyProductTable.AutoSize = true;
            this.CountMyProductTable.Location = new System.Drawing.Point(10, 23);
            this.CountMyProductTable.Name = "CountMyProductTable";
            this.CountMyProductTable.Size = new System.Drawing.Size(44, 18);
            this.CountMyProductTable.TabIndex = 10;
            this.CountMyProductTable.Text = "개수";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart1MyProduct);
            this.groupBox2.Location = new System.Drawing.Point(14, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1764, 686);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "차트 영역";
            // 
            // chart1MyProduct
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1MyProduct.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1MyProduct.Legends.Add(legend1);
            this.chart1MyProduct.Location = new System.Drawing.Point(0, 27);
            this.chart1MyProduct.Name = "chart1MyProduct";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1MyProduct.Series.Add(series1);
            this.chart1MyProduct.Size = new System.Drawing.Size(1768, 659);
            this.chart1MyProduct.TabIndex = 0;
            this.chart1MyProduct.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLarge);
            this.groupBox1.Controls.Add(this.buttonSmall);
            this.groupBox1.Controls.Add(this.buttonMiddle);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.comboBoxSmall);
            this.groupBox1.Controls.Add(this.comboBoxLarge);
            this.groupBox1.Controls.Add(this.labelSmall);
            this.groupBox1.Controls.Add(this.labelLarge);
            this.groupBox1.Controls.Add(this.labelMiddle);
            this.groupBox1.Controls.Add(this.comboBoxMIddle);
            this.groupBox1.Location = new System.Drawing.Point(14, 759);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 158);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "필터";
            // 
            // buttonLarge
            // 
            this.buttonLarge.Location = new System.Drawing.Point(304, 35);
            this.buttonLarge.Name = "buttonLarge";
            this.buttonLarge.Size = new System.Drawing.Size(108, 26);
            this.buttonLarge.TabIndex = 11;
            this.buttonLarge.Text = "검색";
            this.buttonLarge.UseVisualStyleBackColor = true;
            this.buttonLarge.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSmall
            // 
            this.buttonSmall.Location = new System.Drawing.Point(304, 124);
            this.buttonSmall.Name = "buttonSmall";
            this.buttonSmall.Size = new System.Drawing.Size(108, 26);
            this.buttonSmall.TabIndex = 10;
            this.buttonSmall.Text = "검색";
            this.buttonSmall.UseVisualStyleBackColor = true;
            this.buttonSmall.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonMiddle
            // 
            this.buttonMiddle.Location = new System.Drawing.Point(304, 79);
            this.buttonMiddle.Name = "buttonMiddle";
            this.buttonMiddle.Size = new System.Drawing.Size(108, 26);
            this.buttonMiddle.TabIndex = 9;
            this.buttonMiddle.Text = "검색";
            this.buttonMiddle.UseVisualStyleBackColor = true;
            this.buttonMiddle.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(458, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 26);
            this.button4.TabIndex = 8;
            this.button4.Text = "검색";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // comboBoxSmall
            // 
            this.comboBoxSmall.FormattingEnabled = true;
            this.comboBoxSmall.Location = new System.Drawing.Point(74, 124);
            this.comboBoxSmall.Name = "comboBoxSmall";
            this.comboBoxSmall.Size = new System.Drawing.Size(214, 26);
            this.comboBoxSmall.TabIndex = 7;
            // 
            // comboBoxLarge
            // 
            this.comboBoxLarge.FormattingEnabled = true;
            this.comboBoxLarge.Location = new System.Drawing.Point(74, 35);
            this.comboBoxLarge.Name = "comboBoxLarge";
            this.comboBoxLarge.Size = new System.Drawing.Size(214, 26);
            this.comboBoxLarge.TabIndex = 6;
            // 
            // labelSmall
            // 
            this.labelSmall.AutoSize = true;
            this.labelSmall.Location = new System.Drawing.Point(6, 127);
            this.labelSmall.Name = "labelSmall";
            this.labelSmall.Size = new System.Drawing.Size(62, 18);
            this.labelSmall.TabIndex = 5;
            this.labelSmall.Text = "소분류";
            // 
            // labelLarge
            // 
            this.labelLarge.AutoSize = true;
            this.labelLarge.Location = new System.Drawing.Point(6, 38);
            this.labelLarge.Name = "labelLarge";
            this.labelLarge.Size = new System.Drawing.Size(62, 18);
            this.labelLarge.TabIndex = 4;
            this.labelLarge.Text = "대분류";
            // 
            // labelMiddle
            // 
            this.labelMiddle.AutoSize = true;
            this.labelMiddle.Location = new System.Drawing.Point(6, 82);
            this.labelMiddle.Name = "labelMiddle";
            this.labelMiddle.Size = new System.Drawing.Size(62, 18);
            this.labelMiddle.TabIndex = 3;
            this.labelMiddle.Text = "중분류";
            // 
            // comboBoxMIddle
            // 
            this.comboBoxMIddle.FormattingEnabled = true;
            this.comboBoxMIddle.Location = new System.Drawing.Point(74, 79);
            this.comboBoxMIddle.Name = "comboBoxMIddle";
            this.comboBoxMIddle.Size = new System.Drawing.Size(214, 26);
            this.comboBoxMIddle.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7ShowProductPriceNaver);
            this.tabPage3.Controls.Add(this.SearchProductButton1);
            this.tabPage3.Controls.Add(this.textBox1SearchProduct);
            this.tabPage3.Controls.Add(this.label1ProductName);
            this.tabPage3.Controls.Add(this.pictureBox1ProductImage);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1793, 930);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "상품 검색";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7ShowProductPriceNaver
            // 
            this.label7ShowProductPriceNaver.AutoSize = true;
            this.label7ShowProductPriceNaver.Location = new System.Drawing.Point(1083, 679);
            this.label7ShowProductPriceNaver.Name = "label7ShowProductPriceNaver";
            this.label7ShowProductPriceNaver.Size = new System.Drawing.Size(122, 18);
            this.label7ShowProductPriceNaver.TabIndex = 4;
            this.label7ShowProductPriceNaver.Text = "네이버 최저가";
            // 
            // SearchProductButton1
            // 
            this.SearchProductButton1.Location = new System.Drawing.Point(1100, 765);
            this.SearchProductButton1.Name = "SearchProductButton1";
            this.SearchProductButton1.Size = new System.Drawing.Size(633, 127);
            this.SearchProductButton1.TabIndex = 3;
            this.SearchProductButton1.Text = "상품 검색(테스트는 10001 입력)";
            this.SearchProductButton1.UseVisualStyleBackColor = true;
            this.SearchProductButton1.Click += new System.EventHandler(this.SearchProductButton1_Click);
            // 
            // textBox1SearchProduct
            // 
            this.textBox1SearchProduct.Location = new System.Drawing.Point(1086, 729);
            this.textBox1SearchProduct.Name = "textBox1SearchProduct";
            this.textBox1SearchProduct.Size = new System.Drawing.Size(662, 28);
            this.textBox1SearchProduct.TabIndex = 2;
            // 
            // label1ProductName
            // 
            this.label1ProductName.AutoSize = true;
            this.label1ProductName.Location = new System.Drawing.Point(1083, 624);
            this.label1ProductName.Name = "label1ProductName";
            this.label1ProductName.Size = new System.Drawing.Size(62, 18);
            this.label1ProductName.TabIndex = 1;
            this.label1ProductName.Text = "상품명";
            // 
            // pictureBox1ProductImage
            // 
            this.pictureBox1ProductImage.Location = new System.Drawing.Point(1064, 21);
            this.pictureBox1ProductImage.Name = "pictureBox1ProductImage";
            this.pictureBox1ProductImage.Size = new System.Drawing.Size(701, 580);
            this.pictureBox1ProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1ProductImage.TabIndex = 0;
            this.pictureBox1ProductImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1798, 959);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.DataBase.ResumeLayout(false);
            this.DataBase.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1MyProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1ProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox1SearchProduct;
        private System.Windows.Forms.Label label1ProductName;
        private System.Windows.Forms.PictureBox pictureBox1ProductImage;
        private System.Windows.Forms.GroupBox DataBase;
        private System.Windows.Forms.Label CountMyProductNum;
        private System.Windows.Forms.Label CountMyProductTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSmall;
        private System.Windows.Forms.Button buttonMiddle;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBoxSmall;
        private System.Windows.Forms.ComboBox comboBoxLarge;
        private System.Windows.Forms.Label labelSmall;
        private System.Windows.Forms.Label labelLarge;
        private System.Windows.Forms.Label labelMiddle;
        private System.Windows.Forms.ComboBox comboBoxMIddle;
        private System.Windows.Forms.Button SearchProductButton1;
        private System.Windows.Forms.Button buttonLarge;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1MyProduct;
        private System.Windows.Forms.Label label7ShowProductPriceNaver;
    }
}

