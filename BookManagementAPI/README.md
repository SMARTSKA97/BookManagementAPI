The project consist of 3 pillars<br>
> <p>
  > <b>Controllers</b><br>
  > <b>Data</b><br>
  > <b>Models</b><br>
</p>

<h2>Controllers</h2><br>
It's the home to API controllers. It's also responsible for handling HTTP requests and generating responses.<br>
In short, It is the main program of the project where we can do CRUD operations.<br>

> <p>
  > <b>Create</b> - [HttpPost] is used to create a new item <br>
  > <b>Retrieve</b> - [HttpGet] is used to retrieve all the stored item in the Data directory<br>
  > <b>Update</b> - [HttpPut] and [HttpPatch] is used to update an item already stored.<br>
  > <b>Delete</b> - [HttpDelete] is used to remove an item already stored<br>
</p>

<h2>Data</h2>
This is used to store default data layer for the Model. Need to include DB to keep changes permanently.<br>

<h2>Models</h2>
This stores the classes that represent the data of the application. 

## Important
include .AddNewtonsoftJson() to include json for activating JsonPatch
