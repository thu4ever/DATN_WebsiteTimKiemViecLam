using DATN_WebsiteTimKiemViecLam.Controllers;
using DATN_WebsiteTimKiemViecLam.Models;

namespace UnitTestWebsite
{
    [TestClass]
    public class UnitTestDangKy
    {
        TaikhoanController taikhoan;
        [TestInitialize]
        public void SetUp()
        {
            var context = new db_WebsiteTimkiemvieclamContext();
            taikhoan = new TaikhoanController(context);
        }
        [TestMethod]
        public void TestCheckValidDangKyNull()
        {
            string email, mk, mknhaplai, maquyen;
            email = "";
            mk = "";
            mknhaplai = "";
            maquyen = "";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangKyNullEmail()
        {
            string email, mk, mknhaplai, maquyen;
            email = "";
            mk = "Ha@12345";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangKyNullPass() 
        {
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangkyNullPassReEntern() 
        {
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "Ha@12345";
            mknhaplai = "";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidEmailNoFormat1()
        {
            //Test mail khong chua @
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhggmail.com";
            mk = "Ha@12345";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidEmailNoFormat2()
        {
            //Test mail khong chua dau cham
            string email, mk, mknhaplai, maquyen;
            email = "hhaqbhg@gmailcom";
            mk = "Ha@12345";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidPassNoNumber()
        {
            //Mat khau khong chua ky tu so
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "Ha@hahah";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidPassNoSpecialChair()
        {
            //Mat khau khong chua ky tu dac biet
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "Ha123456";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidPassWith7Num()
        {
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "Ha@1234";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        public void TestCheckVailidPassWith9Num()
        {
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "Ha@123456";
            mknhaplai = "Ha@12345";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidPassReEnternNoEqual()
        {
            string email, mk, mknhaplai, maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "Ha@123456";
            mknhaplai = "Ha@56789";
            maquyen = "1";
            bool exp = false;
            bool act = taikhoan.CheckValidDangki(email, mk, mknhaplai, maquyen);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckExistTaiKhoanDK()
        {
            string email;
            email = "hoaiungvien@gmail.com";
            bool exp = false;
            bool act = taikhoan.CheckExisitTaikhoanDK(email);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestDangKy_Click()
        {
            string email, mk, mknhalai;
            string maquyen;
            email = "h.haqbhg@gmail.com";
            mk = "Ha@12345";
            mknhalai= "Ha@12345";
            maquyen = "1";
            int exp = 1;
            int act = taikhoan.btnDangky_Click(maquyen, email, mk,mknhalai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestDangKy_ClickFail()
        {
            string email, mk, mknhaplai;
            string maquyen;
            email = "";
            mk = "";
            mknhaplai = "";
            maquyen = "1";
            int exp = 0;
            int act = taikhoan.btnDangky_Click(maquyen, email, mk, mknhaplai);
            Assert.AreEqual(exp, act);
        }
    }
}
