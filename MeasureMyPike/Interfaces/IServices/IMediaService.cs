using System.Drawing;

namespace MeasureMyPike.Service
{
    public interface IMediaService
    {
        string getImageFormat(Image imageIn);
        byte[] ImageToByteArray(Image imageIn);
    }
}