namespace Forum.App.Services
{
    using System.Collections.Generic;
    using Contracts;
    using Forum.Data;

    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            throw new System.NotImplementedException();
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public string GetCategoryName(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            throw new System.NotImplementedException();
        }
    }
}
