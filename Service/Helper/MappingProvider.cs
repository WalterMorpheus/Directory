using Domain.DTOs.External;
using Domain.Entity.Auth;
using Domain.Entity.Core;

namespace Service.MappingProfiles
{
    public class MappingProvider
    {
        private readonly Dictionary<Type, Type> _dtoEntityMap;

        public MappingProvider()
        {
            _dtoEntityMap = new Dictionary<Type, Type>
            {
                { typeof(ApplicationDto), typeof(Application) },
                { typeof(BusinessTypeDto), typeof(BusinessAreaType) },
                { typeof(UserDto), typeof(User) },
                { typeof(CustomerDto), typeof(Customer) },
                { typeof(UserCustomerApplicationDto), typeof(UserCustomerApplication) },
                { typeof(UserRoleDto), typeof(UserRole) },
                { typeof(RoleDto), typeof(Role) }
            };
        }

        public Type GetEntityType(Type dtoType)
        {
            if (_dtoEntityMap.TryGetValue(dtoType, out var entityType))
            {
                return entityType;
            }

            throw new InvalidOperationException($"No mapping found for DTO type {dtoType}");
        }

        public Type GetEntityType<TDto>()
        {
            return GetEntityType(typeof(TDto));
        }
    }

}
