namespace Client_support_report_temporary
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_AddEditCancel = new System.Windows.Forms.Button();
            this.btn_AddEdit_common = new System.Windows.Forms.Button();
            this.tbox_AddEdit_Common = new System.Windows.Forms.TextBox();
            this.lbl_AddEidt_common = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbbox_SprtType = new System.Windows.Forms.ComboBox();
            this.cmbbox_SprtMethod = new System.Windows.Forms.ComboBox();
            this.cmbbox_Worker = new System.Windows.Forms.ComboBox();
            this.cmbbox_CustUser = new System.Windows.Forms.ComboBox();
            this.cmbbox_Customer = new System.Windows.Forms.ComboBox();
            this.BTN_SprtType_Edit = new System.Windows.Forms.Button();
            this.btn_SprtType_Add = new System.Windows.Forms.Button();
            this.btn_SprtMethod_Edit = new System.Windows.Forms.Button();
            this.btn_SprtMethod_Add = new System.Windows.Forms.Button();
            this.btn_Worker_Edit = new System.Windows.Forms.Button();
            this.btn_Worker_Add = new System.Windows.Forms.Button();
            this.btn_CustUser_Edit = new System.Windows.Forms.Button();
            this.btn_CustUser_Add = new System.Windows.Forms.Button();
            this.btn_Customer_EDIT = new System.Windows.Forms.Button();
            this.btn_Customer_add = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LSTBOX_ING = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Restart_log = new System.Windows.Forms.Button();
            this.txtBOX_DESC = new System.Windows.Forms.TextBox();
            this.btn_CLOSE_log = new System.Windows.Forms.Button();
            this.btn_Hold_log = new System.Windows.Forms.Button();
            this.btn_Start_log = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_AddEditCancel);
            this.panel1.Controls.Add(this.btn_AddEdit_common);
            this.panel1.Controls.Add(this.tbox_AddEdit_Common);
            this.panel1.Controls.Add(this.lbl_AddEidt_common);
            this.panel1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(12, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 139);
            this.panel1.TabIndex = 0;
            // 
            // btn_AddEditCancel
            // 
            this.btn_AddEditCancel.Location = new System.Drawing.Point(107, 87);
            this.btn_AddEditCancel.Name = "btn_AddEditCancel";
            this.btn_AddEditCancel.Size = new System.Drawing.Size(82, 27);
            this.btn_AddEditCancel.TabIndex = 3;
            this.btn_AddEditCancel.Text = "취소";
            this.btn_AddEditCancel.UseVisualStyleBackColor = true;
            this.btn_AddEditCancel.Click += new System.EventHandler(this.btn_AddEditCancel_Click);
            // 
            // btn_AddEdit_common
            // 
            this.btn_AddEdit_common.Location = new System.Drawing.Point(19, 87);
            this.btn_AddEdit_common.Name = "btn_AddEdit_common";
            this.btn_AddEdit_common.Size = new System.Drawing.Size(82, 27);
            this.btn_AddEdit_common.TabIndex = 2;
            this.btn_AddEdit_common.Text = "button1";
            this.btn_AddEdit_common.UseVisualStyleBackColor = true;
            this.btn_AddEdit_common.Click += new System.EventHandler(this.btn_AddEdit_common_Click);
            // 
            // tbox_AddEdit_Common
            // 
            this.tbox_AddEdit_Common.Location = new System.Drawing.Point(19, 49);
            this.tbox_AddEdit_Common.Name = "tbox_AddEdit_Common";
            this.tbox_AddEdit_Common.Size = new System.Drawing.Size(129, 25);
            this.tbox_AddEdit_Common.TabIndex = 1;
            this.tbox_AddEdit_Common.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_AddEdit_Common_KeyDown);
            // 
            // lbl_AddEidt_common
            // 
            this.lbl_AddEidt_common.AutoSize = true;
            this.lbl_AddEidt_common.Location = new System.Drawing.Point(17, 22);
            this.lbl_AddEidt_common.Name = "lbl_AddEidt_common";
            this.lbl_AddEidt_common.Size = new System.Drawing.Size(43, 17);
            this.lbl_AddEidt_common.TabIndex = 0;
            this.lbl_AddEidt_common.Text = "label7";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbbox_SprtType);
            this.panel2.Controls.Add(this.cmbbox_SprtMethod);
            this.panel2.Controls.Add(this.cmbbox_Worker);
            this.panel2.Controls.Add(this.cmbbox_CustUser);
            this.panel2.Controls.Add(this.cmbbox_Customer);
            this.panel2.Controls.Add(this.BTN_SprtType_Edit);
            this.panel2.Controls.Add(this.btn_SprtType_Add);
            this.panel2.Controls.Add(this.btn_SprtMethod_Edit);
            this.panel2.Controls.Add(this.btn_SprtMethod_Add);
            this.panel2.Controls.Add(this.btn_Worker_Edit);
            this.panel2.Controls.Add(this.btn_Worker_Add);
            this.panel2.Controls.Add(this.btn_CustUser_Edit);
            this.panel2.Controls.Add(this.btn_CustUser_Add);
            this.panel2.Controls.Add(this.btn_Customer_EDIT);
            this.panel2.Controls.Add(this.btn_Customer_add);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 127);
            this.panel2.TabIndex = 1;
            // 
            // cmbbox_SprtType
            // 
            this.cmbbox_SprtType.FormattingEnabled = true;
            this.cmbbox_SprtType.Location = new System.Drawing.Point(458, 35);
            this.cmbbox_SprtType.Name = "cmbbox_SprtType";
            this.cmbbox_SprtType.Size = new System.Drawing.Size(103, 25);
            this.cmbbox_SprtType.TabIndex = 19;
            this.cmbbox_SprtType.SelectedIndexChanged += new System.EventHandler(this.cmbbox_SprtType_SelectedIndexChanged);
            // 
            // cmbbox_SprtMethod
            // 
            this.cmbbox_SprtMethod.FormattingEnabled = true;
            this.cmbbox_SprtMethod.Location = new System.Drawing.Point(350, 35);
            this.cmbbox_SprtMethod.Name = "cmbbox_SprtMethod";
            this.cmbbox_SprtMethod.Size = new System.Drawing.Size(101, 25);
            this.cmbbox_SprtMethod.TabIndex = 18;
            this.cmbbox_SprtMethod.SelectedIndexChanged += new System.EventHandler(this.cmbbox_SprtMethod_SelectedIndexChanged);
            // 
            // cmbbox_Worker
            // 
            this.cmbbox_Worker.FormattingEnabled = true;
            this.cmbbox_Worker.Location = new System.Drawing.Point(250, 35);
            this.cmbbox_Worker.Name = "cmbbox_Worker";
            this.cmbbox_Worker.Size = new System.Drawing.Size(94, 25);
            this.cmbbox_Worker.TabIndex = 17;
            this.cmbbox_Worker.SelectedIndexChanged += new System.EventHandler(this.cmbbox_Worker_SelectedIndexChanged);
            // 
            // cmbbox_CustUser
            // 
            this.cmbbox_CustUser.FormattingEnabled = true;
            this.cmbbox_CustUser.Location = new System.Drawing.Point(136, 35);
            this.cmbbox_CustUser.Name = "cmbbox_CustUser";
            this.cmbbox_CustUser.Size = new System.Drawing.Size(97, 25);
            this.cmbbox_CustUser.TabIndex = 16;
            this.cmbbox_CustUser.SelectedIndexChanged += new System.EventHandler(this.cmbbox_CustUser_SelectedIndexChanged);
            // 
            // cmbbox_Customer
            // 
            this.cmbbox_Customer.FormattingEnabled = true;
            this.cmbbox_Customer.Location = new System.Drawing.Point(9, 34);
            this.cmbbox_Customer.Name = "cmbbox_Customer";
            this.cmbbox_Customer.Size = new System.Drawing.Size(107, 25);
            this.cmbbox_Customer.TabIndex = 15;
            this.cmbbox_Customer.SelectedIndexChanged += new System.EventHandler(this.cmbbox_Custermer_SelectedIndexChanged);
            // 
            // BTN_SprtType_Edit
            // 
            this.BTN_SprtType_Edit.Location = new System.Drawing.Point(458, 95);
            this.BTN_SprtType_Edit.Name = "BTN_SprtType_Edit";
            this.BTN_SprtType_Edit.Size = new System.Drawing.Size(75, 23);
            this.BTN_SprtType_Edit.TabIndex = 14;
            this.BTN_SprtType_Edit.Text = "수정";
            this.BTN_SprtType_Edit.UseVisualStyleBackColor = true;
            this.BTN_SprtType_Edit.Click += new System.EventHandler(this.BTN_SprtType_Edit_Click);
            // 
            // btn_SprtType_Add
            // 
            this.btn_SprtType_Add.Location = new System.Drawing.Point(458, 66);
            this.btn_SprtType_Add.Name = "btn_SprtType_Add";
            this.btn_SprtType_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_SprtType_Add.TabIndex = 13;
            this.btn_SprtType_Add.Text = "추가";
            this.btn_SprtType_Add.UseVisualStyleBackColor = true;
            this.btn_SprtType_Add.Click += new System.EventHandler(this.btn_SprtType_Add_Click);
            // 
            // btn_SprtMethod_Edit
            // 
            this.btn_SprtMethod_Edit.Location = new System.Drawing.Point(350, 95);
            this.btn_SprtMethod_Edit.Name = "btn_SprtMethod_Edit";
            this.btn_SprtMethod_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_SprtMethod_Edit.TabIndex = 12;
            this.btn_SprtMethod_Edit.Text = "수정";
            this.btn_SprtMethod_Edit.UseVisualStyleBackColor = true;
            this.btn_SprtMethod_Edit.Click += new System.EventHandler(this.btn_SprtMethod_Edit_Click);
            // 
            // btn_SprtMethod_Add
            // 
            this.btn_SprtMethod_Add.Location = new System.Drawing.Point(350, 66);
            this.btn_SprtMethod_Add.Name = "btn_SprtMethod_Add";
            this.btn_SprtMethod_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_SprtMethod_Add.TabIndex = 11;
            this.btn_SprtMethod_Add.Text = "추가";
            this.btn_SprtMethod_Add.UseVisualStyleBackColor = true;
            this.btn_SprtMethod_Add.Click += new System.EventHandler(this.btn_SprtMethod_Add_Click);
            // 
            // btn_Worker_Edit
            // 
            this.btn_Worker_Edit.Location = new System.Drawing.Point(250, 95);
            this.btn_Worker_Edit.Name = "btn_Worker_Edit";
            this.btn_Worker_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Worker_Edit.TabIndex = 10;
            this.btn_Worker_Edit.Text = "수정";
            this.btn_Worker_Edit.UseVisualStyleBackColor = true;
            this.btn_Worker_Edit.Click += new System.EventHandler(this.btn_Worker_Edit_Click);
            // 
            // btn_Worker_Add
            // 
            this.btn_Worker_Add.Location = new System.Drawing.Point(250, 66);
            this.btn_Worker_Add.Name = "btn_Worker_Add";
            this.btn_Worker_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Worker_Add.TabIndex = 9;
            this.btn_Worker_Add.Text = "추가";
            this.btn_Worker_Add.UseVisualStyleBackColor = true;
            this.btn_Worker_Add.Click += new System.EventHandler(this.btn_Worker_Add_Click);
            // 
            // btn_CustUser_Edit
            // 
            this.btn_CustUser_Edit.Location = new System.Drawing.Point(136, 95);
            this.btn_CustUser_Edit.Name = "btn_CustUser_Edit";
            this.btn_CustUser_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_CustUser_Edit.TabIndex = 8;
            this.btn_CustUser_Edit.Text = "수정";
            this.btn_CustUser_Edit.UseVisualStyleBackColor = true;
            this.btn_CustUser_Edit.Click += new System.EventHandler(this.btn_CustUser_Edit_Click);
            // 
            // btn_CustUser_Add
            // 
            this.btn_CustUser_Add.Location = new System.Drawing.Point(136, 66);
            this.btn_CustUser_Add.Name = "btn_CustUser_Add";
            this.btn_CustUser_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_CustUser_Add.TabIndex = 7;
            this.btn_CustUser_Add.Text = "추가";
            this.btn_CustUser_Add.UseVisualStyleBackColor = true;
            this.btn_CustUser_Add.Click += new System.EventHandler(this.btn_CustUser_Add_Click);
            // 
            // btn_Customer_EDIT
            // 
            this.btn_Customer_EDIT.Location = new System.Drawing.Point(9, 95);
            this.btn_Customer_EDIT.Name = "btn_Customer_EDIT";
            this.btn_Customer_EDIT.Size = new System.Drawing.Size(75, 23);
            this.btn_Customer_EDIT.TabIndex = 6;
            this.btn_Customer_EDIT.Text = "수정";
            this.btn_Customer_EDIT.UseVisualStyleBackColor = true;
            this.btn_Customer_EDIT.Click += new System.EventHandler(this.btn_Customer_EDIT_Click);
            // 
            // btn_Customer_add
            // 
            this.btn_Customer_add.Location = new System.Drawing.Point(9, 66);
            this.btn_Customer_add.Name = "btn_Customer_add";
            this.btn_Customer_add.Size = new System.Drawing.Size(75, 23);
            this.btn_Customer_add.TabIndex = 5;
            this.btn_Customer_add.Text = "추가";
            this.btn_Customer_add.UseVisualStyleBackColor = true;
            this.btn_Customer_add.Click += new System.EventHandler(this.btn_Customer_add_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "지원유형";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "지원방법";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "작업자명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "고객사담당자";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "고객사명";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LSTBOX_ING);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btn_Restart_log);
            this.panel3.Controls.Add(this.txtBOX_DESC);
            this.panel3.Controls.Add(this.btn_CLOSE_log);
            this.panel3.Controls.Add(this.btn_Hold_log);
            this.panel3.Controls.Add(this.btn_Start_log);
            this.panel3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel3.Location = new System.Drawing.Point(12, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(590, 184);
            this.panel3.TabIndex = 2;
            // 
            // LSTBOX_ING
            // 
            this.LSTBOX_ING.FormattingEnabled = true;
            this.LSTBOX_ING.ItemHeight = 17;
            this.LSTBOX_ING.Location = new System.Drawing.Point(11, 109);
            this.LSTBOX_ING.Name = "LSTBOX_ING";
            this.LSTBOX_ING.Size = new System.Drawing.Size(564, 72);
            this.LSTBOX_ING.TabIndex = 22;
            this.LSTBOX_ING.SelectedIndexChanged += new System.EventHandler(this.SelectedDescriptionChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "지원상세내용";
            // 
            // btn_Restart_log
            // 
            this.btn_Restart_log.Location = new System.Drawing.Point(290, 60);
            this.btn_Restart_log.Name = "btn_Restart_log";
            this.btn_Restart_log.Size = new System.Drawing.Size(135, 43);
            this.btn_Restart_log.TabIndex = 3;
            this.btn_Restart_log.Text = "지원재시작 ^";
            this.btn_Restart_log.UseVisualStyleBackColor = true;
            this.btn_Restart_log.Click += new System.EventHandler(this.btn_Restart_log_Click);
            // 
            // txtBOX_DESC
            // 
            this.txtBOX_DESC.Location = new System.Drawing.Point(11, 29);
            this.txtBOX_DESC.Name = "txtBOX_DESC";
            this.txtBOX_DESC.Size = new System.Drawing.Size(426, 25);
            this.txtBOX_DESC.TabIndex = 20;
            // 
            // btn_CLOSE_log
            // 
            this.btn_CLOSE_log.Location = new System.Drawing.Point(431, 60);
            this.btn_CLOSE_log.Name = "btn_CLOSE_log";
            this.btn_CLOSE_log.Size = new System.Drawing.Size(130, 43);
            this.btn_CLOSE_log.TabIndex = 2;
            this.btn_CLOSE_log.Text = "지원종료";
            this.btn_CLOSE_log.UseVisualStyleBackColor = true;
            this.btn_CLOSE_log.Click += new System.EventHandler(this.btn_CLOSE_log_Click);
            // 
            // btn_Hold_log
            // 
            this.btn_Hold_log.Location = new System.Drawing.Point(122, 60);
            this.btn_Hold_log.Name = "btn_Hold_log";
            this.btn_Hold_log.Size = new System.Drawing.Size(162, 43);
            this.btn_Hold_log.TabIndex = 1;
            this.btn_Hold_log.Text = "임시저장(일시정지) v";
            this.btn_Hold_log.UseVisualStyleBackColor = true;
            this.btn_Hold_log.Click += new System.EventHandler(this.btn_Hold_log_Click);
            // 
            // btn_Start_log
            // 
            this.btn_Start_log.Location = new System.Drawing.Point(12, 60);
            this.btn_Start_log.Name = "btn_Start_log";
            this.btn_Start_log.Size = new System.Drawing.Size(105, 43);
            this.btn_Start_log.TabIndex = 0;
            this.btn_Start_log.Text = "지원시작";
            this.btn_Start_log.UseVisualStyleBackColor = true;
            this.btn_Start_log.Click += new System.EventHandler(this.btn_Start_log_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 539);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "개인별 지원기록 프로그램";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbbox_SprtType;
        private System.Windows.Forms.ComboBox cmbbox_SprtMethod;
        private System.Windows.Forms.ComboBox cmbbox_Worker;
        private System.Windows.Forms.ComboBox cmbbox_CustUser;
        private System.Windows.Forms.ComboBox cmbbox_Customer;
        private System.Windows.Forms.Button BTN_SprtType_Edit;
        private System.Windows.Forms.Button btn_SprtType_Add;
        private System.Windows.Forms.Button btn_SprtMethod_Edit;
        private System.Windows.Forms.Button btn_SprtMethod_Add;
        private System.Windows.Forms.Button btn_Worker_Edit;
        private System.Windows.Forms.Button btn_Worker_Add;
        private System.Windows.Forms.Button btn_CustUser_Edit;
        private System.Windows.Forms.Button btn_CustUser_Add;
        private System.Windows.Forms.Button btn_Customer_EDIT;
        private System.Windows.Forms.Button btn_Customer_add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox LSTBOX_ING;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Restart_log;
        private System.Windows.Forms.TextBox txtBOX_DESC;
        private System.Windows.Forms.Button btn_CLOSE_log;
        private System.Windows.Forms.Button btn_Hold_log;
        private System.Windows.Forms.Button btn_Start_log;
        private System.Windows.Forms.Button btn_AddEdit_common;
        private System.Windows.Forms.TextBox tbox_AddEdit_Common;
        private System.Windows.Forms.Label lbl_AddEidt_common;
        private System.Windows.Forms.Button btn_AddEditCancel;
    }


}

