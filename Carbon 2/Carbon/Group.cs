using System;
using System.Collections.Generic;

namespace Carbolibrary
{

	public class Group
	{

		public Group(string name, string description = "", List<User> users = null)
		{
			Name = name;
			Description = description;
			Users = users;
			Meetings = new List<Meeting>();

			if (users == null)
				Users = new List<User>();
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public List<Meeting> Meetings { get; private set; }
		public List<User> Users { get; private set; }

		public void AddUser(User user)
		{
			Users.Add(user);
		}

		public void RemoveUser(User user)
		{
			Users.Remove(user);
		}

		public Meeting AddMeeting(string name, string description, List<User> members)
		{
			Meeting meeting = new Meeting(name, description, members, this);

			Meetings.Add(meeting);

			return meeting;
		}

		public Meeting AddMeeting(Meeting meeting)
		{
			meeting.Group = this;

			Meetings.Add(meeting);

			return meeting;
		}

		public void RemoveMeeting(Meeting meeting)
		{
			Meetings.Remove(meeting);
		}

	}

}
