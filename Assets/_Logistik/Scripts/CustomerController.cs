using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    // [SerializeField] private QuestActiveController _questControl;
    private Customer _selectedCustomer;
    public Customer selectedCustomer
    {
        get { return _selectedCustomer; }
        set
        {
            _selectedCustomer = value;
            if (value != null)
                _questView.availableQuest = value.GetAvailableQuest();
        }
    }
    [SerializeField] private QuestMonitorManager _questView;

    [Space]
    [SerializeField] private CustomerQuestView _customerViewPrefab;
    [SerializeField] private Transform _customerContainer;
    [SerializeField] private CustomerCharacter _character;

    [Space]
    [SerializeField] public Tweening tweening;

    [Space]
    [SerializeField] private List<SO_Customer> customers = new();


    public void InitaizeCustomer()
    {
        foreach (var customer in GameManager.instance.dataCustomer.Customers)
        {
            CustomerQuestView customerView = CreateCustomerView(customer);

            customerView.QuestBtn.onClick.AddListener(() =>
            {
                if (selectedCustomer != null && selectedCustomer == customer)
                    return;

                StartCoroutine(tweening.ShowCustomer(_character.transform,
                    _character.StartAnimPos,
                    _character.EndAnimPos,
                    _character.CharacterImage,
                    _character.DialogueImage
                ));

                selectedCustomer = customer;
                _questView.ShowAcceptButton(true);
                Quest availQuest = selectedCustomer.GetAvailableQuest();
                _character.ShowQuest(availQuest.Description, availQuest.Narrative, selectedCustomer.SpriteCharacter);
            });
        }
    }

    private CustomerQuestView CreateCustomerView(Customer customer)
    {
        CustomerQuestView customerView = Instantiate(_customerViewPrefab, _customerContainer);

        customerView.SetCustomer(customer.SpriteThumbnail, customer.CustomerName);
        return customerView;
    }
}
