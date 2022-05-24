namespace Finance.Tests.StylesUnitTest
{
    public class OrderService
    {
        private readonly IPayPal _payPal;

        public OrderService(IPayPal payPal)
        {
            _payPal = payPal;
        }

        public void Checkout(Order order)
        {
            // Aplicaria regras de negocio

            // Processamento do cartao de credito
            // _payPal.CreditCardPayment();

            // Salvar a Order no banco de dados
        }
    }
}