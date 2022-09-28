using System;
using FriendsTown.Domain.Common;

namespace FriendsTown.Domain
{
    public class Activity : Entity<Guid>
    {
        public Activity(Guid id) : base(id) 
        {
            Id = id;
        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public void Update(string name, string description) 
        {
            Name = name ?? throw new ArgumentException("Name is required");
            Description = description;
        }

        public static Activity Create(Guid id, string name, string description) 
        {
            Activity activity = new Activity(id);
            activity.Update(name, description);

            return activity;
        }
    }
}
