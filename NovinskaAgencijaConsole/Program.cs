using NovinskaAgencijaConsole;

var reporters = new List<Reporter>();
var articles = new List<Article>();

while (true)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Add reporter");
    Console.WriteLine("2. Add article");
    Console.WriteLine("3. Display reporters");
    Console.WriteLine("4. Display articles");
    Console.WriteLine("5. Quit");

    var input = Console.ReadLine();

    if (input == "1")
    {
        Console.WriteLine("Enter reporter details (id, name, email):");

        var reporterInput = Console.ReadLine();
        var parts = reporterInput.Split(',');

        if (parts.Length != 3)
        {
            Console.WriteLine("Invalid input. Please try again.");
            continue;
        }

        var id = parts[0].Trim();
        var name = parts[1].Trim();
        var email = parts[2].Trim();

        var reporter = new Reporter(id, name, email);
        reporters.Add(reporter.Clone() as Reporter);
    }
    else if (input == "2")
    {
        Console.WriteLine("Enter article details (title, content, category, date (yyyy-mm-dd), price, reporter id):");

        var articleInput = Console.ReadLine();
        var parts = articleInput.Split(',');

        if (parts.Length != 6)
        {
            Console.WriteLine("Invalid input. Please try again.");
            continue;
        }

        try
        {
            var title = parts[0].Trim();
            var content = parts[1].Trim();
            var category = parts[2].Trim();
            var date = DateTime.Parse(parts[3].Trim());
            var price = double.Parse(parts[4].Trim());
            var reporterId = parts[5].Trim();
            var reporter = reporters.FirstOrDefault(r => r.Id == reporterId);
            if (reporter == null)
            {
                Console.WriteLine("Reporter not found. Please try again.");
                continue;
            }

            var article = new Article(title, content, category, date, price, reporter);
            articles.Add(article.Clone() as Article);

            // Add a clone of the article to the list of articles for the specified reporter
            reporter.Articles.Add(article.Clone() as Article);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input. Please try again.");
            continue;
        }

        
    }
    else if (input == "3")
    {
        Console.WriteLine("Reporters:");

        foreach (var reporter in reporters)
        {
            Console.WriteLine($"Id: {reporter.Id}");
            Console.WriteLine($"Name: {reporter.Name}");
            Console.WriteLine($"Email: {reporter.Email}");
            Console.WriteLine($"Articles: {reporter.Articles.Count}");
            Console.WriteLine();
        }
    }
    else if (input == "4")
    {
        Console.WriteLine("Articles:");

        foreach (var article in articles)
        {
            Console.WriteLine($"Title: {article.Title}");
            Console.WriteLine($"Content: {article.Content}");
            Console.WriteLine($"Category: {article.Category}");
            Console.WriteLine($"Date: {article.Date}");
            Console.WriteLine($"Price: {article.Price}");
            Console.WriteLine($"Reporter: {article.Reporter.Name} ({article.Reporter.Email})");
            Console.WriteLine();
        }
    }
    else if (input == "5")
    {
        break;
    }
}