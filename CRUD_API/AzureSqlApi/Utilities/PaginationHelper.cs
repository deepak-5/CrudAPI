// AzureSqlApi/Utilities/PaginationHelper.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureSqlApi.Utilities
{
    public static class PaginationHelper
    {
        public static IEnumerable<T> Paginate<T>(IEnumerable<T> source, int page, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (page < 1)
            {
                page = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10; // Default page size
            }

            int skip = (page - 1) * pageSize;

            return source.Skip(skip).Take(pageSize);
        }
    }
}
