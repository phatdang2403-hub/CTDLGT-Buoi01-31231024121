# CTDLGT - Buổi 01

- **Họ tên:** ……………………………
- **Mã số sinh viên:** 31231024121
- **Lớp học phần:** ……………………………

## Hướng dẫn biên dịch và chạy chương trình

Yêu cầu: .NET SDK (đã kiểm tra với .NET 10). Mỗi bài là một project console riêng.

```powershell
cd Bai1
dotnet run
```

Làm tương tự với `Bai2` và `Bai3`. Riêng Bài 3 nên chạy chế độ Release để số đo thời gian chính xác hơn:

```powershell
cd Bai3
dotnet run -c Release
```

**Định dạng nhập:**
- Bài 1: ba số nguyên `a b c`, nhập cùng dòng hoặc mỗi số một dòng.
- Bài 2: số nguyên `n` trước, sau đó là `n` phần tử của mảng (cùng dòng hoặc khác dòng).
- Bài 3: không cần nhập, chương trình tự sinh dữ liệu ngẫu nhiên (seed cố định) để kiểm tra và đo thời gian.

## Mô tả giải pháp

### Bài 1 - Nhập xuất và xử lý điều kiện
Đọc ba số nguyên kiểu `long` (xử lý được số âm và tránh tràn số khi cộng). Số lớn nhất, nhỏ nhất tìm bằng `Math.Max` và `Math.Min`. Tổng là `a + b + c`, trung bình là `tổng / 3.0`, in với đúng hai chữ số thập phân và dấu phẩy như ví dụ của đề.

### Bài 2 - Hai giá trị lớn nhất phân biệt
Duyệt mảng một lần, giữ hai biến `max` và `second` cùng hai cờ báo đã có giá trị hay chưa (không dùng giá trị khởi tạo như `int.MinValue` nên mảng toàn số âm vẫn đúng):
- `x > max`: `max` cũ trở thành `second`, `x` trở thành `max`.
- `x < max` và `x > second` (hoặc chưa có `second`): cập nhật `second`.
- `x == max`: bỏ qua, vì cần giá trị lớn thứ hai **phân biệt**.

Cuối cùng, nếu chưa có `second` thì in `NO`. Chương trình đọc từng số trực tiếp từ đầu vào, không lưu mảng, không sắp xếp và không dùng LINQ.

### Bài 3 - Đoạn con liên tiếp có tổng lớn nhất
- **Phiên bản A (Θ(n²)):** với mỗi điểm đầu `i`, mở rộng điểm cuối `j` và cộng dồn tổng, cập nhật tổng lớn nhất. Không dùng ba vòng lặp.
- **Phiên bản B (Kadane, Θ(n)):** `cur` là tổng lớn nhất của đoạn kết thúc tại vị trí hiện tại, `cur = max(a[i], cur + a[i])`; `best` là giá trị lớn nhất của `cur`. Cả hai phiên bản khởi tạo bằng `a[0]` nên mảng toàn số âm trả về phần tử lớn nhất (không mặc định bằng 0).
- **Đo thời gian:** dùng `Stopwatch`, chạy khởi động một lần, sau đó chạy 21 lần trên cùng một mảng cho cả hai phiên bản và lấy giá trị trung vị.

## Độ phức tạp

| Bài | Thời gian | Bộ nhớ phụ |
|---|---|---|
| Bài 1 | Θ(1) | Θ(1) |
| Bài 2 | Θ(n) | Θ(1) |
| Bài 3 - Phiên bản A | Θ(n²) | Θ(1) |
| Bài 3 - Kadane | Θ(n) | Θ(1) |

## Các test case đã sử dụng

### Bài 1

| Nhập | Kết quả |
|---|---|
| `7 2 10` | Lớn nhất: 10; nhỏ nhất: 2; tổng: 19; trung bình: 6,33 |
| `-5 -2 -9` | Lớn nhất: -2; nhỏ nhất: -9; tổng: -16; trung bình: -5,33 |
| `4 4 9` (hai số bằng nhau) | Lớn nhất: 9; nhỏ nhất: 4; tổng: 17; trung bình: 5,67 |
| `3 3 3` (ba số bằng nhau) | Lớn nhất: 3; nhỏ nhất: 3; tổng: 9; trung bình: 3,00 |
| `-1 -1 -1` (ba số bằng nhau, có số âm) | Lớn nhất: -1; nhỏ nhất: -1; tổng: -3; trung bình: -1,00 |

### Bài 2

| Mảng | Kết quả | Mục đích |
|---|---|---|
| `3 7 2 9 5` | `9 7` | Trường hợp thông thường |
| `8 8 8 3` | `8 3` | Có phần tử trùng |
| `-9 -2 -5` | `-2 -5` | Toàn số âm |
| `4 4 4 4` | `NO` | Không có số thứ hai |
| `1 2` | `2 1` | Kích thước nhỏ nhất |

### Bài 3

| Mảng | Tổng lớn nhất |
|---|---|
| `-2 1 -3 4 -1 2 1 -5 4` | 6 |
| `-8 -3 -6 -2 -5 -4` | -2 |
| `1 2 3` | 6 |

Cả hai phiên bản cho cùng kết quả trên các mảng trên.

**Bảng thời gian** (trung vị của 21 lần chạy, Release, mảng ngẫu nhiên trong khoảng [-100, 100]):

| n | Θ(n²) | Kadane Θ(n) | Nhận xét |
|---|---|---|---|
| 100 | …… ms | …… ms | …… |
| 1.000 | …… ms | …… ms | …… |
| 10.000 | …… ms | …… ms | …… |

## Công cụ AI đã sử dụng

Claude (Anthropic),  được dùng để hỗ trợ đưa ra lời giải cho ba bài, giải thích lỗi khi chạy chương trình và soạn nội dung README này. Tôi đã tự chạy lại mã, kiểm tra kết quả với các test case ở trên và chịu trách nhiệm về bài nộp.
