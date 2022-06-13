namespace FileDemo.StreamReaderAndWriterExample
{
    internal class Program
    {
        static void Main()
        {
            string path = "example.txt";
            /*
            StreamWriter file = null;
            try
            {
                file = new StreamWriter(path, append: false);
                file.WriteLine("Пример TEXT'а");
            }
            finally
            {
                file?.Close();
            }
            */

            using (StreamWriter file = new StreamWriter(path, append: false))
            {
                file.WriteLine("Пример TEXT'а");
            }
            
            using (StreamReader file = new StreamReader(path))
            {
                string str = file.ReadLine();
                Console.WriteLine(str);
            }
        }
    }
}