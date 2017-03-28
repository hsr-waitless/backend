FROM microsoft/dotnet:1.1.1-runtime

WORKDIR /app

COPY Backend/out .

ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Production
EXPOSE 80

ENTRYPOINT ["dotnet", "Backend.dll"]
