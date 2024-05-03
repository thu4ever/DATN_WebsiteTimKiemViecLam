using DATN_WebsiteTimKiemViecLam.Controllers;
using DATN_WebsiteTimKiemViecLam.Models;
using DATN_WebsiteTimKiemViecLam.Service;

namespace UnitTestWebsite
{
    [TestClass]
    public class UniTestDangBai
    {
        DoanhnghiepController dn;
        private readonly TakePictureFromPdf _pdfProcessor;
        [TestInitialize]
        public void SetUp()
        {
            var context = new db_WebsiteTimkiemvieclamContext();
            dn = new DoanhnghiepController(context,_pdfProcessor);
        }
        [TestMethod]
        public void TestCheckValidDangBaiNull() 
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;

            tenbd = "";
            mota = "";
            ycau = "";
            quyenloi = "";
            soluong = "";
            mucluongtoithieu = 0;
            mucluongtoida = 0;
            namkinhnghiem = 0;
            trangthai = 0;
            bool exp= false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiTenBaiNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd =null;
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "2";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiMotaNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = null;
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "2";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiYeuCauNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;

            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = null;
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "2";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiQuyenLoiNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = null;
            soluong = "2";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiSoLuongNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiLuongMinNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "2";
            mucluongtoithieu = 0;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiLuongMaxNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "2";
            mucluongtoithieu = 23000000;
            mucluongtoida = 0;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiNamKinhNghiemNull()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "2";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 0;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckValidDangBaiSoLuongIsChar()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong = "abc";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 1;
            bool exp = false;
            bool act = dn.CheckValidthembaidang(tenbd, mota, ycau, quyenloi, mucluongtoithieu, mucluongtoida, namkinhnghiem, soluong, trangthai);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckDangBai_Click()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = "Product Owner (Sản Phẩm Quản Lý Giáo Dục)";
            mota = "+ Làm việc trực tiếp với đối tác bên ngoài để thấu hiểu dữ liệu hiện tại và khó khăn của họ. Từ đó lên ý tưởng về việc cung cấp các dữ liệu tổng hợp, báo cáo phân tích giúp cải tiến công tác sản xuất, kinh doanh được hiệu quả hơn\r\n+ Nghiên cứu, phân tích xu hướng sản phẩm để tìm kiếm những ý tưởng vượt trội, đề xuất phương án phát triển sản phẩm để mang lại nhiều giá trị cho khách hàng và công ty.\r\n+ Quản lý, sắp xếp, phân loại độ ưu tiên của các yêu cầu đáp ứng cho khách hàng. Phối hợp với Engineering Manager giám sát lộ trình phát triển sản phẩm\r\n";
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";

            int exp = 1;

            TblBaituyendung btd = new TblBaituyendung();
            btd.STenBai = tenbd;
            btd.SMoTa = mota;
            btd.SYeuCau = ycau;
            btd.SQuyenLoi= quyenloi;
            btd.ISoLuong = 2;
            btd.FMucLuongtoithieu = 23;
            btd.FMucluongtoida = 30;
            btd.FNamKinhNghiem = 2;
            btd.ITrangthai = 0;
            btd.FkSMaDn = 10003;
            int act = dn.btnThembaidangg(btd);
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void TestCheckDangBai_Click_Fail()
        {
            string tenbd, mota, ycau, quyenloi, soluong;
            float mucluongtoithieu, mucluongtoida;
            int namkinhnghiem, trangthai;
            tenbd = null;
            mota = null;
            ycau = "+ Tốt nghiệp ĐH trở lên các chuyên ngành về Kinh tế, Tài Chính, Quản trị kinh doanh hoặc các chuyên ngành liên quan....\r\n+ Có tối thiểu 2 năm kinh nghiệm làm việc với vai trò Senior Business Analyst hoặc 1 năm làm Product owner trong công ty phần mềm. Ưu tiên ứng viên có kinh nghiệm làm các sản phẩm về giáo dục và quản lý giáo dục.\r\n+ Có khả năng nghiên cứu, tổng hợp, phân tích, đánh giá thị trường và khách hàng để tìm định hướng và lập kế hoạch phát triển cho sản phẩm.\r\n+ Khả năng giao tiếp và làm việc nhóm tốt, khả năng thuyết phục, thương lượng và giải quyết vấn đề tốt.\r\n+ Có kiến thức về thiết kế trải nghiệm người dùn";
            quyenloi = "+ Lương khởi điểm cạnh tranh theo năng lực upt 1500$, xem xét tăng lương 6 tháng/lần\r\n+ Thưởng cuối năm theo năng suất làm việc tương đương 2-3 tháng lương\r\n+ Ăn trưa miễn phí tại công ty; quà lễ tết, sinh nhật, hiếu hỉ, thăm hỏi, khám sức khỏe, Team building, nghỉ mát hấp dẫn, các CLB thể thao, văn thể mỹ...";
            soluong ="0";
            mucluongtoithieu = 23000000;
            mucluongtoida = 30000000;
            namkinhnghiem = 2;
            trangthai = 0;

            int exp = 0;

            TblBaituyendung btd = new TblBaituyendung();
            btd.STenBai = tenbd;
            btd.SMoTa = mota;
            btd.SYeuCau = ycau;
            btd.SQuyenLoi = quyenloi;
            btd.ISoLuong = Int32.Parse(soluong);
            btd.FMucLuongtoithieu = mucluongtoithieu;
            btd.FMucluongtoida = mucluongtoida;
            btd.FNamKinhNghiem = namkinhnghiem;
            btd.ITrangthai = trangthai;

            int act = dn.btnThembaidangg(btd);
            Assert.AreEqual(exp, act);
        }
    }
}
