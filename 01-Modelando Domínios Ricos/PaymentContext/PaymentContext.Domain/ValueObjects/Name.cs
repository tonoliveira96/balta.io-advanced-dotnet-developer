using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
   public class Name: ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
                AddNotifications(new Contract<INotifiable>()
                    .Requires()
                    .IsNotEmpty(FirstName, "Name.FirstName", "Campo vazio.")
                    .IsNotEmpty(LastName, "Name.LastName", "Campo vazio."));
            
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
