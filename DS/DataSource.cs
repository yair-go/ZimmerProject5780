﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        public static List<HostingUnit> hostingUnits = new List<HostingUnit>();
        public static List<Order> orders = new List<Order>();
        public static List<GuestRequest> guestRequests = new List<GuestRequest>();

        static DataSource()
        {
            initData();
           
        }

        private static void initData()
        {
            foreach (int i in Enumerable.Range(1, 10))
            {
                hostingUnits.Add(new HostingUnit(new Host(), "Unit " + i, (Enums.HostingUnitType)(i % 3)));
            }
        }
    }
}
