<h2>Important Key Takeaways</h2>
> <p>
  > [Route("api/BookManagementAPI")]<br>
  > [ApiController]

<h2>Some Attributes/Methods</h2><br>
> <p>
  > [HttpGet] - To Retrieve all data<br>
  > [HttpGet("{Id:int}", Name ="GetBook")] - To Retrieve certain data based on id <br>
  > [HttpPost] - To Create a new data<br>
  > [HttpDelete("{id:int}", Name ="DeleteBook")] - To Delete a certain data based on id<br>
  > [HttpPut("{id:int}", Name ="Update Book")] - To Update a certain data based on id<br>
  > [HttpPatch("{id:int}", Name = "Update Partial Book")] - To Update a certain data class based on id <br>
</p>
