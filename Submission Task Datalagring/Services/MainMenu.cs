
using Submission_Task_Datalagring.Models.Entities;

namespace Submission_Task_Datalagring.Services;

public class MainMenu
{
    public List<ErrandEntity> errands = new List<ErrandEntity>();
    public List<CustomerEntity> customers = new List<CustomerEntity>();

    public void MainInterface()
    {
        Console.Clear();
        Console.WriteLine("Helpdesk");
        Console.WriteLine("1. Skapa ett ärende");
        Console.WriteLine("2. Visa alla ärenden");
        Console.WriteLine("3. Visa ett specifikt ärende");
        Console.WriteLine("4. Byt ett ärendes status");
        Console.Write("Välj ett av alternativen ovan: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1": CreateErrandAsync(); break;
            case "2": ShowAllErrands(); break;
            case "3": ShowSpecificErrand(); break;
            case "4": ChangeStatus(); break;
        }
    }

    public void CreateErrandAsync()
    {
        Console.Clear();
        Console.WriteLine("Skapa ett nytt ärende");


        ErrandEntity errand = new ErrandEntity();
        CustomerEntity customer = new CustomerEntity();


        Console.WriteLine("Ange Förnamn: ");
        customer.FirstName = Console.ReadLine() ?? "";
        Console.WriteLine("Ange Efternamn: ");
        customer.LastName = Console.ReadLine() ?? "";
        Console.WriteLine("Ange Email: ");
        customer.Email = Console.ReadLine() ?? "";
        errand.Email = customer.Email;
        Console.WriteLine("Ange Telefonnummer: ");
        customer.PhoneNumber = Console.ReadLine() ?? "";
        Console.WriteLine("Beskriv ditt ärende: ");
        errand.Description = Console.ReadLine() ?? "";
        errand.CurrentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        errand.Status = "Ej påbörjad";

        errands.Add(errand);
        customers.Add(customer);

        var database = new DatabaseService();
        database.SaveCustomerToDatabase(customer);
        database.SaveErrandToDatabase(errand);

    }
    public void ShowAllErrands()
    {
        Console.Clear();
        Console.WriteLine("Visar alla ärenden.");

        customers.ForEach(customer => Console.WriteLine("\n" + "Förnamn: " + customer.FirstName + "\n" + "Efternamn: " + customer.LastName + "\n" + "Email: " + customer.Email + "\n" + "Telefonnummer: " + customer.PhoneNumber));
        errands.ForEach(errand => Console.WriteLine("Ärendebeskrivning: " + errand.Description + "\n" + errand.CurrentTime + "\n" + "Status: " + errand.Status + "\n"));

        Console.ReadKey();
    }

    public void ShowSpecificErrand()
    {
        Console.Clear();
        Console.WriteLine("Välj ett ärende genom att skriva e-postadressen kopplad till ärendet");

        customers.ForEach(customer => Console.WriteLine("\n" + "Förnamn: " + customer.FirstName + "\n" + "Efternamn: " + customer.LastName + "\n" + "Email: " + customer.Email + "\n" + "Telefonnummer: " + customer.PhoneNumber));

        string userInput = Console.ReadLine() ?? "";

        Console.Clear();

        foreach (var c in customers) 
        {
            if (userInput.Equals(c.Email))
                Console.WriteLine("\n" + "Förnamn: " + c.FirstName + "\n" + "Efternamn: " + c.LastName + "\n" + "Email: " + c.Email + "\n" + "Telefonnummer: " + c.PhoneNumber);
            foreach (var e in errands)
            {
                if (e.Email == c.Email)
                    Console.WriteLine("Ärendebeskrivning: " + e.Description + "\n" + e.CurrentTime + "\n" + "Status: " + e.Status + "\n");
            }
        }
        

        Console.ReadKey();
    }

    public void ChangeStatus()
    {
        Console.Clear();
        Console.WriteLine("Välj den status du vill ge till ärendet");
        Console.WriteLine("1. Ej påbörjad");
        Console.WriteLine("2. Pågående");
        Console.WriteLine("3. Avslutad");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1": ChangeStatus1(); break;
            case "2": ChangeStatus2(); break;
            case "3": ChangeStatus3(); break;
        }
        void ChangeStatus1()
        {
            Console.Clear();
            Console.WriteLine("Välj ett ärende att byta status på genom att skriva e-postadressen kopplad till ärendet");

            customers.ForEach(customer => Console.WriteLine("\n" + "Förnamn: " + customer.FirstName + "\n" + "Efternamn: " + customer.LastName + "\n" + "Email: " + customer.Email + "\n" + "Telefonnummer: " + customer.PhoneNumber));
            errands.ForEach(errand => Console.WriteLine("Ärendebeskrivning: " + errand.Description + "\n" + errand.CurrentTime + "\n" + "Status: " + errand.Status + "\n"));

            string userInput = Console.ReadLine() ?? "";

            Console.Clear();

            foreach (var e in errands)
            {
                if (userInput.Equals(e.Email))
                    e.Status = "Ej Pågående";
            }

            Console.Clear();
        }
        void ChangeStatus2()
        {
            Console.Clear();
            Console.WriteLine("Välj ett ärende att byta status på genom att skriva e-postadressen kopplad till ärendet");

            customers.ForEach(customer => Console.WriteLine("\n" + "Förnamn: " + customer.FirstName + "\n" + "Efternamn: " + customer.LastName + "\n" + "Email: " + customer.Email + "\n" + "Telefonnummer: " + customer.PhoneNumber));
            errands.ForEach(errand => Console.WriteLine("Ärendebeskrivning: " + errand.Description + "\n" + errand.CurrentTime + "\n" + "Status: " + errand.Status + "\n"));

            string userInput = Console.ReadLine() ?? "";

            Console.Clear();

            foreach (var e in errands)
            {
                if (userInput.Equals(e.Email))
                    e.Status = "Pågående";
            }

       

            Console.Clear();
        }
        void ChangeStatus3()
        {
            Console.Clear();
            Console.WriteLine("Välj ett ärende att byta status på genom att skriva e-postadressen kopplad till ärendet");

            customers.ForEach(customer => Console.WriteLine("\n" + "Förnamn: " + customer.FirstName + "\n" + "Efternamn: " + customer.LastName + "\n" + "Email: " + customer.Email + "\n" + "Telefonnummer: " + customer.PhoneNumber));
            errands.ForEach(errand => Console.WriteLine("Ärendebeskrivning: " + errand.Description + "\n" + errand.CurrentTime + "\n" + "Status: " + errand.Status + "\n"));

            string userInput = Console.ReadLine() ?? "";

            Console.Clear();

            foreach (var e in errands)
            {
                if (userInput.Equals(e.Email))
                    e.Status = "Avslutad";
            }

            Console.Clear();
        }
        

    }
}
