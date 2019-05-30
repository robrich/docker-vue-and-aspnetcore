Create the Apps
===============

The first step is to create the apps using each product's CLI:

1. Download .NET Core SDK from https://dotnet.microsoft.com/download/dotnet-core

2. Download Vue.js CLI from NPM using `npm` or `yarn`:

   `npm install -g @vue/cli`

   Install Node from https://nodejs.org/ if needed.

3. Scaffold the .NET project:

   `dotnet new webapi -n NetApi`

4. Scaffold the Vue app using the Vue cli:

   `vue create vueapp`

   This will walk you through a wizard allowing you to pick your favorite options.

5. To call the backend, we added `src/components/ApiValues.vue`, referenced it from `src/App.vue`, and created `vue.config.js` to proxy requests to the back-end.


Results
-------

The contents of this folder are the results of doing these steps.

We'll copy this content into each other scenario as we build `Dockerfile`s for each technique.
