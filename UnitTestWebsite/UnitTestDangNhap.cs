using DATN_WebsiteTimKiemViecLam.Controllers;
using DATN_WebsiteTimKiemViecLam.Models;


namespace UnitTestWebsite
{
    [TestClass]
    public class UnitTestDangNhap
    {
        TaikhoanController taikhoan;
        [TestInitialize]
        public void SetUp()
        {
            var context = new db_WebsiteTimkiemvieclamContext();
            taikhoan = new TaikhoanController(context);
        }
        [TestMethod]
        public void TestCheckExistTaiKhoan()
        {
            string email = "hoaiungvien@gmail.com";
            bool expected = true;
            bool act = taikhoan.CheckExisitTaikhoan(email);
            Assert.AreEqual(expected, act);
        }
        [TestMethod]
        public void TestCheckNoExistTaiKhoan()
        {
            string email = "hoaiha@gmail.com";
            bool expected = false;
            bool act = taikhoan.CheckExisitTaikhoan(email);
            Assert.AreEqual(expected, act);
        }
        [TestMethod]
        public void TestCheckDisableTaiKhoan()
        {
            string email = "havhh@gmailcom";
            bool exp = true;
            bool act = taikhoan.CheckExisitTaikhoan(email);
            Assert.AreEqual(exp,act);
        }
        [TestMethod]
        public void TestDangNhap_Click()
        {
            string email = "hoaiungvien@gmail.com";
            string mk = "1234";
            long exp= 1;
            long act = taikhoan.Dangnhap_Click(email, mk);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestFailDangNhap_Click()
        {
            string email = "hoaiungvien@gmail.com";
            string mk = "1243";
            long exp = 0;
            long act = taikhoan.Dangnhap_Click(email, mk);
            Assert.AreEqual(exp, act);
        }
    }
}
