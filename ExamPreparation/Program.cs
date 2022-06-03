using System;
using System.IO;
using System.Threading;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var monitor = new FileMonitor(@"D:\Users\dawid.studzizba\Desktop\sfd.txt");
            monitor.SizeChanged += Monitor_sizeChanged;
            Thread.Sleep(10000);
            monitor.Dispose();
        }

        private static void Monitor_sizeChanged(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine($"Rozmiar pliku ulegl zmianie. {e.FileSize}");
        }
    }
    public class SizeChangedEventArgs : EventArgs
    {
        public long FileSize { get; set; }
        public SizeChangedEventArgs(long fileSize)
        {
            FileSize = fileSize;
        }
    }

    public class FileMonitor : IDisposable
    {
        public event EventHandler SizeChanged;
        private volatile bool _looped = true;
        private bool _disposed;
        protected virtual void OnSizeChanged(long fileSize) => SizeChanged?.Invoke(this, new SizeChangedEventArgs(fileSize));
        public FileMonitor(string path)
        {
            var t = new Thread(() =>
            {
                long previewFileSize = 0;
                while(_looped)
                {
                    if (!File.Exists(path)) return;
                    var file = new FileInfo(path);
                    var fileSize = file.Length;
                    if (previewFileSize != fileSize)
                    {
                        previewFileSize = fileSize;
                        OnSizeChanged(previewFileSize);
                    }
                    Thread.Sleep(1000);
                }
            }
            );
            t.Start();
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _looped = false;
                
            }
        }
    }
}
