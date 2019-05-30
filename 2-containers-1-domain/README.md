2 Containers, 1 Domain
======================

In this technique, we assume both website and api are running on the same subdomain -- both on https://www.example.com/.  Yet they're deployed as separate containers so we can scale each differently.

In production, a Kubernetes [Ingress](https://kubernetes.io/docs/concepts/services-networking/ingress/) links the two sites together.  (We could also use an Nginx or HAProxy.)

In development, [Webpack](https://stackoverflow.com/a/49846977/702931) proxies content through the Webpack development server to the api.

We assume here that all resources on `/api/*` are to go to the backend, and all other urls go to the frontend.


New content since Chapter 0
---------------------------

1. `Kubernetes` folder contains all the files used to install both docker images into the cluster, and rig them behind the ingress controller.

2. `vueapp/vue.config.js` is for development only, and hooks up Webpack development server.  It looks for requests to `/api/any/path/here` and forwards it to the backend.


Use it: dev
-----------

1. Run the backend outside the container:

   ```
   cd NetApi
   dotnet run
   ```

2. Run the frontend outside the container:

   ```
   cd vueapp
   npm install
   npm run serve
   ```

3. Open the browser to the frontend:

   `http://localhost:8080/`


Use it: production
------------------

1. Build both the backend and frontend images:

   ```
   cd NetApi
   docker build -t net-api:2c1d .
   cd ..
   cd vueapp
   docker build -t vue-app:2c1d .
   cd ..
   ```

2. Install the kubernetes content:

   ```
   kubectl apply -f Kubernetes
   ```

   kubectl will loop through all the files, installing each one.

3. Get the IP for the ingress controller:

   ```
   kubectl get ingress spa-and-api
   ```

4. Launch your browser to the Kubernetes Cluster IP:

   `http://localhost:80/`


Results
-------

We have the best of both worlds.  We don't have the complexity of `CORS` headers or `BASE_URL` environment variables, yet we can scale each container separately. The price for this solution: we need a complex container orchestrator such as Kubernetes to proxy traffic from a single load balancer to the proper container.
