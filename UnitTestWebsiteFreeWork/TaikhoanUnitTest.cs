using Microsoft.VisualStudio.TestTools.UnitTesting;
using DATN_WebsiteTimKiemViecLam;
using DATN_WebsiteTimKiemViecLam.Controllers;
namespace UnitTestWebsiteFreeWork
{
    [TestClass]
    public class TaikhoanUnitTest
    {
        TaikhoanController taikhoanController;
        [TestInitialize]
        public void SetUp()
        {
            taikhoanController = new TaikhoanController();
        }

        [TestMethod]
        public void CheckValidDangki()
        {
            bool expected = false;
            bool actual = taikhoanController.CheckValidDangki("";
            Assert.AreEqual(expected, actual);
        }
    }
}
