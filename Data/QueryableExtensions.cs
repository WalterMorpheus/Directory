using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

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
            // Ensure the property is an entity (navigation property) and not a scalar value like int or string
            if (IsNavigationProperty(entityType, property))
            {
                // Handle collection properties (e.g., ICollection<UserRoleDto>)
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                {
                    var navigationProperty = entityType.GetProperty(property.Name);
                    if (navigationProperty != null)
                    {
                        // Include the collection navigation property (e.g., UserRoles)
                        query = query.Include(navigationProperty.Name);

                        // Handle nested relationships within the collection (e.g., Role in UserRoleDto)
                        var itemType = property.PropertyType.IsGenericType
                            ? property.PropertyType.GetGenericArguments().FirstOrDefault()
                            : null;

                        if (itemType != null && itemType.IsClass && itemType != typeof(string))
                        {
                            foreach (var nestedProperty in itemType.GetProperties())
                            {
                                // Only include valid navigation properties and avoid cyclical references or redundant includes
                                if (IsNavigationProperty(itemType, nestedProperty) && !IsBackReference(entityType, nestedProperty))
                                {
                                    query = query.Include($"{navigationProperty.Name}.{nestedProperty.Name}");
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

                        // Handle nested navigation properties within the object (e.g., User in UserRoleDto)
                        foreach (var nestedProperty in property.PropertyType.GetProperties())
                        {
                            // Only include valid navigation properties and avoid cyclical references or redundant includes
                            if (IsNavigationProperty(property.PropertyType, nestedProperty) && !IsBackReference(entityType, nestedProperty))
                            {
                                query = query.Include($"{navigationProperty.Name}.{nestedProperty.Name}");
                            }
                        }
                    }
                }
            }
        }

        return query;
    }

    // Helper method to check if a property is a navigation property (i.e., related entity)
    private static bool IsNavigationProperty(Type entityType, PropertyInfo property)
    {
        // Ensure the property is a class or collection but not a scalar (int, string, etc.)
        return (property.PropertyType.IsClass && property.PropertyType != typeof(string)) ||
               (typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string));
    }

    // Helper method to check if a property is a back reference to avoid cyclical includes
    private static bool IsBackReference(Type entityType, PropertyInfo nestedProperty)
    {
        // Check if the property is a reference back to the entity itself (e.g., User in UserRole)
        return nestedProperty.PropertyType == entityType || nestedProperty.Name == entityType.Name;
    }
}
