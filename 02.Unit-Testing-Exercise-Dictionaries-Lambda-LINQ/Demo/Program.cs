
Dictionary<string, decimal[]> products = new();


    string[] data = "Apple 2.50 3.20".Split();

    string product = data[0];
    decimal price = decimal.Parse(data[1]);
    decimal quantity = decimal.Parse(data[2]);

    products.TryAdd(product, new[] { (decimal)0.0, (decimal)0.0 });
    products[product][1] += quantity;
    products[product][0] = price;

