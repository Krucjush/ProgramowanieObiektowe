using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Lab_9
{
    public static class Program
    {
        public static void MainProgram()
        {
            int pageNumber = 1;
            int pageSize = 5;
            string snippetsType = "cs"; // C#

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);

            Console.WriteLine($"PageNumber: {reponse.PageNumber}");
            Console.WriteLine($"PagesCount: {reponse.PagesCount}");
            Console.WriteLine($"PageSize:   {reponse.PageSize}  ");
            Console.WriteLine($"TotalCount: {reponse.TotalCount}");

            Console.WriteLine();
            Console.WriteLine("Snippets:");

            foreach (SnippetReponse snippet in reponse.Batches)
                Console.WriteLine("    (" + snippet.Size + ")    " + snippet.Name + "    [" + snippet.Type + "]    " + snippet.CreationTime + "    " + snippet.UpdateTime);

            // Example ouput:
            //
            //     PageNumber: 1
            //     PagesCount: 12
            //     PageSize:   5
            //     TotalCount: 60
            //     
            //     Snippets:
            //         (1)    C# - fetch current Dirask snippets and display in console    [cs]    2022-05-27 03:23:49    2022-05-27 04:42:43
            //         (2)    C# - request web URL and get response content                [cs]    2022-05-27 02:05:36
            //         (1)    C# - async/await methods with synchronization                [cs]    2022-05-20 11:25:59    2022-05-20 21:16:17
            //         (2)    C# - lock statement usage example                            [cs]    2022-05-20 09:46:34    2022-05-22 01:37:16
            //         (2)    console.log() in C#                                          [cs]    2022-05-18 17:05:41    2022-05-22 19:09:07
        }

        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber=1&pageSize=5&dataOrder=newest&dataGroup=batches&snippetsType=cs";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReposne>(data);
        }
    }
}
