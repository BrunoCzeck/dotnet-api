using CashFlow.Communication.Enums;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;

namespace CashFlow.Application.UserCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisteredExpanseJson Execute(RequesRegistertExpenseJson request)
        {
            Validate(request);

            return new ResponseRegisteredExpanseJson();
        }
        private void Validate(RequesRegistertExpenseJson request)
        {
            var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
            if (titleIsEmpty)
            {
                throw new ArgumentException("O Titulo e obrigatorio");
            }

            if (request.Amount <= 0) {
                throw new ArgumentException("O valor deve ser maior que 0");
            }

            var result = DateTime.Compare(request.Date, DateTime.UtcNow);
            if (result > 0)
            {
                throw new ArgumentException();
            }

            var paymentType = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
            if(paymentType == false)
            {
                throw new ArgumentException("Tipo de pagamento invalido");
            }
        }
    }
}
