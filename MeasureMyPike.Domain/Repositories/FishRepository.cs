﻿using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Domain.Interfaces.IRepositories;

namespace MeasureMyPike.Repo
{
    public class FishRepository : IFishRepository
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public bool UpdateFish(int id, int length, int weight)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var fishToUpdate = conn.Fish.FirstOrDefault(it => it.Id == id);
                    conn.Fish.Attach(fishToUpdate);
                    fishToUpdate.Length = length;
                    fishToUpdate.Weight = weight;
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

        public bool DeleteFish(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var fishToDelete = conn.Fish.First(it => it.Id == id);
                    conn.Fish.Attach(fishToDelete);
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }
    }
}