using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.Aggegates.PostAggregate
{
    public class PostComment
    {
        private PostComment()
        {

        }
        public Guid CommentId { get; private set; }
        public Guid PostId { get; private set; }
        public string Text { get; private set; }
        public Guid UserProfileId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }

        // Factories
        public static PostComment CreatePostComment(Guid postId, string text, Guid userProfileId)
        {
            // TO DO: Add validation

            return new PostComment
            {
                PostId = postId,
                Text = text,
                UserProfileId = userProfileId,
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now,
            };
        }

        // Public methods
        public void UpdateCommentText(string newText)
        {
            Text = newText;
            LastModified = DateTime.Now;
        }


    }
}
