using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.SystemSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DLLPrinting
{
    public class DllInvoicePrint
    {
        string _VoucherNo { get; set; }
        string _PrinterName { get; set; }
        int _NoofCopyPrint { get; set; }
        string _PrintedBy;
        DateTime _PrintedDate;
        int N_Line = 30;
        int N_HeadLine = 0;

        System.Drawing.Font myFont = new System.Drawing.Font("Courier New", 9, FontStyle.Bold);
       // private PrintDocument Document;
        IDocPrintSetting _objDocPrintSetting = new ClsDocPrintSetting();
        public DllInvoicePrint(string VoucherNo, string PrinterName, string DesignName, string PrintedBy, DateTime PrintedDate, int NoofCopyPrint)
        {
            this._VoucherNo = VoucherNo;
            this._PrintedBy = PrintedBy;
            this._PrintedDate = PrintedDate;
            this._PrinterName = PrinterName;
            this._NoofCopyPrint = NoofCopyPrint;
            switch (DesignName)
            {
                //Restaurent Order Design
                case "4InchRestaurantOrder":
                    Default4InchOrderDesign();
                    break;
				case "3InchRestaurantOrder":
					Default3InchOrderDesign();
					break;
				case "KOT/BOT":
                    KOTBOTDesign();
                    break;
                ////Restaurant Design 
                //case "3InchRestaurantTaxBilldll":
                //    ThreeInchCounterTaxBill();
                //    break;
                //Counter/POS Design
                //case "DefaultCounterTaxInvoice3Inchdll":
                //    DefaultCounterTaxInvoice3InchDesign();
                //    break;
                case "3InchCounterTaxBill":
                    ThreeInchCounterTaxBill();
                    break;
                //case "3inchAbbreviatedTaxInvoicedll":
                //    AbbreviatedSalesInvoiceDesign();
                //    break;
                //case "DefaultCounterAbbreviatedInvoice3Inchdll":
                //    DefaultCounterAbbreviatedSalesInvoiceDesign();
                //    break;

                ////Sales Invoice 
                //case "DefaultSalesTaxInvoicedll":
                //    DefaultSalesTaxInvoiceDetails();
                //    break;
                //case "DefaultTaxInvoiceLetterFullPTermdll":
                //    DefaultTaxInvoiceLetterFullPTermDetails();
                //    break;
                //case "DelightSalesTaxInvoicedll":
                //    DelightSalesTaxInvoiceDetails();
                //    break;
                //case "DefaultCounterSalesTicket3Inchdll":
                //    DefaultCounterSalesTicket3InchDetails();
                //    break;

            }
        }
        private void Default4InchOrderDesign()
        {
            StringBuilder strData = new StringBuilder();

            DataSet dsSB = _objDocPrintSetting.SalesOrderDataSet(_VoucherNo);
            DataTable roCom = dsSB.Tables[0]; 
            DataTable dtMaster = dsSB.Tables[1];
            DataTable dtDetail = dsSB.Tables[2];
            DataTable dtProductTerm = dsSB.Tables[3];
            DataTable dtBillTerm = dsSB.Tables[4];

            decimal roundoff = 0;  
            decimal BasicAmt = 0;
            decimal ProductDiscount, BillWiseDiscount = 0;

            foreach (DataRow roMaster in dtMaster.Rows)
            {
                //Print Header Part from roMaster
                BasicAmt = 0;
                ProductDiscount = 0;
                string city = roCom.Rows[0]["City"].ToString() + ',' + roCom.Rows[0]["PhoneNo"].ToString();
                string pan = "PAN NO : " + roCom.Rows[0]["PanNo"].ToString();
                strData.Append(RawPrinterHelper.GetRawPrintString(roCom.Rows[0]["CompanyName"].ToString().MyPadLeft(roCom.Rows[0]["CompanyName"].ToString().Length + Convert.ToInt32((47 - roCom.Rows[0]["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(roCom.Rows[0]["Address"].ToString().MyPadLeft(roCom.Rows[0]["Address"].ToString().Length + Convert.ToInt32((47 - roCom.Rows[0]["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(city.MyPadLeft(city.Length + Convert.ToInt32((47 - city.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((47 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(47, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(18) + "SALES ORDER", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(47, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                //  if (Convert.ToInt32(roMaster["PrintCopy"].ToString()) > 0)
                //    strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(12) + "Copy of Original " + roMaster["PrintCopy"].ToString(), RawPrinterHelper.PrintFontType.Contract, true));
                // objOrder.updatePrintStatus(roMaster["VNo"].ToString(), _printedBy, _printedDate);

                strData.Append(RawPrinterHelper.GetRawPrintString(("Order No: " + roMaster["Voucher No"].ToString()).MyPadRight(30) + "Date: " + Convert.ToDateTime(roMaster["Voucher Date"]).ToShortDateString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Table : " + roMaster["TableDesc"].ToString()).MyPadRight(30) + "Miti: " + roMaster["Voucher Miti"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                if (!string.IsNullOrEmpty(dtDetail.Rows[0]["ResOrderBy"].ToString()))
                    strData.Append(RawPrinterHelper.GetRawPrintString(("Waiter : " + dtDetail.Rows[0]["ResOrderBy"].ToString()).MyPadRight(36), RawPrinterHelper.PrintFontType.Contract, true));

                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadRight(47, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(3) + "Particulars".MyPadRight(20) + "Qty".MyPadLeft(5) + "Rate".MyPadLeft(9) + "Amount".MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadRight(47, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                foreach (DataRow roDetail in dtDetail.Select("[Voucher No] = '" + roMaster["Voucher No"].ToString() + "'"))
                {
                    //Print Detail Part from roDetail                     
                    string qty = Convert.ToDecimal(roDetail["Qty"]).ToString("0.00");
                    string[] s = qty.Split('.');
                    if (Convert.ToInt32(s[1]) <= 0)
                    {
                        qty = s[0];
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["Sno"].ToString() + ".").MyPadRight(3) + roDetail["AdditionalDesc"].ToString().MyPadRight(20) + qty.MyPadLeft(4) + Convert.ToDecimal(roDetail["SalesRate"]).ToString("0.00").MyPadLeft(10) + Convert.ToDecimal(roDetail["BasicAmount"]).ToString("0.00").MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    BasicAmt += Convert.ToDecimal(roDetail["BasicAmount"]);
                }

                //Print Total
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(47, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("Basic Amount :".MyPadLeft(36) + BasicAmt.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(23, ' ') + "-----------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));
             
                Decimal DiscountTerm = 0,  ServiceCharge = 0, VatTerm = 0 , BillDiscount=0, TaxableAmt=0;
                foreach (DataRow roProductTerm in dtProductTerm.Select("[Voucher No] = '" + roMaster["Voucher No"].ToString() + "'"))
                {
                    DiscountTerm = DiscountTerm + Convert.ToDecimal(roProductTerm["P Discount"].ToString()); 
                    ServiceCharge = ServiceCharge + Convert.ToDecimal(roProductTerm["ServiceCharge"].ToString()); 
                }
                foreach (DataRow roBillTerm in dtBillTerm.Select("[Voucher No] = '" + roMaster["Voucher No"].ToString() + "'"))
                {
                    BillDiscount = BillDiscount + Convert.ToDecimal(roBillTerm["Discount"].ToString());
                    VatTerm = VatTerm + Convert.ToDecimal(roBillTerm["VAT"].ToString());
                }
                if ((DiscountTerm+ BillDiscount) != 0)
                    strData.Append(RawPrinterHelper.GetRawPrintString("Discount :".MyPadLeft(36) + (DiscountTerm + BillDiscount).ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                if (ServiceCharge > 0)
                    strData.Append(RawPrinterHelper.GetRawPrintString("Service Charge :".MyPadLeft(36) + ServiceCharge.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                
                //if (BillDiscount > 0)
                //    strData.Append(RawPrinterHelper.GetRawPrintString("Bill Discount :".MyPadLeft(30) + BillDiscount.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                TaxableAmt = BasicAmt + DiscountTerm + ServiceCharge+ BillDiscount;
                strData.Append(RawPrinterHelper.GetRawPrintString("Taxable Value :".MyPadLeft(36) + TaxableAmt.ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));

                if (VatTerm > 0)
                    strData.Append(RawPrinterHelper.GetRawPrintString("Vat :".MyPadLeft(36) + VatTerm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                strData.Append(RawPrinterHelper.GetRawPrintString("Total Amount :".MyPadLeft(36) + (TaxableAmt + VatTerm).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(24, ' ') + "-----------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));


                string rupees = NumberToWord.ToWords((TaxableAmt + VatTerm));  //NumberToWord.ToWords(Convert.ToDecimal(roMaster["NetAmount"]));
                string rupees1 = "";
                if (rupees.Length >= 35)
                {
                    rupees1 = rupees.Substring(0, 35);
                }
                else
                {
                    rupees1 = rupees;
                }

                string rupees2 = "";
                if ((rupees.Length) - 35 >= 40)
                {
                    rupees2 = rupees.Substring(35, 40);
                }
                else
                {
                    rupees2 = rupees.Remove(0, rupees1.Length);
                }

                string rupees3 = "";
                if ((rupees.Length) - 72 >= 40)
                {
                    rupees3 = rupees.Substring(72, 40);
                }
                else
                {
                    rupees3 = rupees.Remove(0, (rupees1.Length + rupees2.Length));
                }

                string rupees4 = "";
                if ((rupees.Length) - 111 >= 40)
                {
                    rupees4 = rupees.Substring(111, 40);
                }
                else
                {
                    rupees4 = rupees.Remove(0, (rupees1.Length + rupees2.Length + rupees3.Length));
                }

                strData.Append(RawPrinterHelper.GetRawPrintString("In word : " + rupees1, RawPrinterHelper.PrintFontType.Contract, true));
                if (!string.IsNullOrEmpty(rupees2))
                    strData.Append(RawPrinterHelper.GetRawPrintString(rupees2, RawPrinterHelper.PrintFontType.Contract, true));
                if (!string.IsNullOrEmpty(rupees3))
                    strData.Append(RawPrinterHelper.GetRawPrintString(rupees3, RawPrinterHelper.PrintFontType.Contract, true));
                if (!string.IsNullOrEmpty(rupees4))
                    strData.Append(RawPrinterHelper.GetRawPrintString(rupees4, RawPrinterHelper.PrintFontType.Contract, true));

                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(47, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                //strData.Append(RawPrinterHelper.GetRawPrintString(("Party Name: " + roMaster["PartyName"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                //   strData.Append(RawPrinterHelper.GetRawPrintString(("Counter : " + roMaster["Cls_Desc"].ToString()).MyPadRight(25) + ("Time : " + Convert.ToDateTime(roMaster["Sb_InvTime"].ToString()).ToShortTimeString().ToString()), RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Cashier : " + roMaster["EnterBy"].ToString()).MyPadRight(25), RawPrinterHelper.PrintFontType.Contract, true));

                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(47, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(10)+"This Bill is not Tax Invoice", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(18) + "THANK YOU", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append("\n\n\n\n\n\n\n");
            }
            RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());

            string GS = Convert.ToString((char)29);
            string ESC = Convert.ToString((char)27);
            string COMMAND = "";
            COMMAND = ESC + "@";
            COMMAND += GS + "V" + (char)1;
            RawPrinterHelper.SendStringToPrinter(_PrinterName, COMMAND);
        }

		private void Default3InchOrderDesign()
		{
			StringBuilder strData = new StringBuilder();

			DataSet dsSB = _objDocPrintSetting.SalesOrderDataSet(_VoucherNo);
			DataTable roCom = dsSB.Tables[0];
			DataTable dtMaster = dsSB.Tables[1];
			DataTable dtDetail = dsSB.Tables[2];
			DataTable dtProductTerm = dsSB.Tables[3];
			DataTable dtBillTerm = dsSB.Tables[4];

			decimal roundoff = 0;
			decimal BasicAmt = 0;
			decimal ProductDiscount, BillWiseDiscount = 0;

			foreach (DataRow roMaster in dtMaster.Rows)
			{
				//Print Header Part from roMaster
				BasicAmt = 0;
				ProductDiscount = 0;
				string city = roCom.Rows[0]["City"].ToString() + ',' + roCom.Rows[0]["PhoneNo"].ToString();
				string pan = "PAN NO : " + roCom.Rows[0]["PanNo"].ToString();
				strData.Append(RawPrinterHelper.GetRawPrintString(roCom.Rows[0]["CompanyName"].ToString().MyPadLeft(roCom.Rows[0]["CompanyName"].ToString().Length + Convert.ToInt32((40 - roCom.Rows[0]["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString(roCom.Rows[0]["Address"].ToString().MyPadLeft(roCom.Rows[0]["Address"].ToString().Length + Convert.ToInt32((40 - roCom.Rows[0]["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString(city.MyPadLeft(city.Length + Convert.ToInt32((40 - city.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((40 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "SALES ORDER", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

				//  if (Convert.ToInt32(roMaster["PrintCopy"].ToString()) > 0)
				//    strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(12) + "Copy of Original " + roMaster["PrintCopy"].ToString(), RawPrinterHelper.PrintFontType.Contract, true));
				// objOrder.updatePrintStatus(roMaster["VNo"].ToString(), _printedBy, _printedDate);

				strData.Append(RawPrinterHelper.GetRawPrintString(("Order No: " + roMaster["Voucher No"].ToString()).MyPadRight(24) + "Date: " + Convert.ToDateTime(roMaster["Voucher Date"]).ToShortDateString() + "", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString(("Table : " + roMaster["TableDesc"].ToString()).MyPadRight(24) + "Miti: " + roMaster["Voucher Miti"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));
				if (!string.IsNullOrEmpty(dtDetail.Rows[0]["ResOrderBy"].ToString()))
					strData.Append(RawPrinterHelper.GetRawPrintString(("Waiter : " + dtDetail.Rows[0]["ResOrderBy"].ToString()).MyPadRight(36), RawPrinterHelper.PrintFontType.Contract, true));

				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadRight(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

				strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(3) + "Particulars".MyPadRight(14) + "Qty".MyPadLeft(5) + "Rate".MyPadLeft(9) + "Amount".MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadRight(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

				foreach (DataRow roDetail in dtDetail.Select("[Voucher No] = '" + roMaster["Voucher No"].ToString() + "'"))
				{
					//Print Detail Part from roDetail                     
					string qty = Convert.ToDecimal(roDetail["Qty"]).ToString("0.00");
					string[] s = qty.Split('.');
					if (Convert.ToInt32(s[1]) <= 0)
					{
						qty = s[0];
					}

					strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["Sno"].ToString() + ".").MyPadRight(3) + roDetail["AdditionalDesc"].ToString().MyPadRight(14) + qty.MyPadLeft(4) + Convert.ToDecimal(roDetail["SalesRate"]).ToString("0.00").MyPadLeft(10) + Convert.ToDecimal(roDetail["BasicAmount"]).ToString("0.00").MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
					BasicAmt += Convert.ToDecimal(roDetail["BasicAmount"]);
				}

				//Print Total
				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("Basic Amount :".MyPadLeft(30) + BasicAmt.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));

				Decimal DiscountTerm = 0, ServiceCharge = 0, VatTerm = 0, BillDiscount = 0, TaxableAmt = 0;
				foreach (DataRow roProductTerm in dtProductTerm.Select("[Voucher No] = '" + roMaster["Voucher No"].ToString() + "'"))
				{
					DiscountTerm = DiscountTerm + Convert.ToDecimal(roProductTerm["P Discount"].ToString());
				}
				foreach (DataRow roBillTerm in dtBillTerm.Select("[Voucher No] = '" + roMaster["Voucher No"].ToString() + "'"))
				{
					BillDiscount = BillDiscount + Convert.ToDecimal(roBillTerm["Discount"].ToString());
					VatTerm = VatTerm + Convert.ToDecimal(roBillTerm["VAT"].ToString());
				}
				if ((DiscountTerm + BillDiscount) != 0)
					strData.Append(RawPrinterHelper.GetRawPrintString("Discount :".MyPadLeft(30) + (DiscountTerm + BillDiscount).ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
				if (ServiceCharge > 0)
					strData.Append(RawPrinterHelper.GetRawPrintString("Service Charge :".MyPadLeft(30) + ServiceCharge.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));


				//if (BillDiscount > 0)
				//    strData.Append(RawPrinterHelper.GetRawPrintString("Bill Discount :".MyPadLeft(30) + BillDiscount.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

				TaxableAmt = BasicAmt + DiscountTerm + ServiceCharge + BillDiscount;
				strData.Append(RawPrinterHelper.GetRawPrintString("Taxable Value :".MyPadLeft(30) + TaxableAmt.ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));

				if (VatTerm > 0)
					strData.Append(RawPrinterHelper.GetRawPrintString("Vat :".MyPadLeft(30) + VatTerm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

				strData.Append(RawPrinterHelper.GetRawPrintString("Total Amount :".MyPadLeft(30) + (TaxableAmt + VatTerm).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));


				string rupees = NumberToWord.ToWords((TaxableAmt + VatTerm));  //NumberToWord.ToWords(Convert.ToDecimal(roMaster["NetAmount"]));
				string rupees1 = "";
				if (rupees.Length >= 28)
				{
					rupees1 = rupees.Substring(0, 28);
				}
				else
				{
					rupees1 = rupees;
				}

				string rupees2 = "";
				if ((rupees.Length) - 28 >= 38)
				{
					rupees2 = rupees.Substring(28, 38);
				}
				else
				{
					rupees2 = rupees.Remove(0, rupees1.Length);
				}

				string rupees3 = "";
				if ((rupees.Length) - 66 >= 38)
				{
					rupees3 = rupees.Substring(66, 38);
				}
				else
				{
					rupees3 = rupees.Remove(0, (rupees1.Length + rupees2.Length));
				}

				string rupees4 = "";
				if ((rupees.Length) - 104 >= 38)
				{
					rupees4 = rupees.Substring(104, 38);
				}
				else
				{
					rupees4 = rupees.Remove(0, (rupees1.Length + rupees2.Length + rupees3.Length));
				}

				strData.Append(RawPrinterHelper.GetRawPrintString("In word : " + rupees1, RawPrinterHelper.PrintFontType.Contract, true));
				if (!string.IsNullOrEmpty(rupees2))
					strData.Append(RawPrinterHelper.GetRawPrintString(rupees2, RawPrinterHelper.PrintFontType.Contract, true));
				if (!string.IsNullOrEmpty(rupees3))
					strData.Append(RawPrinterHelper.GetRawPrintString(rupees3, RawPrinterHelper.PrintFontType.Contract, true));
				if (!string.IsNullOrEmpty(rupees4))
					strData.Append(RawPrinterHelper.GetRawPrintString(rupees4, RawPrinterHelper.PrintFontType.Contract, true));

				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
				//strData.Append(RawPrinterHelper.GetRawPrintString(("Party Name: " + roMaster["PartyName"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
				//strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

			    strData.Append(RawPrinterHelper.GetRawPrintString(("Counter : " + roMaster["Counter Name"].ToString()).MyPadRight(25) + ("Time : " + DateTime.Now.ToShortTimeString().ToString()), RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString(("Cashier : " + roMaster["EnterBy"].ToString()).MyPadRight(25), RawPrinterHelper.PrintFontType.Contract, true));

				strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(5) + "This Bill is not Tax Invoice", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(13) + "THANK YOU", RawPrinterHelper.PrintFontType.Contract, true));
				strData.Append("\n\n\n\n\n\n\n");
			}
			RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());

			string GS = Convert.ToString((char)29);
			string ESC = Convert.ToString((char)27);
			string COMMAND = "";
			COMMAND = ESC + "@";
			COMMAND += GS + "V" + (char)1;
			RawPrinterHelper.SendStringToPrinter(_PrinterName, COMMAND);
		}
		private void KOTBOTDesign()
        {
            StringBuilder strData = new StringBuilder();
            DataSet dsSaleOrder = _objDocPrintSetting.SalesOrderDataSet(_VoucherNo);
            DataTable dtCompany = dsSaleOrder.Tables[0];
            DataTable dtMaster = dsSaleOrder.Tables[1];
            DataTable dtDetail = dsSaleOrder.Tables[2];
            DataTable dtProductTerm = dsSaleOrder.Tables[3];
            DataTable dtBillTerm = dsSaleOrder.Tables[4];
            DataTable dtgroup = dsSaleOrder.Tables[8];
            bool isitem = false;
            if (dtDetail.Rows.Count > 0)
            {
                DataRow roMaster = dtMaster.Rows[0];
                dtDetail.DefaultView.ToTable(true, "Group code");
                foreach (DataRow ro in dtgroup.Rows)
                {
                    isitem = false;
                    strData.Clear();

                    DataRow[] dtt = dtDetail.Select("[Group Code]= '" + ro["ProductGrpShortName"].ToString() + "' and (ResIsPrinted='N' or ResIsPrinted is null)");
                    if (dtt.Length > 0)
                    {
                        isitem = true;
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(ro["ProductGrpDesc"].ToString().MyPadLeft(ro["ProductGrpDesc"].ToString().Length + Convert.ToInt32((30 - ro["ProductGrpDesc"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        if (!string.IsNullOrEmpty(dtDetail.Rows[0]["ResOrderBy"].ToString()))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Waiter : " + dtDetail.Rows[0]["ResOrderBy"].ToString()).MyPadRight(40), RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Order No : " + roMaster["Voucher No"].ToString()).MyPadRight(20) + "Table : " + roMaster["TableDesc"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Order Date : " + Convert.ToDateTime(roMaster["Voucher Date"]).ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).MyPadRight(40), RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        strData.Append(RawPrinterHelper.GetRawPrintString("Particulars".MyPadRight(25) + "Qty".MyPadLeft(5) + (ro["ProductGrpDesc"].ToString() + " No").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        string productgrp = "";
                        foreach (DataRow dr in dtt)
                        {
                            string qty = Convert.ToDecimal(dr["Qty"]).ToString("0.00");
                            string[] s = qty.Split('.');
                            if (Convert.ToInt32(s[1]) <= 0)
                            {
                                qty = s[0];
                            }

                            strData.Append(RawPrinterHelper.GetRawPrintString(dr["AdditionalDesc"].ToString().MyPadRight(25) + qty.MyPadLeft(4) + dr["ResKOTNo"].ToString().MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                            if (!string.IsNullOrEmpty(dr["ResOrderNotes"].ToString().Trim()))
                                strData.Append(RawPrinterHelper.GetRawPrintString("    Note-".MyPadRight(10) + dr["ResOrderNotes"].ToString().MyPadRight(30) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        }
                    }
                    if (isitem == true)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(40, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        string GS = Convert.ToString((char)29);
                        string ESC = Convert.ToString((char)27);
                        string COMMAND = "";
                        COMMAND = ESC + "@";
                        COMMAND += GS + "V" + (char)1;

                        if (!string.IsNullOrEmpty(ro["PrinterName"].ToString().Trim()))
                        {
                            RawPrinterHelper.SendStringToPrinter(ro["PrinterName"].ToString(), strData.ToString());
                            RawPrinterHelper.SendStringToPrinter(ro["PrinterName"].ToString(), COMMAND);
                        }
                        else
                        {
                            RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
                            RawPrinterHelper.SendStringToPrinter(_PrinterName, COMMAND);
                        }
                    }
                }
            }
        }
      
        private void DefaultCounterTaxInvoice3InchDesign()
        {
           DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
           DataTable dtMaster = dsSB.Tables[0];
           DataTable dtDetail = dsSB.Tables[1];
           DataTable dtBTerm = dsSB.Tables[2];
           DataTable dtPTerm = dsSB.Tables[3];
           DataTable dtTaxTermValue = dsSB.Tables[4];
           DataTable dtNonTaxTermValue = dsSB.Tables[5];
            int Sno = 0;
            decimal BasicAmt = 0;
            decimal TotBas = 0;
            decimal TotGrand = 0;
            decimal NonTaxableValue = 0;
            decimal TaxableValue = 0;
            decimal roundoff = 0;
           
            for (int i = 1; i <= _NoofCopyPrint; i++)
            {
                StringBuilder strData = new StringBuilder();
                foreach (DataRow roMaster in dtMaster.Rows)
                {
                    //Print Header Part from roMaster
                    TotGrand = 0;
                    BasicAmt = 0;
                    string city = "";
                    //if (roCom["City"].ToString() != "")
                    //    city = roCom["City"].ToString() + ',' + roCom["Phone"].ToString();
                    //else
                    //    city = roCom["Phone"].ToString();
                    //string pan = "PAN NO : " + roCom["PanNo"].ToString();
                    //strData.Append(RawPrinterHelper.GetRawPrintString(roCom["CompanyName"].ToString().MyPadLeft(roCom["CompanyName"].ToString().Length + Convert.ToInt32((40 - roCom["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString(roCom["Address"].ToString().MyPadLeft(roCom["Address"].ToString().Length + Convert.ToInt32((40 - roCom["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    //if (city.Trim() != "")
                        strData.Append(RawPrinterHelper.GetRawPrintString(city.MyPadLeft(city.Length + Convert.ToInt32((40 - city.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((40 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    if (i == 1)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "TAX INVOICE", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "INVOICE", RawPrinterHelper.PrintFontType.Contract, true));

                    if (Convert.ToInt32(NumberToWord.Val(roMaster["PrintCopy"].ToString())) > 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(12) + "Copy of Original " + roMaster["PrintCopy"].ToString(), RawPrinterHelper.PrintFontType.Contract, true));
                    //if (i == 1)
                    //{
                    //    StringBuilder strSql = new StringBuilder();
                    //    strSql.Append("UPDATE " + _DbName + ".dbo.SalesInvoiceMAster set PrintCopy=Isnull(PrintCopy,0)+1,PrintedBy='" + _printedBy + "' , PrintedDate='" + _printedDate.ToString("MM/dd/yyyy HH:mm:ss") + "'where VNo='" + BillNo + "' \n");
                    //    Database.ExecuteQuery(strSql.ToString());
                    //}
                    //Add//
                    //if (DateType == "D")
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Date: " + Convert.ToDateTime(roMaster["VDate"]).ToShortDateString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //else
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Miti: " + roMaster["VMiti"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (!string.IsNullOrEmpty(roMaster["PartyName"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: " + roMaster["PartyName"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (roMaster["Catagory"].ToString() != "Cash Book")
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: " + roMaster["GLDesc"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: Cash"), RawPrinterHelper.PrintFontType.Contract, true));
                    }
                    if (!string.IsNullOrEmpty(roMaster["VatNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser PAN: " + roMaster["VatNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["PanNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser PAN: " + roMaster["PanNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser PAN: "), RawPrinterHelper.PrintFontType.Contract, true));
                    }
                    if (!string.IsNullOrEmpty(roMaster["PartyAddress"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["PartyAddress"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["AddressI"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["AddressI"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address"), RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode: " + roMaster["PaymentMode"].ToString() + ""), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(3) + "Particulars".MyPadRight(18) + "Qty".MyPadLeft(3) + "Rate".MyPadLeft(8) + "Amount".MyPadLeft(8) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    foreach (DataRow roDetail in dtDetail.Select("VNo = '" + roMaster["VNo"].ToString() + "'"))
                    {
                        //Print Detail Part from roDetail                     
                        string qty = Convert.ToDecimal(roDetail["Qty"]).ToString("0.00");
                        string[] s = qty.Split('.');
                        if (Convert.ToInt32(s[1]) <= 0)
                        {
                            qty = s[0];
                        }

                        Sno = Sno + 1;
                        TotBas = TotBas + Convert.ToDecimal(roDetail["BasicAmt"].ToString());
                        if (Convert.ToDecimal(roDetail["Vat"].ToString()) == 13)
                        {
                            TaxableValue = TaxableValue + Convert.ToDecimal(roDetail["BasicAmt"].ToString());
                        }
                        else
                        {
                            NonTaxableValue = NonTaxableValue + Convert.ToDecimal(roDetail["BasicAmt"].ToString());
                        }
                        BasicAmt = Convert.ToDecimal(roDetail["BasicAmt"].ToString()) / Convert.ToDecimal(roDetail["Qty"].ToString());


                        string PDesc = roDetail["PDesc"].ToString();
                        string PDesc1 = "";
                        if (PDesc.Length >= 18)
                        {
                            PDesc1 = PDesc.Substring(0, 18);
                        }
                        else
                        {
                            PDesc1 = PDesc;
                        }

                        string PDesc2 = "";
                        if ((PDesc.Length) - 18 >= 18)
                        {
                            PDesc2 = PDesc.Substring(18, 18);
                        }
                        else
                        {
                            PDesc2 = PDesc.Remove(0, PDesc1.Length);
                        }

                        string PDesc3 = "";
                        if ((PDesc.Length) - 36 >= 18)
                        {
                            PDesc3 = PDesc.Substring(36, 18);
                        }
                        else
                        {
                            PDesc3 = PDesc.Remove(0, (PDesc1.Length + PDesc2.Length));
                        }

                        string PDesc4 = "";
                        if ((PDesc.Length) - 54 >= 18)
                        {
                            PDesc4 = PDesc.Substring(54, 18);
                        }
                        else
                        {
                            PDesc4 = PDesc.Remove(0, (PDesc1.Length + PDesc2.Length + PDesc3.Length));
                        }

                        //strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["Sno"].ToString() + ".").MyPadRight(3) + roDetail["PDesc"].ToString().MyPadRight(14) + qty.MyPadLeft(4) + Convert.ToDecimal(BasicAmt).ToString("0.00").MyPadLeft(10) + Convert.ToDecimal(roDetail["BasicAmt"]).ToString("0.00").MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["Sno"].ToString() + ".").MyPadRight(3) + PDesc1.MyPadRight(18) + qty.MyPadLeft(3) + Convert.ToDecimal(BasicAmt).ToString("0.00").MyPadLeft(8) + Convert.ToDecimal(roDetail["BasicAmt"]).ToString("0.00").MyPadLeft(8) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        if (!string.IsNullOrEmpty(PDesc2))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc2, RawPrinterHelper.PrintFontType.Contract, true));
                        if (!string.IsNullOrEmpty(PDesc3))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc3, RawPrinterHelper.PrintFontType.Contract, true));
                        if (!string.IsNullOrEmpty(PDesc4))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc4, RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    //Print Total
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("Gross Amount :".MyPadLeft(20) + " ".MyPadLeft(10) + TotBas.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    TotGrand = TotBas;
                    if (dtBTerm.Rows.Count > 0)
                    {
                        foreach (DataRow itemtrm in dtBTerm.Rows)
                        {
                            if (itemtrm["Vat"].ToString() == itemtrm["PTCode"].ToString())
                            {
                                if (dtTaxTermValue.Rows.Count > 0)
                                {
                                    TaxableValue = TaxableValue + @Convert.ToDecimal(NumberToWord.Val(dtTaxTermValue.Rows[0]["LocalAmt"].ToString()));
                                }
                                if (dtNonTaxTermValue.Rows.Count > 0)
                                {
                                    NonTaxableValue = NonTaxableValue + @Convert.ToDecimal(NumberToWord.Val(dtNonTaxTermValue.Rows[0]["LocalAmt"].ToString()));
                                }
                                if (NonTaxableValue > 0)
                                {
                                    strData.Append(RawPrinterHelper.GetRawPrintString("Non Taxable :".MyPadLeft(20) + " ".MyPadLeft(10) + NonTaxableValue.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                                }
                                strData.Append(RawPrinterHelper.GetRawPrintString("Taxable :".MyPadLeft(20) + " ".MyPadLeft(10) + TaxableValue.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                            }
                            if (Convert.ToDecimal(itemtrm["LocalRate"].ToString()) != 0)
                                strData.Append(RawPrinterHelper.GetRawPrintString(itemtrm["PtDesc"].ToString().MyPadLeft(18) + " : ".MyPadLeft(3) + Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalRate"].ToString())).ToString("0.00").MyPadLeft(5) + " %".MyPadLeft(2) + " ".MyPadLeft(2) + Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                            else
                                strData.Append(RawPrinterHelper.GetRawPrintString(itemtrm["PtDesc"].ToString().MyPadLeft(18) + " : ".MyPadLeft(3) + " ".MyPadLeft(9) + Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                            if (itemtrm["Sign"].ToString() == "+")
                            {
                                TotGrand = TotGrand + Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString()));
                            }
                            else
                            {
                                TotGrand = TotGrand - Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString()));
                            }
                        }
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString("Net Amount :".MyPadLeft(20) + " ".MyPadLeft(10) + TotGrand.ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (Convert.ToDecimal(NumberToWord.Val(roMaster["TenderAmt"].ToString())) != 0)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("Tender Amount :".MyPadLeft(20) + " ".MyPadLeft(10) + Convert.ToDecimal(NumberToWord.Val(roMaster["TenderAmt"].ToString())).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("Change Amount :".MyPadLeft(20) + " ".MyPadLeft(10) + Convert.ToDecimal(roMaster["ChangeAmt"]).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    string rupees = NumberToWord.ToWords(Convert.ToDecimal(roMaster["NetAmt"]));
                    string rupees1 = "";
                    if (rupees.Length >= 28)
                    {
                        rupees1 = rupees.Substring(0, 28);
                    }
                    else
                    {
                        rupees1 = rupees;
                    }

                    string rupees2 = "";
                    if ((rupees.Length) - 28 >= 38)
                    {
                        rupees2 = rupees.Substring(28, 38);
                    }
                    else
                    {
                        rupees2 = rupees.Remove(0, rupees1.Length);
                    }

                    string rupees3 = "";
                    if ((rupees.Length) - 66 >= 38)
                    {
                        rupees3 = rupees.Substring(66, 38);
                    }
                    else
                    {
                        rupees3 = rupees.Remove(0, (rupees1.Length + rupees2.Length));
                    }

                    string rupees4 = "";
                    if ((rupees.Length) - 104 >= 38)
                    {
                        rupees4 = rupees.Substring(104, 38);
                    }
                    else
                    {
                        rupees4 = rupees.Remove(0, (rupees1.Length + rupees2.Length + rupees3.Length));
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString("In word : " + rupees1, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees2))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees2, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees3))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees3, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees4))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees4, RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString(("Counter : " + roMaster["ClassCode1"].ToString()).MyPadRight(20) + ("Bill Time : " + Convert.ToDateTime(roMaster["VoTime"].ToString()).ToShortTimeString().ToString()), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString(("Cashier : " + roMaster["UserCode"].ToString()).MyPadRight(20) + ("Print Time: " + DateTime.Now.ToShortTimeString()), RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(6) + "****THANK YOU FOR VISIT****", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append("\n\n\n\n\n\n\n");
                }
                RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());

            }
        }
        private void ThreeInchCounterTaxBill()
        {
            DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
            DataTable dtCompany = dsSB.Tables[0];
            DataTable dtMaster = dsSB.Tables[1];
            DataTable dtDetail = dsSB.Tables[2];
            DataTable dtProductTerm = dsSB.Tables[3];
            dtProductTerm.Columns.Remove("Voucher No");
            dtProductTerm.Columns.Remove("SNo");
            dtProductTerm.Columns.Remove("ProductId");

            DataTable dtBillTerm = dsSB.Tables[4];
            decimal roundoff = 0;
            decimal BasicAmt = 0;
            decimal ProductDiscount = 0;
            //decimal ProductDiscount, BillWiseDiscount = 0;
            for (int i = 1; i <= _NoofCopyPrint; i++)
            {
                StringBuilder strData = new StringBuilder();
                foreach (DataRow roMaster in dtMaster.Rows)
                {
                    // Print Header Part from roMaster
                    BasicAmt = 0;
                    ProductDiscount = 0;
                    string city = "";
                    if (dtCompany.Rows[0]["City"].ToString() != "")
                        city = dtCompany.Rows[0]["City"].ToString() + ',' + dtCompany.Rows[0]["PhoneNo"].ToString();
                    else
                        city = dtCompany.Rows[0]["PhoneNo"].ToString();
                    string pan = "PAN NO : " + dtCompany.Rows[0]["PanNo"].ToString();
                    strData.Append(RawPrinterHelper.GetRawPrintString(dtCompany.Rows[0]["CompanyName"].ToString().MyPadLeft(dtCompany.Rows[0]["CompanyName"].ToString().Length + Convert.ToInt32((40 - dtCompany.Rows[0]["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString(dtCompany.Rows[0]["Address"].ToString().MyPadLeft(dtCompany.Rows[0]["Address"].ToString().Length + Convert.ToInt32((40 - dtCompany.Rows[0]["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString(city.MyPadLeft(city.Length + Convert.ToInt32((40 - city.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((40 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    if (i == 1)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "TAX INVOICE", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "INVOICE", RawPrinterHelper.PrintFontType.Contract, true));

                    if (Convert.ToInt32(NumberToWord.Val(roMaster["PrintCopy"].ToString())) > 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(12) + "Copy of Original " + roMaster["PrintCopy"].ToString(), RawPrinterHelper.PrintFontType.Contract, true));

                    if (!string.IsNullOrEmpty(roMaster["PartyName"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name: " + roMaster["PartyName"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (roMaster["Catagory"].ToString() != "Cash Book")
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name: " + roMaster["GLDesc"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name: Cash"), RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    if (!string.IsNullOrEmpty(roMaster["PartyVatNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Customer PAN: " + roMaster["PartyVatNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["PanNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Customer PAN: " + roMaster["PanNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Customer PAN: "), RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    if (!string.IsNullOrEmpty(roMaster["PartyAddress"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["PartyAddress"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["Ledger Address"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["Ledger Address"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address"), RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //
                    //if (!string.IsNullOrEmpty(roMaster["TableId"].ToString()))
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode: " + roMaster["PaymentType"].ToString() + "").MyPadRight(24) + "Table: " + roMaster["TableDesc"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //else
                    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode: " + roMaster["PaymentType"].ToString() + ""), RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //
                    strData.Append(RawPrinterHelper.GetRawPrintString(("Inv No: " + roMaster["Voucher No"].ToString()).MyPadRight(24) + "Date: " + Convert.ToDateTime(roMaster["Voucher Date"]).ToShortDateString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadLeft(24) + "Miti: " + roMaster["Voucher Miti"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));

                    //   strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadLeft(26) + "Tax Rate : 13%" + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(3) + "Particulars".MyPadRight(14) + "Qty".MyPadLeft(5) + "Rate".MyPadLeft(9) + "Amount".MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    foreach (DataRow roDetail in dtDetail.Select("[Voucher No] = '" + roMaster["Voucher No"].ToString() + "'"))
                    {
                        //Print Detail Part from roDetail                     
                        string qty = Convert.ToDecimal(roDetail["Qty"]).ToString("0.00");
                        string[] s = qty.Split('.');
                        if (Convert.ToInt32(s[1]) <= 0)
                        {
                            qty = s[0];
                        }

                        strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["SNo"].ToString() + ".").MyPadRight(3) + roDetail["AdditionalDesc"].ToString().MyPadRight(14) + qty.MyPadLeft(4) + Convert.ToDecimal(roDetail["SalesRate"]).ToString("0.00").MyPadLeft(10) + Convert.ToDecimal(roDetail["BasicAmount"]).ToString("0.00").MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        BasicAmt += Convert.ToDecimal(roDetail["BasicAmount"]);
                    }

                    //Print Total
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("Basic Amount :".MyPadLeft(30) + BasicAmt.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));

                    Decimal DisTerm = 0, SpTerm = 0, Svterm = 0, vatterm = 0, termAmt=0;

                    for (int j = 0; j < dtProductTerm.Rows.Count; j++)  //--- PRODUCT WISE DISCOUNT
                    {
                        DisTerm = DisTerm + Convert.ToDecimal(dtProductTerm.Rows[j][0].ToString());
                        Svterm = Svterm + Convert.ToDecimal(dtProductTerm.Rows[j][1].ToString());
                    }

                    for (int j = 0; j < dtBillTerm.Rows.Count; j++)  //---- BILL WISE DISCOUNT
                    {
                        DisTerm = DisTerm + Convert.ToDecimal(dtBillTerm.Rows[0][1].ToString());
                    }

                    if (DisTerm != 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("Discount :".MyPadLeft(30) + DisTerm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                    if (Svterm != 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("Service Charge :".MyPadLeft(30) + Svterm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));


                    for (int j = 0; j < dtBillTerm.Rows.Count; j++)  //---- BILL WISE DISCOUNT
                    {
                        vatterm = vatterm + Convert.ToDecimal(dtBillTerm.Rows[0][2].ToString());
                    }

                    if (vatterm > 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("Vat :".MyPadLeft(30) + vatterm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));


                    strData.Append(RawPrinterHelper.GetRawPrintString("Total :".MyPadLeft(30) + (BasicAmt + DisTerm + Svterm + vatterm).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (Convert.ToDecimal(NumberToWord.Val(roMaster["TenderAmount"].ToString())) != 0)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("Tender Amount :".MyPadLeft(30) + Convert.ToDecimal(NumberToWord.Val(roMaster["TenderAmount"].ToString())).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("Change Amount :".MyPadLeft(30) + Convert.ToDecimal(roMaster["ReturnAmount"]).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    string rupees = NumberToWord.ToWords(Convert.ToDecimal(roMaster["NetAmount"]));
                    string rupees1 = "";
                    if (rupees.Length >= 28)
                    {
                        rupees1 = rupees.Substring(0, 28);
                    }
                    else
                    {
                        rupees1 = rupees;
                    }

                    string rupees2 = "";
                    if ((rupees.Length) - 28 >= 38)
                    {
                        rupees2 = rupees.Substring(28, 38);
                    }
                    else
                    {
                        rupees2 = rupees.Remove(0, rupees1.Length);
                    }

                    string rupees3 = "";
                    if ((rupees.Length) - 66 >= 38)
                    {
                        rupees3 = rupees.Substring(66, 38);
                    }
                    else
                    {
                        rupees3 = rupees.Remove(0, (rupees1.Length + rupees2.Length));
                    }

                    string rupees4 = "";
                    if ((rupees.Length) - 104 >= 38)
                    {
                        rupees4 = rupees.Substring(104, 38);
                    }
                    else
                    {
                        rupees4 = rupees.Remove(0, (rupees1.Length + rupees2.Length + rupees3.Length));
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString("In word : " + rupees1, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees2))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees2, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees3))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees3, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees4))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees4, RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString(("Cashier : " + roMaster["EnterBy"].ToString()).MyPadRight(25) + ("Time : " + DateTime.Now.ToShortTimeString()), RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(10) + "THANK YOU FOR VISIT", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append("\n\n\n\n\n\n\n");

                
                }
                RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());

                string GS = Convert.ToString((char)29);
                string ESC = Convert.ToString((char)27);
                string COMMAND = "";
                COMMAND = ESC + "@";
                COMMAND += GS + "V" + (char)1;
                RawPrinterHelper.SendStringToPrinter(_PrinterName, COMMAND);

            }
        }
        private void AbbreviatedSalesInvoiceDesign()
        {
           DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
           DataTable dtMaster = dsSB.Tables[0];
           DataTable dtDetail = dsSB.Tables[1];
           DataTable dtTerm = dsSB.Tables[2];

            //DataTable DTCom = Database.FetchingData("Select StartDate, EndDate, CompanyName, Address, City, State, Country, Phone, Fax, Email,PanNo, District from " + _DbName + ".dbo.companymaster");
            //DataRow roCom = DTCom.Rows[0];

            decimal roundoff = 0;
            decimal BasicAmt = 0;
            decimal TotBas = 0;
            decimal ProductDiscount, BillWiseDiscount = 0;

            for (int i = 1; i <= _NoofCopyPrint; i++)
            {
                StringBuilder strData = new StringBuilder();
                foreach (DataRow roMaster in dtMaster.Rows)
                {
                    //Print Header Part from roMaster

                    if (i == 1)
                        //if (Convert.ToInt32(roMaster["PrintCopy"].ToString()) == 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(8) + "Abbreviated Tax Invoice", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "INVOICE", RawPrinterHelper.PrintFontType.Contract, true));

                    if (Convert.ToInt32(roMaster["PrintCopy"].ToString()) > 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(12) + "Copy of Original " + roMaster["PrintCopy"].ToString(), RawPrinterHelper.PrintFontType.Contract, true));
                    TotBas = 0;
                    BasicAmt = 0;
                    ProductDiscount = 0;
                    //string city = "";
                    //if (roCom["City"].ToString() != "")
                    //    city = roCom["City"].ToString() + ',' + roCom["Phone"].ToString();
                    //else
                    //    city = roCom["Phone"].ToString();
                    //string pan = "PAN NO : " + roCom["PanNo"].ToString();
                    //strData.Append(RawPrinterHelper.GetRawPrintString(roCom["CompanyName"].ToString().MyPadLeft(roCom["CompanyName"].ToString().Length + Convert.ToInt32((40 - roCom["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString(roCom["Address"].ToString().MyPadLeft(roCom["Address"].ToString().Length + Convert.ToInt32((40 - roCom["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    //if (city.Trim() != "")
                    //{
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(city.MyPadLeft(city.Length + Convert.ToInt32((40 - city.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                    //}
                    //strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((40 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));

                    //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //if (i == 1)
                    //{
                    //    StringBuilder strSql = new StringBuilder();
                    //    strSql.Append("UPDATE " + _DbName + ".dbo.SalesInvoiceMAster set PrintCopy=IsNull(PrintCopy,0)+1,PrintedBy='" + _printedBy + "' , PrintedDate='" + _printedDate.ToString("MM/dd/yyyy HH:mm:ss") + "'where VNo='" + BillNo + "' \n");
                    //    Database.ExecuteQuery(strSql.ToString());
                    //}
                    ////Add//
                    //if (DateType == "D")
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Date: " + Convert.ToDateTime(roMaster["VDate"]).ToShortDateString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //else
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Miti: " + roMaster["VMiti"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (!string.IsNullOrEmpty(roMaster["PartyName"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: " + roMaster["PartyName"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (roMaster["Catagory"].ToString() != "Cash Book")
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: " + roMaster["GLDesc"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: Cash"), RawPrinterHelper.PrintFontType.Contract, true));
                    }
                    if (!string.IsNullOrEmpty(roMaster["VatNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser PAN: " + roMaster["VatNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["PanNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser PAN: " + roMaster["PanNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (!string.IsNullOrEmpty(roMaster["PartyAddress"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["PartyAddress"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["AddressI"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["AddressI"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode: " + roMaster["PaymentMode"].ToString() + ""), RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(3) + "Particulars".MyPadRight(14) + "Qty".MyPadLeft(5) + "Rate".MyPadLeft(9) + "Amount".MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (dtDetail.Rows.Count > 0)
                    {
                        foreach (DataRow roDetail in dtDetail.Select("VNo = '" + roMaster["VNo"].ToString() + "'"))
                        {
                            //Print Detail Part from roDetail                     
                            string qty = Convert.ToDecimal(NumberToWord.Val(roDetail["Qty"].ToString())).ToString("0.00");
                            TotBas = TotBas + (Convert.ToDecimal(NumberToWord.Val(roDetail["Qty"].ToString())) * Convert.ToDecimal(NumberToWord.Val(roDetail["LocalRate"].ToString())));
                            BasicAmt = (Convert.ToDecimal(NumberToWord.Val(roDetail["Qty"].ToString())) * Convert.ToDecimal(NumberToWord.Val(roDetail["LocalRate"].ToString())));

                            string[] s = qty.Split('.');
                            if (Convert.ToInt32(s[1]) <= 0)
                            {
                                qty = s[0];
                            }
                            strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["SNo"].ToString() + ".").MyPadRight(3) + roDetail["PDesc"].ToString().MyPadRight(14) + qty.MyPadLeft(4) + Convert.ToDecimal(roDetail["LocalRate"]).ToString("0.00").MyPadLeft(10) + Convert.ToDecimal(BasicAmt).ToString("0.00").MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        }
                    }
                    //Print Total
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("Total :".MyPadLeft(30) + TotBas.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                    //if (dtTerm.Rows.Count > 0)
                    //{
                    //    Decimal DisTerm = 0, SpTerm = 0, Svterm = 0, vatterm = 0;
                    //    if (_sysDisterm != "")
                    //    {
                    //        foreach (DataRow roTerm in dtTerm.Select("VNo = '" + roMaster["VNo"].ToString() + "' and TrmType= 'P' and STCode ='" + _sysDisterm + "'"))
                    //        {
                    //            DisTerm = DisTerm + Convert.ToDecimal(roTerm["CurrAmt"].ToString());
                    //        }
                    //    }
                    //    if (_sysSpDisterm != "")
                    //    {
                    //        foreach (DataRow roTerm in dtTerm.Select("VNo = '" + roMaster["VNo"].ToString() + "' and TrmType= 'P' and STCode ='" + _sysSpDisterm + "'"))
                    //        {
                    //            SpTerm = SpTerm + Convert.ToDecimal(roTerm["CurrAmt"].ToString());
                    //        }
                    //    }
                    //    if (DisTerm > 0)
                    //    {
                    //        strData.Append(RawPrinterHelper.GetRawPrintString("Discount :".MyPadLeft(30) + DisTerm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                    //    }
                    //    if (SpTerm > 0)
                    //    {
                    //        strData.Append(RawPrinterHelper.GetRawPrintString("Spec. Discount :".MyPadLeft(30) + SpTerm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                    //    }
                    //    strData.Append(RawPrinterHelper.GetRawPrintString("Net Total :".MyPadLeft(30) + ((TotBas - DisTerm - SpTerm)).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //}
                    if (Convert.ToDecimal(NumberToWord.Val(roMaster["TenderAmt"].ToString())) != 0)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("Tender Amount :".MyPadLeft(30) + Convert.ToDecimal(NumberToWord.Val(roMaster["TenderAmt"].ToString())).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("Change Amount :".MyPadLeft(30) + Convert.ToDecimal(NumberToWord.Val(roMaster["ChangeAmt"].ToString())).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));
                    }

                    string rupees = NumberToWord.ToWords(Convert.ToDecimal(roMaster["NetAmt"]));
                    string rupees1 = "";
                    if (rupees.Length >= 28)
                    {
                        rupees1 = rupees.Substring(0, 28);
                    }
                    else
                    {
                        rupees1 = rupees;
                    }

                    string rupees2 = "";
                    if ((rupees.Length) - 28 >= 38)
                    {
                        rupees2 = rupees.Substring(28, 38);
                    }
                    else
                    {
                        rupees2 = rupees.Remove(0, rupees1.Length);
                    }

                    string rupees3 = "";
                    if ((rupees.Length) - 66 >= 38)
                    {
                        rupees3 = rupees.Substring(66, 38);
                    }
                    else
                    {
                        rupees3 = rupees.Remove(0, (rupees1.Length + rupees2.Length));
                    }

                    string rupees4 = "";
                    if ((rupees.Length) - 104 >= 38)
                    {
                        rupees4 = rupees.Substring(104, 38);
                    }
                    else
                    {
                        rupees4 = rupees.Remove(0, (rupees1.Length + rupees2.Length + rupees3.Length));
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString("In word : " + rupees1, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees2))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees2, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees3))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees3, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees4))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees4, RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString(("Counter : Terminal  " + roMaster["ClassCode1"].ToString()).MyPadRight(25), RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadLeft(40) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString(("User : " + roMaster["UserCode"].ToString() + "      " + DateTime.Now.ToShortTimeString()).MyPadRight(25), RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(0) + "***Goods one sold will not be return***", RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(0) + "Exchange Within 7 Days with Receipt Only", RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadLeft(40) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(5) + "****Thank You Visit Again****", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append("\n\n\n\n\n\n\n");
                }
                RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
            }
        }
        private void DefaultCounterAbbreviatedSalesInvoiceDesign()
        {
           DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
           DataTable dtMaster = dsSB.Tables[0];
           DataTable dtDetail = dsSB.Tables[1];
           DataTable dtTerm = dsSB.Tables[2];

            decimal roundoff = 0;
            decimal BasbicAmt = 0;
            decimal TotBas = 0;
            decimal ProductDiscount, BillWiseDiscount = 0;

            for (int i = 1; i <= _NoofCopyPrint; i++)
            {
                StringBuilder strData = new StringBuilder();
                foreach (DataRow roMaster in dtMaster.Rows)
                {
                    //Print Header Part from roMaster

                    if (i == 1)
                        //if (Convert.ToInt32(roMaster["PrintCopy"].ToString()) == 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(8) + "Abbreviated Tax Invoice", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "INVOICE", RawPrinterHelper.PrintFontType.Contract, true));

                    if (Convert.ToInt32(roMaster["PrintCopy"].ToString()) > 0)
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(12) + "Copy of Original " + roMaster["PrintCopy"].ToString(), RawPrinterHelper.PrintFontType.Contract, true));
                    //if (DateType == "D")
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Date: " + Convert.ToDateTime(roMaster["VDate"]).ToShortDateString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //else
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Miti: " + roMaster["VMiti"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));


                    //TotBas = 0;
                    //BasicAmt = 0;
                    //ProductDiscount = 0;
                    //string city = "";
                    //if (roCom["City"].ToString() != "")
                    //    city = roCom["City"].ToString() + ',' + roCom["Phone"].ToString();
                    //else
                    //    city = roCom["Phone"].ToString();
                    //strData.Append(RawPrinterHelper.GetRawPrintString(("Seller's Name : " + roCom["CompanyName"].ToString()).MyPadRight(40), RawPrinterHelper.PrintFontType.Contract, true));
                    //if (city.Trim() != "")
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Address : " + roCom["Address"].ToString() + " " + city).MyPadRight(40), RawPrinterHelper.PrintFontType.Contract, true));
                    //else
                    //    strData.Append(RawPrinterHelper.GetRawPrintString(("Address : " + roCom["Address"].ToString()).MyPadRight(40), RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString(("Seller's PAN : " + roCom["PanNo"].ToString()).MyPadRight(40), RawPrinterHelper.PrintFontType.Contract, true));

                    //if (i == 1)
                    //{
                    //    StringBuilder strSql = new StringBuilder();
                    //    strSql.Append("UPDATE " + _DbName + ".dbo.SalesInvoiceMAster set PrintCopy=IsNull(PrintCopy,0)+1,PrintedBy='" + _printedBy + "' , PrintedDate='" + _printedDate.ToString("MM/dd/yyyy HH:mm:ss") + "'where VNo='" + BillNo + "' \n");
                    //    Database.ExecuteQuery(strSql.ToString());
                    //}

                    if (!string.IsNullOrEmpty(roMaster["PartyName"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: " + roMaster["PartyName"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (roMaster["Catagory"].ToString() != "Cash Book")
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: " + roMaster["GLDesc"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's Name: Cash"), RawPrinterHelper.PrintFontType.Contract, true));

                    if (!string.IsNullOrEmpty(roMaster["PartyAddress"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["PartyAddress"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["AddressI"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["AddressI"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (!string.IsNullOrEmpty(roMaster["VatNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's PAN: " + roMaster["VatNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    else if (!string.IsNullOrEmpty(roMaster["PanNo"].ToString()))
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Purchaser's PAN: " + roMaster["PanNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode: " + roMaster["PaymentMode"].ToString() + ""), RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(3) + "Particulars".MyPadRight(18) + "Qty".MyPadLeft(3) + "Rate".MyPadLeft(8) + "Amount".MyPadLeft(8) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    if (dtDetail.Rows.Count > 0)
                    {
                        foreach (DataRow roDetail in dtDetail.Select("VNo = '" + roMaster["VNo"].ToString() + "'"))
                        {
                            //Print Detail Part from roDetail                     
                            string qty = Convert.ToDecimal(NumberToWord.Val(roDetail["Qty"].ToString())).ToString("0.00");
                            TotBas = TotBas + (Convert.ToDecimal(NumberToWord.Val(roDetail["Qty"].ToString())) * Convert.ToDecimal(NumberToWord.Val(roDetail["LocalRate"].ToString())));
                           // BasicAmt = (Convert.ToDecimal(NumberToWord.Val(roDetail["Qty"].ToString())) * Convert.ToDecimal(NumberToWord.Val(roDetail["LocalRate"].ToString())));

                            string[] s = qty.Split('.');
                            if (Convert.ToInt32(s[1]) <= 0)
                            {
                                qty = s[0];
                            }

                            string PDesc = roDetail["PDesc"].ToString();
                            string PDesc1 = "";
                            if (PDesc.Length >= 18)
                            {
                                PDesc1 = PDesc.Substring(0, 18);
                            }
                            else
                            {
                                PDesc1 = PDesc;
                            }

                            string PDesc2 = "";
                            if ((PDesc.Length) - 18 >= 18)
                            {
                                PDesc2 = PDesc.Substring(18, 18);
                            }
                            else
                            {
                                PDesc2 = PDesc.Remove(0, PDesc1.Length);
                            }

                            string PDesc3 = "";
                            if ((PDesc.Length) - 36 >= 18)
                            {
                                PDesc3 = PDesc.Substring(36, 18);
                            }
                            else
                            {
                                PDesc3 = PDesc.Remove(0, (PDesc1.Length + PDesc2.Length));
                            }

                            string PDesc4 = "";
                            if ((PDesc.Length) - 54 >= 18)
                            {
                                PDesc4 = PDesc.Substring(54, 18);
                            }
                            else
                            {
                                PDesc4 = PDesc.Remove(0, (PDesc1.Length + PDesc2.Length + PDesc3.Length));
                            }

                            //strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["SNo"].ToString() + ".").MyPadRight(3) + roDetail["PDesc"].ToString().MyPadRight(14) + qty.MyPadLeft(4) + Convert.ToDecimal(roDetail["LocalRate"]).ToString("0.00").MyPadLeft(10) + Convert.ToDecimal(BasicAmt).ToString("0.00").MyPadLeft(9) + "", RawPrinterHelper.PrintFontType.Contract, true));                            
                           // strData.Append(RawPrinterHelper.GetRawPrintString((roDetail["SNo"].ToString() + ".").MyPadRight(3) + PDesc1.MyPadRight(18) + qty.MyPadLeft(3) + Convert.ToDecimal(roDetail["LocalRate"]).ToString("0.00").MyPadLeft(8) + Convert.ToDecimal(BasicAmt).ToString("0.00").MyPadLeft(8) + "", RawPrinterHelper.PrintFontType.Contract, true));
                            if (!string.IsNullOrEmpty(PDesc2))
                                strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc2, RawPrinterHelper.PrintFontType.Contract, true));
                            if (!string.IsNullOrEmpty(PDesc3))
                                strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc3, RawPrinterHelper.PrintFontType.Contract, true));
                            if (!string.IsNullOrEmpty(PDesc4))
                                strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc4, RawPrinterHelper.PrintFontType.Contract, true));

                        }
                    }
                    //Print Total
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("Gross Amount :".MyPadLeft(30) + TotBas.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                    //if (dtTerm.Rows.Count > 0)
                    //{
                    //    Decimal DisTerm = 0, SpTerm = 0, Svterm = 0, vatterm = 0;
                    //    if (_sysDisterm != "")
                    //    {
                    //        foreach (DataRow roTerm in dtTerm.Select("VNo = '" + roMaster["VNo"].ToString() + "' and TrmType= 'P' and STCode ='" + _sysDisterm + "'"))
                    //        {
                    //            DisTerm = DisTerm + Convert.ToDecimal(roTerm["CurrAmt"].ToString());
                    //        }
                    //    }
                    //    if (_sysSpDisterm != "")
                    //    {
                    //        foreach (DataRow roTerm in dtTerm.Select("VNo = '" + roMaster["VNo"].ToString() + "' and TrmType= 'P' and STCode ='" + _sysSpDisterm + "'"))
                    //        {
                    //            SpTerm = SpTerm + Convert.ToDecimal(roTerm["CurrAmt"].ToString());
                    //        }
                    //    }
                    //    if (DisTerm > 0)
                    //    {
                    //        strData.Append(RawPrinterHelper.GetRawPrintString("Discount :".MyPadLeft(30) + ("-" + DisTerm.ToString("0.00")).MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                    //    }
                    //    if (SpTerm > 0)
                    //    {
                    //        strData.Append(RawPrinterHelper.GetRawPrintString("Spec. Discount :".MyPadLeft(30) + SpTerm.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                    //    }
                    //    strData.Append(RawPrinterHelper.GetRawPrintString("Net Total :".MyPadLeft(30) + ((TotBas - DisTerm - SpTerm)).ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    //    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(20, ' ') + "--------------------" + "", RawPrinterHelper.PrintFontType.Contract, true));

                    //}
                    

                    string rupees = NumberToWord.ToWords(Convert.ToDecimal(roMaster["NetAmt"]));
                    string rupees1 = "";
                    if (rupees.Length >= 28)
                    {
                        rupees1 = rupees.Substring(0, 28);
                    }
                    else
                    {
                        rupees1 = rupees;
                    }

                    string rupees2 = "";
                    if ((rupees.Length) - 28 >= 38)
                    {
                        rupees2 = rupees.Substring(28, 38);
                    }
                    else
                    {
                        rupees2 = rupees.Remove(0, rupees1.Length);
                    }

                    string rupees3 = "";
                    if ((rupees.Length) - 66 >= 38)
                    {
                        rupees3 = rupees.Substring(66, 38);
                    }
                    else
                    {
                        rupees3 = rupees.Remove(0, (rupees1.Length + rupees2.Length));
                    }

                    string rupees4 = "";
                    if ((rupees.Length) - 104 >= 38)
                    {
                        rupees4 = rupees.Substring(104, 38);
                    }
                    else
                    {
                        rupees4 = rupees.Remove(0, (rupees1.Length + rupees2.Length + rupees3.Length));
                    }

                    strData.Append(RawPrinterHelper.GetRawPrintString("In word : " + rupees1, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees2))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees2, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees3))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees3, RawPrinterHelper.PrintFontType.Contract, true));
                    if (!string.IsNullOrEmpty(rupees4))
                        strData.Append(RawPrinterHelper.GetRawPrintString(rupees4, RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString(("Counter : Terminal  " + roMaster["ClassCode1"].ToString() + "      " + DateTime.Now.ToShortTimeString()).MyPadRight(40), RawPrinterHelper.PrintFontType.Contract, true));
                    //strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadLeft(40) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString(("User : " + roMaster["UserCode"].ToString()).MyPadRight(25), RawPrinterHelper.PrintFontType.Contract, true));

                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(5) + "****Thank You Visit Again****", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                    strData.Append("\n\n\n\n\n\n\n");
                }
                RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
            }
        }
        private void DefaultSalesTaxInvoiceHeader(int i, string printer)
        {
            StringBuilder strData = new StringBuilder();
            //strData.Clear();
            //string city = "";
            //if (DTCom.Rows[0]["City"].ToString() != "")
            //    city = DTCom.Rows[0]["City"].ToString() + ',' + DTCom.Rows[0]["Phone"].ToString();
            //else
            //    city = DTCom.Rows[0]["Phone"].ToString();
            //string pan = "PAN NO : " + DTCom.Rows[0]["PanNo"].ToString();
            //strData.Append(RawPrinterHelper.GetRawPrintString(DTCom.Rows[0]["CompanyName"].ToString().MyPadLeft(DTCom.Rows[0]["CompanyName"].ToString().Length + Convert.ToInt32((160 - DTCom.Rows[0]["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //N_HeadLine = 1;

            //if (city.Trim() != "")
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString((DTCom.Rows[0]["Address"].ToString() + " " + city).MyPadLeft((DTCom.Rows[0]["Address"].ToString() + " " + city).Length + Convert.ToInt32((135 - (DTCom.Rows[0]["Address"].ToString() + " " + city).Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(DTCom.Rows[0]["Address"].ToString().MyPadLeft(DTCom.Rows[0]["Address"].ToString().Length + Convert.ToInt32((135 - DTCom.Rows[0]["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //if (pan != "")
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((135 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //if (i == 1)
            //{
            //    if (Convert.ToInt32(NumberToWord.Val(dtMaster.Rows[0]["PrintCopy"].ToString())) > 0)
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     TAX INVOICE" + " - Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).MyPadLeft(("TAX INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length + Convert.ToInt32((160 - ("TAX INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //    else
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     TAX INVOICE").MyPadLeft(("TAX INVOICE").Length + Convert.ToInt32((160 - ("TAX INVOICE").Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //}
            //else
            //{
            //    if (Convert.ToInt32(NumberToWord.Val(dtMaster.Rows[0]["PrintCopy"].ToString())) > 0)
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     INVOICE" + " - Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).MyPadLeft(("INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length + Convert.ToInt32((160 - ("INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //    else
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     INVOICE").MyPadLeft(("INVOICE").Length + Convert.ToInt32((160 - ("INVOICE").Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //}
            //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;
            ////Add//
            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyName"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name     : " + dtMaster.Rows[0]["PartyName"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Invoice No : " + dtMaster.Rows[0]["VNo"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name     : " + dtMaster.Rows[0]["GLDesc"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Invoice No : " + dtMaster.Rows[0]["VNo"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["VatNo"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : " + dtMaster.Rows[0]["VatNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PanNo"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : " + dtMaster.Rows[0]["PanNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : ").MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyAddress"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : " + dtMaster.Rows[0]["PartyAddress"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["AddressI"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : " + dtMaster.Rows[0]["AddressI"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : ").MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"]).ToString().MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyMobileNo"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["PartyMobileNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["Mobile"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["Mobile"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyMobileNo"].ToString()) && string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["PartyMobileNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + (" ").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (string.IsNullOrEmpty(dtMaster.Rows[0]["PartyMobileNo"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"]).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (string.IsNullOrEmpty(dtMaster.Rows[0]["Mobile"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"]).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}

            //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;
            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PaymentMode"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : " + dtMaster.Rows[0]["PaymentMode"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (dtMaster.Rows[0]["Catagory"].ToString() != "Cash Book")
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : Cash").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : Cash").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(4) + "Particulars".MyPadRight(70) + "".MyPadLeft(1) + "AltQty".MyPadLeft(10) + "".MyPadLeft(1) + "Unit".MyPadRight(5) + "".MyPadLeft(1) + "Qty".MyPadLeft(10) + "".MyPadLeft(1) + "Unit".MyPadRight(5) + "".MyPadLeft(1) + "Rate".MyPadLeft(12) + "".MyPadLeft(1) + "".MyPadLeft(1) + "Amount".MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
            strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

            RawPrinterHelper.SendStringToPrinter(printer, strData.ToString());

        }
        private void DefaultSalesTaxInvoiceDetails()
        {
           DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
           DataTable dtMaster = dsSB.Tables[0];
           DataTable dtDetail = dsSB.Tables[1];
           DataTable dtTerm = dsSB.Tables[3];
            
            decimal TotAltQty = 0, RunningTotAltQty = 0;
            decimal TotQty = 0, RunningTotQty = 0;
            decimal TotBasicAmt = 0, RunningTotBasicAmt = 0;
            decimal TotGrandAmt = 0;
            for (int c = 1; c <= _NoofCopyPrint; c++)
            {
                DefaultSalesTaxInvoiceHeader(c, _PrinterName);
                StringBuilder strData = new StringBuilder();
                TotAltQty = 0;
                TotQty = 0;
                TotBasicAmt = 0;
                TotGrandAmt = 0;
                string printdt = "";
                int LCnt = 0;
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    printdt = (dtDetail.Rows[i]["SNo"].ToString() + ".").MyPadRight(4);
                    printdt = printdt + (dtDetail.Rows[i]["PDesc"].ToString()).MyPadRight(70);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);
                    if (dtDetail.Rows[i]["AltUnitCode"].ToString() != "")
                        printdt = printdt + ("").MyPadRight(1) + (dtDetail.Rows[i]["AltUnitCode"].ToString()).MyPadRight(5);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(5);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);
                    if (dtDetail.Rows[i]["UnitCode"].ToString() != "")
                        printdt = printdt + ("").MyPadRight(1) + (dtDetail.Rows[i]["UnitCode"].ToString()).MyPadRight(5);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(5);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalRate"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalRate"].ToString())).ToString("0.00")).MyPadLeft(12);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(12);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString())).ToString("0.00")).MyPadLeft(12);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(12);

                    TotAltQty = TotAltQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString()));
                    TotQty = TotQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString()));
                    TotBasicAmt = TotBasicAmt + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString()));

                    RunningTotAltQty = RunningTotAltQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString()));
                    RunningTotQty = RunningTotQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString()));
                    RunningTotBasicAmt = RunningTotBasicAmt + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString()));

                    strData.Append(RawPrinterHelper.GetRawPrintString(printdt + "", RawPrinterHelper.PrintFontType.Contract, true));
                    LCnt = LCnt + 1;

                    if (N_Line + 10 + dtTerm.Rows.Count == LCnt)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Running Total : ").MyPadLeft(74) + "".MyPadRight(1) + RunningTotAltQty.ToString("0.00").MyPadLeft(10) + "".MyPadLeft(7) + RunningTotQty.ToString("0.00").MyPadLeft(10) + "".MyPadRight(1) + "".MyPadRight(18) + "".MyPadRight(2) + RunningTotBasicAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        //strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));

                        RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
                        DefaultSalesTaxInvoiceHeader(c, _PrinterName);
                        strData.Clear();
                        LCnt = 0;
                        RunningTotAltQty = 0;
                        RunningTotQty = 0;
                        RunningTotBasicAmt = 0;
                    }
                }

                if (LCnt < (N_Line + (12 - N_HeadLine) - dtTerm.Rows.Count))
                {
                    for (int b = LCnt; b <= N_Line + (12 - N_HeadLine) - dtTerm.Rows.Count; b++)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    }
                }
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Printing Date & Time : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).MyPadRight(74) + "".MyPadRight(1) + TotAltQty.ToString("0.00").MyPadLeft(10) + "".MyPadLeft(7) + TotQty.ToString("0.00").MyPadLeft(10) + "".MyPadRight(1) + "Basic Amount : ".MyPadRight(18) + "".MyPadRight(2) + TotBasicAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                TotGrandAmt = TotGrandAmt + TotBasicAmt;
                if (dtTerm.Rows.Count > 0)
                {
                    foreach (DataRow DTRo in dtTerm.Rows)
                    {
                        //if (_sysVatterm == DTRo["PTCode"].ToString())
                        //    strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + "Taxable Value : ".MyPadRight(18) + "".MyPadRight(12) + TotGrandAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        if (Convert.ToDecimal(NumberToWord.Val(DTRo["LocalRate"].ToString())) != 0)
                            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + DTRo["PTDesc"].ToString().MyPadRight(18) + "".MyPadRight(2) + (Convert.ToDecimal(NumberToWord.Val(DTRo["LocalRate"].ToString())).ToString("0.00") + "%").MyPadRight(6) + "".MyPadRight(4) + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        else
                            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + DTRo["PTDesc"].ToString().MyPadRight(18) + "".MyPadRight(2) + "".MyPadRight(6) + "".MyPadRight(4) + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        if (DTRo["Sign"].ToString() == "-")
                            TotGrandAmt = TotGrandAmt - Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString()));
                        else
                            TotGrandAmt = TotGrandAmt + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString()));
                    }
                }

                strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + "Net Amount :".MyPadRight(18) + "".MyPadRight(12) + TotGrandAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("In Words : " + NumberToWord.ToWords(TotGrandAmt)).MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Remarks : " + dtMaster.Rows[0]["Remarks"].ToString()).MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(135, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(135, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadRight(25) + "".MyPadRight(20) + _PrintedBy.MyPadRight(20) + "".MyPadRight(10) + " ".MyPadRight(60) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(25, '-') + "".MyPadRight(15) + "-".MyPadLeft(25, '-') + "".MyPadRight(10) + "-".MyPadLeft(60, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                //strData.Append(RawPrinterHelper.GetRawPrintString("     Received By ".MyPadRight(25) + "".MyPadRight(15) + "     Prepared By ".MyPadRight(25) + "".MyPadRight(10) + ("For " + DTCom.Rows[0]["CompanyName"]).MyPadRight(60) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append("\n\n\n\n");
                RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
            }
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("UPDATE " + _DbName + ".dbo.SalesInvoiceMAster set PrintCopy=Isnull(PrintCopy,0)+1,PrintedBy='" + _PrintedBy + "' , PrintedDate='" + _printedDate.ToString("MM/dd/yyyy HH:mm:ss") + "'where VNo='" + BillNo + "' \n");
            //Database.ExecuteQuery(strSql.ToString());

        }
        private void DefaultTaxInvoiceLetterFullPTermHeader(int i, string printer)
        {
            StringBuilder strData = new StringBuilder();
            strData.Clear();
            //string city = "";
            //if (DTCom.Rows[0]["City"].ToString() != "")
            //    city = DTCom.Rows[0]["City"].ToString() + ',' + DTCom.Rows[0]["Phone"].ToString();
            //else
            //    city = DTCom.Rows[0]["Phone"].ToString();
            //string pan = "PAN/VAT NO : " + DTCom.Rows[0]["PanNo"].ToString();
            //strData.Append(RawPrinterHelper.GetRawPrintString(DTCom.Rows[0]["CompanyName"].ToString().MyPadLeft(DTCom.Rows[0]["CompanyName"].ToString().Length + Convert.ToInt32((160 - DTCom.Rows[0]["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //N_HeadLine = 1;

            //if (city.Trim() != "")
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString((DTCom.Rows[0]["Address"].ToString() + " " + city).MyPadLeft((DTCom.Rows[0]["Address"].ToString() + " " + city).Length + Convert.ToInt32((135 - (DTCom.Rows[0]["Address"].ToString() + " " + city).Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(DTCom.Rows[0]["Address"].ToString().MyPadLeft(DTCom.Rows[0]["Address"].ToString().Length + Convert.ToInt32((135 - DTCom.Rows[0]["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //if (pan != "")
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((135 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //if (i == 1)
            //{
            //    if (Convert.ToInt32(NumberToWord.Val(dtMaster.Rows[0]["PrintCopy"].ToString())) > 0)
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     TAX INVOICE" + " - Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).MyPadLeft(("TAX INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length + Convert.ToInt32((160 - ("TAX INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //    else
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     TAX INVOICE").MyPadLeft(("TAX INVOICE").Length + Convert.ToInt32((160 - ("TAX INVOICE").Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //}
            //else
            //{
            //    if (Convert.ToInt32(NumberToWord.Val(dtMaster.Rows[0]["PrintCopy"].ToString())) > 0)
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     INVOICE" + " - Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).MyPadLeft(("INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length + Convert.ToInt32((160 - ("INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //    else
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     INVOICE").MyPadLeft(("INVOICE").Length + Convert.ToInt32((160 - ("INVOICE").Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //}

            //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;
            ////Add//
            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyName"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name     : " + dtMaster.Rows[0]["PartyName"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Invoice No : " + dtMaster.Rows[0]["VNo"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name     : " + dtMaster.Rows[0]["GLDesc"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Invoice No : " + dtMaster.Rows[0]["VNo"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["VatNo"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : " + dtMaster.Rows[0]["VatNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PanNo"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : " + dtMaster.Rows[0]["PanNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : ").MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyAddress"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : " + dtMaster.Rows[0]["PartyAddress"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["AddressI"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : " + dtMaster.Rows[0]["AddressI"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : ").MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"]).ToString().MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyMobileNo"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["PartyMobileNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["Mobile"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["Mobile"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyMobileNo"].ToString()) && string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["PartyMobileNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + (" ").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (string.IsNullOrEmpty(dtMaster.Rows[0]["PartyMobileNo"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"]).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else if (string.IsNullOrEmpty(dtMaster.Rows[0]["Mobile"].ToString()) && !string.IsNullOrEmpty(dtMaster.Rows[0]["AgentDesc"].ToString()))
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"]).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}

            //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;
            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PaymentMode"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : " + dtMaster.Rows[0]["PaymentMode"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (dtMaster.Rows[0]["Catagory"].ToString() != "Cash Book")
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : Cash").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : Cash").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(4) + "Particulars".MyPadRight(60) + "".MyPadLeft(1) + "AltQty".MyPadLeft(10) + "".MyPadLeft(1) + "Unit".MyPadRight(5) + "".MyPadLeft(1) + "Qty".MyPadLeft(10) + "".MyPadLeft(1) + "Unit".MyPadRight(5) + "".MyPadLeft(1) + "Rate".MyPadLeft(12) + "".MyPadLeft(1) + "P. Dis".MyPadLeft(10) + "".MyPadLeft(1) + "Amount".MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
            strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

            RawPrinterHelper.SendStringToPrinter(printer, strData.ToString());

        }
        private void DefaultTaxInvoiceLetterFullPTermDetails()
        {
           DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
           DataTable dtMaster = dsSB.Tables[0];
           DataTable dtDetail = dsSB.Tables[1];
           DataTable dtBTerm = dsSB.Tables[2];
            
            decimal TotAltQty = 0, RunningTotAltQty = 0;
            decimal TotQty = 0, RunningTotQty = 0;
            decimal TotBasicAmt = 0, RunningTotBasicAmt = 0;
            decimal TotGrandAmt = 0;
            
            for (int c = 1; c <= _NoofCopyPrint; c++)
            {
                DefaultTaxInvoiceLetterFullPTermHeader(c, _PrinterName);
                StringBuilder strData = new StringBuilder();
                TotAltQty = 0;
                TotQty = 0;
                TotBasicAmt = 0;
                TotGrandAmt = 0;
                string printdt = "";
                int LCnt = 0;
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    printdt = (dtDetail.Rows[i]["SNo"].ToString() + ".").MyPadRight(4);
                    printdt = printdt + (dtDetail.Rows[i]["PDesc"].ToString()).MyPadRight(60);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);
                    if (dtDetail.Rows[i]["AltUnitCode"].ToString() != "")
                        printdt = printdt + ("").MyPadRight(1) + (dtDetail.Rows[i]["AltUnitCode"].ToString()).MyPadRight(5);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(5);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);
                    if (dtDetail.Rows[i]["UnitCode"].ToString() != "")
                        printdt = printdt + ("").MyPadRight(1) + (dtDetail.Rows[i]["UnitCode"].ToString()).MyPadRight(5);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(5);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalRate"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalRate"].ToString())).ToString("0.00")).MyPadLeft(12);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(12);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["TermAmt"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["TermAmt"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["BasicAmt"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["BasicAmt"].ToString())).ToString("0.00")).MyPadLeft(12);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(12);

                    TotAltQty = TotAltQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString()));
                    TotQty = TotQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString()));
                    TotBasicAmt = TotBasicAmt + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["BasicAmt"].ToString()));

                    RunningTotAltQty = RunningTotAltQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString()));
                    RunningTotQty = RunningTotQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString()));
                    RunningTotBasicAmt = RunningTotBasicAmt + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["BasicAmt"].ToString()));

                    strData.Append(RawPrinterHelper.GetRawPrintString(printdt + "", RawPrinterHelper.PrintFontType.Contract, true));
                    LCnt = LCnt + 1;

                    if (N_Line + 10 + dtBTerm.Rows.Count == LCnt)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Running Total : ").MyPadLeft(64) + "".MyPadRight(1) + RunningTotAltQty.ToString("0.00").MyPadLeft(10) + "".MyPadLeft(7) + RunningTotQty.ToString("0.00").MyPadLeft(10) + "".MyPadRight(1) + "".MyPadRight(18) + "".MyPadRight(12) + RunningTotBasicAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        //strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));

                        RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
                        DefaultTaxInvoiceLetterFullPTermHeader(c, _PrinterName);
                        strData.Clear();
                        LCnt = 0;
                        RunningTotAltQty = 0;
                        RunningTotQty = 0;
                        RunningTotBasicAmt = 0;
                    }
                }

                if (LCnt < (N_Line + (12 - N_HeadLine) - dtBTerm.Rows.Count))
                {
                    for (int b = LCnt; b <= N_Line + (12 - N_HeadLine) - dtBTerm.Rows.Count; b++)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    }
                }
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Printing Date & Time : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).MyPadRight(64) + "".MyPadRight(1) + TotAltQty.ToString("0.00").MyPadLeft(10) + "".MyPadLeft(7) + TotQty.ToString("0.00").MyPadLeft(10) + "".MyPadRight(1) + "Basic Amount : ".MyPadRight(18) + "".MyPadRight(12) + TotBasicAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                TotGrandAmt = TotGrandAmt + TotBasicAmt;
                //if (dtBTerm.Rows.Count > 0)
                //{
                //    foreach (DataRow DTRo in dtBTerm.Rows)
                //    {
                //        if (_sysVatterm == DTRo["PTCode"].ToString())
                //            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + "Taxable Value : ".MyPadRight(18) + "".MyPadRight(12) + TotGrandAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                //        if (Convert.ToDecimal(NumberToWord.Val(DTRo["LocalRate"].ToString())) != 0)
                //            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + DTRo["PTDesc"].ToString().MyPadRight(18) + "".MyPadRight(2) + (Convert.ToDecimal(NumberToWord.Val(DTRo["LocalRate"].ToString())).ToString("0.00") + "%").MyPadRight(6) + "".MyPadRight(4) + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                //        else
                //            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + DTRo["PTDesc"].ToString().MyPadRight(18) + "".MyPadRight(2) + "".MyPadRight(6) + "".MyPadRight(4) + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                //        if (DTRo["Sign"].ToString() == "-")
                //            TotGrandAmt = TotGrandAmt - Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString()));
                //        else
                //            TotGrandAmt = TotGrandAmt + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString()));
                //    }
                //}

                strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + "Net Amount :".MyPadRight(18) + "".MyPadRight(12) + TotGrandAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("In Words : " + NumberToWord.ToWords(TotGrandAmt)).MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Remarks : " + dtMaster.Rows[0]["Remarks"].ToString()).MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("Please check the goods at the time of delivery other wise we will not be responsible for any.".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(135, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("     " + _PrintedBy + "    ").MyPadRight(25) + "".MyPadRight(20) + "".MyPadRight(20) + "".MyPadRight(10) + " ".MyPadRight(60) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(25, '-') + "".MyPadRight(15) + "".MyPadLeft(25) + "".MyPadRight(10) + "-".MyPadLeft(60, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("     Prepared By ".MyPadRight(25) + "".MyPadRight(15) + "  ".MyPadRight(25) + "".MyPadRight(10) + ("Authorized Signatory ").MyPadRight(60) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append("\n\n\n\n");
                RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
            }
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("UPDATE " + _DbName + ".dbo.SalesInvoiceMAster set PrintCopy=Isnull(PrintCopy,0)+1,PrintedBy='" + _PrintedBy + "' , PrintedDate='" + _printedDate.ToString("MM/dd/yyyy HH:mm:ss") + "'where VNo='" + BillNo + "' \n");
            //Database.ExecuteQuery(strSql.ToString());

        }
        private void DelightSalesTaxInvoiceHeader(int i, string printer)
        {
            StringBuilder strData = new StringBuilder();
            //strData.Clear();
            //if (i == 1)
            //{
            //    if (Convert.ToInt32(NumberToWord.Val(dtMaster.Rows[0]["PrintCopy"].ToString())) > 0)
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     TAX INVOICE" + " - Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).MyPadLeft(("TAX INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length + Convert.ToInt32((160 - ("TAX INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //    else
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     TAX INVOICE").MyPadLeft(("TAX INVOICE").Length + Convert.ToInt32((160 - ("TAX INVOICE").Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //}
            //else
            //{
            //    if (Convert.ToInt32(NumberToWord.Val(dtMaster.Rows[0]["PrintCopy"].ToString())) > 0)
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     INVOICE" + " - Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).MyPadLeft(("INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length + Convert.ToInt32((160 - ("INVOICE" + "  Copy of Original " + dtMaster.Rows[0]["PrintCopy"].ToString()).Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //    else
            //        strData.Append(RawPrinterHelper.GetRawPrintString(("     INVOICE").MyPadLeft(("INVOICE").Length + Convert.ToInt32((160 - ("INVOICE").Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //}
            //string city = "";
            //if (DTCom.Rows[0]["City"].ToString() != "")
            //    city = DTCom.Rows[0]["City"].ToString() + ',' + DTCom.Rows[0]["Phone"].ToString();
            //else
            //    city = DTCom.Rows[0]["Phone"].ToString();
            //string pan = "PAN NO : " + DTCom.Rows[0]["PanNo"].ToString();
            //strData.Append(RawPrinterHelper.GetRawPrintString(DTCom.Rows[0]["CompanyName"].ToString().MyPadLeft(DTCom.Rows[0]["CompanyName"].ToString().Length + Convert.ToInt32((160 - DTCom.Rows[0]["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Expand, true));
            //N_HeadLine = 1;

            //if (city.Trim() != "")
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString((DTCom.Rows[0]["Address"].ToString() + " " + city).MyPadLeft((DTCom.Rows[0]["Address"].ToString() + " " + city).Length + Convert.ToInt32((135 - (DTCom.Rows[0]["Address"].ToString() + " " + city).Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //else
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(DTCom.Rows[0]["Address"].ToString().MyPadLeft(DTCom.Rows[0]["Address"].ToString().Length + Convert.ToInt32((135 - DTCom.Rows[0]["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //if (pan != "")
            //{
            //    strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((135 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
            //    N_HeadLine = N_HeadLine + 1;
            //}
            //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;
            ////Add//
            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyName"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name     : " + dtMaster.Rows[0]["PartyName"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Invoice No : " + dtMaster.Rows[0]["VNo"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name     : " + dtMaster.Rows[0]["GLDesc"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Invoice No : " + dtMaster.Rows[0]["VNo"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["VatNo"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : " + dtMaster.Rows[0]["VatNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PanNo"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : " + dtMaster.Rows[0]["PanNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("PAN/VAT No        : ").MyPadRight(90) + "".MyPadRight(2) + ("Date       : " + Convert.ToDateTime(dtMaster.Rows[0]["VDate"]).ToShortDateString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyAddress"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : " + dtMaster.Rows[0]["PartyAddress"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["AddressI"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : " + dtMaster.Rows[0]["AddressI"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Address  : ").MyPadRight(90) + "".MyPadRight(2) + ("Miti       : " + dtMaster.Rows[0]["VMiti"]).ToString().MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PartyMobileNo"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["PartyMobileNo"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (!string.IsNullOrEmpty(dtMaster.Rows[0]["Mobile"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: " + dtMaster.Rows[0]["Mobile"].ToString()).MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Cont. No.: ").MyPadRight(90) + "".MyPadRight(2) + ("Agent      : " + dtMaster.Rows[0]["AgentDesc"]).ToString().MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;
            //if (!string.IsNullOrEmpty(dtMaster.Rows[0]["PaymentMode"].ToString()))
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : " + dtMaster.Rows[0]["PaymentMode"].ToString()).MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else if (dtMaster.Rows[0]["Catagory"].ToString() != "Cash Book")
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : Cash").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //else
            //    strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode      : Cash/Cheque/Credit/Other").MyPadRight(90) + "".MyPadRight(2) + ("Bill Type  : Cash").MyPadRight(43) + "", RawPrinterHelper.PrintFontType.Contract, true));
            //N_HeadLine = N_HeadLine + 1;

            strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
            strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(4) + "Particulars".MyPadRight(60) + "".MyPadLeft(1) + "AltQty".MyPadLeft(10) + "".MyPadLeft(1) + "Unit".MyPadRight(5) + "".MyPadLeft(1) + "Qty".MyPadLeft(10) + "".MyPadLeft(1) + "Unit".MyPadRight(5) + "".MyPadLeft(1) + "Rate".MyPadLeft(12) + "".MyPadLeft(1) + "Promotion".MyPadLeft(10) + "".MyPadLeft(1) + "Amount".MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
            strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

            RawPrinterHelper.SendStringToPrinter(printer, strData.ToString());

        }
        private void DelightSalesTaxInvoiceDetails()
        {
           DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
           DataTable dtMaster = dsSB.Tables[0];
           DataTable dtDetail = dsSB.Tables[1];
           DataTable dtTerm = dsSB.Tables[3];

            //DTCom = Database.FetchingData("Select StartDate, EndDate, CompanyName, Address, City, State, Country, Phone, Fax, Email,PanNo, District from " + _DbName + ".dbo.companymaster");

            decimal TotAltQty = 0, RunningTotAltQty = 0;
            decimal TotQty = 0, RunningTotQty = 0;
            decimal TotBasicAmt = 0, RunningTotBasicAmt = 0;
            decimal TotGrandAmt = 0;
            for (int c = 1; c <= _NoofCopyPrint; c++)
            {
                DelightSalesTaxInvoiceHeader(c, _PrinterName);
                StringBuilder strData = new StringBuilder();
                TotAltQty = 0;
                TotQty = 0;
                TotBasicAmt = 0;
                TotGrandAmt = 0;
                string printdt = "";
                int LCnt = 0;
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    printdt = (dtDetail.Rows[i]["SNo"].ToString() + ".").MyPadRight(4);
                    printdt = printdt + (dtDetail.Rows[i]["PDesc"].ToString()).MyPadRight(60);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);
                    if (dtDetail.Rows[i]["AltUnitCode"].ToString() != "")
                        printdt = printdt + ("").MyPadRight(1) + (dtDetail.Rows[i]["AltUnitCode"].ToString()).MyPadRight(5);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(5);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);
                    if (dtDetail.Rows[i]["UnitCode"].ToString() != "")
                        printdt = printdt + ("").MyPadRight(1) + (dtDetail.Rows[i]["UnitCode"].ToString()).MyPadRight(5);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(5);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalRate"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalRate"].ToString())).ToString("0.00")).MyPadLeft(12);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(12);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["TermAmt"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["TermAmt"].ToString())).ToString("0.00")).MyPadLeft(10);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(10);

                    if (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString())) != 0)
                        printdt = printdt + ("").MyPadRight(1) + (Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString())).ToString("0.00")).MyPadLeft(12);
                    else
                        printdt = printdt + ("").MyPadRight(1) + ("").MyPadRight(12);

                    TotAltQty = TotAltQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString()));
                    TotQty = TotQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString()));
                    TotBasicAmt = TotBasicAmt + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString()));

                    RunningTotAltQty = RunningTotAltQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["AltQty"].ToString()));
                    RunningTotQty = RunningTotQty + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["Qty"].ToString()));
                    RunningTotBasicAmt = RunningTotBasicAmt + Convert.ToDecimal(NumberToWord.Val(dtDetail.Rows[i]["LocalAmt"].ToString()));

                    strData.Append(RawPrinterHelper.GetRawPrintString(printdt + "", RawPrinterHelper.PrintFontType.Contract, true));
                    LCnt = LCnt + 1;

                    if (N_Line + 10 + dtTerm.Rows.Count == LCnt)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Running Total : ").MyPadLeft(64) + "".MyPadRight(1) + RunningTotAltQty.ToString("0.00").MyPadLeft(10) + "".MyPadLeft(7) + RunningTotQty.ToString("0.00").MyPadLeft(10) + "".MyPadRight(1) + "".MyPadRight(18) + "".MyPadRight(12) + RunningTotBasicAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        //strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));

                        RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
                        DelightSalesTaxInvoiceHeader(c, _PrinterName);
                        strData.Clear();
                        LCnt = 0;
                        RunningTotAltQty = 0;
                        RunningTotQty = 0;
                        RunningTotBasicAmt = 0;
                    }
                }

                if (LCnt < (N_Line + (12 - N_HeadLine) - dtTerm.Rows.Count))
                {
                    for (int b = LCnt; b <= N_Line + (12 - N_HeadLine) - dtTerm.Rows.Count; b++)
                    {
                        strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                    }
                }
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Printing Date & Time : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()).MyPadRight(64) + "".MyPadRight(1) + TotAltQty.ToString("0.00").MyPadLeft(10) + "".MyPadLeft(7) + TotQty.ToString("0.00").MyPadLeft(10) + "".MyPadRight(1) + "Basic Amount : ".MyPadRight(18) + "".MyPadRight(12) + TotBasicAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                TotGrandAmt = TotGrandAmt + TotBasicAmt;
                //if (dtTerm.Rows.Count > 0)
                //{
                //    foreach (DataRow DTRo in dtTerm.Rows)
                //    {
                //        if (_sysVatterm == DTRo["PTCode"].ToString())
                //            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + "Taxable Value : ".MyPadRight(18) + "".MyPadRight(12) + TotGrandAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                //        if (Convert.ToDecimal(NumberToWord.Val(DTRo["LocalRate"].ToString())) != 0)
                //            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + DTRo["PTDesc"].ToString().MyPadRight(18) + "".MyPadRight(2) + (Convert.ToDecimal(NumberToWord.Val(DTRo["LocalRate"].ToString())).ToString("0.00") + "%").MyPadRight(6) + "".MyPadRight(4) + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                //        else
                //            strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + DTRo["PTDesc"].ToString().MyPadRight(18) + "".MyPadRight(2) + "".MyPadRight(6) + "".MyPadRight(4) + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString())).ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                //        if (DTRo["Sign"].ToString() == "-")
                //            TotGrandAmt = TotGrandAmt - Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString()));
                //        else
                //            TotGrandAmt = TotGrandAmt + Convert.ToDecimal(NumberToWord.Val(DTRo["LocalAmt"].ToString()));
                //    }
                //}

                strData.Append(RawPrinterHelper.GetRawPrintString((" ").MyPadRight(65) + "".MyPadRight(1) + "".MyPadRight(10) + "".MyPadRight(6) + "".MyPadRight(10) + "".MyPadRight(1) + "Net Amount :".MyPadRight(18) + "".MyPadRight(12) + TotGrandAmt.ToString("0.00").MyPadLeft(12) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(135, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("In Words : " + NumberToWord.ToWords(TotGrandAmt)).MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(("Remarks : " + dtMaster.Rows[0]["Remarks"].ToString()).MyPadRight(135) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(135, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadLeft(135, ' ') + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString(" ".MyPadRight(25) + "".MyPadRight(20) + _PrintedBy.MyPadRight(20) + "".MyPadRight(10) + " ".MyPadRight(60) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(25, '-') + "".MyPadRight(15) + "-".MyPadLeft(25, '-') + "".MyPadRight(10) + "-".MyPadLeft(60, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                //strData.Append(RawPrinterHelper.GetRawPrintString("     Received By ".MyPadRight(25) + "".MyPadRight(15) + "     Prepared By ".MyPadRight(25) + "".MyPadRight(10) + ("For " + DTCom.Rows[0]["CompanyName"]).MyPadRight(60) + "", RawPrinterHelper.PrintFontType.Contract, true));
                strData.Append("\n\n\n\n");
                RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());
            }
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("UPDATE " + _DbName + ".dbo.SalesInvoiceMAster set PrintCopy=Isnull(PrintCopy,0)+1,PrintedBy='" + _PrintedBy + "' , PrintedDate='" + _printedDate.ToString("MM/dd/yyyy HH:mm:ss") + "'where VNo='" + BillNo + "' \n");
            //Database.ExecuteQuery(strSql.ToString());

        }
        private void DefaultCounterSalesTicket3InchDetails()
        {
           DataSet dsSB = _objDocPrintSetting.SalesInvoiceDataSet(_VoucherNo);
           DataTable dtMaster = dsSB.Tables[0];
           DataTable dtDetail = dsSB.Tables[1];
           DataTable dtBTerm = dsSB.Tables[2];
           DataTable dtPTerm = dsSB.Tables[3];
           DataTable dtTaxTermValue = dsSB.Tables[4];
           DataTable dtNonTaxTermValue = dsSB.Tables[5];
            //DataTable DTCom = Database.FetchingData("Select StartDate, EndDate, CompanyName, Address, City, State, Country, Phone, Fax, Email,PanNo, District from " + _DbName + ".dbo.companymaster");
            //DataRow roCom = DTCom.Rows[0];

            int Sno = 0;
            decimal BasicAmt = 0;
            decimal TotBas = 0;
            decimal TotGrand = 0;
            decimal NonTaxableValue = 0;
            decimal TaxableValue = 0;
            decimal roundoff = 0;

            
            for (int P = 0; P < dtDetail.Rows.Count; P++)//Product/Service wise loop
            {
                for (int Q = 0; Q < Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString()); Q++)//Quantity(No of person) wise loop
                {
                    BasicAmt = 0;
                    TotBas = 0;
                    TotGrand = 0;
                    NonTaxableValue = 0;
                    TaxableValue = 0;
                    StringBuilder strData = new StringBuilder();

                    if (Q != 0)
                    {
                        strData.Append("\n");
                    }
                    else if (Q == 0 && P > 0)
                    {
                        strData.Append("\n");
                    }

                    foreach (DataRow roMaster in dtMaster.Rows)
                    {
                        //Print Header Part from roMaster
                        TotGrand = 0;
                        BasicAmt = 0;
                        string city = "";
                        //if (roCom["City"].ToString() != "")
                        //    city = roCom["City"].ToString() + ',' + roCom["Phone"].ToString();
                        //else
                        //    city = roCom["Phone"].ToString();
                        //string pan = "PAN NO : " + roCom["PanNo"].ToString();
                        //strData.Append(RawPrinterHelper.GetRawPrintString(roCom["CompanyName"].ToString().MyPadLeft(roCom["CompanyName"].ToString().Length + Convert.ToInt32((40 - roCom["CompanyName"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                        //strData.Append(RawPrinterHelper.GetRawPrintString(roCom["Address"].ToString().MyPadLeft(roCom["Address"].ToString().Length + Convert.ToInt32((40 - roCom["Address"].ToString().Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                        //if (city.Trim() != "")
                        //    strData.Append(RawPrinterHelper.GetRawPrintString(city.MyPadLeft(city.Length + Convert.ToInt32((40 - city.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                        //strData.Append(RawPrinterHelper.GetRawPrintString(pan.MyPadLeft(pan.Length + Convert.ToInt32((40 - pan.Length) / 2)), RawPrinterHelper.PrintFontType.Contract, true));
                        //strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        //strData.Append(RawPrinterHelper.GetRawPrintString("".MyPadRight(13) + "TAX INVOICE", RawPrinterHelper.PrintFontType.Contract, true));

                        ////Add//
                        //if (DateType == "D")
                        //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Date: " + Convert.ToDateTime(roMaster["VDate"]).ToShortDateString() + "", RawPrinterHelper.PrintFontType.Contract, true));
                        //else
                        //    strData.Append(RawPrinterHelper.GetRawPrintString(("Bill No : " + roMaster["VNo"].ToString()).MyPadRight(24) + "Miti: " + roMaster["VMiti"].ToString() + "", RawPrinterHelper.PrintFontType.Contract, true));

                        if (!string.IsNullOrEmpty(roMaster["PartyName"].ToString()))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name: " + roMaster["PartyName"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        else if (roMaster["Catagory"].ToString() != "Cash Book")
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name: " + roMaster["GLDesc"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        else
                        {
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Customer Name: Cash"), RawPrinterHelper.PrintFontType.Contract, true));
                        }
                        if (!string.IsNullOrEmpty(roMaster["VatNo"].ToString()))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Vat/Pan No: " + roMaster["VatNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        else if (!string.IsNullOrEmpty(roMaster["PanNo"].ToString()))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Vat/Pan No: " + roMaster["PanNo"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        else
                        {
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Vat/Pan No: "), RawPrinterHelper.PrintFontType.Contract, true));
                        }
                        if (!string.IsNullOrEmpty(roMaster["PartyAddress"].ToString()))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["PartyAddress"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        else if (!string.IsNullOrEmpty(roMaster["AddressI"].ToString()))
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Address: " + roMaster["AddressI"].ToString()) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        else
                        {
                            strData.Append(RawPrinterHelper.GetRawPrintString(("Address"), RawPrinterHelper.PrintFontType.Contract, true));
                        }

                        strData.Append(RawPrinterHelper.GetRawPrintString(("Payment Mode: " + roMaster["PaymentMode"].ToString() + ""), RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        strData.Append(RawPrinterHelper.GetRawPrintString("SN.".MyPadRight(3) + "Particulars".MyPadRight(18) + "Qty".MyPadLeft(3) + "Rate".MyPadLeft(8) + "Amount".MyPadLeft(8) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        System.Data.DataRow[] resultdet;
                        resultdet = dtDetail.Select("PCode ='" + dtDetail.Rows[P]["PCode"].ToString() + "' ", "SNo");
                        foreach (DataRow itemdet in resultdet)
                        {
                            Sno = Sno + 1;
                            if (Convert.ToDecimal(itemdet["BasicAmt"].ToString()) > 0)
                            {
                                TotBas = TotBas + Convert.ToDecimal(itemdet["BasicAmt"].ToString()) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString());

                                if (Convert.ToDecimal(itemdet["Vat"].ToString()) == 13)
                                {
                                    TaxableValue = TaxableValue + Convert.ToDecimal(itemdet["BasicAmt"].ToString()) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString());
                                }
                                else
                                {
                                    NonTaxableValue = NonTaxableValue + Convert.ToDecimal(itemdet["BasicAmt"].ToString()) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString());
                                }
                                BasicAmt = Convert.ToDecimal(itemdet["BasicAmt"].ToString()) / Convert.ToDecimal(itemdet["Qty"].ToString());
                            }


                            string PDesc = itemdet["PDesc"].ToString();
                            string PDesc1 = "";
                            if (PDesc.Length >= 18)
                            {
                                PDesc1 = PDesc.Substring(0, 18);
                            }
                            else
                            {
                                PDesc1 = PDesc;
                            }

                            string PDesc2 = "";
                            if ((PDesc.Length) - 18 >= 18)
                            {
                                PDesc2 = PDesc.Substring(18, 18);
                            }
                            else
                            {
                                PDesc2 = PDesc.Remove(0, PDesc1.Length);
                            }

                            string PDesc3 = "";
                            if ((PDesc.Length) - 36 >= 18)
                            {
                                PDesc3 = PDesc.Substring(36, 18);
                            }
                            else
                            {
                                PDesc3 = PDesc.Remove(0, (PDesc1.Length + PDesc2.Length));
                            }

                            string PDesc4 = "";
                            if ((PDesc.Length) - 54 >= 18)
                            {
                                PDesc4 = PDesc.Substring(54, 18);
                            }
                            else
                            {
                                PDesc4 = PDesc.Remove(0, (PDesc1.Length + PDesc2.Length + PDesc3.Length));
                            }

                            strData.Append(RawPrinterHelper.GetRawPrintString(("1".ToString() + ".").MyPadRight(3) + PDesc1.MyPadRight(18) + "1".MyPadLeft(3) + Convert.ToDecimal(BasicAmt).ToString("0.00").MyPadLeft(8) + Convert.ToDecimal(Convert.ToDecimal(itemdet["BasicAmt"].ToString()) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString())).ToString("0.00").MyPadLeft(8) + "", RawPrinterHelper.PrintFontType.Contract, true));
                            if (!string.IsNullOrEmpty(PDesc2))
                                strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc2, RawPrinterHelper.PrintFontType.Contract, true));
                            if (!string.IsNullOrEmpty(PDesc3))
                                strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc3, RawPrinterHelper.PrintFontType.Contract, true));
                            if (!string.IsNullOrEmpty(PDesc4))
                                strData.Append(RawPrinterHelper.GetRawPrintString(("").MyPadRight(3) + PDesc4, RawPrinterHelper.PrintFontType.Contract, true));
                        }

                        //Print Total
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("Gross Amount :".MyPadLeft(20) + " ".MyPadLeft(10) + TotBas.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        TotGrand = TotBas;
                        if (dtPTerm.Rows.Count > 0)
                        {
                            System.Data.DataRow[] resultPTerm;
                            resultPTerm = dtPTerm.Select("PCode ='" + dtDetail.Rows[P]["PCode"].ToString() + "' ", "PTCode");
                            if (resultPTerm.Length > 0)
                            {
                                foreach (DataRow itemtrm in resultPTerm)
                                {
                                    if (itemtrm["Vat"].ToString() == itemtrm["PTCode"].ToString())
                                    {
                                        if (dtTaxTermValue.Rows.Count > 0)
                                        {
                                            TaxableValue = TaxableValue + @Convert.ToDecimal(NumberToWord.Val(dtTaxTermValue.Rows[0]["LocalAmt"].ToString())) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString());
                                        }
                                        if (dtNonTaxTermValue.Rows.Count > 0)
                                        {
                                            NonTaxableValue = NonTaxableValue + @Convert.ToDecimal(NumberToWord.Val(dtNonTaxTermValue.Rows[0]["LocalAmt"].ToString())) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString());
                                        }
                                        if (NonTaxableValue > 0)
                                        {
                                            strData.Append(RawPrinterHelper.GetRawPrintString("Non Taxable :".MyPadLeft(20) + " ".MyPadLeft(10) + NonTaxableValue.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                                        }
                                        strData.Append(RawPrinterHelper.GetRawPrintString("Taxable :".MyPadLeft(20) + " ".MyPadLeft(10) + TaxableValue.ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                                    }
                                    if (Convert.ToDecimal(itemtrm["LocalRate"].ToString()) != 0)
                                        strData.Append(RawPrinterHelper.GetRawPrintString(itemtrm["PtDesc"].ToString().MyPadLeft(18) + " : ".MyPadLeft(3) + Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalRate"].ToString())).ToString("0.00").MyPadLeft(5) + " %".MyPadLeft(2) + " ".MyPadLeft(2) + (Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString())) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString())).ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));
                                    else
                                        strData.Append(RawPrinterHelper.GetRawPrintString(itemtrm["PtDesc"].ToString().MyPadLeft(18) + " : ".MyPadLeft(3) + " ".MyPadLeft(9) + (Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString())) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString())).ToString("0.00").MyPadLeft(10), RawPrinterHelper.PrintFontType.Contract, true));

                                    if (itemtrm["Sign"].ToString() == "+")
                                    {
                                        TotGrand = TotGrand + Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString())) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString());
                                    }
                                    else
                                    {
                                        TotGrand = TotGrand - Convert.ToDecimal(NumberToWord.Val(itemtrm["LocalAmt"].ToString())) / Convert.ToDecimal(dtDetail.Rows[P]["Qty"].ToString());
                                    }
                                }
                            }
                        }

                        strData.Append(RawPrinterHelper.GetRawPrintString("Net Amount :".MyPadLeft(20) + " ".MyPadLeft(10) + TotGrand.ToString("0.00").MyPadLeft(10) + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        string rupees = NumberToWord.ToWords(TotGrand);
                        string rupees1 = "";
                        if (rupees.Length >= 28)
                        {
                            rupees1 = rupees.Substring(0, 28);
                        }
                        else
                        {
                            rupees1 = rupees;
                        }

                        string rupees2 = "";
                        if ((rupees.Length) - 28 >= 38)
                        {
                            rupees2 = rupees.Substring(28, 38);
                        }
                        else
                        {
                            rupees2 = rupees.Remove(0, rupees1.Length);
                        }

                        string rupees3 = "";
                        if ((rupees.Length) - 66 >= 38)
                        {
                            rupees3 = rupees.Substring(66, 38);
                        }
                        else
                        {
                            rupees3 = rupees.Remove(0, (rupees1.Length + rupees2.Length));
                        }

                        string rupees4 = "";
                        if ((rupees.Length) - 104 >= 38)
                        {
                            rupees4 = rupees.Substring(104, 38);
                        }
                        else
                        {
                            rupees4 = rupees.Remove(0, (rupees1.Length + rupees2.Length + rupees3.Length));
                        }

                        strData.Append(RawPrinterHelper.GetRawPrintString("In word : " + rupees1, RawPrinterHelper.PrintFontType.Contract, true));
                        if (!string.IsNullOrEmpty(rupees2))
                            strData.Append(RawPrinterHelper.GetRawPrintString(rupees2, RawPrinterHelper.PrintFontType.Contract, true));
                        if (!string.IsNullOrEmpty(rupees3))
                            strData.Append(RawPrinterHelper.GetRawPrintString(rupees3, RawPrinterHelper.PrintFontType.Contract, true));
                        if (!string.IsNullOrEmpty(rupees4))
                            strData.Append(RawPrinterHelper.GetRawPrintString(rupees4, RawPrinterHelper.PrintFontType.Contract, true));

                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));

                        strData.Append(RawPrinterHelper.GetRawPrintString(("Counter : " + roMaster["ClassCode1"].ToString()).MyPadRight(20) + ("Bill Time : " + Convert.ToDateTime(roMaster["VoTime"].ToString()).ToShortTimeString().ToString()), RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString(("Cashier : " + roMaster["UserCode"].ToString()).MyPadRight(20) + ("Print Time: " + DateTime.Now.ToShortTimeString()), RawPrinterHelper.PrintFontType.Contract, true));

                        strData.Append(RawPrinterHelper.GetRawPrintString("-".MyPadLeft(40, '-') + "", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append(RawPrinterHelper.GetRawPrintString("".PadLeft(6) + "****THANK YOU FOR VISIT****", RawPrinterHelper.PrintFontType.Contract, true));
                        strData.Append("\n\n\n\n\n\n\n");
                    }
                    RawPrinterHelper.SendStringToPrinter(_PrinterName, strData.ToString());

                }
            }

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("UPDATE " + _DbName + ".dbo.SalesInvoiceMAster set PrintCopy=Isnull(PrintCopy,0)+1,PrintedBy='" + _printedBy + "' , PrintedDate='" + _printedDate.ToString("MM/dd/yyyy HH:mm:ss") + "'where VNo='" + BillNo + "' \n");
            //Database.ExecuteQuery(strSql.ToString());
        }

    }
}
