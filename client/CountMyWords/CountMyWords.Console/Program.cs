using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CountMyWords.Application.Text.Commands.RequestResponse;
using CountMyWords.Application.Text.Queries.RequestResponse;
using CountMyWords.DependencyInjection;
using CountMyWords.Domain.Common;

namespace CountMyWords
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var services = new ServiceCollection();
            services.AddServices(configuration);

            var servicesProvider = services.BuildServiceProvider();

            // TODO: Wrap this into an object
            await StartApp(servicesProvider);
        }

        static async Task StartApp(ServiceProvider servicesProvider)
        {
            var pageSize = 5;

            while (true)
            {
                Console.WriteLine("Select an option");
                Console.WriteLine("0 - To add a new text to the database.");
                Console.WriteLine("1 - To count words.");
                Console.WriteLine("2 - To do browse records from the database or the file.");

                using (var scope = servicesProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetService<IMediator>();
                    try
                    {
                        if (int.TryParse(Console.ReadLine(), out var option))
                        {
                            // Use case - Adding new text to the database
                            if (option == 0)
                            {
                                Console.WriteLine("Write text in a single line.");
                                var text = Console.ReadLine();

                                var request = new AddTextCommand()
                                {
                                    Text = text
                                };

                                var response = await mediator.Send(request);

                                Console.WriteLine($"Added a new text value with an Id of {response.Id}");
                            }
                            // Use case - Counting the words of text with a given Id (database or file)
                            else if (option == 1)
                            {
                                Console.WriteLine("0 - To count words of a text from the database.");
                                Console.WriteLine("1 - To count words of a text from the file.");

                                if (int.TryParse(Console.ReadLine(), out option))
                                {
                                    Console.WriteLine("Enter text's ID:");
                                    var idString = Console.ReadLine();

                                    if (!Guid.TryParse(idString, out var id))
                                    {
                                        Console.WriteLine("Wrong Id format.");
                                        continue;
                                    }

                                    CountWordsCommand request;
                                    if (option == 0)
                                    {
                                        request = new CountWordsCommand
                                        {
                                            ReadFrom = ReadTextFromType.Database,
                                            Id = id
                                        };
                                    }
                                    else if (option == 1)
                                    {
                                        request = new CountWordsCommand
                                        {
                                            ReadFrom = ReadTextFromType.File,
                                            Id = id
                                        };
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong input, please try again.");
                                        continue;
                                    }

                                    var response = await mediator.Send(request);
                                    Console.WriteLine($"Number of the words {response.WordCount}");
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input, please try again.");
                                    continue;
                                }
                            }
                            // Use case - Browsing the database or the file
                            else if (option == 2)
                            {
                                Console.WriteLine("0 - To browse from the database.");
                                Console.WriteLine("1 - To browse from the file.");

                                ReadTextFromType readFrom = ReadTextFromType.Database;

                                if (int.TryParse(Console.ReadLine(), out option))
                                {
                                    if (option == 0)
                                    {
                                        readFrom = ReadTextFromType.Database;
                                    }
                                    else if (option == 1)
                                    {
                                        readFrom = ReadTextFromType.File;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong input, please try again.");
                                        continue;
                                    }
                                }

                                var page = 1;
                                var breakLoop = false;

                                while (true)
                                {
                                    if (breakLoop)
                                    {
                                        break;
                                    }

                                    Console.WriteLine($"Page: {page}. Page size: {pageSize}. Use arrows to go through pages.");

                                    var request = new BrowseTextQuery
                                    {
                                        Page = page,
                                        PageSize = pageSize,
                                        ReadFrom = readFrom
                                    };

                                    var response = await mediator.Send(request);

                                    var i = (page - 1) * pageSize;
                                    foreach (var line in response.Texts)
                                    {
                                        i++;
                                        Console.WriteLine($"{i} \t {line.Id} \t {line.Text}");
                                    }

                                    var inputKey = Console.ReadKey().Key;
                                    switch (inputKey)
                                    {
                                        case ConsoleKey.Escape:
                                            breakLoop = true;
                                            break;
                                        case ConsoleKey.LeftArrow:
                                            if (page > 1)
                                            {
                                                page--;
                                            }
                                            break;
                                        case ConsoleKey.RightArrow:
                                            page++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, please try again.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}


