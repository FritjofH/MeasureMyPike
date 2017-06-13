using MeasureMyPike;
using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;

public class CatchService
{
    public bool createCatch(byte[] image, string format, string comment, Lures lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username)
    {
        DatabaseConnection dbconn = new DatabaseConnection();

        List<Media> mediaList = new List<Media>();
        mediaList.Add(new Media
        {
            MediaFormat = format,
            Image = new MediaData
            {
                Length = image.Length,
                Data = image
            }
        });

        //User user = dbconn.getUserPasswordHash(username);

        Catch cc = new Catch
        {
            //User = user,
            Comment = new Comment { Text = comment },
            Media = mediaList,
            Lures = lure,
            Fish = new Fish { Length = fishLength, Weight = fishWeight },
            Location = new Location { Lake = lake, Coordinates = coordinates },
            WeatherData = new WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
            Timestamp = DateTime.Now    // TODO: kanske inte fångades när man knappade inte det
        };

        return dbconn.addCatch(cc);
    }
}
