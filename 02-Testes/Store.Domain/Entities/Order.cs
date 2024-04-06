
using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Order : Entity
    {
        public Order(Customer customer, decimal deliveryFree, Discount discount)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(customer, "Customer", "Cliente inválido")
);
            Customer = customer;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Items = new List<OrderItem>();
            DeliveryFree = deliveryFree;
            Discount = discount;
            Status = EorderStatus.WaitingPayment;
        }

        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public decimal DeliveryFree { get; private set; }
        public Discount Discount { get; private set; }
        public EorderStatus Status { get; private set; }

        public void AddItem(Product product, int quantity)
        {

            var item = new OrderItem(product, quantity);
            if (item.Valid)
                Items.Add(item);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFree;
            total -= Discount != null ? Discount.Value() : 0;

            return total;
        }

        public void Pay(decimal amount)
        {
            if (amount == Total())
            {
                this.Status = EorderStatus.WaitingDelivery;
            }
        }

        public void Cancel()
        {
            Status = EorderStatus.Canceled;
        }
    }
}
