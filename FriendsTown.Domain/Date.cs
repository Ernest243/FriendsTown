using System;
using FriendsTown.Domain.Common;

namespace FriendsTown.Domain
{
    public class Date : ValueObject<Date>
    {
        public Date() { }

        private Date(DateTime date) 
        {
            if (date.CompareTo(DateTime.Now) <= 0) 
            {
                throw new ArgumentException("Date must be greater than today");
            }

            Value = date;
        }

        public DateTime Value { get; protected set; }

        public static Date FromString(string stringDate) 
        {
            if (DateTime.TryParse(stringDate, out var convertedDate))
            {
                return new Date(convertedDate);
            }
            else 
            {
                throw new ArgumentException("Incorrect date");
            }
        }

        public static Date FromDate(DateTime date) => new Date(date);
        public int RemainingDays => (Value - DateTime.Now).Days;

        public string Announcement => $"We wait for you on " + $" {Value.ToShortDateString()}";
    }
}
