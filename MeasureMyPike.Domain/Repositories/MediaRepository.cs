using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Domain.Interfaces.IRepositories;
using System.Data.Entity;

namespace MeasureMyPike.Repo
{
    public class MediaRepository : IMediaRepository
    {
        public MediaDO AddMedia(MediaDO newMedia)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var created = conn.Media.Add(newMedia);
                    conn.SaveChanges();

                    return created;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public MediaDataDO AddMediaData(MediaDataDO newMediaData)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var created = conn.MediaData.Add(newMediaData);
                    conn.SaveChanges();

                    return created;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public bool DeleteMedia(MediaDO mediaToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Media.Attach(mediaToDelete);
                    conn.MediaData.Attach(mediaToDelete.Image);
                    conn.Media.Remove(mediaToDelete);
                    conn.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public bool DeleteMediaData(MediaDataDO mediaDataToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.MediaData.Attach(mediaDataToDelete);
                    conn.MediaData.Remove(mediaDataToDelete);
                    conn.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public List<MediaDO> GetAllMedia()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var result = conn.Media.ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public List<MediaDataDO> GetAllMediaData()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var result = conn.MediaData.Include(it=>it.Media).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public MediaDO GetMedia(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selected = conn.Media.Where(it => it.Id == id).FirstOrDefault();
                    {
                        if (selected != null)
                        {
                            return selected;
                        }
                        else return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public MediaDataDO GetMediaData(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selected = conn.MediaData.Where(it => it.Id == id).Include(it=>it.Media).FirstOrDefault();
                    {
                        if (selected != null)
                        {
                            return selected;
                        }
                        else return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
    }
}