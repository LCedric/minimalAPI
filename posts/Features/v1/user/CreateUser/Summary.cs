public sealed class Summary : Summary<Endpoint>
{
    public Summary()
    {
//        Summary = "Create a new user";
//        Description = "blank Description";

        ExampleRequest = new UserToCreate
        {
            FirstName = "Marlon",
            LastName = "Brondo",
            Age = 21,
        };

        Response(200, example: new UserCreated
        {
            FullName = "Marlon Brondo",
            IsOver18 = true
        });
    }
}