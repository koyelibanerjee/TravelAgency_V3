﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.CSUI.FrmSub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.CSUI.FrmSub.Tests
{
    [TestClass()]
    public class FrmIdentificationValueTests
    {
        [TestMethod()]
        public void FrmIdentificationValueTest()
        {
            //FrmIdentificationValue frm = new FrmIdentificationValue();
            //frm.ShowDialog();

            //Assert.Fail();
            int i = String.CompareOrdinal(null, null);
            i = String.CompareOrdinal("", null);
            i = String.CompareOrdinal("", "a");
            i = String.CompareOrdinal("a", null);


        }
    }
}