Docker Isn't All Hype; Create Robust Deployments for Vue.js and ASP.NET Core
============================================================================

This demonstrates various approaches to building a SPA application and supporting backend in Docker. It is the companion code to the [Docker Isn't All Hype](https://robrich.org/slides/docker-vue-and-aspnetcore/#/) presentation.

Vue and ASP.NET were used here purely for demonstration.  The same principles apply to Angular or React, Java or Python, or any technology with a single page app and a supporting back-end.

In each folder, we demonstrate one approach:

- 0-CLIs - Let's scaffold out both projects.

- 0-Dockerfiles-for-each - Classic Dockerfiles for each piece. Here's where most tutorials stop.

- 2-containers-2-domains - We put our website on https://www.example.com/ and our api on https://api.example.com/.

- 2-containers-1-domain - We put both front-end and back-end into separate containers, but stitch them together into a single URL via a Kubernetes Ingress controller.

- 1-container-1-domain - Deploy both SPA and back-end into a single container, using the back-end to host the front-end's static files.

- server-rendered-spa - Visual Studio's New Project template hosts both pieces together and includes server-rendered components.


LICENSE: MIT, Copyright Richardson & Sons, LLC.
