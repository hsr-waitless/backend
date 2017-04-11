# Backend

[![Build Status](https://travis-ci.org/hsr-waitless/backend.svg?branch=master)](https://travis-ci.org/hsr-waitless/backend)

## Requirements
- https://www.microsoft.com/net/core

## Install dependecies
```
dotnet restore
```

## Run Backend
```
dotnet run watch
```

## Create Migrations
*All commands need to be executed in the Database folder!*

```
dotnet ef -s ../Backend migrations add {Name}
```

## Apply Migrations (Local)
```
dotnet ef -s ../Backend database update
```

## Apply Migrations (Production)
```
dotnet ef -s ../Backend database update --environment Production
```