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
            Timestamp = DateTime.Now    // TODO: kanske skicka med istället = fångades
        };

        return dbconn.addCatch(cc);
    }

    public bool updateCatch(int id, byte[] image, string format, string comment, Lures lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username)
    {
        DatabaseConnection dbconn = new DatabaseConnection();

        var c = dbconn.getCatch(id);
        c.Comment = new Comment { Text = comment };
        c.Media.Add(new Media { MediaFormat = format, Image = new MediaData { Length=image.Length, Data=image} });
        c.Lures = lure;
        c.Fish = new Fish { Length = fishLength, Weight = fishWeight };
        c.Location = new Location { Lake = lake, Coordinates = coordinates};
        c.WeatherData = new WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition };
        c.Timestamp = DateTime.Now; // TODO: kanske skicka med istället
        
        return dbconn.updateCatch(id, c);
    }

    public List<Catch> getAllCatch()
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        var c = dbconn.getAllCatch();

        return c;
    }

    public Catch getCatch(int id)
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        var c = dbconn.getCatch(id);

        return c;
    }

    public bool deleteCatch(int id)
    {
        DatabaseConnection dbconn = new DatabaseConnection();

        return dbconn.deleteCatch(id);
    }
}
