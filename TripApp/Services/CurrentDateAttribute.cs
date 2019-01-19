using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using TripApp.Models;

namespace TripApp.Services
{
    class CurrentDateAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            using (AppDbContext db = new AppDbContext())
            {
                //if (dt >= db.Trips)
                    return true;
            }
            //return false;

        }
    }
}
