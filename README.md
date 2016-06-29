# dotnet-spa
Hello world of aspnet mvc webapi + vue.

Dotnet core 1.0 is finally shipped, and I am considering to use that as my main stack in the future. I don't use razor to generate html in server side, instead, I use c# to write backend api and use javascript to write the web UI.

In this example, it will cover:
* multiple projects in `src`
* unittest with xUnit
* aspnet core webapi
* webpack project hosted in aspnet net

### Steps to create this project
* create global.json
* tune `.editorconfig` and `.gitignore`
* create dir `src` and `test`
* cretea `calclib` and `calcapi` under `src`
* under `calclib`, run `dotnet new -t lib`, and write a simple library
* create dir `calclib-test` under `test`
* under `calclib-test`, run `dotnet new -t xunittest`
* update `project.json`, add dependency to calclib, in current project, also include xunit dependencies
* write unit tests
* `dotnet restore` then `dn test test/calclib-test`

### References
* [Tutorial on dotnet docs site](https://docs.microsoft.com/en-us/dotnet/articles/core/tutorials/using-on-macos)
