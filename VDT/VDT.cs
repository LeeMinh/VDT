using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VDT.AirlineInvoice;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace VDT
{
    public partial class VDT : Form
    {
        public VDT()
        {
            InitializeComponent();
        }
        public int AgentIDQH = 0;  

        private void button1_Click(object sender, EventArgs e)
        {
            AgentIDQH = new userprofile().AgentID;
            Thread thread = new Thread(() => addTicketQH(loadFile(txtLinkFile.Text)));
            thread.Start();
        }

        public void addticket(string[] listTicketNo, string si, string pass, string pcc)
        {
            foreach (var item in listTicketNo)
            {
                InvoiceDetail invoice = new InvoiceDetail();
                invoice = invoice.GetByTicketNo(item);
                if (invoice.InvoiceDetailID > 0)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        txtOk.Text += item + " - đã có trong dữ liệu; ";
                    });
                    //txtOk.Text += item + "-đã có trong DB | ";
                    continue;
                }
                else
                {
                    VNAWS soap = new VNAWS();
                    soap.AuthenticationValue = new Authentication() { Username = "invoice", Password = "idb@@" };
                    var res = soap.OpenFullTicketNumber(item, si, pass, pcc);
                    if (res.VCRDisplay == null || res.VCRDisplay.Length <= 0)
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            txtFail.Text += item + " - Không load được số vé;";
                        });
                        //txtFail.Text += item + "-Không load được số vé | ";
                        continue;
                    }
                    else
                    {
                        invoice.TicketNo = res.TicketNo;
                        invoice.TicketType = res.TicketType;
                        invoice.TripCode = res.TripCode;
                        invoice.TicketFare = res.TicketFare;
                        invoice.TicketVAT = res.TicketVAT;
                        invoice.TicketTax = res.TicketTax;
                        invoice.TicketTaxGlobal = res.TicketTaxGlobal;
                        invoice.RealPay = res.RealPay;
                        invoice.TicketPrice = res.TicketPrice;
                        invoice.VCRDisplay = res.VCRDisplay;
                        invoice.UpdateSystem = res.UpdateSystem;
                        invoice.Airline = res.Airline;
                        invoice.InvoiceID = 0;
                        invoice.PNRCode = res.PNRCode != null ? res.PNRCode : "0";
                        invoice.PaxName = res.PaxName;
                        invoice.AgentID = AgentIDQH;
                        invoice.AgentBranchID = 0;
                        invoice.UpdateTime = DateTime.Now;
                        invoice.OtherFees = res.OtherFees;
                        invoice.ReturnFees = res.ReturnFees;
                        invoice.ChangeTicket = res.ChangeTicket != null ? res.ChangeTicket : "0";
                        invoice.ChangeLevelFee = res.ChangeLevelFee;
                        invoice.ChangeLevelFeeVAT = res.ChangeLevelFeeVAT;
                        invoice.Note = res.Note != null ? res.Note : "0";
                        invoice.AgentFee = res.AgentFee;
                        invoice.AgentFeeVAT = res.AgentFeeVAT;
                        invoice.SoldDate = res.SoldDate;
                        int id = 0;
                        try
                        {
                            id = invoice.Insert();
                            if (id > 0)
                            {
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    txtOk.Text += item + "-Thêm thành công | ";
                                });
                                //txtOk.Text += item + "-Thêm thành công | ";
                            }
                            else
                            {
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    txtFail.Text += item + "-Thêm thất bại | ";
                                });
                                //txtFail.Text += item + "-Thêm thất bại | ";
                            }
                        }
                        catch (Exception)
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                txtFail.Text += item + "-Thêm thất bại | ";
                            });
                            //txtFail.Text += item + "-Thêm thất bại | ";
                            continue;
                        }

                    }
                }
            }
        }

        public void addTicketQH(List<InvoiceDetail> listTicketNo)
        {
            foreach (var item in listTicketNo)
            {
                InvoiceDetail invoice = new InvoiceDetail();
                invoice = invoice.GetByTicketNo(item.TicketNo);
                if (invoice.InvoiceDetailID > 0)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        txtOk.Text += item + " - đã có trong dữ liệu; ";
                    });
                    //txtOk.Text += item + "-đã có trong DB | ";
                    continue;
                }
                else
            {   
                    invoice.TicketNo = item.TicketNo;
                    invoice.TicketType = item.TicketType;
                    invoice.TripCode = item.TripCode;
                    invoice.TicketFare = item.TicketFare;
                    invoice.TicketVAT = item.TicketVAT;
                    invoice.TicketTax = item.TicketTax;
                    invoice.TicketTaxGlobal = item.TicketTaxGlobal;
                    invoice.RealPay = item.RealPay;
                    invoice.TicketPrice = item.TicketPrice;
                    invoice.VCRDisplay = item.VCRDisplay;
                    invoice.UpdateSystem = item.UpdateSystem;
                    invoice.Airline = item.Airline;
                    invoice.InvoiceID = 0;
                    invoice.PNRCode = item.PNRCode != null ? item.PNRCode : "0";
                    invoice.PaxName = item.PaxName;
                    invoice.AgentID = item.AgentID;
                    invoice.AgentBranchID = 0;
                    invoice.UpdateTime = DateTime.Now;
                    invoice.OtherFees = item.OtherFees;
                    invoice.ReturnFees = item.ReturnFees;
                    invoice.ChangeTicket = item.ChangeTicket != null ? item.ChangeTicket : "0";
                    invoice.ChangeLevelFee = item.ChangeLevelFee;
                    invoice.ChangeLevelFeeVAT = item.ChangeLevelFeeVAT;
                    invoice.Note = item.Note != null ? item.Note : "0";
                    invoice.AgentFee = item.AgentFee;
                    invoice.AgentFeeVAT = item.AgentFeeVAT;
                    invoice.SoldDate = item.SoldDate;
                    int id = 0;
                    try
                    {
                        id = invoice.Insert();
                        if (id > 0)
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                txtOk.Text += item.PNRCode + "-Thêm thành công | ";
                            });
                            //txtOk.Text += item + "-Thêm thành công | ";
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                txtFail.Text += item.PNRCode + "-Thêm thất bại | ";
                            });
                            //txtFail.Text += item + "-Thêm thất bại | ";
                        }
                    }
                    catch (Exception)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            txtFail.Text += item.PNRCode + "-Thêm thất bại | ";
                        });
                        //txtFail.Text += item + "-Thêm thất bại | ";
                        continue;
                    } 
                }
            }
        }

        System.IO.Stream myStream = null;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
       

        public List<InvoiceDetail> loadFile(string FileName = "")
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            int rCnt;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            var  ListItemInvoice = new List<InvoiceDetail>();
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                if ((range.Cells[rCnt, 5] as Excel.Range).Text.ToString().Replace(",", "") !="")
                {    
                    var TicketItem = new InvoiceDetail();

                    TicketItem.TicketNo = (range.Cells[rCnt, 5] as Excel.Range).Text.ToString().Replace(",", "");
                    TicketItem.TicketType = 1;
                    TicketItem.TripCode = "";   
                    if((range.Cells[rCnt, 16] as Excel.Range).Text != "" || (range.Cells[rCnt, 16] as Excel.Range).Text !=null)
                    {
                        TicketItem.TripCode = (range.Cells[rCnt, 16] as Excel.Range).Text;
                        //string checktexttripcode = (range.Cells[rCnt, 16] as Excel.Range).Text;
                        //if (checktexttripcode.Contains(';') == true)
                        //{
                        //    var tripcode = checktexttripcode.Split(';');
                        //    for(int x=0; x <tripcode.Length; x++)
                        //    {
                        //        var tripround = tripcode[x].Trim().Split(' ');
                        //        TicketItem.TripCode += tripround[3];
                        //    }
                        //}
                        //else
                        //{
                        //    var tripround = checktexttripcode.Split(' ');
                        //    TicketItem.TripCode += tripround[3];
                        //}
                    }
                    TicketItem.TicketFare = int.Parse(Convert.ToString((range.Cells[rCnt, 8] as Excel.Range).Text).Replace(",", ""));
                    TicketItem.TicketVAT = int.Parse(Convert.ToString((range.Cells[rCnt, 10] as Excel.Range).Text).Replace(",", ""));
                    TicketItem.TicketTax = int.Parse(Convert.ToString((range.Cells[rCnt, 11] as Excel.Range).Text).Replace(",", ""));
                    // TicketItem.TicketTaxGlobal = res.TicketTaxGlobal;
                    //TicketItem.RealPay = res.RealPay;

                    TicketItem.TicketPrice = int.Parse(((range.Cells[rCnt, 12] as Excel.Range).Text).Replace(",", ""));
                    TicketItem.VCRDisplay = "";
                    TicketItem.UpdateSystem = true;
                    TicketItem.Airline = (string)(range.Cells[rCnt, 17] as Excel.Range).Text;
                    TicketItem.InvoiceID = 0;
                    TicketItem.PNRCode = (string)(range.Cells[rCnt, 4] as Excel.Range).Text;
                    TicketItem.PaxName = (string)(range.Cells[rCnt, 6] as Excel.Range).Text;
                    TicketItem.AgentID = AgentIDQH;
                    TicketItem.AgentBranchID = 0;
                    TicketItem.UpdateTime = DateTime.Now;
                    if (Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Text) == null || Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Text) == "")
                    {
                        TicketItem.OtherFees = 0;
                    }
                    else
                    {
                        TicketItem.OtherFees = int.Parse(Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Text).Replace(",", ""));
                        //TicketItem.OtherFees = Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Text) ==null ? 0 : int.Parse(Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Text).Replace(",", ""));
                    }
                    //TicketItem.ReturnFees = res.ReturnFees;
                    //TicketItem.ChangeTicket = res.ChangeTicket != null ? res.ChangeTicket : "0";
                    //TicketItem.ChangeLevelFee = res.ChangeLevelFee;
                    //TicketItem.ChangeLevelFeeVAT = res.ChangeLevelFeeVAT;
                    //TicketItem.Note = res.Note != null ? res.Note : "0";
                    //TicketItem.AgentFee = res.AgentFee;
                    //TicketItem.AgentFeeVAT = res.AgentFeeVAT;
                    TicketItem.SoldDate = Convert.ToDateTime((string)(range.Cells[rCnt, 2] as Excel.Range).Text);
                    ListItemInvoice.Insert(ListItemInvoice.Count, TicketItem);
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            //Marshal.ReleaseComObject(xlWorkSheet);
            //Marshal.ReleaseComObject(xlWorkBook);
            //Marshal.ReleaseComObject(xlApp);

            return ListItemInvoice;
        }

        private void SelectFile_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\../Desktop";
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            txtLinkFile.Text = openFileDialog1.FileName;
                            //loadFile(openFileDialog1.FileName);                              
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi phát sinh trong quá trình đọc file. Vui lòng thử lại: " + ex.Message);
                }
            }
        }
    }
}
