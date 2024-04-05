using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValeuObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var newDocument = new Document("1234", EDocumentType.Cnpj);
           Assert.IsTrue(!newDocument.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsIValid()
        {
            var newDocument = new Document("34110468000150", EDocumentType.Cnpj);
            Assert.IsTrue(newDocument.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var newDocument = new Document("1234", EDocumentType.Cpf);
            Assert.IsTrue(!newDocument.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("11122233344")]
        public void ShouldReturnErrorWhenCPFIsIValid(string cpf)
        {
            var newDocument = new Document(cpf, EDocumentType.Cpf);
            Assert.IsTrue(newDocument.IsValid);
        }
    }
}
