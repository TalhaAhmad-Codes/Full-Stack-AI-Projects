namespace StudentManagement.Utilities.Menu;

public abstract class BaseMenu
{
    private readonly IReadOnlyList<string> _options;

    protected BaseMenu(string title, IEnumerable<string> options)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentNullException.ThrowIfNull(options);

        _options = options.Where(option => !string.IsNullOrWhiteSpace(option)).ToList();

        if (_options.Count == 0)
        {
            throw new ArgumentException("At least one menu option is required.", nameof(options));
        }

        Title = title;
    }

    protected string Title { get; }

    protected IReadOnlyList<string> Options => _options;

    public void Show()
    {
        RunMenu();
    }

    protected virtual void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine(Title);
        Console.WriteLine(new string('-', Title.Length));

        for (var index = 0; index < _options.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_options[index]}");
        }

        Console.WriteLine();
    }

    protected virtual int SelectOption()
    {
        while (true)
        {
            DisplayMenu();
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var selectedOption) &&
                selectedOption >= 1 &&
                selectedOption <= _options.Count)
            {
                return selectedOption;
            }

            Console.WriteLine($"Please enter a number between 1 and {_options.Count}.");
            Console.WriteLine();
        }
    }

    protected virtual void RunMenu()
    {
        var selectedOption = SelectOption();
        HandleSelection(selectedOption);
    }

    protected abstract void HandleSelection(int selectedOption);
}
