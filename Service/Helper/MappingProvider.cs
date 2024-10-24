using Domain.DTOs.External;
using Domain.DTOs.Interanal;
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
                { typeof(IntUserDto), typeof(User) },
                { typeof(CustomerDto), typeof(Customer) },
                { typeof(IntCustomerDto), typeof(Customer) },
                { typeof(IntApplicationDto), typeof(Application) },
                { typeof(CustomerApplicationDto), typeof(CustomerApplication) },
                { typeof(UserCustomerDto), typeof(UserCustomer) }
            };
        }

        public Type GetEntityType(Type dtoType)
        {
            if (_dtoEntityMap.TryGetValue(dtoType, out var entityType))
            {
                return entityType;
            }

            throw new ArgumentException($"No mapping found for DTO type {dtoType}");
        }

        public Type GetEntityType<TDto>()
        {
            return GetEntityType(typeof(TDto));
        }
    }

}
