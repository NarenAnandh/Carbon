using System;
using System.Collections.Generic;

namespace Carbolibrary
{

	public class Post
	{

		public Post(
			string title,
			string content,
			List<User> members,
			Meeting meeting = null)
		{
			Title = title;
			Content = content;
			Users = members;
			Meeting = meeting;
			Date = DateTime.Now;
			Editable = true;
		}

		public List<User> Users { get; set; }
		public DateTime Date { get; set; }
		public string Content { get; set; }
		public string Title { get; set; }
		public bool Editable { get; set; }
		public Meeting Meeting { get; set; }

	}

}
