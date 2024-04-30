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
            bool exp =false;
            bool act = uv.CheckValidTimkiemVieclam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithTenCongviec()
        {
            string tg = "";
            string kinhnghiem = "";
            string diachi = "";
            string mucluong = "";
            string tencv = "Nhân Viên Kinh Doanh";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg,kinhnghiem,diachi,mucluong,tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithMucLuong()
        {
            string tg = "";
            string kinhnghiem = "";
            string diachi = "";
            string mucluong = "5";
            string tencv = "";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithDiaChi()
        {
            string tg = "";
            string kinhnghiem = "";
            string diachi = "Hà Nam";
            string mucluong = "";
            string tencv = "";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithKinhNghiem()
        {
            string tg = "";
            string kinhnghiem = "1";
            string diachi = "";
            string mucluong = "";
            string tencv = "";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithThoiGian()
        {
            string tg = "2023-03-02";
            string kinhnghiem = "";
            string diachi = "";
            string mucluong = "";
            string tencv = "";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithAll()
        {
            string tg = "2023-03-02";
            string kinhnghiem = "1";
            string diachi = "Hà Nam";
            string mucluong = "5";
            string tencv = "Nhân Viên Kinh Doanh";
            int exp = 1;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestTimKiem_Click_WithFailName()
        {
            string tg = "";
            string kinhnghiem = "";
            string diachi = "";
            string mucluong = "";
            string tencv = "Nhân Viên Kinh Doanh12";
            int exp = 0;
            int act = uv.btn_TimkiemViecLam(tg, kinhnghiem, diachi, mucluong, tencv);
            Assert.AreEqual(exp, act);
        }
    }
}
