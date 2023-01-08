# Clean Architechture
Demo of C# Clean Architechture
ref: https://github.com/jasontaylordev/CleanArchitecture
ref: https://jasontaylor.dev/clean-architecture-getting-started/

> ![concept](/images/concept.jpg)
จุดประสงค์ของการใช้ Clean Architecture จะช่วยให้เราสามารถแยก layer ของโค้ด โดยในแต่ละ layer ก็จะทำงานของตัวเองอย่างชัดเจนไปเลย หรือที่เราเรียกว่า separation of concern นั่นเอง

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




- **Independent of Frameworks** หมายความว่า โค้ดที่เราเขียนจะไม่ผูกติดอยู่กับ framework ไปทุกส่วนของโค้ด ในวันไหนที่เราอยากจะเปลี่ยนไปใช้ framework อื่นๆ จะได้ปรับเปลี่ยนได้อย่างง่ายขึ้น

- **Testable** หมายถึง เราจะสามารถ test code ของเราง่ายขึ้น

- **Independent of UI** เมื่อเราแยกส่วนของ UI ออกจาก business logic แล้ว สิ่งที่ง่ายขึ้นก็คือ เราสามารถเปลี่ยนแปลง UI ได้โดยไม่ต้องกังวลว่า business logic จะพังทลายไปด้วยหรือเปล่า

- **Independent of Database** เป็นการแยกส่วนที่ติดต่อกับ database ออกมา สมมติเหตุการณ์สักหน่อย ก็คงจะนึกถึง case ของ เวลาเราสร้าง project ขึ้นมาใหม่ เราใช้ database sqlite แต่นานวันเข้า sqlite ไม่ตอบโจทย์ของการใช้งานของ user จริงๆ บน production เราจะต้องเปลี่ยน database ไปใช้ Oracle แทน เราก็สามารถทำได้ง่าย เพราะเราได้แยก layer ไว้อยู่ที่ layer เดียวแล้ว

- **Independent of any external agency** หมายถึง business logic ต่างๆ จะไม่รู้ว่าเกิดอะไรขึ้นภายในโค้ดที่ business logic สนใจเลยยย