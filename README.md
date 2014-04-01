## mite.net

A .NET library for interacting with the [RESTful API](http://mite.yo.lk/en/api) of [mite](http://mite.yo.lk/en), a sleek time tracking webapp.
```c#
var uri = new Uri("http://{mydomain}.mite.yo.lk");
var miteConfiguration = new MiteConfiguration(uri, "{my-api-key}");
 
using (IDataContext context = new MiteDataContext(miteConfiguration))
{
  var customer = new Customer();
  customer.Name = "Myself";

  customer = context.Create(customer);

  var project = new Project();
  project.Name = "mite.net";
  project.Customer = customer;

  context.Create(project);
}  
```
## How to build

If you want to restore the project after you cloned it please run:
    
    00_boot.bat
 
This will restore all necessary packages for building the project.
After that you could run a new build with:

    02_build.bat
    
## Contributing

 1. `git config --global core.autocrlf false` or clone with `--config core.autocrlf=false`
 1. Hack!
 1. Make a pull request.

## Build Status
[![Build status](https://ci.appveyor.com/api/projects/status/s9ed7ctye1o9b66q)](https://ci.appveyor.com/project/ccellar/mite-net)