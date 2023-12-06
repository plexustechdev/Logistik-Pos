using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Customer/Level", order = 0)]
public class SO_Customer : ScriptableObject
{
    [SerializeField] private List<Customer> customers;

    public List<Customer> Customers => customers;

    public Customer GetCustomerByName(string name)
    {
        for (int i = 0; i < customers.Count; i++)
        {
            if (customers[i].CustomerName == name)
            {
                return customers[i];
            }
        }

        return null;
    }

    public Customer GetCustomerByIndex(int id)
    {
        return customers[id];
    }
}



