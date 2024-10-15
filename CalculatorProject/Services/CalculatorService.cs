public class CalculatorService
{
    private decimal _currentValue;
    private decimal _previousValue;
    private string _currentOperation;
    public string DisplayValue { get; private set; } = "0";
    private bool isNewEntry = true;

    public void InputDigit(string digit)
    {
        if (isNewEntry || DisplayValue == "0")
        {
            DisplayValue = digit;
            isNewEntry = false;
        }
        else
        {
            DisplayValue += digit;
        }
        _currentValue = decimal.Parse(DisplayValue);
    }

    public void InputDecimal()
    {
        if (!DisplayValue.Contains("."))
        {
            DisplayValue += ".";
            isNewEntry = false;
        }
    }

    public void SetOperation(string operation)
    {
        if (!isNewEntry)
        {
            CalculateResult();
        }

        _previousValue = _currentValue;
        _currentOperation = operation;
        isNewEntry = true;
    }

    public void CalculateResult()
    {
        switch (_currentOperation)
        {
            case "+":
                _currentValue = _previousValue + _currentValue;
                break;
            case "-":
                _currentValue = _previousValue - _currentValue;
                break;
            case "*":
                _currentValue = _previousValue * _currentValue;
                break;
            case "/":
                if (_currentValue != 0)
                {
                    _currentValue = _previousValue / _currentValue;
                }
                else
                {
                    DisplayValue = "Error";
                    isNewEntry = true;
                    return;
                }
                break;
        }

        DisplayValue = _currentValue.ToString();
        _previousValue = _currentValue; 
        isNewEntry = true;
    }

    public void Clear()
    {
        _currentValue = 0;
        _previousValue = 0;
        _currentOperation = null;
        DisplayValue = "0";
        isNewEntry = true;
    }

    public void DeleteLastCharacter()
    {
        if (DisplayValue.Length > 1)
        {
            DisplayValue = DisplayValue.Substring(0, DisplayValue.Length - 1);
        }
        else
        {
            DisplayValue = "0";
        }

        _currentValue = decimal.Parse(DisplayValue);
    }
}