Server-rendered SPA
===================

Server-rendering produces the SPA's first render cycle on the server, and ships this customized html to the browser. The SPA boots up on the browser, and continues the interactions from here.


Technique
---------

Inside Visual Studio, choose File -> New -> ASP.NET Core Website, then choose the Angular or React template.  (Sadly no Vue template.)  It uses the same "host both front-end and back-end in one site" solution we saw in chapter 4.  In addition, it includes server-rendered content.  Check the "Add Docker Support" check-box in the new project dialog, and it'll scaffold out the Dockerfile too.


Results
-------

The SPA page is first rendered on the server, producing great SEO-worthy pages on first paint. Then the SPA boots up and continues the interaction. This is great when Search Engine Optimization is key, and works well for users with JavaScript disabled. It requires a server-platform that supports this though (usually Node.js), and generally strays far from the SPA's CLI tools.
