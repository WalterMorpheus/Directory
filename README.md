# Induction Assessment

**Author:** Walter Mutemi  
**Date:** 4 October 2024  

## API Structure

- **API Layer**
  - Controller
    - BaseControllerExtender
    - Authentication
      - AuthenticationServices
    - Application
      - EndpointServices
    - Customer
      - EndpointServices
    - CustomerApplication
      - EndpointServices
    - Person
      - EndpointServices
    - BusinessAreaType
      - EndpointServices
    - BusinessArea
      - EndpointServices
  - DTO
    - UserDto
    - ApplicationDto
    - CustomerDto
    - CustomerApplicationDto
    - PersonDto
    - BusinessAreaDto
    - BusinessAreaTypeDto
  - Helper
    - Automapper Profiles
  - Extension
    - ClaimsPrincipleExtension
    - IdentityServiceExtensions

- **Service Layer**
  - AuthenticationServices
    - IAuthentication
  - EndpointServices
    - IEndpoints

- **Interface Layer**
  - IEndpoints
    - ICreate
    - IRead
    - IUpdate
    - IDelete
  - IAuthentication
    - ILogin
    - IRegister
    - IForgot
  - ICRUD
    - ICreate
    - IRead
    - IUpdate
    - IDelete

- **Entity Layer**
  - User **(created by Microsoft Identity)**
  - Role **(created by Microsoft Identity)**
  - UserRole **(created by Microsoft Identity)**
  - UserConfirmation
  - ExceptionLog
  - Application
  - Customer
  - CustomerApplication
  - Person
  - BusinessArea
  - BusinessAreaType

- **Repository Layer**
  - Application
    - ICRUD
  - Customer
    - ICRUD
  - ApplicationCustomer
    - ICRUD
  - Person
    - ICRUD

---

## EF  useful commends

dotnet ef database update

cd ../Data

dotnet ef migrations add v_xxxxxxxx_db --startup-project ../ApiDirectory




