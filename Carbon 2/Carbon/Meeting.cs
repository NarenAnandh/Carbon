using System.Collections.Generic;
using System.Linq;

namespace Carbolibrary
{

	public class Meeting
	{

		public Meeting(
			string name,
			string description,
			List<User> users,
			Group group = null)
		{
			Name = name;
			Description = description;
			MeetingUsers = users;
			Group = group;

			Posts = new List<Post>();
			SortedPosts = new List<Post>();
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public Group Group;
		public List<Post> Posts { get; private set; }
		public List<Post> SortedPosts { get; private set; }
		public List<User> MeetingUsers { get; private set; }

		public Post AddPost(string title, string content, List<User> members)
		{
			Post post = new Post(title, content, members, this);
			Posts.Add(post);

			return post;
		}

		public Post AddPost(Post post)
		{
			post.Meeting = this;

			Posts.Add(post);

			return post;
		}

		public void RemovePost(Post post)
		{
			Posts.Remove(post);
		}

	}

}
