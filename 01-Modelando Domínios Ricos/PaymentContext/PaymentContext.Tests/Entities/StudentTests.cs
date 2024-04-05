


using PaymenContext.Domain.Entities;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;


        public StudentTests() {
            var _name = new Name("Dua", "Lipa");
            var _document = new Document("1112223344", EDocumentType.Cpf);
            var _email = new Email("dua.lipa@dualipa.com");
            var _address = new Address("Central Street", "1234", "Central", "London", "UK", "England", "000001");

            var _student = new Student(_name, _document, _email);
            var _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldreturnErroWhenHasActiveSubscription()
        {
            var payment = new PayPalPayment("sdsd54fs5f4sd5f4s5f4d5f4", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WARNER BROS RECORDS", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(!_student.IsValid);
        }

        [TestMethod]
        public void ShouldreturnErroWhenHasActiveSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(!_student.IsValid);
        }

        [TestMethod]
        public void ShouldreturnErroWhenAddSubscription()
        {
            var payment = new PayPalPayment("sdsd54fs5f4sd5f4s5f4d5f4", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WARNER BROS RECORDS", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.IsValid);
        }
    }
}
