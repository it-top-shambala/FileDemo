using System.Text;

namespace FileDemo.FileStreamExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "example.txt";
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            string text = "Пример text'а";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            file.Write(bytes, 0, bytes.Length);
            file.Close();
        }
    }
}