FROM microsoft/dotnet:1.0.4-runtime

WORKDIR /app

COPY Api/out .

ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "Api.dll"]