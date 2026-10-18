namespace AlerteViolence.Views;

public partial class CalculatricePage : ContentPage
{
    private string _currentInput = "0";
    private double _firstNumber = 0;
    private string _operator = "";
    private bool _isNewOperation = true;

    public CalculatricePage()
    {
        InitializeComponent();
    }

    private void OnNumberClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            string number = button.Text;

            if (_isNewOperation)
            {
                _currentInput = number;
                _isNewOperation = false;
            }
            else
            {
                _currentInput = _currentInput == "0" ? number : _currentInput + number;
            }

            DisplayLabel.Text = _currentInput;
        }
    }

    private void OnOperatorClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            _firstNumber = double.Parse(_currentInput);
            _operator = button.Text;
            _isNewOperation = true;
        }
    }

    private void OnEqualsClicked(object sender, EventArgs e)
    {
        if (!_isNewOperation && !string.IsNullOrEmpty(_operator))
        {
            double secondNumber = double.Parse(_currentInput);
            double result = 0;

            switch (_operator)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "×":
                    result = _firstNumber * secondNumber;
                    break;
                case "÷":
                    result = secondNumber != 0 ? _firstNumber / secondNumber : 0;
                    break;
            }

            _currentInput = result.ToString();
            DisplayLabel.Text = _currentInput;
            _isNewOperation = true;
            _operator = "";
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        _currentInput = "0";
        _firstNumber = 0;
        _operator = "";
        _isNewOperation = true;
        DisplayLabel.Text = _currentInput;
    }

    private void OnBackspaceClicked(object sender, EventArgs e)
    {
        if (_currentInput.Length > 1)
        {
            _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
        }
        else
        {
            _currentInput = "0";
        }
        DisplayLabel.Text = _currentInput;
    }

    private async void OnRetourClicked(object sender, EventArgs e)
    {
        // Retour à l'accueil
        await Shell.Current.GoToAsync(nameof(SosReportPage));
    }
}