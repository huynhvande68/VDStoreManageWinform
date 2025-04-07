# Hướng dẫn sử dụng Phần mềm Quản lý Cửa hàng VDStore

## Giới thiệu
VDStore là một phần mềm quản lý cửa hàng toàn diện được xây dựng bằng C# và Windows Forms. Phần mềm hỗ trợ quản lý nhân viên, khách hàng, sản phẩm, đơn hàng và hóa đơn.

## Yêu cầu hệ thống
- Windows 7 hoặc cao hơn
- .NET Framework 4.7.2 hoặc cao hơn
- SQL Server 2014 hoặc cao hơn
- Visual Studio 2019 hoặc cao hơn (để phát triển)

## Hướng dẫn cài đặt

### 1. Cài đặt cơ sở dữ liệu
1. Mở SQL Server Management Studio (SSMS)
2. Kết nối đến SQL Server của bạn
3. Trong SSMS, mở file script SQL: `VDStore/DAL/DatabaseScript.sql`
4. Chạy script để tạo cơ sở dữ liệu, bảng, stored procedures và tài khoản admin mặc định

### 2. Cấu hình chuỗi kết nối
1. Mở file `App.config` trong thư mục gốc của dự án
2. Tìm đến phần chuỗi kết nối:
   ```xml
   <connectionStrings>
     <add name="PiStoreConnection" connectionString="Data Source=.;Initial Catalog=PiStoreDB;Integrated Security=True" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
3. Nếu cần, hãy thay đổi chuỗi kết nối:
   - `Data Source=.` tham chiếu đến SQL Server cục bộ. Thay đổi thành tên máy chủ của bạn nếu khác.
   - `Integrated Security=True` sử dụng xác thực Windows. Nếu bạn sử dụng xác thực SQL Server, thay thế bằng `User ID=tên_đăng_nhập;Password=mật_khẩu;`

### 3. Biên dịch và chạy ứng dụng
1. Mở file solution (`VDStore.sln`) trong Visual Studio
2. Biên dịch solution (Nhấn F6 hoặc chọn Build > Build Solution)
3. Chạy ứng dụng (Nhấn F5 hoặc chọn Debug > Start Debugging)

### 4. Đăng nhập vào ứng dụng
- Sử dụng thông tin đăng nhập admin mặc định:
  - Tên đăng nhập: `admin`
  - Mật khẩu: `admin123`

## Hướng dẫn sử dụng

### Menu chính
Menu chính cung cấp truy cập đến tất cả các chức năng:
- **Dashboard**: Hiển thị tổng quan về doanh thu, tồn kho, hiệu suất nhân viên và thông tin khách hàng (Chỉ Admin)
- **Home**: Giao diện bán hàng và giỏ hàng
- **Quản lý nhân viên**: Thêm, sửa và xóa thông tin nhân viên (Chỉ Admin)
- **Quản lý khách hàng**: Quản lý thông tin khách hàng
- **Quản lý sản phẩm**: Quản lý thông tin và tồn kho sản phẩm
- **Quản lý đơn hàng**: Xem và quản lý đơn hàng hiện có
- **Quản lý hóa đơn**: Xem lịch sử hóa đơn
- **Đăng xuất**: Đăng xuất khỏi hệ thống

### Phân quyền người dùng
- **Admin**: Có toàn quyền truy cập vào tất cả các chức năng
- **Nhân viên**: Có thể sử dụng chức năng bán hàng, quản lý khách hàng, sản phẩm, đơn hàng và hóa đơn
- **Khách hàng**: Chỉ có thể sử dụng chức năng mua hàng

### Quản lý nhân viên
1. Nhấp vào "Quản lý nhân viên" trong menu chính
2. Sử dụng form để thêm nhân viên mới hoặc chỉnh sửa thông tin nhân viên
3. Điền vào các trường thông tin bắt buộc (Tên, Email, v.v.)
4. Nhấp "Lưu" để tạo/cập nhật thông tin nhân viên
5. Sử dụng chức năng tìm kiếm để tìm nhân viên cụ thể
6. Sử dụng nút "Xuất CSV" để xuất danh sách nhân viên ra file CSV

### Quản lý khách hàng
Tương tự như quản lý nhân viên, form này cho phép bạn quản lý thông tin khách hàng.

### Quản lý sản phẩm
Quản lý hàng tồn kho với module này:
- Thêm sản phẩm mới với thông tin như tên, mô tả, giá và số lượng
- Cập nhật thông tin sản phẩm hiện có
- Theo dõi số lượng sản phẩm trong kho
- Thêm hình ảnh sản phẩm
- Xuất danh sách sản phẩm ra file CSV

### Bán hàng (Home)
1. Tìm kiếm sản phẩm bằng cách nhập từ khóa vào ô tìm kiếm
2. Chọn khách hàng từ dropdown hoặc sử dụng khách hàng ẩn danh
3. Thêm sản phẩm vào giỏ hàng
4. Điều chỉnh số lượng sản phẩm trong giỏ hàng nếu cần
5. Nhấp "Đặt hàng" để hoàn tất đơn hàng
6. Xuất danh sách giỏ hàng ra file CSV nếu cần

### Quản lý đơn hàng
1. Xem tất cả các đơn hàng hoặc lọc theo khách hàng
2. Xem chi tiết đơn hàng bằng cách nhấp vào đơn hàng
3. Xuất danh sách đơn hàng ra file CSV

### Quản lý hóa đơn
1. Xem tất cả các hóa đơn hoặc lọc theo ngày
2. Xem chi tiết hóa đơn bằng cách nhấp vào hóa đơn
3. In hóa đơn (chức năng dự kiến trong tương lai)

### Dashboard (Dành cho Admin)
1. Xem tổng quan về doanh thu, tồn kho, hiệu suất nhân viên và thông tin khách hàng
2. Lọc thông tin theo khoảng thời gian (7 ngày, 30 ngày, 90 ngày, 365 ngày, tất cả)
3. Làm mới dữ liệu bằng nút "Refresh"

## Xử lý sự cố

### Vấn đề kết nối cơ sở dữ liệu
- Kiểm tra SQL Server đang chạy
- Kiểm tra chuỗi kết nối trong App.config
- Đảm bảo bạn có quyền truy cập SQL Server thích hợp

### Vấn đề đăng nhập
- Thông tin đăng nhập admin mặc định là tên đăng nhập: `admin`, mật khẩu: `admin123`
- Nếu quên mật khẩu, bạn có thể đặt lại trong SQL Server với câu lệnh:
  ```sql
  UPDATE [User] SET Password = 'admin123' WHERE Username = 'admin'
  ```

### Người phát triển
Dự án này được phát triển bởi [Tên của bạn/nhóm].

Liên hệ: [Email/Thông tin liên hệ của bạn]

---

© 2023 VDStore. Bảo lưu mọi quyền. 