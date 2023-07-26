namespace ReProject
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
            this.List = new System.Windows.Forms.GroupBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Timer = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.position_Label = new System.Windows.Forms.Label();
            this.position_O = new System.Windows.Forms.Label();
            this.sale_Label = new System.Windows.Forms.Label();
            this.sale_T = new System.Windows.Forms.TextBox();
            this.sale = new System.Windows.Forms.Label();
            this.purchase_T = new System.Windows.Forms.TextBox();
            this.purchase_Label = new System.Windows.Forms.Label();
            this.count_T = new System.Windows.Forms.TextBox();
            this.purchase = new System.Windows.Forms.Label();
            this.sale_TT = new System.Windows.Forms.Label();
            this.count_Label = new System.Windows.Forms.Label();
            this.purchase_TT = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.count_TT = new System.Windows.Forms.Label();
            this.Out = new System.Windows.Forms.Button();
            this.position_T = new System.Windows.Forms.TextBox();
            this.Barcd_F_T = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Find = new System.Windows.Forms.Button();
            this.position = new System.Windows.Forms.Label();
            this.barcd_F = new System.Windows.Forms.Label();
            this.barcd_Label = new System.Windows.Forms.Label();
            this.div_n_Label = new System.Windows.Forms.Label();
            this.div_m_Label = new System.Windows.Forms.Label();
            this.img_prod_nm_Label = new System.Windows.Forms.Label();
            this.item_no_Label = new System.Windows.Forms.Label();
            this.nutrition_info_Label = new System.Windows.Forms.Label();
            this.volume_Label = new System.Windows.Forms.Label();
            this.comp_nm_Label = new System.Windows.Forms.Label();
            this.div_s_Label = new System.Windows.Forms.Label();
            this.div_l_Label = new System.Windows.Forms.Label();
            this.item_cd_Label = new System.Windows.Forms.Label();
            this.barcd = new System.Windows.Forms.Label();
            this.nutrition_info = new System.Windows.Forms.Label();
            this.volume = new System.Windows.Forms.Label();
            this.img_prod_nm = new System.Windows.Forms.Label();
            this.comp_nm = new System.Windows.Forms.Label();
            this.div_n = new System.Windows.Forms.Label();
            this.div_s = new System.Windows.Forms.Label();
            this.div_m = new System.Windows.Forms.Label();
            this.item_cd = new System.Windows.Forms.Label();
            this.div_l = new System.Windows.Forms.Label();
            this.item_no = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compnmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgprodnmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcdDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nutritioninfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.Controls.Add(this.DataGridView1);
            this.List.Controls.Add(this.Timer);
            this.List.Controls.Add(this.Time);
            this.List.Controls.Add(this.Log);
            this.List.Location = new System.Drawing.Point(12, 288);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(1002, 378);
            this.List.TabIndex = 6;
            this.List.TabStop = false;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AutoGenerateColumns = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.positionDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.itemcdDataGridViewTextBoxColumn,
            this.itemnoDataGridViewTextBoxColumn,
            this.divlDataGridViewTextBoxColumn,
            this.divmDataGridViewTextBoxColumn,
            this.divsDataGridViewTextBoxColumn,
            this.divnDataGridViewTextBoxColumn,
            this.compnmDataGridViewTextBoxColumn,
            this.imgprodnmDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.barcdDV,
            this.nutritioninfoDataGridViewTextBoxColumn,
            this.purchaseDataGridViewTextBoxColumn,
            this.saleDataGridViewTextBoxColumn});
            this.DataGridView1.DataSource = this.productBindingSource;
            this.DataGridView1.Location = new System.Drawing.Point(0, 7);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.Size = new System.Drawing.Size(1002, 253);
            this.DataGridView1.TabIndex = 4;
            this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(ReProject.product);
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Location = new System.Drawing.Point(1, 360);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(38, 12);
            this.Timer.TabIndex = 3;
            this.Timer.Text = "Timer";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(0, 360);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(0, 12);
            this.Time.TabIndex = 2;
            // 
            // Log
            // 
            this.Log.FormattingEnabled = true;
            this.Log.ItemHeight = 12;
            this.Log.Location = new System.Drawing.Point(0, 266);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(1002, 88);
            this.Log.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.position_Label);
            this.groupBox1.Controls.Add(this.position_O);
            this.groupBox1.Controls.Add(this.sale_Label);
            this.groupBox1.Controls.Add(this.sale_T);
            this.groupBox1.Controls.Add(this.sale);
            this.groupBox1.Controls.Add(this.purchase_T);
            this.groupBox1.Controls.Add(this.purchase_Label);
            this.groupBox1.Controls.Add(this.count_T);
            this.groupBox1.Controls.Add(this.purchase);
            this.groupBox1.Controls.Add(this.sale_TT);
            this.groupBox1.Controls.Add(this.count_Label);
            this.groupBox1.Controls.Add(this.purchase_TT);
            this.groupBox1.Controls.Add(this.count);
            this.groupBox1.Controls.Add(this.count_TT);
            this.groupBox1.Controls.Add(this.Out);
            this.groupBox1.Controls.Add(this.position_T);
            this.groupBox1.Controls.Add(this.Barcd_F_T);
            this.groupBox1.Controls.Add(this.Add);
            this.groupBox1.Controls.Add(this.Find);
            this.groupBox1.Controls.Add(this.position);
            this.groupBox1.Controls.Add(this.barcd_F);
            this.groupBox1.Controls.Add(this.barcd_Label);
            this.groupBox1.Controls.Add(this.div_n_Label);
            this.groupBox1.Controls.Add(this.div_m_Label);
            this.groupBox1.Controls.Add(this.img_prod_nm_Label);
            this.groupBox1.Controls.Add(this.item_no_Label);
            this.groupBox1.Controls.Add(this.nutrition_info_Label);
            this.groupBox1.Controls.Add(this.volume_Label);
            this.groupBox1.Controls.Add(this.comp_nm_Label);
            this.groupBox1.Controls.Add(this.div_s_Label);
            this.groupBox1.Controls.Add(this.div_l_Label);
            this.groupBox1.Controls.Add(this.item_cd_Label);
            this.groupBox1.Controls.Add(this.barcd);
            this.groupBox1.Controls.Add(this.nutrition_info);
            this.groupBox1.Controls.Add(this.volume);
            this.groupBox1.Controls.Add(this.img_prod_nm);
            this.groupBox1.Controls.Add(this.comp_nm);
            this.groupBox1.Controls.Add(this.div_n);
            this.groupBox1.Controls.Add(this.div_s);
            this.groupBox1.Controls.Add(this.div_m);
            this.groupBox1.Controls.Add(this.item_cd);
            this.groupBox1.Controls.Add(this.div_l);
            this.groupBox1.Controls.Add(this.item_no);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 275);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // position_Label
            // 
            this.position_Label.AutoSize = true;
            this.position_Label.Location = new System.Drawing.Point(591, 29);
            this.position_Label.Name = "position_Label";
            this.position_Label.Size = new System.Drawing.Size(49, 12);
            this.position_Label.TabIndex = 51;
            this.position_Label.Text = "position";
            // 
            // position_O
            // 
            this.position_O.AutoSize = true;
            this.position_O.Location = new System.Drawing.Point(508, 29);
            this.position_O.Name = "position_O";
            this.position_O.Size = new System.Drawing.Size(29, 12);
            this.position_O.TabIndex = 50;
            this.position_O.Text = "위치";
            // 
            // sale_Label
            // 
            this.sale_Label.AutoSize = true;
            this.sale_Label.Location = new System.Drawing.Point(591, 143);
            this.sale_Label.Name = "sale_Label";
            this.sale_Label.Size = new System.Drawing.Size(29, 12);
            this.sale_Label.TabIndex = 49;
            this.sale_Label.Text = "sale";
            // 
            // sale_T
            // 
            this.sale_T.Location = new System.Drawing.Point(761, 174);
            this.sale_T.Name = "sale_T";
            this.sale_T.Size = new System.Drawing.Size(113, 21);
            this.sale_T.TabIndex = 37;
            // 
            // sale
            // 
            this.sale.AutoSize = true;
            this.sale.Location = new System.Drawing.Point(508, 143);
            this.sale.Name = "sale";
            this.sale.Size = new System.Drawing.Size(53, 12);
            this.sale.TabIndex = 48;
            this.sale.Text = "판매가격";
            // 
            // purchase_T
            // 
            this.purchase_T.Location = new System.Drawing.Point(761, 137);
            this.purchase_T.Name = "purchase_T";
            this.purchase_T.Size = new System.Drawing.Size(113, 21);
            this.purchase_T.TabIndex = 36;
            // 
            // purchase_Label
            // 
            this.purchase_Label.AutoSize = true;
            this.purchase_Label.Location = new System.Drawing.Point(591, 105);
            this.purchase_Label.Name = "purchase_Label";
            this.purchase_Label.Size = new System.Drawing.Size(58, 12);
            this.purchase_Label.TabIndex = 47;
            this.purchase_Label.Text = "purchase";
            // 
            // count_T
            // 
            this.count_T.Location = new System.Drawing.Point(761, 100);
            this.count_T.Name = "count_T";
            this.count_T.Size = new System.Drawing.Size(113, 21);
            this.count_T.TabIndex = 35;
            // 
            // purchase
            // 
            this.purchase.AutoSize = true;
            this.purchase.Location = new System.Drawing.Point(508, 105);
            this.purchase.Name = "purchase";
            this.purchase.Size = new System.Drawing.Size(53, 12);
            this.purchase.TabIndex = 46;
            this.purchase.Text = "구입가격";
            // 
            // sale_TT
            // 
            this.sale_TT.AutoSize = true;
            this.sale_TT.Location = new System.Drawing.Point(684, 177);
            this.sale_TT.Name = "sale_TT";
            this.sale_TT.Size = new System.Drawing.Size(53, 12);
            this.sale_TT.TabIndex = 34;
            this.sale_TT.Text = "판매가격";
            // 
            // count_Label
            // 
            this.count_Label.AutoSize = true;
            this.count_Label.Location = new System.Drawing.Point(591, 67);
            this.count_Label.Name = "count_Label";
            this.count_Label.Size = new System.Drawing.Size(36, 12);
            this.count_Label.TabIndex = 45;
            this.count_Label.Text = "count";
            // 
            // purchase_TT
            // 
            this.purchase_TT.AutoSize = true;
            this.purchase_TT.Location = new System.Drawing.Point(684, 141);
            this.purchase_TT.Name = "purchase_TT";
            this.purchase_TT.Size = new System.Drawing.Size(53, 12);
            this.purchase_TT.TabIndex = 33;
            this.purchase_TT.Text = "구입가격";
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(508, 67);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(29, 12);
            this.count.TabIndex = 44;
            this.count.Text = "개수";
            // 
            // count_TT
            // 
            this.count_TT.AutoSize = true;
            this.count_TT.Location = new System.Drawing.Point(684, 105);
            this.count_TT.Name = "count_TT";
            this.count_TT.Size = new System.Drawing.Size(29, 12);
            this.count_TT.TabIndex = 32;
            this.count_TT.Text = "개수";
            // 
            // Out
            // 
            this.Out.Location = new System.Drawing.Point(890, 151);
            this.Out.Name = "Out";
            this.Out.Size = new System.Drawing.Size(94, 55);
            this.Out.TabIndex = 31;
            this.Out.Text = "OUT";
            this.Out.UseVisualStyleBackColor = true;
            this.Out.Click += new System.EventHandler(this.Out_Click);
            // 
            // position_T
            // 
            this.position_T.Location = new System.Drawing.Point(761, 63);
            this.position_T.Name = "position_T";
            this.position_T.Size = new System.Drawing.Size(113, 21);
            this.position_T.TabIndex = 30;
            // 
            // Barcd_F_T
            // 
            this.Barcd_F_T.Location = new System.Drawing.Point(761, 26);
            this.Barcd_F_T.Name = "Barcd_F_T";
            this.Barcd_F_T.Size = new System.Drawing.Size(113, 21);
            this.Barcd_F_T.TabIndex = 29;
            this.Barcd_F_T.TextChanged += new System.EventHandler(this.Barcd_F_T_TextChanged);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(890, 85);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(94, 55);
            this.Add.TabIndex = 27;
            this.Add.Text = "ADD";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(890, 20);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(96, 55);
            this.Find.TabIndex = 26;
            this.Find.Text = "조회";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Location = new System.Drawing.Point(684, 69);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(29, 12);
            this.position.TabIndex = 24;
            this.position.Text = "위치";
            // 
            // barcd_F
            // 
            this.barcd_F.AutoSize = true;
            this.barcd_F.Location = new System.Drawing.Point(684, 33);
            this.barcd_F.Name = "barcd_F";
            this.barcd_F.Size = new System.Drawing.Size(69, 12);
            this.barcd_F.TabIndex = 22;
            this.barcd_F.Text = "바코드 검색";
            // 
            // barcd_Label
            // 
            this.barcd_Label.AutoSize = true;
            this.barcd_Label.Location = new System.Drawing.Point(353, 139);
            this.barcd_Label.Name = "barcd_Label";
            this.barcd_Label.Size = new System.Drawing.Size(37, 12);
            this.barcd_Label.TabIndex = 21;
            this.barcd_Label.Text = "barcd";
            // 
            // div_n_Label
            // 
            this.div_n_Label.AutoSize = true;
            this.div_n_Label.Location = new System.Drawing.Point(353, 102);
            this.div_n_Label.Name = "div_n_Label";
            this.div_n_Label.Size = new System.Drawing.Size(34, 12);
            this.div_n_Label.TabIndex = 20;
            this.div_n_Label.Text = "div_n";
            // 
            // div_m_Label
            // 
            this.div_m_Label.AutoSize = true;
            this.div_m_Label.Location = new System.Drawing.Point(353, 65);
            this.div_m_Label.Name = "div_m_Label";
            this.div_m_Label.Size = new System.Drawing.Size(38, 12);
            this.div_m_Label.TabIndex = 19;
            this.div_m_Label.Text = "div_m";
            // 
            // img_prod_nm_Label
            // 
            this.img_prod_nm_Label.AutoSize = true;
            this.img_prod_nm_Label.Location = new System.Drawing.Point(353, 176);
            this.img_prod_nm_Label.Name = "img_prod_nm_Label";
            this.img_prod_nm_Label.Size = new System.Drawing.Size(81, 12);
            this.img_prod_nm_Label.TabIndex = 18;
            this.img_prod_nm_Label.Text = "img_prod_nm";
            // 
            // item_no_Label
            // 
            this.item_no_Label.AutoSize = true;
            this.item_no_Label.Location = new System.Drawing.Point(353, 28);
            this.item_no_Label.Name = "item_no_Label";
            this.item_no_Label.Size = new System.Drawing.Size(49, 12);
            this.item_no_Label.TabIndex = 17;
            this.item_no_Label.Text = "item_no";
            // 
            // nutrition_info_Label
            // 
            this.nutrition_info_Label.AutoSize = true;
            this.nutrition_info_Label.Location = new System.Drawing.Point(105, 217);
            this.nutrition_info_Label.Name = "nutrition_info_Label";
            this.nutrition_info_Label.Size = new System.Drawing.Size(75, 12);
            this.nutrition_info_Label.TabIndex = 16;
            this.nutrition_info_Label.Text = "nutrition_info";
            // 
            // volume_Label
            // 
            this.volume_Label.AutoSize = true;
            this.volume_Label.Location = new System.Drawing.Point(105, 179);
            this.volume_Label.Name = "volume_Label";
            this.volume_Label.Size = new System.Drawing.Size(46, 12);
            this.volume_Label.TabIndex = 15;
            this.volume_Label.Text = "volume";
            // 
            // comp_nm_Label
            // 
            this.comp_nm_Label.AutoSize = true;
            this.comp_nm_Label.Location = new System.Drawing.Point(105, 139);
            this.comp_nm_Label.Name = "comp_nm_Label";
            this.comp_nm_Label.Size = new System.Drawing.Size(61, 12);
            this.comp_nm_Label.TabIndex = 14;
            this.comp_nm_Label.Text = "comp_nm";
            // 
            // div_s_Label
            // 
            this.div_s_Label.AutoSize = true;
            this.div_s_Label.Location = new System.Drawing.Point(105, 102);
            this.div_s_Label.Name = "div_s_Label";
            this.div_s_Label.Size = new System.Drawing.Size(34, 12);
            this.div_s_Label.TabIndex = 13;
            this.div_s_Label.Text = "div_s";
            // 
            // div_l_Label
            // 
            this.div_l_Label.AutoSize = true;
            this.div_l_Label.Location = new System.Drawing.Point(105, 65);
            this.div_l_Label.Name = "div_l_Label";
            this.div_l_Label.Size = new System.Drawing.Size(30, 12);
            this.div_l_Label.TabIndex = 12;
            this.div_l_Label.Text = "div_l";
            // 
            // item_cd_Label
            // 
            this.item_cd_Label.AutoSize = true;
            this.item_cd_Label.Location = new System.Drawing.Point(105, 28);
            this.item_cd_Label.Name = "item_cd_Label";
            this.item_cd_Label.Size = new System.Drawing.Size(49, 12);
            this.item_cd_Label.TabIndex = 11;
            this.item_cd_Label.Text = "item_cd";
            // 
            // barcd
            // 
            this.barcd.AutoSize = true;
            this.barcd.Location = new System.Drawing.Point(255, 139);
            this.barcd.Name = "barcd";
            this.barcd.Size = new System.Drawing.Size(41, 12);
            this.barcd.TabIndex = 10;
            this.barcd.Text = "바코드";
            // 
            // nutrition_info
            // 
            this.nutrition_info.AutoSize = true;
            this.nutrition_info.Location = new System.Drawing.Point(16, 218);
            this.nutrition_info.Name = "nutrition_info";
            this.nutrition_info.Size = new System.Drawing.Size(41, 12);
            this.nutrition_info.TabIndex = 9;
            this.nutrition_info.Text = "영양소";
            // 
            // volume
            // 
            this.volume.AutoSize = true;
            this.volume.Location = new System.Drawing.Point(16, 180);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(29, 12);
            this.volume.TabIndex = 8;
            this.volume.Text = "무게";
            // 
            // img_prod_nm
            // 
            this.img_prod_nm.AutoSize = true;
            this.img_prod_nm.Location = new System.Drawing.Point(255, 176);
            this.img_prod_nm.Name = "img_prod_nm";
            this.img_prod_nm.Size = new System.Drawing.Size(41, 12);
            this.img_prod_nm.TabIndex = 7;
            this.img_prod_nm.Text = "상풍명";
            // 
            // comp_nm
            // 
            this.comp_nm.AutoSize = true;
            this.comp_nm.Location = new System.Drawing.Point(16, 142);
            this.comp_nm.Name = "comp_nm";
            this.comp_nm.Size = new System.Drawing.Size(41, 12);
            this.comp_nm.TabIndex = 6;
            this.comp_nm.Text = "제작사";
            // 
            // div_n
            // 
            this.div_n.AutoSize = true;
            this.div_n.Location = new System.Drawing.Point(255, 102);
            this.div_n.Name = "div_n";
            this.div_n.Size = new System.Drawing.Size(41, 12);
            this.div_n.TabIndex = 5;
            this.div_n.Text = "세분류";
            // 
            // div_s
            // 
            this.div_s.AutoSize = true;
            this.div_s.Location = new System.Drawing.Point(16, 104);
            this.div_s.Name = "div_s";
            this.div_s.Size = new System.Drawing.Size(41, 12);
            this.div_s.TabIndex = 4;
            this.div_s.Text = "소분류";
            // 
            // div_m
            // 
            this.div_m.AutoSize = true;
            this.div_m.Location = new System.Drawing.Point(255, 65);
            this.div_m.Name = "div_m";
            this.div_m.Size = new System.Drawing.Size(41, 12);
            this.div_m.TabIndex = 3;
            this.div_m.Text = "중분류";
            // 
            // item_cd
            // 
            this.item_cd.AutoSize = true;
            this.item_cd.Location = new System.Drawing.Point(16, 28);
            this.item_cd.Name = "item_cd";
            this.item_cd.Size = new System.Drawing.Size(65, 12);
            this.item_cd.TabIndex = 0;
            this.item_cd.Text = "아이템코드";
            // 
            // div_l
            // 
            this.div_l.AutoSize = true;
            this.div_l.Location = new System.Drawing.Point(16, 66);
            this.div_l.Name = "div_l";
            this.div_l.Size = new System.Drawing.Size(41, 12);
            this.div_l.TabIndex = 2;
            this.div_l.Text = "대분류";
            // 
            // item_no
            // 
            this.item_no.AutoSize = true;
            this.item_no.Location = new System.Drawing.Point(255, 28);
            this.item_no.Name = "item_no";
            this.item_no.Size = new System.Drawing.Size(65, 12);
            this.item_no.TabIndex = 1;
            this.item_no.Text = "아이템넘버";
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "position";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "count";
            this.countDataGridViewTextBoxColumn.HeaderText = "count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            // 
            // itemcdDataGridViewTextBoxColumn
            // 
            this.itemcdDataGridViewTextBoxColumn.DataPropertyName = "item_cd";
            this.itemcdDataGridViewTextBoxColumn.HeaderText = "item_cd";
            this.itemcdDataGridViewTextBoxColumn.Name = "itemcdDataGridViewTextBoxColumn";
            // 
            // itemnoDataGridViewTextBoxColumn
            // 
            this.itemnoDataGridViewTextBoxColumn.DataPropertyName = "item_no";
            this.itemnoDataGridViewTextBoxColumn.HeaderText = "item_no";
            this.itemnoDataGridViewTextBoxColumn.Name = "itemnoDataGridViewTextBoxColumn";
            // 
            // divlDataGridViewTextBoxColumn
            // 
            this.divlDataGridViewTextBoxColumn.DataPropertyName = "div_l";
            this.divlDataGridViewTextBoxColumn.HeaderText = "div_l";
            this.divlDataGridViewTextBoxColumn.Name = "divlDataGridViewTextBoxColumn";
            // 
            // divmDataGridViewTextBoxColumn
            // 
            this.divmDataGridViewTextBoxColumn.DataPropertyName = "div_m";
            this.divmDataGridViewTextBoxColumn.HeaderText = "div_m";
            this.divmDataGridViewTextBoxColumn.Name = "divmDataGridViewTextBoxColumn";
            // 
            // divsDataGridViewTextBoxColumn
            // 
            this.divsDataGridViewTextBoxColumn.DataPropertyName = "div_s";
            this.divsDataGridViewTextBoxColumn.HeaderText = "div_s";
            this.divsDataGridViewTextBoxColumn.Name = "divsDataGridViewTextBoxColumn";
            // 
            // divnDataGridViewTextBoxColumn
            // 
            this.divnDataGridViewTextBoxColumn.DataPropertyName = "div_n";
            this.divnDataGridViewTextBoxColumn.HeaderText = "div_n";
            this.divnDataGridViewTextBoxColumn.Name = "divnDataGridViewTextBoxColumn";
            // 
            // compnmDataGridViewTextBoxColumn
            // 
            this.compnmDataGridViewTextBoxColumn.DataPropertyName = "comp_nm";
            this.compnmDataGridViewTextBoxColumn.HeaderText = "comp_nm";
            this.compnmDataGridViewTextBoxColumn.Name = "compnmDataGridViewTextBoxColumn";
            // 
            // imgprodnmDataGridViewTextBoxColumn
            // 
            this.imgprodnmDataGridViewTextBoxColumn.DataPropertyName = "img_prod_nm";
            this.imgprodnmDataGridViewTextBoxColumn.HeaderText = "img_prod_nm";
            this.imgprodnmDataGridViewTextBoxColumn.Name = "imgprodnmDataGridViewTextBoxColumn";
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            // 
            // barcdDV
            // 
            this.barcdDV.DataPropertyName = "barcd";
            this.barcdDV.HeaderText = "barcd";
            this.barcdDV.Name = "barcdDV";
            // 
            // nutritioninfoDataGridViewTextBoxColumn
            // 
            this.nutritioninfoDataGridViewTextBoxColumn.DataPropertyName = "nutrition_info";
            this.nutritioninfoDataGridViewTextBoxColumn.HeaderText = "nutrition_info";
            this.nutritioninfoDataGridViewTextBoxColumn.Name = "nutritioninfoDataGridViewTextBoxColumn";
            // 
            // purchaseDataGridViewTextBoxColumn
            // 
            this.purchaseDataGridViewTextBoxColumn.DataPropertyName = "purchase";
            this.purchaseDataGridViewTextBoxColumn.HeaderText = "purchase";
            this.purchaseDataGridViewTextBoxColumn.Name = "purchaseDataGridViewTextBoxColumn";
            // 
            // saleDataGridViewTextBoxColumn
            // 
            this.saleDataGridViewTextBoxColumn.DataPropertyName = "sale";
            this.saleDataGridViewTextBoxColumn.HeaderText = "sale";
            this.saleDataGridViewTextBoxColumn.Name = "saleDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 704);
            this.Controls.Add(this.List);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Mylneventory";
            this.List.ResumeLayout(false);
            this.List.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox List;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox position_T;
        private System.Windows.Forms.TextBox Barcd_F_T;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.Label barcd_F;
        private System.Windows.Forms.Label barcd_Label;
        private System.Windows.Forms.Label div_n_Label;
        private System.Windows.Forms.Label div_m_Label;
        private System.Windows.Forms.Label img_prod_nm_Label;
        private System.Windows.Forms.Label item_no_Label;
        private System.Windows.Forms.Label volume_Label;
        private System.Windows.Forms.Label comp_nm_Label;
        private System.Windows.Forms.Label div_s_Label;
        private System.Windows.Forms.Label div_l_Label;
        private System.Windows.Forms.Label item_cd_Label;
        private System.Windows.Forms.Label barcd;
        private System.Windows.Forms.Label nutrition_info;
        private System.Windows.Forms.Label volume;
        private System.Windows.Forms.Label img_prod_nm;
        private System.Windows.Forms.Label comp_nm;
        private System.Windows.Forms.Label div_n;
        private System.Windows.Forms.Label div_s;
        private System.Windows.Forms.Label div_m;
        private System.Windows.Forms.Label item_cd;
        private System.Windows.Forms.Label div_l;
        private System.Windows.Forms.Label item_no;
        private System.Windows.Forms.Label nutrition_info_Label;
        private System.Windows.Forms.ListBox Log;
        private System.Windows.Forms.Button Out;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label count_TT;
        private System.Windows.Forms.Label purchase_TT;
        private System.Windows.Forms.Label sale_TT;
        private System.Windows.Forms.TextBox count_T;
        private System.Windows.Forms.TextBox purchase_T;
        private System.Windows.Forms.TextBox sale_T;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Label sale_Label;
        private System.Windows.Forms.Label sale;
        private System.Windows.Forms.Label purchase_Label;
        private System.Windows.Forms.Label purchase;
        private System.Windows.Forms.Label count_Label;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Label position_O;
        private System.Windows.Forms.Label position_Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn compnmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imgprodnmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcdDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nutritioninfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleDataGridViewTextBoxColumn;
    }
}

