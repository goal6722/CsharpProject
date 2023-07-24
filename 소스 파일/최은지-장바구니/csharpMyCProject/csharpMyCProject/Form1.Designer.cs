namespace csharpMyCProject
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
			this.components = new System.ComponentModel.Container();
			this.barcd = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pay_label = new System.Windows.Forms.Label();
			this.pay = new System.Windows.Forms.Label();
			this.count_label = new System.Windows.Forms.Label();
			this.count = new System.Windows.Forms.Label();
			this.item_label = new System.Windows.Forms.Label();
			this.item = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.payDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shoppingCartBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.search = new System.Windows.Forms.Button();
			this.add = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.shoppingCartBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// barcd
			// 
			this.barcd.Location = new System.Drawing.Point(442, 45);
			this.barcd.Name = "barcd";
			this.barcd.Size = new System.Drawing.Size(100, 21);
			this.barcd.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pay_label);
			this.groupBox1.Controls.Add(this.pay);
			this.groupBox1.Controls.Add(this.count_label);
			this.groupBox1.Controls.Add(this.count);
			this.groupBox1.Controls.Add(this.item_label);
			this.groupBox1.Controls.Add(this.item);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(283, 121);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// pay_label
			// 
			this.pay_label.AutoSize = true;
			this.pay_label.Location = new System.Drawing.Point(168, 78);
			this.pay_label.Name = "pay_label";
			this.pay_label.Size = new System.Drawing.Size(59, 12);
			this.pay_label.TabIndex = 5;
			this.pay_label.Text = "pay_label";
			// 
			// pay
			// 
			this.pay.AutoSize = true;
			this.pay.Location = new System.Drawing.Point(29, 78);
			this.pay.Name = "pay";
			this.pay.Size = new System.Drawing.Size(29, 12);
			this.pay.TabIndex = 4;
			this.pay.Text = "금액";
			// 
			// count_label
			// 
			this.count_label.AutoSize = true;
			this.count_label.Location = new System.Drawing.Point(168, 56);
			this.count_label.Name = "count_label";
			this.count_label.Size = new System.Drawing.Size(69, 12);
			this.count_label.TabIndex = 3;
			this.count_label.Text = "count_label";
			// 
			// count
			// 
			this.count.AutoSize = true;
			this.count.Location = new System.Drawing.Point(29, 47);
			this.count.Name = "count";
			this.count.Size = new System.Drawing.Size(29, 12);
			this.count.TabIndex = 2;
			this.count.Text = "개수";
			// 
			// item_label
			// 
			this.item_label.AutoSize = true;
			this.item_label.Location = new System.Drawing.Point(168, 23);
			this.item_label.Name = "item_label";
			this.item_label.Size = new System.Drawing.Size(62, 12);
			this.item_label.TabIndex = 1;
			this.item_label.Text = "item_label";
			// 
			// item
			// 
			this.item.AutoSize = true;
			this.item.Location = new System.Drawing.Point(29, 23);
			this.item.Name = "item";
			this.item.Size = new System.Drawing.Size(41, 12);
			this.item.TabIndex = 0;
			this.item.Text = "상품명";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Location = new System.Drawing.Point(0, 138);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(716, 238);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.payDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.shoppingCartBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(6, 13);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(698, 219);
			this.dataGridView1.TabIndex = 0;
			// 
			// itemDataGridViewTextBoxColumn
			// 
			this.itemDataGridViewTextBoxColumn.DataPropertyName = "item";
			this.itemDataGridViewTextBoxColumn.HeaderText = "item";
			this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
			this.itemDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// countDataGridViewTextBoxColumn
			// 
			this.countDataGridViewTextBoxColumn.DataPropertyName = "count";
			this.countDataGridViewTextBoxColumn.HeaderText = "count";
			this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
			this.countDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// payDataGridViewTextBoxColumn
			// 
			this.payDataGridViewTextBoxColumn.DataPropertyName = "pay";
			this.payDataGridViewTextBoxColumn.HeaderText = "pay";
			this.payDataGridViewTextBoxColumn.Name = "payDataGridViewTextBoxColumn";
			this.payDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// shoppingCartBindingSource
			// 
			this.shoppingCartBindingSource.DataSource = typeof(csharpMyCProject.ShoppingCart);
			// 
			// search
			// 
			this.search.Location = new System.Drawing.Point(583, 36);
			this.search.Name = "search";
			this.search.Size = new System.Drawing.Size(75, 23);
			this.search.TabIndex = 2;
			this.search.Text = "조회";
			this.search.UseVisualStyleBackColor = true;
			this.search.Click += new System.EventHandler(this.search_Click);
			// 
			// add
			// 
			this.add.Location = new System.Drawing.Point(583, 82);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(75, 23);
			this.add.TabIndex = 3;
			this.add.Text = "추가";
			this.add.UseVisualStyleBackColor = true;
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.add);
			this.Controls.Add(this.search);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.barcd);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.shoppingCartBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox barcd;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label pay_label;
		private System.Windows.Forms.Label pay;
		private System.Windows.Forms.Label count_label;
		private System.Windows.Forms.Label count;
		private System.Windows.Forms.Label item_label;
		private System.Windows.Forms.Label item;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button search;
		private System.Windows.Forms.Button add;
		private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn payDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource shoppingCartBindingSource;
	}
}

