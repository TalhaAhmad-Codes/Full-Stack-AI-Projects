namespace StudentManagement.Utilities.Menu;

public abstract class BaseMenu<Enum>
{
    private readonly IReadOnlyList<string> _options;
    protected string Title { get; }
    protected IReadOnlyList<string> Options => _options;

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

    protected bool IsValidOption(int option) => option > 0 && option < _options.Count;

    public Enum Start()
    {
        return RunMenu();
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

            if (int.TryParse(input, out var selectedOption) && IsValidOption(selectedOption))
            {
                return selectedOption;
            }

            Console.WriteLine($"Please enter a number between 1 and {_options.Count}.");
            Console.WriteLine();
        }
    }

    protected virtual Enum RunMenu()
    {
        Enum option;

        do
        {
            try
            {
                var selectedOption = SelectOption();
                option = HandleSelection(selectedOption);
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        } while (true);

        return option;
    }

    protected abstract Enum HandleSelection(int selectedOption);
}
