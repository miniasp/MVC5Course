using System.Data.Entity.Core.Objects;
using System.Linq;

namespace MVC5Course.Models
{
	public static class RepositoryIQueryableExtensions
	{
		public static IQueryable<T> Include<T>
			(this IQueryable<T> source, string path)
		{
			var objectQuery = source as ObjectQuery<T>;
			if (objectQuery != null)
			{
				return objectQuery.Include(path);
			}
			return source;
		}
	}
}