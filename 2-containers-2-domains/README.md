2 Containers, 2 Domains
=======================

Let's imagine we'll deploy the SPA to https://www.example.com/ and the back-end API to https://api.example.com/

Because they're separate, each can grow and evolve separately.  This has some up-sides and some downsides.


New content since Chapter 0
---------------------------

1. `NetApi/Dockerfile` and `NetApi/Startup.cs` have references to CORS headers using the `CORS_DOMAIN` environment variable.  We can override this as we launch the container:

   `docker run -e CORS_DOMAIN=https://foo -p 5000:5000 -d net-api`
   
   The variable we're specifying here is the allowed domain(s) that can use this service.

2. `vueapp/.env.production` and `vueapp/src/components/ApiValues.vue` reference `VUE_APP_BASE_URL` environment variable.  This is the api's domain, and gets baked into the image, so we can't override this at runtime.

Because these two environment variables will be different in each environment, we need to carefully adjust these files **each time we build** to link the environments back together.

Note that these URLs aren't between the containers, but rather how the browser referrs to each.  This is because the browser is running the SPA, and making the call to the backend.


Use it: dev
-----------

1. Set the `CORS_DOMAIN` environment variable in `NetApi/Properties/launchSettings.json` or in the Properties pages inside Visual Studio.

2. Set the `VUE_APP_BASE_URL` environment variable in `vueapp/.env.local`.

3. Run the backend outside the container:

   ```
   cd NetApi
   dotnet run
   ```

4. Run the frontend outside the container:

   ```
   cd vueapp
   npm install
   npm run serve
   ```

5. Open the browser to the frontend:

   `http://localhost:8080/`


Use it: production
------------------

1. Adjust the `CORS_DOMAIN` line in `NetApi/Dockerfile`.

2. Adjust the `VUE_APP_BASE_URL` line in `vueapp/.env.production`.

3. Build the .NET image:

   ```bash
   cd NetApi
   docker build -t net-api:2c2d .
   cd ..
   ```

4. Build the Vue.js image:

   ```bash
   cd vueapp
   docker build -t vue-app:2c2d .
   cd ..
   ```

5. Run both containers:

   ```bash
   docker run -p 5000:5000 -d net-api:2c2d
   docker run -p 3000:80 -d vue-app:2c2d
   ```

6. Launch your browser to the vue app:

   `http://localhost:3000/`


Results
-------

Each side can grow independently, they can get deployed independently -- even to different hosting platforms or vendors. But we need to carefully configure `CORS` headers in the API, and carefully configure the API's `BASE_URL` in the front-end.  This configuration must be unique per environment, and may be different for different developers depending on their tools (Docker Desktop vs Minikube vs K3s).
