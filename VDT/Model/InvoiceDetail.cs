using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VDT;
namespace VDT
{
    public class InvoiceDetail
    {
        
        private DBAccess db;
        //--------------------------------------------------------------------------
        public InvoiceDetail()
        {
            db = new DBAccess();
        }
        //--------------------------------------------------------------------------
        ~InvoiceDetail()
        {

        }
        //--------------------------------------------------------------------------
        public virtual void Dispose()
        {

        }
        //--------------------------------------------------------------------------
        public int InvoiceDetailID { get; set; }
        public string TicketNo { get; set; }
        public int TicketType { get; set; }
        public string TripCode { get; set; }
        public int TicketFare { get; set; }
        public int TicketVAT { get; set; }
        public int TicketTax { get; set; }
        public int TicketTaxGlobal { get; set; }
        public int RealPay { get; set; }
        public int TicketPrice { get; set; }
        public string VCRDisplay { get; set; }
        public bool? UpdateSystem { get; set; }
        public string Airline { get; set; }
        public int InvoiceID { get; set; }
        public string PNRCode { get; set; }
        public string PaxName { get; set; }
        public int AgentID { get; set; }
        public int AgentBranchID { get; set; }
        public DateTime UpdateTime { get; set; }
        public int OtherFees { get; set; }
        public int ReturnFees { get; set; }
        public string ChangeTicket { get; set; }
        public int ChangeLevelFee { get; set; }
        public int ChangeLevelFeeVAT { get; set; }
        public string Note { get; set; }
        public int AgentFee { get; set; }
        public int AgentFeeVAT { get; set; }
        public DateTime SoldDate { get; set; }
        //--------------------------------------------------------------------------
        public List<InvoiceDetail> init(SqlCommand cmd)
        {
            SqlConnection con = db.getConnection();
            cmd.Connection = con;
            List<InvoiceDetail> l_InvoiceDetail = new List<InvoiceDetail>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                SmartDataReader smartReader = new SmartDataReader(reader);
                while (smartReader.Read())
                {
                    InvoiceDetail m_InvoiceDetail = new InvoiceDetail();
                    m_InvoiceDetail.InvoiceDetailID = smartReader.GetInt32("InvoiceDetailID");
                    m_InvoiceDetail.TicketNo = smartReader.GetString("TicketNo");
                    m_InvoiceDetail.TicketType = smartReader.GetInt32("TicketType");
                    m_InvoiceDetail.TripCode = smartReader.GetString("TripCode");
                    m_InvoiceDetail.TicketFare = smartReader.GetInt32("TicketFare");
                    m_InvoiceDetail.TicketVAT = smartReader.GetInt32("TicketVAT");
                    m_InvoiceDetail.TicketTax = smartReader.GetInt32("TicketTax");
                    m_InvoiceDetail.TicketTaxGlobal = smartReader.GetInt32("TicketTaxGlobal");
                    m_InvoiceDetail.RealPay = smartReader.GetInt32("RealPay");
                    m_InvoiceDetail.TicketPrice = smartReader.GetInt32("TicketPrice");
                    m_InvoiceDetail.VCRDisplay = smartReader.GetString("VCRDisplay");
                    m_InvoiceDetail.UpdateSystem = smartReader.GetBoolean("UpdateSystem");
                    m_InvoiceDetail.Airline = smartReader.GetString("Airline");
                    m_InvoiceDetail.InvoiceID = smartReader.GetInt32("InvoiceID");
                    m_InvoiceDetail.PNRCode = smartReader.GetString("PNRCode");
                    m_InvoiceDetail.PaxName = smartReader.GetString("PaxName");
                    m_InvoiceDetail.AgentID = smartReader.GetInt32("AgentID");
                    m_InvoiceDetail.AgentBranchID = smartReader.GetInt32("AgentBranchID");
                    m_InvoiceDetail.UpdateTime = smartReader.GetDateTime("UpdateTime");
                    m_InvoiceDetail.OtherFees = smartReader.GetInt32("OtherFees");
                    m_InvoiceDetail.ReturnFees = smartReader.GetInt32("ReturnFees");
                    m_InvoiceDetail.ChangeTicket = smartReader.GetString("ChangeTicket");
                    m_InvoiceDetail.ChangeLevelFee = smartReader.GetInt32("ChangeLevelFee");
                    m_InvoiceDetail.ChangeLevelFeeVAT = smartReader.GetInt32("ChangeLevelFeeVAT");
                    m_InvoiceDetail.Note = smartReader.GetString("Note");
                    m_InvoiceDetail.AgentFee = smartReader.GetInt32("AgentFee");
                    m_InvoiceDetail.AgentFeeVAT = smartReader.GetInt32("AgentFeeVAT");
                    m_InvoiceDetail.SoldDate = smartReader.GetDateTime("SoldDate");
                    l_InvoiceDetail.Add(m_InvoiceDetail);
                }
                smartReader.disposeReader(reader);
                return l_InvoiceDetail;
            }
            catch (SqlException err)
            {
                throw err;
            }
            finally
            {
                db.closeConnection(con);
            }
        }
        //--------------------------------------------------------------------------
        public int Insert()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InvoiceDetailInsert");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TicketNo",this.TicketNo));
                cmd.Parameters.Add(new SqlParameter("@TicketType",this.TicketType));
                cmd.Parameters.Add(new SqlParameter("@TripCode",this.TripCode));
                cmd.Parameters.Add(new SqlParameter("@TicketFare",this.TicketFare));
                cmd.Parameters.Add(new SqlParameter("@TicketVAT",this.TicketVAT));
                cmd.Parameters.Add(new SqlParameter("@TicketTax",this.TicketTax));
                cmd.Parameters.Add(new SqlParameter("@TicketTaxGlobal",this.TicketTaxGlobal));
                cmd.Parameters.Add(new SqlParameter("@RealPay",this.RealPay));
                cmd.Parameters.Add(new SqlParameter("@TicketPrice",this.TicketPrice));
                cmd.Parameters.Add(new SqlParameter("@VCRDisplay",this.VCRDisplay));
                cmd.Parameters.Add(new SqlParameter("@UpdateSystem",this.UpdateSystem));
                cmd.Parameters.Add(new SqlParameter("@Airline",this.Airline));
                cmd.Parameters.Add(new SqlParameter("@InvoiceID", this.InvoiceID));
                cmd.Parameters.Add(new SqlParameter("@PNRCode",this.PNRCode));
                cmd.Parameters.Add(new SqlParameter("@PaxName",this.PaxName));
                cmd.Parameters.Add(new SqlParameter("@AgentID",this.AgentID));
                cmd.Parameters.Add(new SqlParameter("@AgentBranchID",this.AgentBranchID));
                cmd.Parameters.Add(new SqlParameter("@UpdateTime",this.UpdateTime));
                cmd.Parameters.Add(new SqlParameter("@OtherFees",this.OtherFees));
                cmd.Parameters.Add(new SqlParameter("@ReturnFees",this.ReturnFees));
                cmd.Parameters.Add(new SqlParameter("@ChangeTicket",this.ChangeTicket));
                cmd.Parameters.Add(new SqlParameter("@ChangeLevelFee",this.ChangeLevelFee));
                cmd.Parameters.Add(new SqlParameter("@ChangeLevelFeeVAT",this.ChangeLevelFeeVAT));
                cmd.Parameters.Add(new SqlParameter("@Note",this.Note));
                cmd.Parameters.Add(new SqlParameter("@AgentFee",this.AgentFee));
                cmd.Parameters.Add(new SqlParameter("@AgentFeeVAT",this.AgentFeeVAT));
                cmd.Parameters.Add(new SqlParameter("@SoldDate",this.SoldDate));
                cmd.Parameters.Add("@InvoiceDetailID", SqlDbType.Int).Direction = ParameterDirection.Output;
                db.ExecuteSQL(cmd);
                this.InvoiceDetailID = (cmd.Parameters["@InvoiceDetailID"].Value == null) ? 0 : Convert.ToInt32(cmd.Parameters["@InvoiceDetailID"].Value);
                return this.InvoiceDetailID;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        //--------------------------------------------------------------------------
        public void Update()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InvoiceDetailUpdate");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InvoiceDetailID",this.InvoiceDetailID));
                cmd.Parameters.Add(new SqlParameter("@TicketNo",this.TicketNo));
                cmd.Parameters.Add(new SqlParameter("@TicketType",this.TicketType));
                cmd.Parameters.Add(new SqlParameter("@TripCode",this.TripCode));
                cmd.Parameters.Add(new SqlParameter("@TicketFare",this.TicketFare));
                cmd.Parameters.Add(new SqlParameter("@TicketVAT",this.TicketVAT));
                cmd.Parameters.Add(new SqlParameter("@TicketTax",this.TicketTax));
                cmd.Parameters.Add(new SqlParameter("@TicketTaxGlobal",this.TicketTaxGlobal));
                cmd.Parameters.Add(new SqlParameter("@RealPay",this.RealPay));
                cmd.Parameters.Add(new SqlParameter("@TicketPrice",this.TicketPrice));
                cmd.Parameters.Add(new SqlParameter("@VCRDisplay",this.VCRDisplay));
                cmd.Parameters.Add(new SqlParameter("@UpdateSystem",this.UpdateSystem));
                cmd.Parameters.Add(new SqlParameter("@Airline",this.Airline));
                cmd.Parameters.Add(new SqlParameter("@InvoiceID", this.InvoiceID));
                cmd.Parameters.Add(new SqlParameter("@PNRCode",this.PNRCode));
                cmd.Parameters.Add(new SqlParameter("@PaxName",this.PaxName));
                cmd.Parameters.Add(new SqlParameter("@AgentID",this.AgentID));
                cmd.Parameters.Add(new SqlParameter("@AgentBranchID",this.AgentBranchID));
                cmd.Parameters.Add(new SqlParameter("@UpdateTime",this.UpdateTime));
                cmd.Parameters.Add(new SqlParameter("@OtherFees",this.OtherFees));
                cmd.Parameters.Add(new SqlParameter("@ReturnFees",this.ReturnFees));
                cmd.Parameters.Add(new SqlParameter("@ChangeTicket",this.ChangeTicket));
                cmd.Parameters.Add(new SqlParameter("@ChangeLevelFee",this.ChangeLevelFee));
                cmd.Parameters.Add(new SqlParameter("@ChangeLevelFeeVAT",this.ChangeLevelFeeVAT));
                cmd.Parameters.Add(new SqlParameter("@Note",this.Note));
                cmd.Parameters.Add(new SqlParameter("@AgentFee",this.AgentFee));
                cmd.Parameters.Add(new SqlParameter("@AgentFeeVAT",this.AgentFeeVAT));
                cmd.Parameters.Add(new SqlParameter("@SoldDate",this.SoldDate));
                db.ExecuteSQL(cmd);                
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        
        //---------------------------------------------------------------------------------------------
        public InvoiceDetail GetByTicketNo(string ticketNo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InvoiceDetailGetByTicketNo");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TicketNo", ticketNo));
                List<InvoiceDetail> lAr = init(cmd);
                if (lAr.Count == 1) return lAr[0] as InvoiceDetail;
                else return new InvoiceDetail();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}