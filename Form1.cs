using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Globalization;

namespace Client_support_report_temporary
{
    public partial class Form1 : Form
    {
        private DateTime DT = new DateTime();
        XmlDocument xmlSettingDoc = new XmlDocument();
        XmlDocument xmlLogDoc = new XmlDocument();

        string sXmlFilePath;
        string sXmlOutpurPath;
        string sDirPath;
        string sOPT_stype;
        string sOPT_AE;
        string REG_ID="";
        string GSTATUS = "CLOSED";
        bool Sign_of_NotApply_ListBox_Change = false;
        bool State_support = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                     
            sDirPath = "D:\\!_Support_Report";
            DirectoryInfo di1 = new DirectoryInfo(sDirPath);
            if (di1.Exists == false)
            {
                MessageBox.Show("D:\\!_Support_Report 폴더를 생성합니다. \n 앞으로 .xml 파일 data는 아래에 저장됩니다. "); 
                di1.Create();
            }
            sXmlFilePath = sDirPath + "\\SupportInfo.xml";
            FileInfo fi1 = new FileInfo(sXmlFilePath);
            if (fi1.Exists == false)  // 파일이 존재하지 않으면 설정파일을 생성한다.
            {
                XMLCreate(sXmlFilePath, "설정");
            }
            xmlSettingDoc.Load(sXmlFilePath);
            loadxmltoForm();  /// 콤보박스의 list정보를 추가함. 
            Load_Current_Info(); // <current> 정보를 판넬이 추가 
            Load_InWork_init(); // Inwork 초기화 정보가 있을시 List Box에 추가 
            panel1.Location = new Point(12, 400);
            panel3.Location = new Point(12, 145);
            this.Width = 622;
            this.Height = 375;
            btn_CLOSE_log.Enabled = false;
            btn_Hold_log.Enabled = false;
            if ( LSTBOX_ING.Items.Count == 0 )
            {
                btn_Restart_log.Enabled = false;
            }
        }

