Dockerfiles for each step
=========================

In this chapter we'll copy the content from `0-CLIs` and add the typical `Dockerfile`s for each project.  When we're done, we'll have fully functional containers, but they won't interact with each other.

New content since Chapter 0
---------------------------

1. `NetApi/Dockerfile` is the file used to package a .NET app, and represents a typical `Dockerfile`.

2. `vueapp/Dockerfile` is the file used to package the Vue.js app.

3. Each folder has a `.dockerignore` file. Like the `.gitignore` file, these files are not copied into the Docker image.

4. `vueapp/nginx.conf` is a config file for Nginx to serve the index.html file as the 404 page.


Use it
------

1. Build the .NET image:

   ```bash
   cd NetApi
   docker build -t net-api:step0 .
   cd ..
   ```

2. Build the Vue.js image:

   ```bash
   cd vueapp
   docker build -t vue-app:step0 .
   cd ..
   ```

Results
-------

This is the typical result we'd get if we followed a "Docker for Vue.js" and a "Docker for ASP.NET Core" tutorial.  Each system is working fine, but they're not working together.

Digging into each technique, we'll see how we can customize the `Dockerfile`s and applications to meet the needs of each hosting and container strategy.
