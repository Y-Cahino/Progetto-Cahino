using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.f
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Xml;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        ECommerceSystem system = new ECommerceSystem("data.json");

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        string userId = Prompt.ShowDialog("Enter User ID:", "Login");
        string password = Prompt.ShowDialog("Enter Password:", "Login");

        if (system.Login(userId, password))
        {
            Console.WriteLine("Login successful");
            system.ConfirmOrder("order123");
            system.Checkout("order123");
            system.SavePDF("order123");
            system.Process("order123");
            system.ViewProduct("product123");
            system.ChangeDefaultStore("store456");
            system.Customize("Model: Sedan, Wheels: Alloy, Color: Red");
        }
        else
        {
            Console.WriteLine("Login failed");
        }
    }
}

public class ECommerceSystem
{
    private string dataFile;
    private dynamic data;

    public ECommerceSystem(string dataFile)
    {
        this.dataFile = dataFile;
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            string json = File.ReadAllText(dataFile);
            data = JsonConvert.DeserializeObject<dynamic>(json);
        }
        catch (FileNotFoundException)
        {
            data = new
            {
                Users = new Dictionary<string, dynamic>
                {
                    { "user1", new { Password = "password1" } }
                },
                Orders = new List<dynamic>(),
                Products = new List<dynamic>(),
                Cars = new List<Car>
                {
                    new Car { Model = "Sedan", Wheels = "Alloy", Color = "Red" },
                    new Car { Model = "SUV", Wheels = "Steel", Color = "Blue" },
                    new Car { Model = "Hatchback", Wheels = "Alloy", Color = "Green" }
                }
            };
            SaveData();
        }
    }

    private void SaveData()
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(dataFile, json);
    }

    public bool Login(string userId, string password)
    {
        if (data.Users.ContainsKey(userId) && data.Users[userId].Password == password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ConfirmOrder(string orderId)
    {
        Console.WriteLine($"Order {orderId} confirmed");
        // Implementation for confirming order
        SaveData();
    }

    public void Checkout(string orderId)
    {
        Console.WriteLine($"Checkout for order {orderId} completed");
        // Implementation for checkout
        SaveData();
    }

    public void SavePDF(string orderId)
    {
        Console.WriteLine($"PDF for order {orderId} saved");
        // Implementation for saving PDF
        SaveData();
    }

    public void Process(string orderId)
    {
        Console.WriteLine($"Processing order {orderId}");
        // Implementation for processing order
        SaveData();
    }

    public void ViewProduct(string productId)
    {
        Console.WriteLine($"Viewing product {productId}");
        // Implementation for viewing product
    }

    public void ChangeDefaultStore(string storeId)
    {
        Console.WriteLine($"Changed default store to {storeId}");
        // Implementation for changing default store
        SaveData();
    }

    public void Customize(string customizationDetails)
    {
        Console.WriteLine($"Customization applied: {customizationDetails}");
        // Implementation for customizing
        SaveData();
    }
}

public class Car
{
    public string Model { get; set; }
    public string Wheels { get; set; }
    public string Color { get; set; }
}

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 500,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };
        Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
        TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
        Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmation);
        prompt.AcceptButton = confirmation;

        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
    }
}
