# OrderApplicationMicro
This project micro service implementation for order and customer domains. The ddd approach has been tried to be taken as an example.

# Requirements

* .NET 5
* .SQLSERVER
# How to run
Solution properties and multiple startup project customer api, order api and gateway api
![MultipleStart](https://user-images.githubusercontent.com/65852808/138621437-db47a1da-4caf-419e-9e2e-d4d0197fc80e.png)

# Gateway
Created gateway with ocelot also i use MMLib.SwaggerForOcelot so you can manage your microservices from gateway swagger easily you can see the endpoints below from gateway

![GatewaySwaggerChange](https://user-images.githubusercontent.com/65852808/138620621-0670bed6-6e6d-4c06-92f6-56368a74f7f9.png)
![GatewayOrder](https://user-images.githubusercontent.com/65852808/138620767-f596b746-d5e7-4b47-a2e3-37edadd7bb01.png)
# 

# Equipments
* FluentValidation
* EFCore
* AutoMapper
* Ocelot
* MMlib.SwaggerForOcelot
* MMlib.Ocelot.Provider.AppConfiguration
* Swagger
