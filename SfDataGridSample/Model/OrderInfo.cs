﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class OrderItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string Name { get; set; }
        public int TokenNo { get; set; }
        public string BillStatus { get; set; }
        public int Count { get; set; }
        public bool IsChecked
        {
            get
            {
                return Count == 1 ? true : false;
            }
            set
            {
                Count = value ? 1 : 0;
            }
        }
    }

}
