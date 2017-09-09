namespace Pool_Application
{
    using Business_Layer;
    using Pool_Application.Properties;
    using Report_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmMain : Form
    {
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem attendanceProcessToolStripMenuItem;
        private ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private ToolStripMenuItem cancelPayReceiptToolStripMenuItem;
        private ToolStripMenuItem caocherChangeByLevalToolStripMenuItem;
        private clsGlobleVariable cGlobleVariable;
        private ToolStripMenuItem coacherBarcodeToolStripMenuItem;
        private IContainer components;
        private ToolStripMenuItem contentsToolStripMenuItem1;
        private clsUserRight cUserRights;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem dailyReportsToolStripMenuItem;
        private ToolStripMenuItem dailyToolStripMenuItem;
        private ToolStripMenuItem databaseUpdateToolStripMenuItem;
        private ToolStripMenuItem dataConvertToolStripMenuItem1;
        private ToolStripMenuItem duePaymentToolStripMenuItem;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem employeeMasterToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem holidayCalenderToolStripMenuItem;
        private ToolStripMenuItem incomingReportsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem1;
        private ToolStripMenuItem leaveInformationToolStripMenuItem;
        private ToolStripMenuItem levelChangeToolStripMenuItem;
        private ToolStripMenuItem levelWiseSummaryToolStripMenuItem;
        private ToolStripMenuItem logOffToolStripMenuItem;
        private ToolStripMenuItem manualLogEntryToolStripMenuItem;
        private ToolStripMenuItem manualLogEntryToolStripMenuItem1;
        private ToolStripMenuItem masterInformationReportToolStripMenuItem;
        private ToolStripMenuItem MenuFile;
        private ToolStripMenuItem MenuMasterSetting;
        public MenuStrip menuStrip;
        private ToolStripMenuItem multipleBreakingToolStripMenuItem;
        private ToolStripMenuItem multipleLeaveAssingToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem processesToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem rosterAssignToolStripMenuItem;
        private ToolStripMenuItem rosterScheduleToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem1;
        private ToolStripMenuItem shiftAssToolStripMenuItem;
        private string strCurrentUser;
        private string strLocationName;
        private ToolStripMenuItem studentBarcodeToolStripMenuItem;
        private ToolStripMenuItem summaryToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolTip ToolTip;
        private ToolStripMenuItem userLevelToolStripMenuItem;
        private ToolStripMenuItem userMasterToolStripMenuItem;
        private ToolStripMenuItem userRightsToolStripMenuItem;
        private ToolStripMenuItem viewStudentToolStripMenuItem;

        public frmMain()
        {
            this.components = null;
            this.cGlobleVariable = new clsGlobleVariable();
            this.cUserRights = new clsUserRight();
            this.InitializeComponent();
        }

        public frmMain(string CurrentUser, string LocationName)
        {
            this.components = null;
            this.cGlobleVariable = new clsGlobleVariable();
            this.cUserRights = new clsUserRight();
            this.InitializeComponent();
            this.strCurrentUser = CurrentUser;
            this.strLocationName = LocationName;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void attendanceProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAttendanceProcessCoacher { MdiParent = this }.Show();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBackupDatabase().Show();
        }

        private void btnInvice_Click(object sender, EventArgs e)
        {
            new frmInvoiceNew { MdiParent = this }.Show();
        }

        private void btnStudentAttendance_Click(object sender, EventArgs e)
        {
            new frmBeadBarcode { MdiParent = this }.Show();
        }

        private void btnStudentMaster_Click(object sender, EventArgs e)
        {
            new frmStudentMasterNew { MdiParent = this }.Show();
        }

        private void btnViewStudent_Click(object sender, EventArgs e)
        {
            new frmBook { MdiParent = this }.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.toolStrip1.Visible = false;
        }

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHoloidayCalender { MdiParent = this }.Show();
        }

        private void cancelPayReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCancelInvoice { MdiParent = this }.Show();
        }

        private void caocherChangeByLevalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUpdateCoachByLevel { MdiParent = this }.Show();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private bool CheckUpdates()
        {
            clsStudentPromotion promotion = new clsStudentPromotion();
            if (promotion.GetPendingPromotions(this.cGlobleVariable.LocationCode, DateTime.Now).Rows.Count > 0)
            {
                return true;
            }
            clsInvoice invoice = new clsInvoice();
            return (invoice.GetLastPaymentDates().Rows.Count > 0);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                form.Close();
            }
        }

        private void coacherBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReportViewer("rptCoacherBarcode.rpt").Show();
        }

        private void companyDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void companyWorkingDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CreateUserRights()
        {
            foreach (Control control in base.Controls)
            {
                if (object.ReferenceEquals(control.GetType(), typeof(MenuStrip)))
                {
                    DataTable table = this.cUserRights.getUserRights_Data(this.cGlobleVariable.CurrentUserID, this.cGlobleVariable.LocationCode);
                    foreach (ToolStripMenuItem item in this.menuStrip.Items)
                    {
                        foreach (ToolStripItem item2 in item.DropDownItems)
                        {
                            if (table.Rows.Count > 0)
                            {
                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    if (table.Rows[i][4].ToString() == item2.Name.ToString())
                                    {
                                        item2.Enabled = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dailyReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDailyPaymentDetails { MdiParent = this }.Show();
        }

        private void databaseUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dataConvertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmAttendanceProcess { MdiParent = this }.Show();
        }

        private void designationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void duePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDuePayStudent { MdiParent = this }.Show();
        }

        private void employeeFeedingHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void employeeLeaveCanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void employeeLeaveLeaveAssignToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmStudentMasterNew { MdiParent = this }.Show();
        }

        private void employeementTypeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void employeeRosterStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void employeeShortLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void employeeTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void examMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flexibleWorkingHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            clsSystemUpdate update = new clsSystemUpdate();
            if (!update.CheckIsUpdated() && this.CheckUpdates())
            {
                new frmSystemUpdate().ShowDialog();
            }
            this.CreateUserRights();
        }

        private void holidayCalenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHoloidayCalender { MdiParent = this }.Show();
        }

        private void incomingReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmInvoiceReports { MdiParent = this }.Show();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new MenuStrip();
            this.MenuFile = new ToolStripMenuItem();
            this.logOffToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.MenuMasterSetting = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.saveAsToolStripMenuItem = new ToolStripMenuItem();
            this.newToolStripMenuItem = new ToolStripMenuItem();
            this.employeeMasterToolStripMenuItem = new ToolStripMenuItem();
            this.saveToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator9 = new ToolStripSeparator();
            this.editMenu = new ToolStripMenuItem();
            this.holidayCalenderToolStripMenuItem = new ToolStripMenuItem();
            this.rosterAssignToolStripMenuItem = new ToolStripMenuItem();
            this.rosterScheduleToolStripMenuItem = new ToolStripMenuItem();
            this.shiftAssToolStripMenuItem = new ToolStripMenuItem();
            this.manualLogEntryToolStripMenuItem = new ToolStripMenuItem();
            this.multipleBreakingToolStripMenuItem = new ToolStripMenuItem();
            this.manualLogEntryToolStripMenuItem1 = new ToolStripMenuItem();
            this.caocherChangeByLevalToolStripMenuItem = new ToolStripMenuItem();
            this.levelChangeToolStripMenuItem = new ToolStripMenuItem();
            this.viewStudentToolStripMenuItem = new ToolStripMenuItem();
            this.leaveInformationToolStripMenuItem = new ToolStripMenuItem();
            this.multipleLeaveAssingToolStripMenuItem = new ToolStripMenuItem();
            this.cancelPayReceiptToolStripMenuItem = new ToolStripMenuItem();
            this.processesToolStripMenuItem = new ToolStripMenuItem();
            this.dataConvertToolStripMenuItem1 = new ToolStripMenuItem();
            this.attendanceProcessToolStripMenuItem = new ToolStripMenuItem();
            this.duePaymentToolStripMenuItem = new ToolStripMenuItem();
            this.reportsToolStripMenuItem = new ToolStripMenuItem();
            this.dailyReportsToolStripMenuItem = new ToolStripMenuItem();
            this.studentBarcodeToolStripMenuItem = new ToolStripMenuItem();
            this.coacherBarcodeToolStripMenuItem = new ToolStripMenuItem();
            this.summaryToolStripMenuItem = new ToolStripMenuItem();
            this.masterInformationReportToolStripMenuItem = new ToolStripMenuItem();
            this.incomingReportsToolStripMenuItem = new ToolStripMenuItem();
            this.levelWiseSummaryToolStripMenuItem = new ToolStripMenuItem();
            this.toolsToolStripMenuItem = new ToolStripMenuItem();
            this.customizeToolStripMenuItem = new ToolStripMenuItem();
            this.userLevelToolStripMenuItem = new ToolStripMenuItem();
            this.userMasterToolStripMenuItem = new ToolStripMenuItem();
            this.userRightsToolStripMenuItem = new ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.contentsToolStripMenuItem1 = new ToolStripMenuItem();
            this.indexToolStripMenuItem1 = new ToolStripMenuItem();
            this.searchToolStripMenuItem1 = new ToolStripMenuItem();
            this.toolStripSeparator12 = new ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new ToolStripMenuItem();
            this.databaseUpdateToolStripMenuItem = new ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripMenuItem1 = new ToolStripMenuItem();
            this.toolStrip1 = new ToolStrip();
            this.toolStripButton5 = new ToolStripButton();
            this.toolStripButton1 = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripButton2 = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.toolStripButton3 = new ToolStripButton();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.toolStripButton4 = new ToolStripButton();
            this.dailyToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            base.SuspendLayout();
            this.menuStrip.AllowDrop = true;
            this.menuStrip.BackColor = Color.Transparent;
            this.menuStrip.Font = new Font("Tahoma", 8.25f);
            this.menuStrip.Items.AddRange(new ToolStripItem[] { this.MenuFile, this.MenuMasterSetting, this.editMenu, this.leaveInformationToolStripMenuItem, this.processesToolStripMenuItem, this.reportsToolStripMenuItem, this.toolsToolStripMenuItem, this.helpToolStripMenuItem });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.MenuFile;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = ToolStripRenderMode.System;
            this.menuStrip.Size = new Size(0x404, 0x18);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.MenuFile.DropDownItems.AddRange(new ToolStripItem[] { this.logOffToolStripMenuItem, this.exitToolStripMenuItem });
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new Size(0x23, 20);
            this.MenuFile.Text = "&File";
            this.logOffToolStripMenuItem.Image = (Image) manager.GetObject("logOffToolStripMenuItem.Image");
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new Size(0x84, 0x16);
            this.logOffToolStripMenuItem.Text = "Log &Off";
            this.logOffToolStripMenuItem.Click += new EventHandler(this.logOffToolStripMenuItem_Click);
            this.exitToolStripMenuItem.Image = (Image) manager.GetObject("exitToolStripMenuItem.Image");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            this.exitToolStripMenuItem.Size = new Size(0x84, 0x16);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            this.MenuMasterSetting.DropDownItems.AddRange(new ToolStripItem[] { this.toolStripSeparator3, this.saveAsToolStripMenuItem, this.newToolStripMenuItem, this.employeeMasterToolStripMenuItem, this.saveToolStripMenuItem, this.toolStripSeparator9 });
            this.MenuMasterSetting.ImageTransparentColor = SystemColors.ActiveBorder;
            this.MenuMasterSetting.Name = "MenuMasterSetting";
            this.MenuMasterSetting.Overflow = ToolStripItemOverflow.AsNeeded;
            this.MenuMasterSetting.Size = new Size(0x6f, 20);
            this.MenuMasterSetting.Text = "&Master Information";
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(0xbf, 6);
            this.saveAsToolStripMenuItem.BackColor = SystemColors.AppWorkspace;
            this.saveAsToolStripMenuItem.Font = new Font("Tahoma", 8.25f);
            this.saveAsToolStripMenuItem.Image = (Image) manager.GetObject("saveAsToolStripMenuItem.Image");
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            this.saveAsToolStripMenuItem.Size = new Size(0xc2, 0x16);
            this.saveAsToolStripMenuItem.Text = "Class Master ";
            this.saveAsToolStripMenuItem.Click += new EventHandler(this.SaveAsToolStripMenuItem_Click);
            this.newToolStripMenuItem.Image = (Image) manager.GetObject("newToolStripMenuItem.Image");
            this.newToolStripMenuItem.ImageTransparentColor = Color.Black;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            this.newToolStripMenuItem.Size = new Size(0xc2, 0x16);
            this.newToolStripMenuItem.Text = "Coacher Master";
            this.newToolStripMenuItem.Click += new EventHandler(this.ShowNewForm);
            this.employeeMasterToolStripMenuItem.Image = (Image) manager.GetObject("employeeMasterToolStripMenuItem.Image");
            this.employeeMasterToolStripMenuItem.Name = "employeeMasterToolStripMenuItem";
            this.employeeMasterToolStripMenuItem.ShortcutKeys = Keys.F12;
            this.employeeMasterToolStripMenuItem.Size = new Size(0xc2, 0x16);
            this.employeeMasterToolStripMenuItem.Text = "Student Master";
            this.employeeMasterToolStripMenuItem.Click += new EventHandler(this.employeeMasterToolStripMenuItem_Click);
            this.saveToolStripMenuItem.Image = (Image) manager.GetObject("saveToolStripMenuItem.Image");
            this.saveToolStripMenuItem.ImageTransparentColor = Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            this.saveToolStripMenuItem.Size = new Size(0xc2, 0x16);
            this.saveToolStripMenuItem.Text = "Payment Method";
            this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new Size(0xbf, 6);
            this.editMenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.editMenu.DropDownItems.AddRange(new ToolStripItem[] { this.holidayCalenderToolStripMenuItem, this.rosterAssignToolStripMenuItem, this.rosterScheduleToolStripMenuItem, this.shiftAssToolStripMenuItem, this.manualLogEntryToolStripMenuItem, this.multipleBreakingToolStripMenuItem, this.manualLogEntryToolStripMenuItem1, this.caocherChangeByLevalToolStripMenuItem, this.levelChangeToolStripMenuItem, this.viewStudentToolStripMenuItem });
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new Size(0x55, 20);
            this.editMenu.Text = "&System Setup";
            this.holidayCalenderToolStripMenuItem.Name = "holidayCalenderToolStripMenuItem";
            this.holidayCalenderToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.holidayCalenderToolStripMenuItem.Text = "Holiday Calendar";
            this.holidayCalenderToolStripMenuItem.Click += new EventHandler(this.holidayCalenderToolStripMenuItem_Click);
            this.rosterAssignToolStripMenuItem.Name = "rosterAssignToolStripMenuItem";
            this.rosterAssignToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.rosterAssignToolStripMenuItem.Text = "Student Attendance";
            this.rosterAssignToolStripMenuItem.Click += new EventHandler(this.rosterAssignToolStripMenuItem_Click);
            this.rosterScheduleToolStripMenuItem.Name = "rosterScheduleToolStripMenuItem";
            this.rosterScheduleToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.rosterScheduleToolStripMenuItem.Text = "Coacher Attendance";
            this.rosterScheduleToolStripMenuItem.Click += new EventHandler(this.rosterScheduleToolStripMenuItem_Click);
            this.shiftAssToolStripMenuItem.Name = "shiftAssToolStripMenuItem";
            this.shiftAssToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.shiftAssToolStripMenuItem.Text = "Student Promotions";
            this.shiftAssToolStripMenuItem.Click += new EventHandler(this.shiftAssToolStripMenuItem_Click);
            this.manualLogEntryToolStripMenuItem.Name = "manualLogEntryToolStripMenuItem";
            this.manualLogEntryToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.manualLogEntryToolStripMenuItem.Text = "Employee Active/Cancel";
            this.manualLogEntryToolStripMenuItem.Click += new EventHandler(this.manualLogEntryToolStripMenuItem_Click);
            this.multipleBreakingToolStripMenuItem.Name = "multipleBreakingToolStripMenuItem";
            this.multipleBreakingToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.multipleBreakingToolStripMenuItem.Text = "Confirm Student Attendance";
            this.multipleBreakingToolStripMenuItem.Click += new EventHandler(this.multipleBreakingToolStripMenuItem_Click);
            this.manualLogEntryToolStripMenuItem1.Name = "manualLogEntryToolStripMenuItem1";
            this.manualLogEntryToolStripMenuItem1.Size = new Size(0xd3, 0x16);
            this.manualLogEntryToolStripMenuItem1.Text = "Manual Log Entry";
            this.manualLogEntryToolStripMenuItem1.Click += new EventHandler(this.manualLogEntryToolStripMenuItem1_Click);
            this.caocherChangeByLevalToolStripMenuItem.Name = "caocherChangeByLevalToolStripMenuItem";
            this.caocherChangeByLevalToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.caocherChangeByLevalToolStripMenuItem.Text = "Caocher Change By Leval";
            this.caocherChangeByLevalToolStripMenuItem.Click += new EventHandler(this.caocherChangeByLevalToolStripMenuItem_Click);
            this.levelChangeToolStripMenuItem.Name = "levelChangeToolStripMenuItem";
            this.levelChangeToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.levelChangeToolStripMenuItem.Text = "Level Change";
            this.levelChangeToolStripMenuItem.Click += new EventHandler(this.levelChangeToolStripMenuItem_Click);
            this.viewStudentToolStripMenuItem.Name = "viewStudentToolStripMenuItem";
            this.viewStudentToolStripMenuItem.Size = new Size(0xd3, 0x16);
            this.viewStudentToolStripMenuItem.Text = "View Student";
            this.viewStudentToolStripMenuItem.Click += new EventHandler(this.viewStudentToolStripMenuItem_Click);
            this.leaveInformationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.multipleLeaveAssingToolStripMenuItem, this.cancelPayReceiptToolStripMenuItem, this.dailyToolStripMenuItem });
            this.leaveInformationToolStripMenuItem.Name = "leaveInformationToolStripMenuItem";
            this.leaveInformationToolStripMenuItem.Size = new Size(0x36, 20);
            this.leaveInformationToolStripMenuItem.Text = "Invoice";
            this.multipleLeaveAssingToolStripMenuItem.Name = "multipleLeaveAssingToolStripMenuItem";
            this.multipleLeaveAssingToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.multipleLeaveAssingToolStripMenuItem.Text = "Pay Receipt";
            this.multipleLeaveAssingToolStripMenuItem.Click += new EventHandler(this.multipleLeaveAssingToolStripMenuItem_Click);
            this.cancelPayReceiptToolStripMenuItem.Name = "cancelPayReceiptToolStripMenuItem";
            this.cancelPayReceiptToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.cancelPayReceiptToolStripMenuItem.Text = "Cancel Pay Receipt";
            this.cancelPayReceiptToolStripMenuItem.Click += new EventHandler(this.cancelPayReceiptToolStripMenuItem_Click);
            this.processesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.dataConvertToolStripMenuItem1, this.attendanceProcessToolStripMenuItem, this.duePaymentToolStripMenuItem });
            this.processesToolStripMenuItem.Name = "processesToolStripMenuItem";
            this.processesToolStripMenuItem.Size = new Size(0x43, 20);
            this.processesToolStripMenuItem.Text = "Processes";
            this.dataConvertToolStripMenuItem1.Name = "dataConvertToolStripMenuItem1";
            this.dataConvertToolStripMenuItem1.Size = new Size(0xad, 0x16);
            this.dataConvertToolStripMenuItem1.Text = "Student Attendance";
            this.dataConvertToolStripMenuItem1.Click += new EventHandler(this.dataConvertToolStripMenuItem1_Click);
            this.attendanceProcessToolStripMenuItem.Name = "attendanceProcessToolStripMenuItem";
            this.attendanceProcessToolStripMenuItem.Size = new Size(0xad, 0x16);
            this.attendanceProcessToolStripMenuItem.Text = "Coacher Attendance";
            this.attendanceProcessToolStripMenuItem.Click += new EventHandler(this.attendanceProcessToolStripMenuItem_Click);
            this.duePaymentToolStripMenuItem.Name = "duePaymentToolStripMenuItem";
            this.duePaymentToolStripMenuItem.Size = new Size(0xad, 0x16);
            this.duePaymentToolStripMenuItem.Text = "Due Payment ";
            this.duePaymentToolStripMenuItem.Click += new EventHandler(this.duePaymentToolStripMenuItem_Click);
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.dailyReportsToolStripMenuItem, this.summaryToolStripMenuItem, this.masterInformationReportToolStripMenuItem, this.incomingReportsToolStripMenuItem, this.levelWiseSummaryToolStripMenuItem });
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new Size(0x39, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.dailyReportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.studentBarcodeToolStripMenuItem, this.coacherBarcodeToolStripMenuItem });
            this.dailyReportsToolStripMenuItem.Name = "dailyReportsToolStripMenuItem";
            this.dailyReportsToolStripMenuItem.Size = new Size(0xee, 0x16);
            this.dailyReportsToolStripMenuItem.Text = "Print Barcode";
            this.dailyReportsToolStripMenuItem.Click += new EventHandler(this.dailyReportsToolStripMenuItem_Click);
            this.studentBarcodeToolStripMenuItem.Name = "studentBarcodeToolStripMenuItem";
            this.studentBarcodeToolStripMenuItem.Size = new Size(0x9c, 0x16);
            this.studentBarcodeToolStripMenuItem.Text = "Student Barcode";
            this.studentBarcodeToolStripMenuItem.Click += new EventHandler(this.studentBarcodeToolStripMenuItem_Click);
            this.coacherBarcodeToolStripMenuItem.Name = "coacherBarcodeToolStripMenuItem";
            this.coacherBarcodeToolStripMenuItem.Size = new Size(0x9c, 0x16);
            this.coacherBarcodeToolStripMenuItem.Text = "Coacher Barcode";
            this.coacherBarcodeToolStripMenuItem.Click += new EventHandler(this.coacherBarcodeToolStripMenuItem_Click);
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new Size(0xee, 0x16);
            this.summaryToolStripMenuItem.Text = "Reports";
            this.summaryToolStripMenuItem.Click += new EventHandler(this.summaryToolStripMenuItem_Click);
            this.masterInformationReportToolStripMenuItem.Name = "masterInformationReportToolStripMenuItem";
            this.masterInformationReportToolStripMenuItem.Size = new Size(0xee, 0x16);
            this.masterInformationReportToolStripMenuItem.Text = "Coacher Reports";
            this.masterInformationReportToolStripMenuItem.Click += new EventHandler(this.masterInformationReportToolStripMenuItem_Click);
            this.incomingReportsToolStripMenuItem.Name = "incomingReportsToolStripMenuItem";
            this.incomingReportsToolStripMenuItem.Size = new Size(0xee, 0x16);
            this.incomingReportsToolStripMenuItem.Text = "Income Reports";
            this.incomingReportsToolStripMenuItem.Click += new EventHandler(this.incomingReportsToolStripMenuItem_Click);
            this.levelWiseSummaryToolStripMenuItem.Name = "levelWiseSummaryToolStripMenuItem";
            this.levelWiseSummaryToolStripMenuItem.Size = new Size(0xee, 0x16);
            this.levelWiseSummaryToolStripMenuItem.Text = "Level Wise Summary / ABC Report";
            this.levelWiseSummaryToolStripMenuItem.Click += new EventHandler(this.levelWiseSummaryToolStripMenuItem_Click);
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.customizeToolStripMenuItem, this.backupDatabaseToolStripMenuItem });
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new Size(0x2c, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            this.customizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.userLevelToolStripMenuItem, this.userMasterToolStripMenuItem, this.userRightsToolStripMenuItem });
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new Size(0x9d, 0x16);
            this.customizeToolStripMenuItem.Text = "Security";
            this.userLevelToolStripMenuItem.Name = "userLevelToolStripMenuItem";
            this.userLevelToolStripMenuItem.Size = new Size(0x84, 0x16);
            this.userLevelToolStripMenuItem.Text = "User Level";
            this.userLevelToolStripMenuItem.Click += new EventHandler(this.userLevelToolStripMenuItem_Click);
            this.userMasterToolStripMenuItem.Name = "userMasterToolStripMenuItem";
            this.userMasterToolStripMenuItem.Size = new Size(0x84, 0x16);
            this.userMasterToolStripMenuItem.Text = "User Master";
            this.userMasterToolStripMenuItem.Click += new EventHandler(this.userMasterToolStripMenuItem_Click);
            this.userRightsToolStripMenuItem.Name = "userRightsToolStripMenuItem";
            this.userRightsToolStripMenuItem.Size = new Size(0x84, 0x16);
            this.userRightsToolStripMenuItem.Text = "User Rights";
            this.userRightsToolStripMenuItem.Click += new EventHandler(this.userRightsToolStripMenuItem_Click);
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new Size(0x9d, 0x16);
            this.backupDatabaseToolStripMenuItem.Text = "Backup Database";
            this.backupDatabaseToolStripMenuItem.Click += new EventHandler(this.backupDatabaseToolStripMenuItem_Click);
            this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.contentsToolStripMenuItem1, this.indexToolStripMenuItem1, this.searchToolStripMenuItem1, this.toolStripSeparator12, this.aboutToolStripMenuItem1, this.databaseUpdateToolStripMenuItem });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            this.contentsToolStripMenuItem1.Name = "contentsToolStripMenuItem1";
            this.contentsToolStripMenuItem1.Size = new Size(0x9e, 0x16);
            this.contentsToolStripMenuItem1.Text = "&Contents";
            this.indexToolStripMenuItem1.Name = "indexToolStripMenuItem1";
            this.indexToolStripMenuItem1.Size = new Size(0x9e, 0x16);
            this.indexToolStripMenuItem1.Text = "&Index";
            this.searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
            this.searchToolStripMenuItem1.Size = new Size(0x9e, 0x16);
            this.searchToolStripMenuItem1.Text = "&Search";
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new Size(0x9b, 6);
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new Size(0x9e, 0x16);
            this.aboutToolStripMenuItem1.Text = "&About...";
            this.aboutToolStripMenuItem1.Click += new EventHandler(this.aboutToolStripMenuItem1_Click);
            this.databaseUpdateToolStripMenuItem.Name = "databaseUpdateToolStripMenuItem";
            this.databaseUpdateToolStripMenuItem.Size = new Size(0x9e, 0x16);
            this.databaseUpdateToolStripMenuItem.Text = "Database Update";
            this.databaseUpdateToolStripMenuItem.Click += new EventHandler(this.databaseUpdateToolStripMenuItem_Click);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(12, 20);
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = DockStyle.Right;
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripButton5, this.toolStripButton1, this.toolStripSeparator1, this.toolStripButton2, this.toolStripSeparator2, this.toolStripButton3, this.toolStripSeparator4, this.toolStripButton4 });
            this.toolStrip1.Location = new Point(0x3be, 0x18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(70, 0x2d2);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = (Image) manager.GetObject("toolStripButton5.Image");
            this.toolStripButton5.ImageTransparentColor = Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new Size(0x44, 0x13);
            this.toolStripButton5.Text = "Close";
            this.toolStripButton5.Click += new EventHandler(this.toolStripButton5_Click);
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.BackgroundImage = Resources.EmployeeMaster_;
            this.toolStripButton1.BackgroundImageLayout = ImageLayout.Stretch;
            this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = Color.Indigo;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new Size(50, 0x2f);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0x44, 6);
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.BackgroundImage = Resources.Attendance;
            this.toolStripButton2.BackgroundImageLayout = ImageLayout.Stretch;
            this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new Size(50, 0x2f);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(0x44, 6);
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.BackgroundImage = Resources.Book;
            this.toolStripButton3.BackgroundImageLayout = ImageLayout.Stretch;
            this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.ImageTransparentColor = Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new Size(50, 0x2f);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new EventHandler(this.toolStripButton3_Click);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(0x44, 6);
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.BackgroundImage = Resources.Accounting;
            this.toolStripButton4.BackgroundImageLayout = ImageLayout.Stretch;
            this.toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.ImageTransparentColor = Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new Size(50, 0x2f);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new EventHandler(this.toolStripButton4_Click);
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.dailyToolStripMenuItem.Text = "Daily Payments";
            this.dailyToolStripMenuItem.Visible = false;  /// need to enable
            this.dailyToolStripMenuItem.Click += new EventHandler(this.dailyToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Resources._new;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x404, 0x2ea);
            base.Controls.Add(this.toolStrip1);
            base.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            base.IsMdiContainer = true;
            base.MainMenuStrip = this.menuStrip;
            base.Name = "frmMain";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pool Attendance System... V=1.0";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.frmMain_Load);
            base.FormClosed += new FormClosedEventHandler(this.frmMain_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void levelChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLevelChange { MdiParent = this }.Show();
        }

        private void levelWiseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLevelWiseSummary { MdiParent = this }.Show();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void logOffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void manualLogEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmActiveCancalHistory { MdiParent = this }.Show();
        }

        private void manualLogEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmManualLogEntry { MdiParent = this }.Show();
        }

        private void masterInformationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCoacherReports { MdiParent = this }.Show();
        }

        private void multipleBreakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConfirmStudentAttendance { MdiParent = this }.Show();
        }

        private void multipleLeaveAssingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmInvoiceNew { MdiParent = this }.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rosterAssignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBeadBarcode { MdiParent = this }.Show();
        }

        private void rosterScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReadBarcodeCoacher { MdiParent = this }.Show();
        }

        private void roundOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmClassMaster { MdiParent = this }.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmPaymentMethod { MdiParent = this }.Show();
        }

        private void shiftAssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmStudentPromotions { MdiParent = this }.Show();
        }

        private void shiftDayDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            new frmCoacherMasterNew { MdiParent = this }.Show();
        }

        private void statusMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void studentBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReportViewer().Show();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReports { MdiParent = this }.Show();
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new frmStudentMasterNew { MdiParent = this }.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new frmBeadBarcode { MdiParent = this }.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new frmBook { MdiParent = this }.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new frmInvoiceNew { MdiParent = this }.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.toolStrip1.Visible = false;
        }

        private void turnOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUserLevelMaster { MdiParent = this }.Show();
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUserMaster { MdiParent = this }.Show();
        }

        private void userRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUserRights { MdiParent = this }.Show();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBook { MdiParent = this }.Show();
        }
    }
}

