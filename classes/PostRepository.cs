using System.Collections.Generic;
using firstDotNetProj.interfaces;
namespace firstDotNetProj.classes
{
    public class PostRepository : IRepository<Post>
    {
        public List<Post> postList = new List<Post>();
        public void erase(int id)
        {
            postList[id].delete();
        }

        public void insert(Post _object)
        {
            postList.Add(_object);
        }

        public List<Post> List()
        {
            return postList;
        }

        public int nextId()
        {
            return postList.Count;
        }

        public Post returbById(int id)
        {
            return postList[id];
        }

        public void update(int id, Post _object)
        {
            postList[id] = _object;
        }
    }
}