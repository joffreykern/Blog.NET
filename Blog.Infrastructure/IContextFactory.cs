using Blog.Core;
using System;
namespace Blog.Infrastructure
{
    public interface IContextFactory
    {
        EntitiesModel Get();
    }
}
