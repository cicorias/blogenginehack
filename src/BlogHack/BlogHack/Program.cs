using MetaWeblogSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogHack
{
    class Program
    {
        //test of GH flow in VS.
        static void Main(string[] args)
        {

            BlogConnectionInfo connection = new BlogConnectionInfo(
                "http://cicoria.com/cs1/blogs/cedarlogic",
                "http://cicoria.com/cs1/blogs/metablog.ashx",
                "zzz",
                "zzz",
                "zzz");


            var client = new Client(connection);

            var blogs = client.GetUsersBlogs();

            foreach (var blog in blogs)
            {
                Console.WriteLine("ID: {0}  Name: {1}", blog.BlogID, blog.BlogName);
            }

            //Console.ReadLine();

            //var title = "test" + Guid.NewGuid().ToString();
            //var description = "body text";
            //List<string> categories = new List<string> { "azure", "security" };

            var imagebits = File.ReadAllBytes("1258.2015-09-10_08-14-03.png-550x0.png");

            //var image = client.NewMediaObject("1258.2015-09-10_08-14-03.png-550x0.png", "image/png", imagebits);

            //Console.WriteLine(image.URL);

            //Console.ReadLine();

            var inFile = File.ReadAllText("post.json");
            var inBody = File.ReadAllText("post.html");



            var post = new { title = "" , categories = new List<string>()};
            

            var postObj = JsonConvert.DeserializeAnonymousType(inFile, post);


            client.NewPost(postObj.title, inBody, postObj.categories, true, DateTime.Now);

        }
    }
}
