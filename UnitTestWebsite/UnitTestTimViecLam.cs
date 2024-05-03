using DATN_WebsiteTimKiemViecLam.Controllers;
using DATN_WebsiteTimKiemViecLam.Models;

namespace UnitTestWebsite
{
    [TestClass]
    public class UnitTestTimViecLam
    {
        UngVienController uv;
        [TestInitialize]
        public void SetUp()
        {
            var context = new db_WebsiteTimkiemvieclamContext();
            uv = new UngVienController(context);
        }
        [TestMethod]
        public void TestCheckValidTimViecLamNull()
        {
            string tg = "";
            string kinhnghiem = "";
            string diachi = "";
            string mucluong = "";
            string tencv = "";
            bool exp =true;
            bool act = uv.CheckValidTimkiemVieclam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithTenCongviec()
        {
            string tg = "100";
            string kinhnghiem =null;
            string diachi = null;
            string mucluong = "5";
            string tencv = "Nhân Viên";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg,kinhnghiem,diachi,mucluong,tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithMucLuong()
        {
            string tg = "100";
            string kinhnghiem = null;
            string diachi = null;
            string mucluong = "5";
            string tencv = null;
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithDiaChi()
        {
            string tg = "100";
            string kinhnghiem = null;
            string diachi = "Hà";
            string mucluong = "1";
            string tencv = null;
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithKinhNghiem()
        {
            string tg = "100";
            string kinhnghiem = "1";
            string diachi = " ";
            string mucluong = "1";
            string tencv = " ";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithThoiGian()
        {
            string tg = "100";
            string kinhnghiem = "1";
            string diachi = " ";
            string mucluong = "1";
            string tencv = " ";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithAll()
        {
            string tg = "7";
            string kinhnghiem = "100";
            string diachi = "Hà Nội";
            string mucluong = "1";
            string tencv = "FRESHER";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithFailName()
        {
            string tg = "100";
            string kinhnghiem = null;
            string diachi = null;
            string mucluong = "1";
            string tencv = "Nhân Viên Kinh Doanh 12";
            int exp = 0;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
    }
}
