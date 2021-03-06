﻿using System.Drawing;
using System.IO;
using System.Linq;

namespace MeasureMyPike.Service
{
    public class MediaService : IMediaService
    {
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public string GetImageFormat(Image imageIn)
        {
            return typeof(System.Drawing.Imaging.ImageFormat)
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .ToList()
                .ConvertAll(property => property.GetValue(null, null))
                .Single(image_format => image_format.Equals(imageIn.RawFormat))
                .ToString();
        }
    }
}
