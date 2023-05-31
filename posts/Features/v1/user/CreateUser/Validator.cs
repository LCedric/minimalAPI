public sealed class Validator : Validator<UserToCreate>
{
    public Validator() : base()
    {
        RuleFor(x => x.FirstName)
        .NotEmpty();

        RuleFor(x => x.LastName)
        .Length(4, 100);

        RuleFor(x => x.Age)
            .NotEmpty()
            .WithMessage("we need your age!")
            .GreaterThan(12)
            .WithMessage("you are not legal yet!");
    }
}