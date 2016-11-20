using System;

namespace Bloginek.Data.Domain
{
    public interface IEntity
    {
        bool Deleted { get; }
        Guid Id { get; }
    }
}
