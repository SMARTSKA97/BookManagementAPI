
## Important Key Takeaways
> <p>
  > [Route("api/BookManagementAPI")]<br>
  > [ApiController]
</p>

## Some Attributes/Methods
> <p>
  > <b>[HttpGet]</b> - To Retrieve all data<br>
  > <b>[HttpGet("{Id:int}", Name ="GetBook")]</b> - To Retrieve certain data based on id <br>
  > <B>[HttpPost]</B> - To Create a new data<br>
  > <b>[HttpDelete("{id:int}", Name ="DeleteBook")]</b> - To Delete a certain data based on id<br>
  > <b>[HttpPut("{id:int}", Name ="Update Book")]</b> - To Update a certain data based on id<br>
  > <b>[HttpPatch("{id:int}", Name = "Update Partial Book")]</b> - To Update a certain data class based on id <br>
</p>

## Status Code and meaning
> <p>
  > <b>200</b> - OK<br>
  > <b>201</b> - Created<br>
  > <b>204</b> - No Content<br>
  > <b>400</b> - Bad Request<br>
  > <b>404</b> - Not Found<br>
  > <b>500</b> - InternalServerError<br>
</p>
