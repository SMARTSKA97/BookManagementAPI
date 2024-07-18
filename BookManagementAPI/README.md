The project consist of 3 pillars<br>
> <p>
  > *Controllers*<br>
  > *Data*<br>
  > *Models*<br>
</p>

<h2>Controllers</h2><br>
It's the home to API controllers. It's also responsible for handling HTTP requests and generating responses.<br>
In short, It is the main program of the project where we can do CRUD operations.<br>

> <p>
    > *Create* - [HttpPost] is used to create a new item <br>
    > *Retrieve* - [HttpGet] is used to retrieve all the stored item in the Data directory<br>
    > *Update* - [HttpPut] and [HttpPatch] is used to update an item already stored.<br>
    > *Delete* - [HttpDelete] is used to remove an item already stored<br>
  </p>

<h2>Data</h2>
This is used to store default data layer for the Model. Need to include DB to keep changes permanently.<br>

<h2>Models</h2>
This stores the classes that represent the data of the application. 
