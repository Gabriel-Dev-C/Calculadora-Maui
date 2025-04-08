namespace CalculadoraPadrao
{
    public partial class MainPage : ContentPage
    {
        private double _currentValue = 0;
        private double _lastValue = 0;
        private string _operator = string.Empty;
        private bool _isNewEntry = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (_isNewEntry)
            {
                lblResultado.Text = button.Text;
                _isNewEntry = false;
            }
            else
            {
                lblResultado.Text += button.Text;
            }
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            _lastValue = double.Parse(lblResultado.Text);
            _operator = button.Text;
            _isNewEntry = true;
        }

        private void OnEqualClicked(object sender, EventArgs e)
        {
            _currentValue = double.Parse(lblResultado.Text);

            switch (_operator)
            {
                case "+":
                    _currentValue = _lastValue + _currentValue;
                    break;
                case "-":
                    _currentValue = _lastValue - _currentValue;
                    break;
                case "X":
                    _currentValue = _lastValue * _currentValue;
                    break;
                case "/":
                    _currentValue = _lastValue / _currentValue;
                    break;
                case "1/X":
                    _currentValue = 1 / _currentValue;
                    break;
                case "X²":
                    _currentValue = Math.Pow(_currentValue, 2);
                    break;
                case "Raiz²":
                    _currentValue = Math.Sqrt(_currentValue);
                    break;
                case "%":
                    _currentValue = _lastValue * (_currentValue / 100);
                    break;
                case "+/-":
                    _currentValue = -_currentValue;
                    break;
            }

            lblResultado.Text = _currentValue.ToString();
            _isNewEntry = true;
        }

        private void OnClearEntryClicked(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            _isNewEntry = true;
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            _currentValue = 0;
            _lastValue = 0;
            _operator = string.Empty;
            _isNewEntry = true;
        }

        private void OnBackspaceClicked(object sender, EventArgs e)
        {
            if (lblResultado.Text.Length > 1)
            {
                lblResultado.Text = lblResultado.Text.Substring(0, lblResultado.Text.Length - 1);
            }
            else
            {
                lblResultado.Text = "0";
                _isNewEntry = true;
            }

        }

    }
}