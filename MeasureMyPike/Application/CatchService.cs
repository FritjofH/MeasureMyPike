using System;

public class CatchService
{
    public bool createCatch(byte[] image, string format, string comment, Model.Lures lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Model.Brand brand)
    {
        DatabaseConnection dbconn = new DatabaseConnection();

        List<Model.Media> mediaList = new List<Model.Media>();
        mediaList.Add(new Model.Media
        {
            MediaFormat = format,
            Image = new Model.MediaData
            {
                Length = image.Length,
                Data = image
            }
        });

        Model.Users user = dbconn.getUser(username);

        Model.Catch cc = new Model.Catch
        {
            User = user,
            Comment = new Model.Comment { Text = comment },
            Media = mediaList,
            Lures = lure,

            Fish = new Model.Fish { Length = fishLength, Weight = fishWeight },
            Location = new Model.Location { Lake = lake, Coordinates = coordinates },
            WeatherData = new Model.WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
            Timestamp = DateTime.Now    // TODO: kanske inte fångades när man knappade inte det
        };

        dbconn.addCatch(cc);
    }
}
