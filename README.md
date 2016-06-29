# dotnet-spa
Hello world of aspnet mvc webapi + vue.

Dotnet core 1.0 is finally shipped, and I am considering to use that as my main stack in the future. I don't use razor to generate html in server side, instead, I use c# to write backend api and use javascript to write the web UI.

My working environment now is mac OSX, so I don't use visual studio. Currently I am using vscode, it is not as powerful as VS, but already enough to me.

In this example, it will cover:
* multiple projects in `src`
* unittest with xUnit
* aspnet core webapi
* webpack project hosted in aspnet net

And these are not covered, and might be covered in the future
* authentication, especially social login
* comprehensive logging solution
* secret and configuration management
* js app unit test
* browser testing
* docker image build

### How to run it
* clone, of course
* install dotnet core and nodejs on your machine
* `dotnet restore`
* `npm install`
* `npm run` to list the available scripts, and enjoy!

### Steps to create this project
* create global.json
* tune `.editorconfig` and `.gitignore`
* create dir `src` and `test`
* cretea `calclib` under `src`
* under `calclib`, run `dotnet new -t lib`, and write a simple library
* create dir `calclib-test` under `test`
* under `calclib-test`, run `dotnet new -t xunittest`
* update `project.json`, add dependency to calclib, in current project, also include xunit dependencies
* write unit tests
* `dotnet restore` then `dn test test/calclib-test`, make sure tests all pass.
* now, create the webapi, currently `dotnet new -t web` will create aspnet mvc project, but I only need api. So, use yeoman.
* `npm install -g yo generator-aspnet`
* `yo aspnet` under `src`, create `calcapi` project
* do some cleanup, we don't need everything in the template, e.g. remove IIS, gulp, bower and Docker related files
* add tool dotnet watch: https://github.com/aspnet/dotnet-watch
* add dependency to calclib, and add the logic
* to run the webapi, cd to `src/calcapi`, run `dotnet watch run`, then test the api at `http://localhost:5000`.
* add package.json, add some helper scripts, run with `npm run`
* now, add frontend part, create a vue project (I use vue-cli with webpack-simple), and move files into this project
* put the js app source code in `fe-src`, modify the webpack.config.js
* to develop: open 2 terminal windows: `npm run fedev` and `npm run bedev`. Two instances would watch source code in be and fe.
* use `http://localhost:18000` in browser to test the app, api call would be proxied to `http://localhost:5000`
* to build the application: run `npm run publish`, the final package can be found under `publish` dir
* to verify the dist: run `npm run verifydist`

### References
* [Tutorial on dotnet docs site](https://docs.microsoft.com/en-us/dotnet/articles/core/tutorials/using-on-macos)
