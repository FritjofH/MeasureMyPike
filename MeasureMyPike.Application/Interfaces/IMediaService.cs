using System.Drawing;

namespace MeasureMyPike.Service
{
    public interface IMediaService
    {
        string GetImageFormat(Image imageIn);
        byte[] ImageToByteArray(Image imageIn);
    }
}