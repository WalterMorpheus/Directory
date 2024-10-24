using Microsoft.EntityFrameworkCore;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> IncludeRelatedEntities<TEntity, TDto>(this IQueryable<TEntity> query)
        where TEntity : class
        where TDto : class
    {
        var entityType = typeof(TEntity);
        var dtoType = typeof(TDto);

        // Go through all the properties in the DTO
        foreach (var property in dtoType.GetProperties())
        {
            // If the property is a collection (like ICollection<UserRoleDto>)
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
            {
                var navigationProperty = entityType.GetProperty(property.Name);
                if (navigationProperty != null)
                {
                    // Include the collection navigation property (e.g., UserRoles)
                    query = query.Include(navigationProperty.Name);

                    // Avoid walking back the relationship (which causes EF warnings)
                    var itemType = property.PropertyType.IsGenericType
                        ? property.PropertyType.GetGenericArguments().FirstOrDefault()
                        : null;

                    if (itemType != null && itemType.IsClass && itemType != typeof(string))
                    {
                        // Include nested navigation properties only if they are not cyclical
                        foreach (var nestedProperty in itemType.GetProperties())
                        {
                            // Avoid including properties that would cause EF Core to walk back (e.g., User in UserRole)
                            if (nestedProperty.Name != entityType.Name) // Prevent self-referencing includes
                            {
                                var nestedNavigation = itemType.GetProperty(nestedProperty.Name);
                                if (nestedNavigation != null)
                                {
                                    query = query.Include($"{navigationProperty.Name}.{nestedNavigation.Name}");
                                }
                            }
                        }
                    }
                }
            }
            // Handle single object navigation properties (e.g., Role in UserRoleDto)
            else if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                var navigationProperty = entityType.GetProperty(property.Name);
                if (navigationProperty != null)
                {
                    // Include the single navigation property (e.g., Role)
                    query = query.Include(navigationProperty.Name);

                    // Handle nested navigation properties within the object (e.g., User in UserRole)
                    foreach (var nestedProperty in property.PropertyType.GetProperties())
                    {
                        // Avoid walking back the relationship
                        if (nestedProperty.Name != entityType.Name) // Prevent self-referencing includes
                        {
                            var nestedNavigation = property.PropertyType.GetProperty(nestedProperty.Name);
                            if (nestedNavigation != null)
                            {
                                query = query.Include($"{navigationProperty.Name}.{nestedNavigation.Name}");
                            }
                        }
                    }
                }
            }
        }

        return query;
    }
}
