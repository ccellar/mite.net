## mite.net

A .NET library for interacting with the [RESTful API](http://mite.yo.lk/en/api) of [mite](http://mite.yo.lk/en), a sleek time tracking webapp.
```c#
var miteConfiguration = new MiteConfiguration(new Uri("http://{mydomain}.mite.yo.lk"), "{my-api-key}");
 
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