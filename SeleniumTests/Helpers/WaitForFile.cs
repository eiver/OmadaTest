using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests.Helpers
{
    class WaitForFile
    {
        public static bool WaitUntilExists(string path, TimeSpan timeout)
        {
            ManualResetEvent fileFoundEvent = new ManualResetEvent(false);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            Task.Run(() => 
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (File.Exists(path)) fileFoundEvent.Set();
                    cancellationToken.WaitHandle.WaitOne(500);
                    System.Diagnostics.Debug.WriteLine("waiting");
                }
            }, cancellationToken);

            bool fileFound = fileFoundEvent.WaitOne(timeout);

            cancellationTokenSource.Cancel();
            return fileFound;
        }
    }
}
