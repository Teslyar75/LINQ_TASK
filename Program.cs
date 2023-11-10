/*Для вирішення завдань використовуйте синтаксис запитів LINQ.
Завдання 1:
Реалізуйте користувацький тип «Фірма». В ньому має бути
інформація про назву фірми, дату заснування, профіль бізнесу
(маркетинг, IT, і т. д.), ПІБ директора, кількість працівників,
адреса.
Для масиву фірм реалізуйте такі запити:
 Отримати інформацію про всі фірми.
 Отримати фірми, які мають у назві слово «Food».
 Отримати фірми, які працюють у галузі маркетингу.
 Отримати фірми, які працюють у галузі маркетингу або IT.
 Отримати фірми з кількістю працівників більшою, ніж 100.
 Отримати фірми з кількістю працівників у діапазоні від 100
до 300.
 Отримати фірми, які знаходяться в Лондоні.
 Отримати фірми, в яких прізвище директора White.
 Отримати фірми, які засновані більше двох років тому.
 Отримати фірми з дня заснування яких минуло 123 дні.
 Отримати фірми, в яких прізвище директора Black і мають в
назві фірми слово «White».
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_With_Query_Syntax
{
    class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Profile { get; set; }
        public string CEO { get; set; }
        public int NumberOfWorkers { get; set; }
        public string Address { get; set; }

        public Company(string name, DateTime foundationDate, string profile, string ceo, int numberOfWorkers, string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            Profile = profile;
            CEO = ceo;
            NumberOfWorkers = numberOfWorkers;
            Address = address;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Company> companies = new List<Company>
            {
                new Company("Food For You", DateTime.Now.AddYears(-3), "Продукты питания", "John Tomas", 150, "New York"),
                new Company("IT Thought", DateTime.Now.AddYears(-2), "IT", "Jane Doe", 200, "San Francisco"),
                new Company("Mark For U", DateTime.Now.AddYears(-1), "Маркетинг", "Michael Duglas", 80, "London"),
                new Company("White Nights", DateTime.Now.AddYears(-4), "IT", "Terry White", 300, "London"),
                new Company("Black Doors", DateTime.Now.AddYears(-5), "Маркетинг", "Bob Black", 120, "Paris")
            };

            var allCompanies = from c in companies select c;
            var foodCompanies = from c in companies where c.Name.Contains("Продукты питания") select c;
            var marketingCompanies = from c in companies where c.Profile == "Маркетинг" select c;
            var markOrIT = from c in companies where c.Profile == "Маркетинг" || c.Profile == "IT" select c;
            var Over100Workers = from c in companies where c.NumberOfWorkers > 100 select c;
            var between100And300Workers = from c in companies where c.NumberOfWorkers >= 100 && c.NumberOfWorkers <= 300 select c;
            var fromLondon = from c in companies where c.Address == "London" select c;
            var whiteDirectors = from c in companies where c.CEO.Split(' ').Last() == "White" select c;
            var MoreThan2YearsAgo = from c in companies where c.FoundationDate < DateTime.Now.AddYears(-2) select c;
            var founded123DaysAgo = from c in companies where (DateTime.Now - c.FoundationDate).TotalDays > 123 select c;
            var blackDirectorsOrWhiteCompanies = from c in companies where c.CEO.Split(' ').Last() == "Black" || c.Name.Contains("White") select c;

            Console.WriteLine("Все компании:");
            DisplayCompanies(allCompanies);

            Console.WriteLine("\nКомпании продуктов питания:");
            DisplayCompanies(foodCompanies);

            Console.WriteLine("\nМаркетинговые компании :");
            DisplayCompanies(marketingCompanies);

            Console.WriteLine("\nМаркетинг и сфера IT:");
            DisplayCompanies(markOrIT);

            Console.WriteLine("\nВ этих компаниях работает более 100 человек:");
            DisplayCompanies(Over100Workers);

            Console.WriteLine("\nВ этих компаниях работает от 100 до 300 человек:");
            DisplayCompanies(between100And300Workers);

            Console.WriteLine("\nКомпании с пропиской в Лондоне:");
            DisplayCompanies(fromLondon);

            Console.WriteLine("\nКомпания, владельцем которой является мистер White:");
            DisplayCompanies(whiteDirectors);

            Console.WriteLine("\nЭтим компаниям более 2 лет:");
            DisplayCompanies(MoreThan2YearsAgo);

            Console.WriteLine("\nЭтим компаниям больше 123 дней:");
            DisplayCompanies(founded123DaysAgo);

            Console.WriteLine("\nДиректор: Black, Компания: White:");
            DisplayCompanies(blackDirectorsOrWhiteCompanies);

            Console.ReadKey();
        }

        static void DisplayCompanies(IEnumerable<Company> companies)
        {
            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Name}, \t" +
                    $"{company.Profile}, " +
                    $"{company.CEO}, " +
                    $"{company.NumberOfWorkers} работников, " +
                    $"Основана в {company.FoundationDate}, " +
                    $"Располагается в {company.Address}");
            }
        }
    }
}
