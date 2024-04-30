using DATN_WebsiteTimKiemViecLam.Controllers;
using DATN_WebsiteTimKiemViecLam.Models;
using DATN_WebsiteTimKiemViecLam.Service;

namespace UnitTestWebsite
{
    [TestClass]
    public class UnitTestXoaBai
    {
        DoanhnghiepController dn;
        private readonly TakePictureFromPdf _pdfProcessor;
        [TestInitialize]
        public void SetUp()
        {
            var context = new db_WebsiteTimkiemvieclamContext();
            dn = new DoanhnghiepController(context, _pdfProcessor);
        }
        [TestMethod]
        public void TestXoa_Click_Succes()
        {
            long pk = 19;
            int exp = 1;
            int act = dn.btnXoaBaiDang(pk);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestXoa_Click_Fail()
        {
            long pk = 19;
            int exp = 0;
            int act = dn.btnXoaBaiDang(pk);
            Assert.AreEqual(exp, act);
        }
    }
}
