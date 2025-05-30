using System.Text;

public class FileService : IFileService
{
    public void WriteToFile(string filePath, string content)
    {
        //Chuyển nội dung chuỗi (string) sang mảng byte (byte[]) bằng mã hóa UTF-8, vì FileStream chỉ xử lý dữ liệu nhị phân.
        byte[] buffer = Encoding.UTF8.GetBytes(content);
        using FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        //Ghi toàn bộ buffer (nội dung file) vào stream, từ vị trí 0 đến buffer.Length.
        fs.Write(buffer, 0, buffer.Length);
    }

    public string? ReadFromFile(string filePath)
    {
        if (!FileExists(filePath)) return null;

        //Mở một FileStream để đọc file.
        //using đảm bảo rằng stream sẽ được đóng tự động sau khi dùng xong.
        //Các tham số:
        //filePath: đường dẫn file
        //FileMode.Open: mở file hiện có
        //FileAccess.Read: chỉ cho phép đọc

        using FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        //Tạo mảng byte có độ dài bằng kích thước file (tính bằng byte).
        //Đây là nơi lưu dữ liệu đọc từ file vào.

        byte[] buffer = new byte[fs.Length];
        //Đọc toàn bộ buffer (nội dung file) vào stream, từ vị trí 0 đến buffer.Length.
        fs.ReadExactly(buffer, 0, buffer.Length);
        //Chuyển mảng byte đã đọc thành chuỗi, với bộ mã UTF-8.
        return Encoding.UTF8.GetString(buffer);
    }

    public bool FileExists(string filePath)
    {//Trả về true nếu file tồn tại tại filePath, ngược lại là false.
        return File.Exists(filePath);
    }
}
