
SET COMPOSE_CONVERT_WINDOWS_PATHS=1

docker-compose -f docker.environment/workspace.docker-compose.yml up -d 
docker-compose -f docker.microservices/docker-compose.microservices.yml up --build

pause