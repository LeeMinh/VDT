using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VDT;

namespace VDT
{
    public class Agent
    {
        private DBAccess db;
        public Agent()
        {
            db = new DBAccess();
        }
        //--------------------------------------------------------------------------
        ~Agent()
        {

        }
        //--------------------------------------------------------------------------
        public virtual void Dispose()
        {

        }
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public string AgentCompanyName { get; set; }
        public string AgentCompanyAddress { get; set; }
        public string AgentTaxCode { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string SigninSabre { get; set; }
        public string PasscodeSabre { get; set; }
        public string SuffixSabre { get; set; }
        public string HardcopyPrinterAddress { get; set; }
        public string TicketPrinterAddress { get; set; }
        public string TicketPrintRoutine { get; set; }
        public string StationNumber { get; set; }
        public string AgentLogo { get; set; }
        public int ParentID { get; set; }
    }
}
