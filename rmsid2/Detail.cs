using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rmsid2
{
    class Detail
    {
        public int ID;
        public string Name;
        public byte[] Picture;
        public decimal Price;
        public int Quantity;
        public decimal Total;
        public string Category;
        public string Description;

        public int SaleID;
        public DateTime SaleTime;
        public int SalesmanID;

        public string tablename;
        public int tableStatus;
        public int tableid;

        public string Ordertype;
        public string table;

        public int custid;

        public int deliverBoyId;
        public string deliveryBoy_Name;

        public string user_privelage;
        public string username;
        public int userid;

        public DateTime StartDate;
        public DateTime EndDate;

        public float totalamnt;

        public int orderid;
    }
}
