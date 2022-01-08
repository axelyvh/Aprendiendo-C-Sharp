namespace LibreriaAxel
{
    public class CuentaBancaria
    {
        public int balance { get; set; }
        private readonly ILoggerGeneral _loggerGeneral;

        public CuentaBancaria(ILoggerGeneral loggerGeneral) {
            balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposito(int monto) {
            _loggerGeneral.Message("Esta depositando la cantidad de: " + monto.ToString());
            balance += monto;
            return true;
        }

        public bool Retiro(int monto) {
            if (monto <= balance) {
                _loggerGeneral.LogDatabase("Monto de retiro: " + monto.ToString());
                balance -= monto;
                return _loggerGeneral.LogBalanceDespuesRetiro(balance);
            }
            return _loggerGeneral.LogBalanceDespuesRetiro(balance - monto);
        }

        public int GetBalance()
        {
            return balance;
        }

    }
}
