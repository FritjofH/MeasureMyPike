﻿using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Domain.Models;
using System.Data.Entity;

namespace MeasureMyPike.Repo
{
    public class LureRepository : ILureRepository
    {
        public LureDO AddLure(LureDO newLure)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Brand.Attach(newLure.Brand);
                    var createdLure = conn.Lure.Add(newLure);
                    conn.SaveChanges();

                    return createdLure;
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

        public LureDO GetLure(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedLure = conn.Lure.Where(it => it.Id == id).Include(it => it.Brand).FirstOrDefault();
                    {
                        if (selectedLure != null)
                        {
                            return selectedLure;
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

        public List<LureDO> GetAllLures()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var lureList = conn.Lure.Include(it => it.Brand).ToList();

                    return lureList;
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

        public bool UpdateLure(int id, string lureName, int weight, string colour)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var lureToUpdate = conn.Lure.FirstOrDefault(it => it.Id == id);

                    conn.Lure.Attach(lureToUpdate);
                    
                    lureToUpdate.Name = lureName;
                    lureToUpdate.Weight = weight;
                    lureToUpdate.Colour = colour;
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

        public bool DeleteLure(LureDO lureToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Lure.Attach(lureToDelete);
                    conn.Lure.Remove(lureToDelete);
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