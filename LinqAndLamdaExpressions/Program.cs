namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            // 3 - print number of posts for each user.
            var allUserPosts = from post in allPosts
                            group post by post.UserId into userGroup
                            select new { userId = userGroup.Key, count = userGroup.Count() };
            allUserPosts = allUserPosts.OrderBy(group => group.count).ThenBy(group => group.userId).Reverse();
            foreach(var group in allUserPosts)
            {
                Console.WriteLine("UserId: {0}, Count: {1} ", group.userId, group.count);
            }



            // 4 - find all users that have lat and long negative.
            var UsersFromWestOrSouth = allUsers
                .Where(user => { if (user.Address == null || user.Address.Geo == null) return false; return user.Address.Geo.Lat < 0 || user.Address.Geo.Lng < 0; });
            foreach(var wrongGeo in UsersFromWestOrSouth)
            {
                Console.WriteLine("UserId : {0}, Lat: {1}, Lng : {2}", wrongGeo.Id, wrongGeo.Address.Geo.Lat, wrongGeo.Address.Geo.Lng);
            }


            // 5 - find the post with longest body.
            var orderedPostsByLength = (from post in allPosts
                                       orderby post.Body.Length
                                       descending
                                       select post).First();
            Console.WriteLine(orderedPostsByLength.Id + " -> " + orderedPostsByLength.Body);
            // 6 - print the name of the employee that have post with longest body.

            var postUser = (from user in allUsers where user.Id == orderedPostsByLength.UserId select user).First();
            Console.WriteLine("User => Id: {0}, Name: {1}", postUser.Id, postUser.Name);
            // 7 - select all addresses in a new List<Address>. print the list.

            List<Address> addresses = (from user in allUsers select user.Address).ToList();
            addresses.DisplayAddress();

            // 8 - print the user with min lat
            var minLatUser = (from user in allUsers orderby user.Address.Geo.Lat ascending select user).First();
            Console.WriteLine("User: {0}, Lat: {1}", minLatUser.Name, minLatUser.Address.Geo.Lat);

            // 9 - print the user with max long
            var maxLngUser = (from user in allUsers orderby user.Address.Geo.Lng descending select user).First();
            Console.WriteLine("User: {0}, Lat: {1}", maxLngUser.Name, maxLngUser.Address.Geo.Lng);

            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only
            List<UserPosts> userPosts = new List<UserPosts>();
            var userPostsAll =
                (from user in allUsers
                 join post in allPosts on user.Id equals post.UserId into postGroup
                 select new { User = user, Posts = postGroup });
            foreach(var tmp in userPostsAll)
            {
                UserPosts uPost = new UserPosts();
                uPost.User = tmp.User;
                uPost.Posts = tmp.Posts.ToList();
                userPosts.Add(uPost);
            }

            // 11 - order users by zip code

            var zipSortedUsers = allUsers.OrderBy(user => user.Address.Zipcode);
            foreach (var zipUser in zipSortedUsers)
            {
                Console.WriteLine("UserId : {0}, NAme: {1}, Zipcode : {2}", zipUser.Id, zipUser.Name, zipUser.Address.Zipcode);
            }
            // 12 - order users by number of posts
            var userPostsSorted = 
                (from user in allUsers
                join post in allPosts on user.Id equals post.UserId into postGroup
                select new { UserName = user.Name, Posts = postGroup.Count()}).OrderBy(data => data.Posts);
            foreach (var group in userPostsSorted)
            {
                Console.WriteLine("UserId: {0}, Count: {1} ", group.UserName, group.Posts);
            }
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }

        
    }

    public static class Extensions
    {
        public static void DisplayAddress(this List<Address> addresses)
        {
            foreach(Address addr in addresses)
            {
                Console.WriteLine("City: {0}, Street: {1}, Suite: {2}, Zipcode: {3}, Lat: {4}, Lng:{5}", addr.City, addr.Street, addr.Suite, addr.Zipcode, addr.Geo.Lat, addr.Geo.Lng);
            }
        }
    }
}
