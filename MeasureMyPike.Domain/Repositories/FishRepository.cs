using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public class FishRepository
    {
        public FishDO GetFish(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedFish = conn.Fish.FirstOrDefault(it => it.Id == id);
                    {
                        if (selectedFish != null)
                        {
                            return selectedFish;
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
                return null;
            }
        }

        public List<FishDO> GetAllFishes()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var fishList = conn.Fish.ToList();

                    return fishList;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public FishDO UpdateFish(int id, string length, string weight)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var fishToUpdate = conn.Fish.FirstOrDefault(it => it.Id == id);
                    fishToUpdate.Id = id;
                    conn.SaveChanges();

                    return fishToUpdate;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteFish(FishDO fishToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Fish.Remove(fishToDelete);
                    conn.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}