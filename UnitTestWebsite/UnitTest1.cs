using DATN_WebsiteTimKiemViecLam.Controllers;
using DATN_WebsiteTimKiemViecLam.Models;

namespace UnitTestWebsite
{
    [TestClass]
    public class UnitTest1
    {
        TaikhoanController taikhoan;
       [TestInitialize]
        public void SetUp()
        {
            var context = new db_WebsiteTimkiemvieclamContext();
            taikhoan = new TaikhoanController(context);
        }
        [TestMethod]
        public void TC_UT_STTND_001()
        {
            bool expected = false;
            string txtHoten = "";
            string txtGioitinh = "";
            string txtAnh = "";
            string txtSodienthoai = "";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_002()
        {
            bool expected = false;
            string txtHoten = "";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "0347382190";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_003()
        {
            bool expected = false;
            string txtHoten = "thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_004()
        {
            bool expected = false;
            string txtHoten = "thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "";
            string txtSodienthoai = "0347382190";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_005()
        {
            bool expected = false;
            string txtHoten = "thuhoai";
            string txtGioitinh = "";
            string txtAnh = "hanam";
            string txtSodienthoai = "0347382190";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_006()
        {
            bool expected = false;
            string txtHoten = "123thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "0347382190";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_007()
        {
            bool expected = false;
            string txtHoten = "@#thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "0347382190";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_008()
        {
            bool expected = false;
            string txtHoten = "thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "0347sa2190";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_009()
        {
            bool expected = false;
            string txtHoten = "thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "034722232";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_010()
        {
            bool expected = false;
            string txtHoten = "thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "03472223221";

            // Gọi phương thức cần kiểm tra
            bool actual = taikhoan.CheckValidthongtinUV(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_011()
        {
            int expected = 1;
            string txtHoten = "thuhoai";
            string txtGioitinh = "nu";
            string txtAnh = "hanam";
            string txtSodienthoai = "0347222322";

            // Gọi phương thức cần kiểm tra
            int actual = taikhoan.btnChinhsuathongtinnUV_Click(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TC_UT_STTND_012()
        {
            int expected = 1;
            string txtHoten = "thuhoai";
            string txtGioitinh = "";
            string txtAnh = "hanam";
            string txtSodienthoai = "0347222322";

            // Gọi phương thức cần kiểm tra
            int actual = taikhoan.btnChinhsuathongtinnUV_Click(txtHoten, txtGioitinh, txtAnh, txtSodienthoai);

            // So sánh kết quả với kỳ vọng
            Assert.AreEqual(expected, actual);
        }

    }
}