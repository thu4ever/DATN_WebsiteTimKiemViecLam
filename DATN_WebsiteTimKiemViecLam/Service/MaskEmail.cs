namespace DATN_WebsiteTimKiemViecLam.Service
{
    public class MaskEmail
    {
            public string MaskaEmail(string email)
            {
                // Kiểm tra xem email có hợp lệ hay không
                if (!IsValidEmail(email))
                {
                    throw new ArgumentException("Email không hợp lệ", nameof(email));
                }

                // Phân tách địa chỉ email thành tên người dùng và tên miền
                string[] parts = email.Split('@');
                string username = parts[0];
                string domain = parts[1];

                // Lấy một phần của tên người dùng (vd: "hello" -> "h***o")
                string maskedUsername = MaskString(username);

                // Ghép lại địa chỉ email
                return $"{maskedUsername}@{domain}";
            }

            private bool IsValidEmail(string email)
            {
                // Thực hiện kiểm tra đơn giản về định dạng email
                // (trong thực tế nên sử dụng kiểm tra chi tiết hơn)
                return email.Contains("@");
            }

            private string MaskString(string input)
            {
                // Ẩn đi một phần của chuỗi, giữ lại ký tự đầu và cuối
                if (input.Length <= 2)
                {
                    return input; // Không ẩn nếu chuỗi quá ngắn
                }

                char[] chars = input.ToCharArray();
                for (int i = 1; i < chars.Length - 1; i++)
                {
                    chars[i] = '*';
                }

                return new string(chars);
            }
        }
}
