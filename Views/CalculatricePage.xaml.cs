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
            if (_isNewOperation) { _currentInput = button.Text; _isNewOperation = false; }
            else { _currentInput = _currentInput == "0" ? button.Text : _currentInput + button.Text; }
            DisplayLabel.Text = _currentInput;
        }
    }

    private void OnOperatorClicked(object sender, EventArgs e)
    {
        if (sender is Button button) { _firstNumber = double.Parse(_currentInput); _operator = button.Text; _isNewOperation = true; }
    }

    private void OnEqualsClicked(object sender, EventArgs e)
    {
        if (!_isNewOperation && !string.IsNullOrEmpty(_operator))
        {
            double secondNumber = double.Parse(_currentInput);
            double result = _operator switch
            {
                "+" => _firstNumber + secondNumber,
                "-" => _firstNumber - secondNumber,
                "×" => _firstNumber * secondNumber,
                "÷" => secondNumber != 0 ? _firstNumber / secondNumber : 0,
                _ => 0
            };
            _currentInput = result.ToString();
            DisplayLabel.Text = _currentInput;
            _isNewOperation = true;
            _operator = "";
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        _currentInput = "0"; _firstNumber = 0; _operator = ""; _isNewOperation = true;
        DisplayLabel.Text = _currentInput;
    }

    private void OnBackspaceClicked(object sender, EventArgs e)
    {
        _currentInput = _currentInput.Length > 1 ? _currentInput.Substring(0, _currentInput.Length - 1) : "0";
        DisplayLabel.Text = _currentInput;
    }

    private async void OnQuitterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}