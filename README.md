# Loans App

## Introduction

This app will accept several inputs and make a loan approval using acceptance criteria

## Prerequisites

> .NET8

## Approach

First I created xUnit tests with names that correlated with the requirements

Next I built a service that satisfied these requirements

I ensured that all tests for the decision engine passed so that all requirements were met

Finally I created the console user interaction

## Things not done in the interest of time

There are loads of numbers hard coded that should be coming from configuration - a combo of Key Vault, appsettings and user secrets

I did not implement dependency injection as with console apps there's some boilerplate required that 1 hour did not allow for. This would be essential for unit testing of the GetReport method.

I did not validate user input, again in the interest of the time allotted. Full validation of user input would be required at least to make sure they entered numerical values!

I did not implement a logging provider or exception middleware, but I did put exception handling in the service and comment where I would normally log exceptions. Geenrally I would let exceptions bubble up and log them at the last minute.

Because the repository is fake it is not asyncronous, it would all need to return Tasks and be made async if the repository were real.