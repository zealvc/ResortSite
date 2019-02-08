using InstaSharper.API;
using InstaSharper.Classes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Resort.Application.Instagrams.Commands
{
    public class ChangeInstaCommand
    {
        
        private readonly IInstaApi _instaApi;

        public ChangeInstaCommand(IInstaApi instaApi)
        {
            _instaApi = instaApi;
        }

        public async Task DoShow(string path, string caption)


        {

            var mediaImage = new InstaImage
            {
                Height = 1080,
                Width = 1080,
                URI = new Uri(Path.GetFullPath(@"c:\" + path), UriKind.Absolute).LocalPath
            };
            var result = await _instaApi.UploadPhotoAsync(mediaImage, caption);
            Console.WriteLine(result.Succeeded
                ? $"Media created: {result.Value.Pk}, {result.Value.Caption}"
                : $"Unable to upload photo: {result.Info.Message}");
        }

    }
}

