using System.Runtime;

namespace TrainingApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
            {
                Console.Write(">> ");
                // List [path]
                var input = Console.ReadLine().Trim(); // remove space
                var IndexWhiteSpace = input.IndexOf(' ');
                var command = input.Substring(0, IndexWhiteSpace).ToLower(); //List 
                var path = input.Substring(IndexWhiteSpace + 1).Trim(); // path ignore white space

                if (command == "list")
                {
                    foreach (var entry in Directory.GetDirectories(path))
                        Console.WriteLine($"\t[Dir] {entry}");
                    foreach (var entry in Directory.GetFiles(path))
                        Console.WriteLine($"\t[Files] {entry}");
                }
                else if (command == "info")
                {
                        if (Directory.Exists(path))
                        {
                            var DirInfo=new DirectoryInfo(path);
                            Console.WriteLine($"Type: Directory");
                            Console.WriteLine($"Created At: {DirInfo.CreationTime}");
                            Console.WriteLine($"Last Modified At: {DirInfo.LastWriteTime}");

                        }else if (File.Exists(path)){
                            var FileInfo=new FileInfo(path);
                            Console.WriteLine($"Type: File");
                            Console.WriteLine($"Created At: {FileInfo.CreationTime}");
                            Console.WriteLine($"Last Modified At: {FileInfo.LastWriteTime}");
                            Console.WriteLine($"LSize in Bytes: {FileInfo.Length} Byte");
                        }
                        else
                        {
                            Console.WriteLine("Not File , Not Directory ");
                        }
                      
                }
                else if (command == "mkdir")
                {
                        Directory.CreateDirectory(path);
                }
                else if (command == "remove")
                {
                        if (Directory.Exists(path))
                        {
                            Directory.Delete(path);
                        }
                        else if(File.Exists(path))
                        {
                            File.Delete(path);
                        }

                }
                else if (command == "print")
                {
                        if (File.Exists(path))
                        {
                            var content=File.ReadAllText(path);
                            Console.WriteLine(content);
                        }
                }
                else if (command == "exit")
                {
                    break;
                }
            }
          }
        }
    }
}
