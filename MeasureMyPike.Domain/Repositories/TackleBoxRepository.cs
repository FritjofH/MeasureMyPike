using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Domain.Interfaces;

namespace MeasureMyPike.Repo
{
    public class TackleBoxRepository : ITackleBoxRepository
    {

        public TackleBoxDO AddTackleBox(TackleBoxDO newTackleBox)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var createdTackleBox = conn.TackleBox.Add(newTackleBox);
                    conn.SaveChanges();

                    return createdTackleBox;
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

        public TackleBoxDO GetTackleBox(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedTackleBox = conn.TackleBox.First(u => u.Id == id);

                    return selectedTackleBox;
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

        public bool DeleteTackleBox(TackleBoxDO tackleBoxToDelete)
        {
            try
            {                
                using (var conn = new ModelContainer())
                {
                    conn.TackleBox.Attach(tackleBoxToDelete);
                    // we should disconnect all Lures that belong to this tacklebox!
                    // or is that done automagically?
                    conn.TackleBox.Attach(tackleBoxToDelete);
                    tackleBoxToDelete.Lure.Clear();
                    conn.TackleBox.Remove(tackleBoxToDelete);
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