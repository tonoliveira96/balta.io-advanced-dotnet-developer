using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document: ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<INotifiable>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido."));
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; set; }

        private bool Validate()
        {
            if(Type == EDocumentType.Cnpj && Number.Length == 14)
            {
                return true;
            }

            if (Type == EDocumentType.Cpf && Number.Length == 11)
            {
                return true;
            }
            return false;
        }
    }
}
