using System.Collections.Generic;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public interface IMediaRepository
    {
        MediaDataDO AddMediaData(MediaDataDO newMediaData);
        MediaDO AddMedia(MediaDO newMedia);
        bool DeleteMediaData(MediaDataDO mediaDataToDelete);
        bool DeleteMedia(MediaDO mediaToDelete);
        List<MediaDataDO> GetAllMediaData();
        List<MediaDO> GetAllMedia();
        MediaDataDO GetMediaData(int id);
        MediaDO GetMedia(int id);
    }
}