dotnet publish -c Release -o ou

docker build -t no0dles/waitless-backend
docker login --username $DOCKER_USER --password $DOCKER_PASS
docker push no0dles/waitless-backend
