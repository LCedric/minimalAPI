using System.ComponentModel;

public sealed class Endpoint : Endpoint<UserToCreate, UserCreated>
{
    public sealed override void Configure()
    {
        Post("/user/create");
        Version(1);
        AllowAnonymous();
    }

    public sealed override async Task HandleAsync(UserToCreate myRequest, CancellationToken _)
    {
        var response = new UserCreated()
        {
            FullName = myRequest.FirstName + " " + myRequest.LastName,
            IsOver18 = myRequest.Age > 18
        };

        await SendAsync(response);
    }
}

public sealed record UserCreated
{
    public string FullName { get; set; } = string.Empty;
    public bool IsOver18 { get; set; }
}

public sealed record UserToCreate
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
}