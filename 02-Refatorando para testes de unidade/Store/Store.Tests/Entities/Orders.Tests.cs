using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class Orders
    {
        private readonly Customer _customer = new Customer("Everton", "everton@teste.com");
        private readonly Product _product = new Product("Produto 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_Um_Novo_Pedido_Valido_Ele_Deve_Gerar_Um_Numero_Com_8_Caracteres()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_Um_Novo_Pedido_Seu_Status_Deve_Ser_Aguardando_Pagamento()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(order.Status, Domain.Enums.EorderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_Um_Novo_Pedido_Seu_Status_Deve_Ser_Aguardando_Entrega()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 1);
            order.Pay(10);
            Assert.AreEqual(order.Status, Domain.Enums.EorderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_Um_Novo_Pedido_Cancelado_Seu_Status_Deve_Ser_Cancelado()
        {
            var order = new Order(_customer, 0, null);
            order.Cancel();
            Assert.AreEqual(order.Status, Domain.Enums.EorderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_Um_Novo_Item_Sem_Produto_o_Mesmo_Nao_Deve_Ser_Adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(null, 10);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_Um_Novo_Item_Com_Quantidade_Zero_Ou_Menor_O_Mesmo_Nao_Deve_Ser_Adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 0);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_Um_Novo_Pedido_Valido_Seu_Total_Deve_Ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5));
            var order = new Order(_customer, 10, expiredDiscount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, null);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 6);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            var order = new Order(null, 10, _discount);
            Assert.AreEqual(order.Valid, false);
        }
    }
}
