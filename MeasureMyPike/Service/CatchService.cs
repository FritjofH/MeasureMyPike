using MeasureMyPike;
using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;

public class CatchService
{
    public Catch CreateCatch(byte[] image, string format, string comment, Lures lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username)
    {
        CatchRepository dbconn = new CatchRepository();

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
            Timestamp = DateTime.Now    // TODO: kanske skicka med istället = fångades
        };

        return dbconn.AddCatch(cc);
    }

    public bool UpdateCatch(int id, byte[] image, string format, string comment, Lures lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username)
    {
        CatchRepository dbconn = new CatchRepository();

        var c = dbconn.GetCatch(id);
        c.Comment = new Comment { Text = comment };
        c.Media.Add(new Media { MediaFormat = format, Image = new MediaData { Length=image.Length, Data=image} });
        c.Lures = lure;
        c.Fish = new Fish { Length = fishLength, Weight = fishWeight };
        c.Location = new Location { Lake = lake, Coordinates = coordinates};
        c.WeatherData = new WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition };
        c.Timestamp = DateTime.Now; // TODO: kanske skicka med istället
        
        return dbconn.UpdateCatch(id, c);
    }

    public List<Catch> GetAllCatch()
    {
        CatchRepository dbconn = new CatchRepository();
        var c = dbconn.GetAllCatch();

        return c;
    }

    public Catch GetCatch(int id)
    {
        CatchRepository dbconn = new CatchRepository();
        var c = dbconn.GetCatch(id);

        return c;
    }

    public bool DeleteCatch(int id)
    {
        CatchRepository dbconn = new CatchRepository();

        return dbconn.DeleteCatch(id);
    }
}
