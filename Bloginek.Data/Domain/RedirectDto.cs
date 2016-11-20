using System;

namespace Bloginek.Data.Domain
{
    public class RedirectDto : IEntity
    {
        public Guid Id { get; }
        public bool Deleted { get; set; }
        public string RedirectTo { get; set; }
        public string RedirectFrom { get; set; }
    }
}
