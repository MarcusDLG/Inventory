docker build -t inventory-of-drones .

docker tag inventory-of-drones registry.heroku.com/inventory-of-drones/web

docker push registry.heroku.com/inventory-of-drones/web

heroku container:release web -a inventory-of-drones