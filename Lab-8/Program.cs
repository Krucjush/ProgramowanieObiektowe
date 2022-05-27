using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab_9
{
    public class Program
    {
        public static void Main()
        {
            var pageNumber = 1;
            var pageSize = 5;
            var snippetsType = "cs";

            var response = FetchSnippets(pageNumber, pageSize, snippetsType);

            Console.WriteLine($"PageNumber:  {response.PageNumber}");
            Console.WriteLine($"PagesCount:  {response.PagesCount}");
            Console.WriteLine($"PageSize:    {response.PageSize}");
            Console.WriteLine($"TotalCount:  {response.TotalCount}");

            Console.WriteLine("\nSnippets:");

            foreach (var snippet in response.Batches)
            {
                Console.WriteLine("    (" + snippet.Size + ")    " + snippet.Name + "    [" + snippet.Type + "]    " + snippet.CreationTime + "    " + snippet.UpdateTime);
            }
        }
        public static string FetchData(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                var encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static PageResponse FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            var url = $"https://dirask.com/api/snippets?pageNumber=1&pageSize=5&dataOrder=newest&dataGroup=batches&snippetsType=cs";
            var data = FetchData(url);

            return JsonSerializer.Deserialize<PageResponse>(data);
        }
    }
}
