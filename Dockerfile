FROM microsoft/dotnet:1.1.1-runtime

WORKDIR /app

COPY Backend/out .

ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Api.dll"]
