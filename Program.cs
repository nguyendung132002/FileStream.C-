using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

var builder = Host.CreateApplicationBuilder(args);

// Đăng ký dịch vụ
builder.Services.AddSingleton<IFileService, FileService>();

// Tạo host
using IHost host = builder.Build();

// Resolve service
var fileService = host.Services.GetRequiredService<IFileService>();

string filePath = "user_input.txt";

// Nhập từ người dùng
Console.Write("Nhập nội dung muốn ghi vào file: ");
string? input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("❌ Không có nội dung để ghi.");
    return;
}

fileService.WriteToFile(filePath, input);
Console.WriteLine("✅ Đã ghi vào file.");

// Đọc lại nếu file tồn tại
string? content = fileService.ReadFromFile(filePath);
if (content != null)
{
    Console.WriteLine("📄 Nội dung trong file:");
    Console.WriteLine(content);
}
else
{
    Console.WriteLine("❌ File không tồn tại hoặc rỗng.");
}
