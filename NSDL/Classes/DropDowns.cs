using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;


namespace NSDL.Classes
{
    public class DropDowns    
        {
        public List<VendorDropDown>  VendorList()
        {
            List<VendorDropDown> list = new List<VendorDropDown>();
            using (var db = new SingleEntities())
            {
                foreach (Vendor_master x in db.Vendor_master)
                {
                    VendorDropDown obj = new VendorDropDown();
                    obj.id = x.vm_cd;
                    obj.name = x.vm_name;
                    list.Add(obj);
                }
            }
            return list;

        }
        public List<InstrumentDropDown> InstrumentList()
        {
            List<InstrumentDropDown> list = new List<InstrumentDropDown>();
            using (var db = new SingleEntities())
            {
                foreach (Instrument_master x in db.Instrument_master)
                {
                    InstrumentDropDown obj = new InstrumentDropDown();
                    obj.id = x.im_instcd;
                    obj.name = x.im_desc;
                    obj.im_trtype = x.im_trtype;
                    obj.im_defaultyn = x.im_defaultyn;
                    list.Add(obj);
                }
            }
            return list;

        }
        public List<VendorDropDown> bookSizesList()
        {
            List<VendorDropDown> list = new List<VendorDropDown>();
            using (var db = new SingleEntities())
            {
                foreach (Book_size x in db.Book_size)
                {
                    VendorDropDown obj = new VendorDropDown();
                    obj.id = x.bk_size;
                    obj.name = x.bk_size.ToString();
                    list.Add(obj);
                }
            }
            return list;

        }

        public List<LotSize> LotSizeList()
        {
            List<LotSize> list = new List<LotSize>();
            using (var db = new SingleEntities())
            {
                foreach(Lot_size x in db.Lot_size)
                {
                    LotSize obj = new LotSize();
                    obj.lz_lotno = x.lz_lotno;
                    obj.lz_type=x.lz_type;
                    obj.lz_size = x.lz_size;
                    obj.lz_status = x.lz_status;
                    obj.mkrid=x.mkrid;
                    obj.mkrdt=x.mkrdt;
                    list.Add(obj);
                }
            }
            return list;

        }

    }
    
    public class VendorDropDown {
        public int? id { get; set; }
        public string name { get; set; }
    }

    public class InstrumentDropDown
    {
        public int id { get; set; }
        public string name { get; set; }
        public string im_trtype { get; set; }
        public string im_defaultyn { get; set; }

    }

    public class BookSizesDropDown
    {
        public int? id { get; set; }
        public string name { get; set; }
    }

    public class LotSize
    {
        public decimal lz_lotno { get; set; }
        public string lz_type { get; set; }
        public int lz_size { get; set; }
        public string lz_status { get; set; }
        public string mkrid  { get; set; }
        public DateTime? mkrdt { get; set; }
        public string lz_branchcd { get; set; }
    }
}