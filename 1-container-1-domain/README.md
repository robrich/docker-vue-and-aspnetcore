1 Container, 1 Domain
=====================

In this technique, both front-end and back-end run from the same container built from a single `Dockerfile`.  We can't scale them separately, but we deploy changes in either simultaniously.


New content since Chapter 0
---------------------------

1. `NetApi/Startup.cs` adds `DefaultFiles` and `StaticFiles` references so .NET can serve the JavaScript, CSS, and images.

2. `NetApi/Controllers/SpaController.cs` serves the `index.html` page for each route in the Vue app.

3. `vueapp/vue.config.js` is for development only, and hooks up Webpack development server.  It looks for requests to `/api/any/path/here` and forwards it to the backend.

4. `vueapp/nginx.conf` is gone. We use .NET's Kestrel web server for that now.

5. `Dockerfile` at the root of the solution replaces the files in each project.  This single file builds stages for each application.


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

1. Build and run the single container:

   ```
   docker build -t spa-and-api:1c1d .
   docker run -p 5000:5000 -d spa-and-api:1c1d
   ```

2. Launch your browser to the app:

   `http://localhost:5000/`


Results
-------

In dev, we leverage Webpack Dev Server to proxy through the front-end to the back-end.  In Production, we deploy the SPA's static files into the back-end's static files directory (`public` or `wwwroot` or similar).
