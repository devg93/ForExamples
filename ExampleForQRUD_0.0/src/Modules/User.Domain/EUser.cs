using User.Domain.Vo;

namespace User.Domain;

public class EUser
{
    public Guid Id { get; private set; }
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public LName LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    private EUser(Guid id, Name name, Email email, PhoneNumber phoneNumber, LName lastName)
    {
        Id = id;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        LastName = lastName;
    }


    public static EUser Create(Guid id, Name name, Email email, PhoneNumber phoneNumber, LName lastName)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        }

        return new EUser(id, name, email, phoneNumber, lastName);
    }

}
