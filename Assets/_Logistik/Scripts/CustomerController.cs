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

    private int _countLevel = 1;

    public void InitaizeCustomer()
    {
        _countLevel = 1;

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

            _countLevel++;
        }
    }

    private CustomerQuestView CreateCustomerView(Customer customer)
    {
        CustomerQuestView customerView = Instantiate(_customerViewPrefab, _customerContainer);

        bool isLocked = _countLevel > QuestActiveController.currentLevel;
        print(isLocked);
        customerView.SetCustomer(customer.SpriteThumbnail, customer.CustomerName, isLocked);

        return customerView;
    }
}
