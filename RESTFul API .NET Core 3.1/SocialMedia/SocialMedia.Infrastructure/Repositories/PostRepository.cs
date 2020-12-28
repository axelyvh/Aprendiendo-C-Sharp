using SocialMedia.Core.Entitties;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {

        public async Task<IEnumerable<Post>> GetPosts() {

            var posts = Enumerable.Range(1, 10).Select(x => new Post { 
                PostId = x,
                Description = $"Descripcion {x}",
                Date = DateTime.Now,
                Image = $"htpps://miapis.com/{x}",
                UserId = x * 2
            });

            await Task.Delay(1000);

            return posts;

        }

    }
}
