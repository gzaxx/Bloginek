using System;

namespace Bloginek.Data.Domain
{
    public class PostDto : IEntity
    {
        public Guid Id { get; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Preview { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DatePublished { get; set; }        
    }
}