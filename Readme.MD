# Clean Architechture
ref: https://jasontaylor.dev/clean-architecture-getting-started/

> ![concept](/images/concept.jpg)
�ش���ʧ��ͧ����� Clean Architecture �Ъ�������������ö�¡ layer �ͧ�� ������� layer ��зӧҹ�ͧ����ͧ���ҧ�Ѵਹ���� ���ͷ��������¡��� separation of concern ����ͧ

> ![Structure](/images/structure.png)
- The project names with in `src` folder
- The `Domain` represents the Domain layer and contains enterprise or domain logic and includes entities, enums, exceptions, interfaces, types and logic specific to the domain layer. This layer has no dependencies on anything external.
- The `Application` represents the Application layer and contains all business logic. This project implements CQRS (Command Query Responsibility Segregation), with each business use case represented by a single command or query. This layer is dependent on the Domain layer but has no dependencies on any other layer or project.This layer defines interfaces that are implemented by outside layers. For example, if the application needs to access a notification service, a new interface would be added to the Application and the implementation would be created within Infrastructure.
- The `Infrastructure` represents the Infrastructure layer and contains classes for accessing external resources such as file systems, web services, SMTP, and so on. These classes should be based on interfaces defined within the Application layer.
- The `WebApi` represents the Presentation layer.This layer depends on both the Application and Infrastructure layers. Please note the dependency on Infrastructure is only to support dependency injection. Therefore Startup.cs should include the only reference to Infrastructure.

## Tests
The tests folder contains numerous unit and integration tests projects to help get you up and running quickly. The details of these projects will be explored in a follow-up post. In the meantime, feel free to explore and ask any questions below.

## Technologies
Aside from .NET Core, numerous technologies are used within this solution including:

- CQRS with MediatR
- Validation with FluentValidation
- Object-Object Mapping with AutoMapper
- Data access with Entity Framework Core
- Web API using ASP.NET Core
- Open API with Swagger
- Security using ASP.NET Core Identity + IdentityServer
- Automated testing with xUnit.net, Moq, and Shouldly




- **Independent of Frameworks** ���¤������ �鴷�������¹�����١�Դ����Ѻ framework 价ء��ǹ�ͧ�� ��ѹ�˹��������ҡ������¹��� framework ���� �����Ѻ����¹�����ҧ���¢��

- **Testable** ���¶֧ ��Ҩ�����ö test code �ͧ��ҧ��¢��

- **Independent of UI** ���������¡��ǹ�ͧ UI �͡�ҡ business logic ���� ��觷����¢�鹡��� �������ö����¹�ŧ UI ��������ͧ�ѧ����� business logic �оѧ����仴�����������

- **Independent of Database** �繡���¡��ǹ���Դ��͡Ѻ database �͡�� ������˵ء�ó��ѡ˹��� �礧�й֡�֧ case �ͧ ����������ҧ project ��������� ����� database sqlite ��ҹ�ѹ��� sqlite ���ͺ⨷��ͧ�����ҹ�ͧ user ��ԧ� �� production ��Ҩе�ͧ����¹ database ��� Oracle ᷹ ��ҡ�����ö������� ����������¡ layer ��������� layer ��������

- **Independent of any external agency** ���¶֧ business logic ��ҧ� ������������Դ���â�������鴷�� business logic ʹ������