        private void btn_AddEdit_common_Click(object sender, EventArgs e)
        // ADD/EDIT 버튼 클릭시 실행하는 모듈 
        {
            string NodeName1;
            switch (sOPT_stype)
            {
                case "Customer":
                    NodeName1 = "Customer";
                    break;
                case "Worker":
                    NodeName1 = "Worker";
                    break;
                case "SupportMethod":
                    NodeName1 = "SupportMethod";
                    break;
                case "SupportType":
                    NodeName1 = "SupportType";
                    break;
                case "CustUser":
                    NodeName1 = "CustUser";
                    break;
                default:  // 이루틴은 나올수 없슴
                    NodeName1 = "";
                    break;
            }
            if (sOPT_AE == "ADD")
            {
                if (tbox_AddEdit_Common.Text.Trim() == "")
                {
                    MessageBox.Show("추가할내용이 없습니다.");
                }
                else
                {
                    //MessageBox.Show("xml Customer 추가 .");
                    XmlNode root = xmlSettingDoc.DocumentElement;
                    XmlNode firstNode = xmlSettingDoc.CreateElement(NodeName1);
                    XmlNode SecondNode = xmlSettingDoc.CreateElement(NodeName1);
                    XmlAttribute NMAttr = xmlSettingDoc.CreateAttribute("Name");
                    if (NodeName1 != "CustUser")
                    {
                        root.AppendChild(firstNode);
                        NMAttr.Value = tbox_AddEdit_Common.Text;
                        firstNode.Attributes.Append(NMAttr);
                    }
                    else  // ( NodeName1 == "CustUser")
                    {
                        if (cmbbox_Customer.Text == "")
                        {
                            MessageBox.Show("고객사명 선택되지 않았습니다.");
                        }
                        else
                        {
                            foreach (XmlNode XmlN in root.ChildNodes)
                            {
                                if (XmlN.Name == "Customer")
                                {
                                    foreach (XmlAttribute xmlAttr in XmlN.Attributes)
                                    {
                                        if (xmlAttr.Name == "Name")
                                        {
                                            if (xmlAttr.Value == cmbbox_Customer.Text)
                                            {
                                                XmlN.AppendChild(SecondNode);
                                                NMAttr.Value = tbox_AddEdit_Common.Text;
                                                SecondNode.Attributes.Append(NMAttr);
                                            }
                                        }
                                    }

                                }

                            }
                        }
                    }
                    switch (NodeName1)
                    {
                        case "Customer":
                            cmbbox_Customer.Text = tbox_AddEdit_Common.Text;
                            cmbbox_Customer.Items.Add(cmbbox_Customer.Text);
                            cmbbox_CustUser.Text = "";
                            break;
                        case "Worker":
                            cmbbox_Worker.Text = tbox_AddEdit_Common.Text;
                            cmbbox_Worker.Items.Add(cmbbox_Worker.Text);
                            break;
                        case "SupportMethod":
                            cmbbox_SprtMethod.Text = tbox_AddEdit_Common.Text;
                            cmbbox_SprtMethod.Items.Add(cmbbox_SprtMethod.Text);
                            break;
                        case "SupportType":
                            cmbbox_SprtType.Text = tbox_AddEdit_Common.Text;
                            cmbbox_SprtType.Items.Add(cmbbox_SprtType.Text);
                            break;
                        case "CustUser":
                            cmbbox_CustUser.Text = tbox_AddEdit_Common.Text;
                            cmbbox_CustUser.Items.Add(cmbbox_CustUser.Text);
                            break;
                    }
                    panel1.Location = new Point(12, 400);
                    panel3.Location = new Point(12, 145);
                    tbox_AddEdit_Common.Text = "";
                    xmlSettingDoc.Save(sXmlFilePath);
                }

            }
            else  // (sOPT_AE == "EDIT") 
            {
                XmlNode root = xmlSettingDoc.DocumentElement;
                XmlNodeList elemList = root.ChildNodes;
                foreach (XmlNode Subnode in elemList)
                {
                    if (sOPT_stype == "CustUser")
                    {
                        if (Subnode.Name == "Customer")
                        {
                            foreach (XmlNode CustUserNode in Subnode.ChildNodes)
                            {
                                if (CustUserNode.Name == "CustUser")
                                {
                                    foreach (XmlAttribute xmlAttr in CustUserNode.Attributes)
                                    {
                                        if (xmlAttr.Name == "Name")
                                        {
                                            if (xmlAttr.Value == cmbbox_CustUser.Text)
                                            {
                                                xmlAttr.Value = tbox_AddEdit_Common.Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Subnode.Name == NodeName1)
                        {
                            foreach (XmlAttribute xmlAttr in Subnode.Attributes)
                            {
                                if (xmlAttr.Name == "Name")
                                {
                                    if (xmlAttr.Value == cmbbox_Customer.Text)
                                    {
                                        xmlAttr.Value = tbox_AddEdit_Common.Text;
                                    }
                                }
                            }
                        }
                    }
                }

                switch (sOPT_stype)
                {
                    case "Customer":
                        cmbbox_Customer.Items.RemoveAt(cmbbox_Customer.Items.IndexOf(cmbbox_Customer.Text));
                        cmbbox_Customer.Items.Add(tbox_AddEdit_Common.Text);
                        cmbbox_Customer.Text = tbox_AddEdit_Common.Text;
                        break;
                    case "Worker":
                        cmbbox_Worker.Items.RemoveAt(cmbbox_Worker.Items.IndexOf(cmbbox_Worker.Text));
                        cmbbox_Worker.Items.Add(tbox_AddEdit_Common.Text);
                        cmbbox_Worker.Text = tbox_AddEdit_Common.Text;
                        break;
                    case "SupportMethod":
                        cmbbox_SprtMethod.Items.RemoveAt(cmbbox_SprtMethod.Items.IndexOf(cmbbox_SprtMethod.Text));
                        cmbbox_SprtMethod.Items.Add(tbox_AddEdit_Common.Text);
                        cmbbox_SprtMethod.Text = tbox_AddEdit_Common.Text;
                        break;
                    case "SupportType":
                        cmbbox_SprtType.Items.RemoveAt(cmbbox_SprtType.Items.IndexOf(cmbbox_SprtType.Text));
                        cmbbox_SprtType.Items.Add(tbox_AddEdit_Common.Text);
                        cmbbox_SprtType.Text = tbox_AddEdit_Common.Text;
                        break;
                    case "CustUser":
                        cmbbox_CustUser.Items.RemoveAt(cmbbox_CustUser.Items.IndexOf(cmbbox_CustUser.Text));
                        cmbbox_CustUser.Items.Add(tbox_AddEdit_Common.Text);
                        cmbbox_CustUser.Text = tbox_AddEdit_Common.Text;
                        break;
                }

                panel1.Location = new Point(12, 400);
                panel3.Location = new Point(12, 145);
                tbox_AddEdit_Common.Text = "";
                xmlSettingDoc.Save(sXmlFilePath);
            }
        }

        private void btn_AddEditCancel_Click(object sender, EventArgs e)
        // ADDEDITCancel 버튼 클릭시 실행 
        {
            panel1.Location = new Point(12, 400);
            panel3.Location = new Point(12, 145);
        }

        private void btn_Customer_add_Click(object sender, EventArgs e)
        // Custormer(고객사) ADD버튼 클릭시 실행 
        {
            sOPT_stype = "Customer";
            sOPT_AE = "ADD";
            panel1.Location = new Point(12, 145);
            panel3.Location = new Point(12, 400);
            lbl_AddEidt_common.Text = "업체명추가";
            btn_AddEdit_common.Text = "추가";
        }

        private void btn_Customer_EDIT_Click(object sender, EventArgs e)
        // Customer(고객사) EDIT 버튼 클릭시 실행 
        {

            if (cmbbox_Customer.Text == "")
            {
                MessageBox.Show("고객사가 선택되지 않았습니다.");
            } else
            {
                tbox_AddEdit_Common.Text = cmbbox_Customer.Text;
                sOPT_stype = "Customer";
                sOPT_AE = "EDIT";
                panel1.Location = new Point(12, 145);
                panel3.Location = new Point(12, 400);
                lbl_AddEidt_common.Text = "업체명수정";
                btn_AddEdit_common.Text = "UPDATE";
            }
        }

        private void btn_Worker_Add_Click(object sender, EventArgs e)
        // Worcker(작업자) ADD 버튼 클릭시 실행
        {
            sOPT_stype = "Worker";
            sOPT_AE = "ADD";
            panel1.Location = new Point(12, 145);
            panel3.Location = new Point(12, 400);
            lbl_AddEidt_common.Text = "작업자추가";
            btn_AddEdit_common.Text = "추가";
        }

        private void btn_SprtMethod_Add_Click(object sender, EventArgs e)
        // SprtMethod(지원방법) ADD 버튼 클릭시 실행 
        {
            sOPT_stype = "SupportMethod";
            sOPT_AE = "ADD";
            panel1.Location = new Point(12, 145);
            panel3.Location = new Point(12, 400);
            lbl_AddEidt_common.Text = "지원방법추가";
            btn_AddEdit_common.Text = "추가";
        }

        private void btn_SprtType_Add_Click(object sender, EventArgs e)
        // SprtType(지원타입) ADD버튼 클릭시 실행 
        {
            sOPT_stype = "SupportType";
            sOPT_AE = "ADD";
            panel1.Location = new Point(12, 145);
            panel3.Location = new Point(12, 400);
            lbl_AddEidt_common.Text = "지원Type추가";
            btn_AddEdit_common.Text = "추가";
        }

        private void cmbbox_Custermer_SelectedIndexChanged(object sender, EventArgs e)
        // Customer ComboBOX의 내용을 변경하면 --> CustUser의 CompoBOX의 내용이 갱신된다. 
        {
            XmlNode root = xmlSettingDoc.DocumentElement;
            XmlNodeList elemList;
            XmlNode Customer1 = root; // 임시 할당
            cmbbox_CustUser.Items.Clear();
            cmbbox_CustUser.Text = "";
            XmlNode Node1 = null;
            elemList = root.ChildNodes;
            foreach (XmlNode Subnode in elemList)
            {
                // CuatUser의 콤보박스 재등록 
                if (Subnode.Name == "Customer")
                {
                    foreach (XmlAttribute xmlAttr in Subnode.Attributes)
                    {
                        if (xmlAttr.Name == "Name")
                        {
                            if (xmlAttr.Value == cmbbox_Customer.Text)
                            {
                                foreach (XmlNode Subnode2 in Subnode.ChildNodes)
                                {
                                    if (Subnode2.Name == "CustUser")
                                    {
                                        foreach (XmlAttribute xmlAttr2 in Subnode2.Attributes)
                                        {
                                            if (xmlAttr2.Name == "Name")
                                            {
                                                cmbbox_CustUser.Items.Add(xmlAttr2.Value);
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            btn_Start_log.Enabled = true;
            btn_Restart_log.Enabled = false;
            btn_Hold_log.Enabled = false;
            btn_CLOSE_log.Enabled = false;
        }

        private void btn_CustUser_Add_Click(object sender, EventArgs e)
        // CustUser ADD 버튼 클릭시 실행 
        {
            sOPT_stype = "CustUser";
            sOPT_AE = "ADD";
            panel1.Location = new Point(12, 145);
            panel3.Location = new Point(12, 400);
            lbl_AddEidt_common.Text = "고객 사용자 추가";
            btn_AddEdit_common.Text = "추가";
        }

        private void btn_CustUser_Edit_Click(object sender, EventArgs e)
        // CustUser EDIT 버튼 클릭시 실행 
        {
            XmlNodeList xNodelist;
            XmlNode xNode;
            XmlNode xNodeParent;
            XmlAttribute xAttrParent = null;
            xNode = xmlSettingDoc.DocumentElement;
            xNodelist = xNode.SelectNodes("descendant::CustUser");

            if (cmbbox_CustUser.Text == "")
            {
                MessageBox.Show("사용자가 선택되지 않았습니다.");
            }
            else
            {
                foreach (XmlNode N1 in xNodelist)
                {
                    xNodeParent = N1.ParentNode;
                    foreach (XmlAttribute xAttr in xNodeParent.Attributes)
                    {
                        if (xAttr.Name == "Name")
                        {
                            xAttrParent = xAttr;
                        }
                    }
                    foreach (XmlAttribute A1 in N1.Attributes)
                    {
                        if (xAttrParent.Value == cmbbox_Customer.Text)
                        {
                            //  여기 작업하다 빠져나감. 
                            Console.WriteLine(N1.Name + " " + A1.Name + " " + A1.Value);

                            if (cmbbox_Customer.Text == "")
                            {
                                MessageBox.Show("고객사가 선택되지 않았습니다.");
                            }
                            else
                            {
                                tbox_AddEdit_Common.Text = cmbbox_CustUser.Text;
                                sOPT_stype = "CustUser";
                                sOPT_AE = "EDIT";
                                panel1.Location = new Point(12, 145);
                                panel3.Location = new Point(12, 400);
                                lbl_AddEidt_common.Text = "사용자명수정";
                                btn_AddEdit_common.Text = "UPDATE";
                            }
                        }
                    }
                }
            }
        }

        private void cmbbox_CustUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 아무것도하지말것 ,      임시저장 xml 를  Form1_Close시로 변경
        }
        private void Current_Cmb_Texts_Update()
        // 현재 선택된  combo box의 Text를 Update하기 
        {
            XmlNode root = xmlSettingDoc.DocumentElement;
            XmlNodeList elemList;
            elemList = root.ChildNodes;
            foreach (XmlNode Subnode in elemList)
            {
                if (Subnode.Name == "Current")
                {
                    Subnode.RemoveAll();
                    XmlNode node1 = xmlSettingDoc.CreateElement("Customer");
                    Subnode.AppendChild(node1);
                    node1.InnerText = cmbbox_Customer.Text;
                    node1 = xmlSettingDoc.CreateElement("CustUser");
                    Subnode.AppendChild(node1);
                    node1.InnerText = cmbbox_CustUser.Text;
                    node1 = xmlSettingDoc.CreateElement("Worker");
                    Subnode.AppendChild(node1);
                    node1.InnerText = cmbbox_Worker.Text;
                    node1 = xmlSettingDoc.CreateElement("SprtMethod");
                    Subnode.AppendChild(node1);
                    node1.InnerText = cmbbox_SprtMethod.Text;
                    node1 = xmlSettingDoc.CreateElement("SprtType");
                    Subnode.AppendChild(node1);
                    node1.InnerText = cmbbox_SprtType.Text;
                    xmlSettingDoc.Save(sXmlFilePath);
                }
            }
            btn_Start_log.Enabled = true;
            btn_Restart_log.Enabled = false;
            btn_Hold_log.Enabled = false;
            btn_CLOSE_log.Enabled = false;
        }


        private void tbox_AddEdit_Common_KeyDown(object sender, KeyEventArgs e)
        // 추가또는 편집 입력창에 Enter가 들어갈 경우 ( 버튼을 누름  추가됨 )
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_AddEdit_common_Click(sender, e);
            }
        }

        private void btn_Start_log_Click(object sender, EventArgs e)
        {
            State_support = true;
            if ((txtBOX_DESC.Text).Trim() == "")
            {
                MessageBox.Show("지원상세 내용이 없습니다.");
                return;
            }


            if ( LSTBOX_ING.Items.Count > 0 )
            {
                if (cmbbox_Customer.Text + "," + cmbbox_CustUser.Text + "," + txtBOX_DESC.Text == LSTBOX_ING.SelectedItem.ToString())
                {
                    MessageBox.Show("등록된 내용과 같습니다.");
                    return;
                }
            }

            REG_ID = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            Save_InWork(REG_ID); // 설정파일에 <InWork>를 xml에 등록
            Save_Log_Info("START", REG_ID); //lOG 파일이 시작기록을 남김
            GSTATUS = "STARTED";
            btn_Hold_log.Enabled = true;
            btn_CLOSE_log.Enabled = true;
            btn_Start_log.Enabled = false;
            btn_Restart_log.Enabled = false;

        }

        private void cmbbox_Worker_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Start_log.Enabled = true;
            btn_Restart_log.Enabled = false;
            btn_Hold_log.Enabled = false;
            btn_CLOSE_log.Enabled = false;
            //Current_Cmb_Texts_Update();
            // 아무것도하지말것 ,      임시저장 xml 를  Form1_Close시로 변경
        }

        private void cmbbox_SprtMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Start_log.Enabled = true;
            btn_Restart_log.Enabled = false;
            btn_Hold_log.Enabled = false;
            btn_CLOSE_log.Enabled = false;
            //Current_Cmb_Texts_Update();
            // 아무것도하지말것 ,      임시저장 xml 를  Form1_Close시로 변경
        }

        private void cmbbox_SprtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Start_log.Enabled = true;
            btn_Restart_log.Enabled = false;
            btn_Hold_log.Enabled = false;
            btn_CLOSE_log.Enabled = false;
            //Current_Cmb_Texts_Update(); 
            // 아무것도하지말것 ,      임시저장 xml 를  Form1_Close시로 변경
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Current_Cmb_Texts_Update();
            GSTATUS = "HOLDED";
            Save_Current_Info(REG_ID);
            if (GSTATUS == "STARTED" || GSTATUS == "RESTARED" )
            {
                Save_Log_Info("HOLD", REG_ID);
            }            
            REG_ID = "";
        }

        private void btn_Hold_log_Click(object sender, EventArgs e)
        {
            State_support = false;
            GSTATUS = "HOLDED";

            Save_Log_Info("HOLD",REG_ID); // log 파일에 중단 기록을 남김
            REG_ID = "";
            btn_Hold_log.Enabled = false;
            btn_CLOSE_log.Enabled = false;
            btn_Start_log.Enabled = true;
            btn_Restart_log.Enabled = true;
        }

        private void btn_Restart_log_Click(object sender, EventArgs e)
        {
            State_support = true;
            if (LSTBOX_ING.SelectedItem == null)
            {
                MessageBox.Show("아래 List에서 항목을 하나 선택하십시요.");
                return;
            }else
            {
                GSTATUS = "RESTARTED";
                REG_ID = Find_InWork(LSTBOX_ING.SelectedItem.ToString());
                Save_Log_Info("RESTART", REG_ID); // log 파일에 재시작 기록을 남김
                btn_Hold_log.Enabled = true;
                btn_CLOSE_log.Enabled = true;
                btn_Start_log.Enabled = false;
                btn_Restart_log.Enabled = false;
                return;
            }            
        }

        private void btn_CLOSE_log_Click(object sender, EventArgs e)
        {
            State_support = false;
            GSTATUS = "CLOSED";
            Sign_of_NotApply_ListBox_Change = true;
            Save_Log_Info("FINISH", REG_ID); // log 파일에 종료 기록을 남김
            Delete_Inwork_info(LSTBOX_ING.SelectedItem.ToString());            
            string Temp = LSTBOX_ING.SelectedItem.ToString();
            
            LSTBOX_ING.Items.Remove(Temp);
            txtBOX_DESC.Text = "";
            btn_Hold_log.Enabled = false;
            btn_CLOSE_log.Enabled = false;
            btn_Start_log.Enabled = true;
            btn_Restart_log.Enabled = true;
            Sign_of_NotApply_ListBox_Change = false;
        }

        private void loadxmltoForm()
        {
            XmlNode root = xmlSettingDoc.DocumentElement;
            XmlNodeList elemList = root.ChildNodes;

            foreach (XmlNode Subnode in elemList)
            {
                if (Subnode.Name == "Customer")
                {
                    foreach (XmlAttribute xmlattr in Subnode.Attributes)
                    {
                        if (xmlattr.Name == "Name")
                        {
                            cmbbox_Customer.Items.Add(xmlattr.Value);
                        }
                    }
                }
                if (Subnode.Name == "Worker")
                {
                    foreach (XmlAttribute xmlattr in Subnode.Attributes)
                    {
                        if (xmlattr.Name == "Name")
                        {
                            cmbbox_Worker.Items.Add(xmlattr.Value);
                        }
                    }
                }
                if (Subnode.Name == "SupportMethod")
                {
                    foreach (XmlAttribute xmlattr in Subnode.Attributes)
                    {
                        if (xmlattr.Name == "Name")
                        {
                            cmbbox_SprtMethod.Items.Add(xmlattr.Value);
                        }
                    }
                }
                if (Subnode.Name == "SupportType")
                {
                    foreach (XmlAttribute xmlattr in Subnode.Attributes)
                    {
                        if (xmlattr.Name == "Name")
                        {
                            cmbbox_SprtType.Items.Add(xmlattr.Value);
                        }
                    }
                }
                // 프로그램 Loading시 고객사가 선정되어 있지 않기 때문에 사용자는 combox 등록을  무시한다. 
            }
        }

        private void XMLCreate(string xmlfilename, string str1)  // 초기 xml 등록 프로그램 
        // 설정 XML 생성하는 기능 
        {
            XmlDocument NewXmlDoc = new XmlDocument();
            NewXmlDoc.AppendChild(NewXmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));
            XmlNode root = NewXmlDoc.CreateElement("Root");
            NewXmlDoc.AppendChild(root);

            switch (str1)
            {
                case "설정":
                    XmlNode node1 = NewXmlDoc.CreateElement("Current");
                    root.AppendChild(node1);
                    break;
                case "LOG":
                    break;
            }

            NewXmlDoc.Save(xmlfilename);
        }


        private void Save_Log_Info(string status1, string TempID)
        // LOG 파일의 저장 ( 아래 버튼 네게중 한개를 누를 때 시행 )
        {
            string LogFIleName;            
            DT = DateTime.Today;
            Console.WriteLine("Log_" + DT.Year.ToString() + String.Format("{0,2:00}", DT.Month)); //+ String.Format("{0,2:00}", DT.Day));
            LogFIleName = "Log_" + DT.Year.ToString() + String.Format("{0,2:00}", DT.Month); //+ String.Format("{0,2:00}", DT.Day);


            sXmlOutpurPath = sDirPath + "\\" + LogFIleName + ".xml";
            Console.WriteLine(sXmlOutpurPath);
            Load_LOG_file(sXmlOutpurPath);

            XmlNode root = xmlLogDoc.DocumentElement;
            XmlNode log = xmlLogDoc.CreateElement("LOG");
            root.AppendChild(log);            

            xmlLogDoc.AppendChild(root);
            XmlNode Node = xmlLogDoc.CreateElement("ID");
            log.AppendChild(Node);
            Node.InnerText = TempID;

            Node = xmlLogDoc.CreateElement("Date");
            log.AppendChild(Node);
            Node.InnerText = DT.Year.ToString() + String.Format("{0,2:00}", DT.Month) + String.Format("{0,2:00}", DT.Day);

            Node = xmlLogDoc.CreateElement("고객");
            log.AppendChild(Node);
            Node.InnerText = cmbbox_Customer.Text;

            Node = xmlLogDoc.CreateElement("사용자");
            log.AppendChild(Node);
            Node.InnerText = cmbbox_CustUser.Text;

            Node = xmlLogDoc.CreateElement("작업자");
            log.AppendChild(Node);
            Node.InnerText = cmbbox_Worker.Text;

            Node = xmlLogDoc.CreateElement("지원방법");
            log.AppendChild(Node);
            Node.InnerText = cmbbox_SprtMethod.Text;

            Node = xmlLogDoc.CreateElement("지원Type");
            log.AppendChild(Node);
            Node.InnerText = cmbbox_SprtType.Text;

            Node = xmlLogDoc.CreateElement("상세내용");
            log.AppendChild(Node);
            Node.InnerText = txtBOX_DESC.Text;

            Node = xmlLogDoc.CreateElement("STATUS");
            log.AppendChild(Node);
            switch (status1)
            {
                case "START":
                    Node.InnerText = "START";
                    break;
                case "HOLD":
                    Node.InnerText = "HOLD";
                    break;
                case "RESTART":
                    Node.InnerText = "RESTART";
                    break;
                case "FINISH":
                    Node.InnerText = "FINISH";
                    break;
            }

           
            Node = xmlLogDoc.CreateElement("Time");
            log.AppendChild(Node);

            //Console.WriteLine(DateTime.Now.ToString()); //+ String.Format("{0,2:00}", DT.Day));
            Node.InnerText = DateTime.Now.ToString();
            xmlLogDoc.Save(sXmlOutpurPath);
        }

        private void Load_LOG_file(string LOGFILEPath)
        // LOG 파일의 초기 load 
        {
            FileInfo fi1 = new FileInfo(LOGFILEPath);
            if (fi1.Exists == false)
            {
                XMLCreate(LOGFILEPath, "LOG");
            }
            xmlLogDoc.Load(LOGFILEPath);
        }

        private void Load_Current_Info()
        // 임시저장한 값들을 Combo Box들에 재입력 
        {
            XmlNode root = xmlSettingDoc.DocumentElement;
            XmlNodeList elemList;
            elemList = root.ChildNodes;
            foreach (XmlNode Subnode in elemList)
            {
                if (Subnode.Name == "Current")
                {
                    Console.WriteLine(Subnode.Name);
                    XmlNode Subnode2;
                    for (int i = 0; i < Subnode.ChildNodes.Count; i++)
                    //foreach(XmlNode Subnode2 in Subnode.ChildNodes )
                    {

                        Subnode2 = Subnode.ChildNodes.Item(i);
                        Console.WriteLine(Subnode2.Name + Subnode2.InnerText);
                        Console.WriteLine(Subnode.ChildNodes.Count);
                        if (Subnode2.Name == "SprtType")
                        {
                            cmbbox_SprtType.Text = Subnode2.InnerText;
                        }
                        if (Subnode2.Name == "Customer")
                        {
                            cmbbox_Customer.Text = Subnode2.InnerText;
                        }
                        if (Subnode2.Name == "CustUser")
                        {
                            cmbbox_CustUser.Text = Subnode2.InnerText;
                        }
                        if (Subnode2.Name == "Worker")
                        {
                            cmbbox_Worker.Text = Subnode2.InnerText;
                        }
                        if (Subnode2.Name == "SprtMethod")
                        {
                            cmbbox_SprtMethod.Text = Subnode2.InnerText;
                        }
                        if (Subnode2.Name == "Description")
                        {
                            txtBOX_DESC.Text = Subnode2.InnerText;
                        }
                    }
                }
            }
        }

        private void Save_Current_Info(string tempID)
        // <SaveTemp> 등록 
        {
            XmlNode root = xmlSettingDoc.DocumentElement;
            XmlNodeList elemList = root.ChildNodes;
            XmlNode subnode;

            foreach (XmlNode tempNode in elemList )
            {
                if (tempNode.Name == "Current")
                {
                    tempNode.RemoveAll() ;// 먼저 기존정보를 날린다. 

                    subnode = xmlSettingDoc.CreateElement("Customer");
                    subnode.InnerText = cmbbox_Customer.Text;
                    tempNode.AppendChild(subnode);

                    subnode = xmlSettingDoc.CreateElement("CustUser");
                    subnode.InnerText = cmbbox_CustUser.Text;
                    tempNode.AppendChild(subnode);

                    subnode = xmlSettingDoc.CreateElement("Worker");
                    subnode.InnerText = cmbbox_Worker.Text;
                    tempNode.AppendChild(subnode);

                    subnode = xmlSettingDoc.CreateElement("SprtMethod");
                    subnode.InnerText = cmbbox_SprtMethod.Text;
                    tempNode.AppendChild(subnode);

                    subnode = xmlSettingDoc.CreateElement("SprtType");
                    subnode.InnerText = cmbbox_SprtType.Text;
                    tempNode.AppendChild(subnode);

                    subnode = xmlSettingDoc.CreateElement("Description");
                    subnode.InnerText = txtBOX_DESC.Text;
                    tempNode.AppendChild(subnode);
                }
            }
            xmlSettingDoc.Save(sXmlFilePath);
        }

        private void Save_InWork(string tempID)
        // <InWork> 등록 
        {
            XmlNode root = xmlSettingDoc.DocumentElement;
            XmlNodeList elemList = root.ChildNodes;
            XmlNode TempSave = xmlSettingDoc.CreateElement("InWork");
            root.AppendChild(TempSave); 
            XmlNode subnode;
            subnode = xmlSettingDoc.CreateElement("ID");
            subnode.InnerText = tempID;
            TempSave.AppendChild(subnode);

            subnode = xmlSettingDoc.CreateElement("TEXT");
            subnode.InnerText = cmbbox_Customer.Text  + "," + cmbbox_CustUser.Text + "," + txtBOX_DESC.Text ;
            LSTBOX_ING.Items.Add(subnode.InnerText);
            LSTBOX_ING.SetSelected(LSTBOX_ING.Items.Count-1, true);
            TempSave.AppendChild(subnode); 

            subnode = xmlSettingDoc.CreateElement("Customer");
            subnode.InnerText = cmbbox_Customer.Text;
            TempSave.AppendChild(subnode);

            subnode = xmlSettingDoc.CreateElement("CustUser");
            subnode.InnerText = cmbbox_CustUser.Text;
            TempSave.AppendChild(subnode);

            subnode = xmlSettingDoc.CreateElement("Worker");
            subnode.InnerText = cmbbox_Worker.Text;
            TempSave.AppendChild(subnode);

            subnode = xmlSettingDoc.CreateElement("SprtMethod");
            subnode.InnerText = cmbbox_SprtMethod.Text ;
            TempSave.AppendChild(subnode);

            subnode = xmlSettingDoc.CreateElement("SprtType");
            subnode.InnerText = cmbbox_SprtType.Text  ;
            TempSave.AppendChild(subnode);

            subnode = xmlSettingDoc.CreateElement("Description");
            subnode.InnerText = txtBOX_DESC.Text  ;
            TempSave.AppendChild(subnode);
            xmlSettingDoc.Save(sXmlFilePath);
        }

        private string Find_InWork(string Description)
        // <InWork> 등록 정보 Panel로 끌어옴 
        {
            bool flag1 = false;
            string LastReturnVal = "";
            XmlNode SELVAL=null;
            XmlNodeList Xlist = xmlSettingDoc.SelectNodes("//Root//InWork");

            foreach (XmlNode AA in Xlist)
            {
                Console.WriteLine("get_temp_pause" + AA.Name);
                foreach ( XmlNode BB in AA.ChildNodes )
                {
                    if ( BB.Name == "TEXT")
                    {
                        if ( BB.InnerText == Description)
                        {
                            flag1 = true; // 찾았어.
                            SELVAL = AA;
                            break;
                        }
                    }
                }
            }


            if (flag1 == true)
            {
                foreach (XmlNode AA in SELVAL.ChildNodes)
                {
                    if (AA.Name == "ID")
                    {
                        LastReturnVal = AA.InnerText;
                    }
                    if (AA.Name == "Customer")
                    {
                        cmbbox_Customer.Text = AA.InnerText;
                    }
                    if (AA.Name == "CustUser")
                    {
                        cmbbox_CustUser.Text = AA.InnerText;
                    }
                    if (AA.Name == "Worker")
                    {
                        cmbbox_Worker.Text = AA.InnerText;
                    }
                    if (AA.Name == "SprtMethod")
                    {
                       cmbbox_SprtMethod.Text = AA.InnerText;
                    }
                    if (AA.Name == "SprtType")
                    {
                        cmbbox_SprtType.Text = AA.InnerText;
                    }
                    if (AA.Name == "Description")
                    {
                        txtBOX_DESC.Text = AA.InnerText;
                    }
                }
            }
            else
            {
                return "";
            }

            return LastReturnVal;
        }

        private void Delete_Inwork_info(string Description)
        // <TempSave> 항목 삭제 
        {
            bool flag1 = false;            
            XmlNode SELVAL = null;
            XmlNode SELVALParent = null;
            XmlNodeList Xlist = xmlSettingDoc.SelectNodes("//Root//InWork");

            foreach (XmlNode AA in Xlist)
            {
                Console.WriteLine("get_temp_pause" + AA.Name);
                foreach (XmlNode BB in AA.ChildNodes)
                {
                    if (BB.Name == "TEXT")
                    {
                        if (BB.InnerText == Description)
                        {
                            flag1 = true; // 찾았어.
                            SELVAL = AA;
                            break;
                        }
                    }
                }
            }
            if (flag1 == true)
            {
                SELVALParent = SELVAL.ParentNode;
                //SELVAL.RemoveAll();
                SELVALParent.RemoveChild(SELVAL);
            }
            xmlSettingDoc.Save(sXmlFilePath);
        }


        private void Load_InWork_init()
        {
            XmlNode root = xmlSettingDoc.DocumentElement;
            XmlNodeList elemList = root.ChildNodes;
            XmlNodeList elemlist2; 
            foreach (XmlNode XN in elemList)
            {
                if (XN.Name == "InWork")
                {
                    elemlist2 = XN.ChildNodes;
                    {
                        foreach ( XmlNode XN2 in elemlist2)
                        {
                            if ( XN2.Name == "TEXT")
                            {
                                LSTBOX_ING.Items.Add(XN2.InnerText); 
                            }
                        }
                    }
                }
            }
        }
        private void SelectedDescriptionChange(object sender, EventArgs e)
        {
            if ( !Sign_of_NotApply_ListBox_Change )
            {
                SELDescChange();
            }
            
        }

        private void SELDescChange()
        {
            string LogFIleName;
            DT = DateTime.Today;
            LogFIleName = "Log_" + DT.Year.ToString() + String.Format("{0,2:00}", DT.Month); //+ String.Format("{0,2:00}", DT.Day);

            sXmlOutpurPath = sDirPath + "\\" + LogFIleName + ".xml";
            Console.WriteLine(sXmlOutpurPath);
            Load_LOG_file(sXmlOutpurPath);

            XmlNodeList Xlist = xmlSettingDoc.SelectNodes("//Root//InWork");
            XmlNode LogRoot = xmlLogDoc.SelectSingleNode("//Root");
            XmlNode LogLog = null;
            XmlNode LogChild = null;
            bool Flag;
            Flag = true;

            foreach (XmlNode AA in Xlist)
            {
                Console.WriteLine(AA.Name);
                foreach (XmlNode BB in AA.ChildNodes)
                {
                    Console.WriteLine(BB.Name);
                    if (BB.Name == "TEXT")
                    {
                        Console.WriteLine(BB.InnerText);
                        Console.WriteLine((string)LSTBOX_ING.SelectedItem.ToString());
                        if (BB.InnerText == (string)LSTBOX_ING.SelectedItem.ToString())
                        {
                            Console.WriteLine("BB : " + BB.ParentNode.FirstChild.InnerText);
                            Console.WriteLine(LogRoot.Name);
                            LogLog = LogRoot.LastChild;
                            Console.WriteLine("LogLog 첫번째 노드의 Text: " + LogLog.FirstChild.InnerText);
                            while (BB.ParentNode.FirstChild.InnerText != LogLog.FirstChild.InnerText)
                            {
                                LogLog = LogLog.PreviousSibling;
                                Console.WriteLine("++");
                            }
                            LogChild = LogLog.FirstChild;
                            // 첫번째는 그냥 재낀다  IDd인걸 알기에 
                            Console.WriteLine(LogChild.Name);
                            while (LogChild.Name != "STATUS")
                            {
                                LogChild = LogChild.NextSibling;
                                Console.WriteLine("+");
                            }
                            Console.WriteLine(LogChild.Name + "," + LogChild.InnerText);

                            if (LogChild.InnerText == "START" || LogChild.InnerText == "RESTART")
                            {
                                btn_Start_log.Enabled = false;
                                btn_Restart_log.Enabled = false;
                                btn_Hold_log.Enabled = true;
                                btn_CLOSE_log.Enabled = true;
                            }
                            else
                            {
                                btn_Start_log.Enabled = false;
                                btn_Restart_log.Enabled = true;
                                btn_Hold_log.Enabled = false;
                                btn_CLOSE_log.Enabled = false;
                            }

                            Console.WriteLine("break");
                            Flag = false;
                            break;
                        }
                    }
                }
                if (!Flag)
                {
                    break;
                }
            }
        }

        private void btn_Worker_Edit_Click(object sender, EventArgs e)
        {
            if ( cmbbox_Worker.Text == "")
            {
                MessageBox.Show("작업자가 선택되지 않습니다.");
            }
            else
            {
                tbox_AddEdit_Common.Text = cmbbox_Worker.Text;
                sOPT_stype = "Worker";
                sOPT_AE = "EDIT";
                panel1.Location = new Point(12, 145);
                panel3.Location = new Point(12, 400);
                lbl_AddEidt_common.Text = "작업자수정";
                btn_AddEdit_common.Text = "UPDATE";
            }
        }

        private void btn_SprtMethod_Edit_Click(object sender, EventArgs e)
        {
            if ( cmbbox_SprtMethod.Text == "")
            {
                MessageBox.Show("지원방법이 선택되지 않았습니다.");
            }
            else
            {
                tbox_AddEdit_Common.Text = cmbbox_SprtMethod.Text;
                sOPT_stype = "SupportMethod";
                sOPT_AE = "EDIT";
                panel1.Location = new Point(12, 145);
                panel3.Location = new Point(12, 400);
                lbl_AddEidt_common.Text = "지원방법수정";
                btn_AddEdit_common.Text = "UPDATE";
            }
        }

        private void BTN_SprtType_Edit_Click(object sender, EventArgs e)
        {
            if ( cmbbox_SprtType.Text == "")
            {
                MessageBox.Show("지원유형이 선택되지 않았습니다.");
            }
            else
            {
                tbox_AddEdit_Common.Text = cmbbox_SprtType.Text;
                sOPT_stype = "SupportType";
                sOPT_AE = "EDIT";
                panel1.Location = new Point(12, 145);
                panel3.Location = new Point(12, 400);
                lbl_AddEidt_common.Text = "지원유형수정";
                btn_AddEdit_common.Text = "UPDATE";
            }
        }
    }
}
