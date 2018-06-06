export ROOT_SRC_DIR := ${pwd}

all:

create-all:
	-$(MAKE) create-namespace
	-$(MAKE) create-mysql
	-$(MAKE) create-mongo
	-$(MAKE) create-postgresql
	-$(MAKE) create-web-app
	-$(MAKE) create-result-app
	-$(MAKE) create-worker-app
	-$(MAKE) create-ingress

delete-all:
	-$(MAKE) delete-mysql
	-$(MAKE) delete-mongo
	-$(MAKE) delete-postgresql
	-$(MAKE) delete-web-app
	-$(MAKE) delete-result-app
	-$(MAKE) delete-worker-app
	-$(MAKE) delete-ingress
	-$(MAKE) delete-namespace

create-namespace:
	kubectl create -f k8s-specifications/namespace.yaml
create-mysql:
	kubectl create -f k8s-specifications/mysql_db.yaml
create-mongo:
	kubectl create -f k8s-specifications/mongo_db.yaml
create-postgresql:
	kubectl create -f k8s-specifications/postgresql_db.yaml
create-web-app:
	kubectl create -f k8s-specifications/web_app.yaml
create-worker-app:
	kubectl create -f k8s-specifications/worker.yaml
create-result-app:
	kubectl create -f k8s-specifications/result_app.yaml
create-ingress:
	kubectl create -f k8s-specifications/ingress1.yaml


delete-namespace:
	kubectl delete -f k8s-specifications/namespace.yaml
delete-mysql:
	kubectl delete -f k8s-specifications/mysql_db.yaml
delete-mongo:
	kubectl delete -f k8s-specifications/mongo_db.yaml
delete-postgresql:
	kubectl delete -f k8s-specifications/postgresql_db.yaml
delete-web-app:
	kubectl delete -f k8s-specifications/web_app.yaml
delete-worker-app:
	kubectl delete -f k8s-specifications/worker.yaml
delete-result-app:
	kubectl delete -f k8s-specifications/result_app.yaml
delete-ingress:
	kubectl delete -f k8s-specifications/ingress1.yaml