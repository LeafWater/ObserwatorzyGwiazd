using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace ObserwatorzyGwiazd
{
    class PobraniePliku
    {
        public IDownloadFile File;
        bool isDownloading = true;

        // 3 metody związane z pobieraniem pliku z internetu
        public async void DownloadFile(String FileName)
        {
            await Task.Yield();
            await Task.Run(() =>
            {
                var downloadManager = CrossDownloadManager.Current;
                var file = downloadManager.CreateDownloadFile(FileName);
                downloadManager.Start(file, true);
                while (isDownloading)
                {
                    isDownloading = IsDownloading(file);
                }
            });
        }
        public bool IsDownloading(IDownloadFile File)
        {
            if (File == null) return false;

            switch (File.Status)
            {
                case DownloadFileStatus.INITIALIZED:
                case DownloadFileStatus.PAUSED:
                case DownloadFileStatus.PENDING:
                case DownloadFileStatus.RUNNING:
                    return true;

                case DownloadFileStatus.COMPLETED:
                case DownloadFileStatus.CANCELED:
                case DownloadFileStatus.FAILED:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void AbortDownloading()
        {
            CrossDownloadManager.Current.Abort(File);
        }


    }
}
