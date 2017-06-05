﻿using MeasureMyPike.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;

namespace MeasureMyPike
{
    public class DatabaseConnection
    {
        public bool createUser(string lastName, string firstName, string username, string passwordHash)
        {
            using (var conn = new ModelContainer())
            {
                if (conn.Users.FirstOrDefault(it => it.Username == username) == null)
                {
                    conn.Users.Add(new Model.User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Username = username,
                        MemberSince = DateTime.Now,
                        Security = new Model.Security { Password = passwordHash }
                    });

                    conn.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public string deleteUser(string username)
        {
            using (var conn = new ModelContainer())
            {
                Model.User user = conn.Users.First(u => u.Username == username);
                if (user != null)
                {
                    conn.Users.Remove(user);
                    conn.SaveChanges();
                    return "Användaren har raderats";
                }

                return "Det finns ingen användare med det angivna användarnamnet";
            }
        }

        public string getUserPassword(string username)
        {
            using (var conn = new ModelContainer())
            {
                return conn.Users.First(it => it.Username == username).Security.Password;
            }
        }

        public string addLure(string lureName, Model.Brand brand)
        {
            using (var conn = new ModelContainer())
            {
                if (conn.Lures.FirstOrDefault(it => it.Name == lureName) == null)
                {

                    conn.Lures.Add(new Model.Lures
                    {
                        Name = lureName,
                        Brand = brand,
                        Catch = null
                    });
                    conn.SaveChanges();
                    return "Lure har skapats";
                }
            }
            return "Det finns redan en Lure med det angivna Lurenamnet, försök igen med ett annat Lurenamn";
        }

        public string addBrand(Model.Brand brand)
        {
            using (var conn = new ModelContainer())
            {
                if (conn.Brand.FirstOrDefault(it => it.Name == brand.Name) == null)
                {

                    conn.Brand.Add(new Model.Brand
                    {
                        Name = brand.Name

                    });
                    conn.SaveChanges();
                    return "Brand har skapats";
                }
            }
            return "Det finns redan en Brand med det angivna Brandnamnet, försök igen med ett annat Brandnamn";
        }

        public Model.Brand getBrand(Model.Brand brand)
        {
            using (var conn = new ModelContainer())
            {
                Model.Brand o = conn.Brand.FirstOrDefault(it => it.Id == brand.Id);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public bool createCatch(byte[] image, string format, string comment, string lures, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Model.Brand brand)
        {
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

            using (var conn = new ModelContainer())
            {
                conn.Catch.Add(new Model.Catch
                {
                    User = conn.Users.First(),
                    Comment = new Model.Comment { Text = comment },
                    Media = mediaList,
                    Lures = new Model.Lures { Name = lures, Brand = brand },

                    Fish = new Model.Fish { Length = fishLength, Weight = fishWeight },
                    Location = new Model.Location { Lake = lake, Coordinates = coordinates },
                    WeatherData = new Model.WeatherData { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
                    Timestamp = DateTime.Now
                });

                conn.SaveChanges();
                return true;
            }
        }
    }
}
