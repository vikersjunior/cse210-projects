using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.CalculateTotalCost();
        }

        double shippingCost = _customer.LivesInUsa() ? 5 : 35;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabelBuilder = new StringBuilder();

        foreach (Product product in _products)
        {
            packingLabelBuilder.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }

        return packingLabelBuilder.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}