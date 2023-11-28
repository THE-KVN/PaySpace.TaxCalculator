# PaySpace.TaxCalculator
Create a small full stack solution to do tax calculations using .NET Core using MVC Razor.

I used Clean Architecture and ASP.NET Core to develop this solution.

## Table of Contents

- [Installation](#installation)
- [Technologies](#technologies)

## Installation
The solution has two running parts.
1. PaySpace.TaxCalculator.API : Resftful api.
   Database : A sqlite database is included in the solution to use (called tax.db) , the DefaultConnection can be set in the appsetting.json file for the project
2. PaySpace.TaxCalculator.UI : UI for the tax calculator.
   APIUrl: The UI needs to know where the api endpoints are listening (set to https://localhost:7279/ at the moment) the APIUrl can be set in the appsetting.json file for the project

## Technologies

    ASP.NET Core 8
    Entity Framework Core 8
    MediatR
    AutoMapper
    FluentValidation
    NUnit

