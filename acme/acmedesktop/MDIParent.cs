﻿using DataAccessLayer.Common;
using acmedesktop.MasterSetup;
using acmedesktop.SystemSetting;
using System;
using System.Windows.Forms;
using acmedesktop.DataTransaction.BillingTransaction;
using acmedesktop.DataTransaction.Finance;
using acmedesktop.Common;
using acmedesktop.DataTransaction.Sales;
using acmedesktop.DataTransaction.Purchase;
using acmedesktop.ARAPReport;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System.Data;
using acmedesktop.DataTransaction.NormalProduction;
using acmedesktop.FinanceReport;

namespace acmedesktop
{
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            
            InitializeComponent();
            //menuStrip.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            if (DataAccessLayer.Common.ClsGlobal.ShowLoginForm == true)
            {
                Common.UserLogin frm = new Common.UserLogin();
                frm.ShowDialog();
            }
            if (DataAccessLayer.Common.ClsGlobal.ShowCompanyCreate == true)
            {
                FrmCompany  frm = new FrmCompany();
                frm.ShowDialog();
            }

            if (DataAccessLayer.Common.ClsGlobal.ShowCompanyList == true)
            {
                Common.CompanyList frm = new Common.CompanyList();
                frm.ShowDialog();
            }
            SelectMaster();

        }

        private void SelectMaster()
        {

            ToolStripInitial.Text = ClsGlobal.Initial;
            ToolStripCompany.Text = ClsGlobal.CompanyName;
            if (ClsGlobal.DateType == "D")
            {
                ToolStripStartDate.Text = ClsGlobal.CompanyStartDate;
                ToolStripEndDate.Text = ClsGlobal.CompanyEndDate;
            }
            else
            {
                ToolStripStartDate.Text = ClsGlobal.CompanyStartMiti;
                ToolStripEndDate.Text = ClsGlobal.CompanyEndMiti;
            }

            DataAccessLayer.SystemSetting.ClsCompany _company = new DataAccessLayer.SystemSetting.ClsCompany();
            DataAccessLayer.SystemSetting.ClsBranch _branch = new DataAccessLayer.SystemSetting.ClsBranch();
            DataAccessLayer.SystemSetting.ClsCompanyUnit _companyunit = new DataAccessLayer.SystemSetting.ClsCompanyUnit();
            DataAccessLayer.Interface.MasterSetup.ICounter _counter = new DataAccessLayer.MasterSetup.ClsCounter();

            //----------- Choose Software Focus----------

            try
            {
                DataTable dtCompanyInfo = _company.CompanyInfo();
                if (dtCompanyInfo.Rows.Count > 0)
                {
                     ClsGlobal.SoftwareFocus = dtCompanyInfo.Rows[0]["SoftwareFocus"].ToString();
                    if (string.IsNullOrEmpty(ClsGlobal.SoftwareFocus))
                    {
                        FrmSoftwareFocus frm = new FrmSoftwareFocus();
                        frm.ShowDialog();
                    }
					else if (ClsGlobal.SoftwareFocus == "Restaurant")
					{
						MnuProductGroup1.Text = "Used/UnUsed";
						MnuProductGroup2.Text = "Preparation Center";
					}
                }
                //-----------Choose Branch--------------
                var frm3 = new FrmBranchList
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    WindowState = FormWindowState.Normal
                };
                DataTable dtbranch = _branch.GetDataBranch(0);
                if (dtbranch.Rows.Count > 0)
                {
                    frm3.ShowDialog();
                }
                //---------Choose CompanyUnit----------------

                var frm1 = new FrmCompanyUnitList
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    WindowState = FormWindowState.Normal
                };
                DataTable dtCompanyUnit = _companyunit.GetDataCompanyUnit(Convert.ToInt32(ClsGlobal.BranchId));
                if (dtCompanyUnit.Rows.Count > 0)
                {
                    frm1.ShowDialog();
                }

                //---------Choose Counter----------------
                if (ClsGlobal.SoftwareFocus == "Restaurant" || ClsGlobal.SoftwareFocus == "POS")
                {
                    var frm2 = new FrmCounterList
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        WindowState = FormWindowState.Normal
                    };
                    DataTable dtCounter = _counter.GetDataCounter(0);
                    if (dtCounter.Rows.Count > 0)
                    {
                        frm2.ShowDialog();
                    }
                }
            }
            catch { }

        }

        private void MnuCompanyMaster_Click(object sender, EventArgs e)
        {
            FrmCompany frm = new FrmCompany();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuBranch_Click(object sender, EventArgs e)
        {
            FrmBranch frm = new FrmBranch();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void BtnCompanyUnit_Click(object sender, EventArgs e)
        {
            FrmCompanyUnit frm = new FrmCompanyUnit();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuUpdateCompany_Click(object sender, EventArgs e)
        {
            DataAccessLayer.Common.ClsUpdateCompany _companyUpdate = new  DataAccessLayer.Common.ClsUpdateCompany();
            _companyUpdate.CreateView();
        }

        private void MnuCompanyList_Click(object sender, EventArgs e)
        {
            var frm = new CompanyList
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.ShowDialog();
            SelectMaster();
        }

        private void MnuBranchList_Click(object sender, EventArgs e)
        {
            var frm = new FrmBranchList
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.ShowDialog();
        }

        private void MnuCompanyUnitList_Click(object sender, EventArgs e)
        {
            var frm = new FrmCompanyUnitList
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.ShowDialog();
        }

        private void MnuDocNumbering_Click(object sender, EventArgs e)
        {
            var frm = new FrmDocumentNumbering
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuReDocumentNumbering_Click(object sender, EventArgs e)
        {

        }

        private void MnuSalesTerm_Click(object sender, EventArgs e)
        {
            FrmSalesTerm frm = new FrmSalesTerm();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void PurchaseTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPurchaseTerm frm = new FrmPurchaseTerm();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuAccountGroup_Click(object sender, EventArgs e)
        {
            FrmAccountGroup frm = new FrmAccountGroup();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void AccountSubGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAccountSubGroup frm = new FrmAccountSubGroup();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuGeneralLedger_Click(object sender, EventArgs e)
        {
            FrmGeneralledger frm = new FrmGeneralledger();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuSubledger_Click(object sender, EventArgs e)
        {
            FrmSubledger frm = new FrmSubledger();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuLedgerMapping_Click(object sender, EventArgs e)
        {
            FrmGeneralLedgerMapping frm = new FrmGeneralLedgerMapping();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuBranchwiseMapping_Click(object sender, EventArgs e)
        {
            
        }

        private void MnuUnitwiseMapping_Click(object sender, EventArgs e)
        {

        }

        private void MnuLedgerLock_Click(object sender, EventArgs e)
        {
            FrmGeneralLedgerLock frm = new FrmGeneralLedgerLock();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuLedgerImport_Click(object sender, EventArgs e)
        {

        }

        private void MnuProductGroup_Click(object sender, EventArgs e)
        {
            FrmProductGroup frm = new FrmProductGroup();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuProductSubGroup_Click(object sender, EventArgs e)
        {
            FrmProductSubGroup frm = new FrmProductSubGroup();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuProductUnit_Click(object sender, EventArgs e)
        {
            FrmProductUnit frm = new FrmProductUnit();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuProductCompany_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = new FrmDepartment();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuProduct_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuCounterProduct_Click(object sender, EventArgs e)
        {
            FrmCounterProduct frm = new FrmCounterProduct();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuProductScheme_Click(object sender, EventArgs e)
        {
            FrmProductScheme frm = new FrmProductScheme();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void MnuProductImport_Click(object sender, EventArgs e)
        {
            var frm = new FrmProductImport
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuProductLock_Click(object sender, EventArgs e)
        {
            var frm = new FrmProductLock
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuMainSalesman_Click(object sender, EventArgs e)
        {
            var frm = new FrmMainSalesMan
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSubSalesman_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesMan
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuMainArea_Click(object sender, EventArgs e)
        {
            var frm = new FrmMainArea
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSubArea_Click(object sender, EventArgs e)
        {
            var frm = new FrmSubArea
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuCounter_Click(object sender, EventArgs e)
        {
            var frm = new FrmCounter
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuGodown_Click(object sender, EventArgs e)
        {
            var frm = new FrmGodown
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuDepartment_Click(object sender, EventArgs e)
        {
            var frm = new FrmDepartment
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuCurrency_Click(object sender, EventArgs e)
        {
            var frm = new FrmCurrency
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
        private void MnuNarration_Click(object sender, EventArgs e)
        {
            var frm = new FrmNarration
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
       
        private void MnuPOSBilling_Click(object sender, EventArgs e)
        {
           
            
            var frm = new POSBilling
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
			if(ClsGlobal.PosBillValid ==true)
				 frm.Show();
        }

        private void MnuCashBankEntry_Click(object sender, EventArgs e)
        {
            var frm = new FrmCashBankVoucher
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
        
        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MnuSystemSetting_Click(object sender, EventArgs e)
        {
            var frm = new FrmSystemSetting
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
        
        private void MnuPrintSetting_Click(object sender, EventArgs e)
        {
            var frm = new FrmPrintSetting
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
        
        private void MnuOpeningLedger_Click(object sender, EventArgs e)
        {

        }
        
        private void MnuMenuPermissionGroup_Click(object sender, EventArgs e)
        {
            var frm = new FrmMenuPermissionGroup
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuMenuPermissionRights_Click(object sender, EventArgs e)
        {
            var frm = new FrmMenuPermissionRights
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuUserMaster_Click(object sender, EventArgs e)
        {
            var frm = new FrmUserMaster
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuCompanyRights_Click(object sender, EventArgs e)
        {
            var frm = new FrmCompanyRights
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
        private void MnuBrachRights_Click(object sender, EventArgs e)
        {
            var frm = new FrmBrachRights
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
        private void MnuCompanyUnitRights_Click(object sender, EventArgs e)
        {
            var frm = new FrmCompanyUnitRights
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuChangePassword_Click(object sender, EventArgs e)
        {
            var frm = new FrmChangePassword
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
        private void MnuJournalEntry_Click(object sender, EventArgs e)
        {
            var frm = new FrmJournalVoucher
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuCreditNoteEntry_Click(object sender, EventArgs e)
        {
            var frm = new FrmCreditNoteVoucher
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuDebitNote_Click(object sender, EventArgs e)
        {
            var frm = new FrmDebitNoteVoucher
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuCostCenter_Click(object sender, EventArgs e)
        {
            var frm = new FrmCostCenter
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuUDFMaster_Click(object sender, EventArgs e)
        {
            var frm = new FrmUdfMaster
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuFloor_Click(object sender, EventArgs e)
        {
            var frm = new FrmFloor
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuProductMapping_Click(object sender, EventArgs e)
        {
            var frm = new FrmProductMapping
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuServerSetting_Click(object sender, EventArgs e)
        {
            var frm = new FrmServerSetting
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuRestaurantBilling_Click(object sender, EventArgs e)
        {
            FrmRestaurantBilling frm = new FrmRestaurantBilling();
            //frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
			if (ClsGlobal.PosBillValid == true)
				 frm.Show();
        }

        private void MnuTableMaster_Click(object sender, EventArgs e)
        {
            var frm = new FrmTable
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuMember_Click(object sender, EventArgs e)
        {
            var frm = new FrmMembership
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuMemberType_Click(object sender, EventArgs e)
        {
            var frm = new FrmMemberType
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesInvoice_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesInvoice
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesOrder_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesOrder
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesChallan_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesChallan
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesReturnInvoice_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesReturn
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesExpBrk_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesExpBrkReturn
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesQuotation_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesQuotation
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuOpeningBillwiseLedger_Click(object sender, EventArgs e)
        {

        }

        private void MnuOpeningProduct_Click(object sender, EventArgs e)
        {

        }

        private void MnuProvisionalCashBankEntry_Click(object sender, EventArgs e)
        {

        }

        private void MnuProvisionalJournalEntry_Click(object sender, EventArgs e)
        {

        }

        private void MnuProvisionalDebitNoteEntry_Click(object sender, EventArgs e)
        {

        }

        private void MnuProvisionalCreditNoteEntry_Click(object sender, EventArgs e)
        {

        }

        private void MnuPDC_Click(object sender, EventArgs e)
        {

        }

        private void MnuPurchaseIndent_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseIndent
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseQuotation_Click(object sender, EventArgs e)
        {
             var frm = new FrmPurchaseQuotation
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseOrder_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseOrder
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseChallan_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseChallan
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseGIT_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseQuotation
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseInvoice_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseInvoice
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseAVTInvoice_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseQuotation
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseAdditional_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseQuotation
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseReturn_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseReturn
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseExpBrk_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseExpBrkReturn
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesInvoiceAVT_Click(object sender, EventArgs e)
        {
            var frm = new POSBilling
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesAdditional_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesInvoice
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuProductGroup1_Click(object sender, EventArgs e)
        {
            var frm = new FrmProductGroup1
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuProductGroup2_Click(object sender, EventArgs e)
        {
            var frm = new FrmProductGroup2
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuHelp_Click(object sender, EventArgs e)
        {

        }

        private void MnuSalesRegister_Click(object sender, EventArgs e)
        {
            var frm = new RptSalesRegister
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesOrderRegister_Click(object sender, EventArgs e)
        {
            var frm = new RptSalesOrderRegister
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MenuUserMaster_Click(object sender, EventArgs e)
        {

        }

        private void MnuUserRestriction_Click(object sender, EventArgs e)
        {
            var frm = new UserRestriction
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuBillOfMaterial_Click(object sender, EventArgs e)
        {
            var frm = new FrmBOM
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPickListOption_Click(object sender, EventArgs e)
        {
            var frm = new FrmPickListOption
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuKOTAssign_Click(object sender, EventArgs e)
        {
            var frm = new FrmKOT
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuRptAllLedger_Click(object sender, EventArgs e)
        {
            var frm = new RptAllLedger
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuDayBook_Click(object sender, EventArgs e)
        {
            var frm = new RptDayBook
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuPurchaseChallanReturn_Click(object sender, EventArgs e)
        {
            var frm = new FrmPurchaseChallanReturn
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }

        private void MnuSalesChallanReturn_Click(object sender, EventArgs e)
        {
            var frm = new FrmSalesChallanReturn
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frm.Show();
        }
    }
}
