using System;
using System.Collections.Generic;

namespace GildedRose.Console.Services
{
    /// <summary>
    /// Services Repository with Per-Request Instances
    /// </summary>
    public class Service
    {
        // ----------------------
        // Exported Services
        // ----------------------

        public static ItemService ItemService => GetInstance(() => { return new ItemService(Program.Items); });


        /// <summary>
        /// Get Service Instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Factory"></param>
        /// <returns></returns>
        private static T GetInstance<T>(Func<T> Factory)
        {
            return Factory.Invoke();
        }


    }
}