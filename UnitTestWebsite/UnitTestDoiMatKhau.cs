using DATN_WebsiteTimKiemViecLam.Controllers;
using DATN_WebsiteTimKiemViecLam.Models;
namespace UnitTestWebsite
{
    [TestClass]
    public class UnitTestDoiMatKhau
    {
        TaikhoanController taikhoan;
        [TestInitialize]
        public void SetUp()
        {
            var context = new db_WebsiteTimkiemvieclamContext();
            taikhoan = new TaikhoanController(context);
        }
        [TestMethod]
        public void TestCheckValidDMKNull()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "";
            mkcu = "";
            mkmoi = "";
            mkmoinhaplai = "";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidOldPassNull()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "h.haqbhg@gmail.com";
            mkcu = "";
            mkmoi = "hh@12345";
            mkmoinhaplai = "hh@12345";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidNewPassNull()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "havhh@gmail.com";
            mkcu = "Ha@12345";
            mkmoi = "";
            mkmoinhaplai = "hh@12345";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidNewPassReEnterNull()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "h.haqbhg@gmail.com";
            mkcu = "Ha@12345";
            mkmoi = "hh@12345";
            mkmoinhaplai = "";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidNewPassNoNum()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "h.haqbhg@gmail.com";
            mkcu = "Ha@12345";
            mkmoi = " hh@hangh";
            mkmoinhaplai = "hh@12345";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidNewPassNoSpecialChar()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "h.haqbhg@gmail.com";
            mkcu = "havhh#12";
            mkmoi = "hh123456";
            mkmoinhaplai = "hh12345";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidNewPassWith7Num()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "h.haqbhg@gmail.com";
            mkcu = "Ha@12345";
            mkmoi = "hh@1234";
            mkmoinhaplai = "hh@12345";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidNewPassWith9Num()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "havhh@gmail.com";
            mkcu = "Ha@12345";
            mkmoi = "hh@123456";
            mkmoinhaplai = "hh@12345";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidNewPassReEnterFail()
        {
            string email, mkcu, mkmoi, mkmoinhaplai;
            email = "h.haqbhg@gmail.com";
            mkcu = "Ha@12345";
            mkmoi = "hh@12345";
            mkmoinhaplai = "hh@56789";
            bool exp = false;
            bool act = taikhoan.CheckValidDoimatkhau(email, mkcu, mkmoi, mkmoinhaplai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestDoiMatKhau_Click()
        {
            string email, mkcu, mkmoi;
            email = "h.haqbhg@gmail.com";
            mkcu = "Ha@12345";
            mkmoi = "hh@12345";
            bool exp = true;
            bool act = taikhoan.btnDoimatkhauu_Click(email, mkcu, mkmoi);
            Assert.AreEqual(exp , act);
        }
        [TestMethod]
        public void TestDoiMatKhau_ClickFail()
        {
            string email, mkcu, mkmoi;
            email = "h.haqbhg@gmail.com";
            mkcu = "";
            mkmoi = "";
            bool exp = false;
            bool act = taikhoan.btnDoimatkhauu_Click(email, mkcu, mkmoi);
            Assert.AreEqual(exp, act);
        }
    }
}
