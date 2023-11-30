using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    // [SerializeField] private QuestActiveController _questControl;
    [SerializeField] private QuestMonitorManager _questView;

    [Space]
    [SerializeField] private CustomerQuestView _customerViewPrefab;
    [SerializeField] private Transform _customerContainer;
    [SerializeField] private CustomerCharacter _character;

    [Space]
    [SerializeField] private Tweening tweening;

    [Space]
    [SerializeField] private List<SO_Customer> customers = new();

    private void Start()
    {
        foreach (var customer in customers)
        {
            CustomerQuestView customerView = CreateCustomerView(customer);

            customerView.QuestBtn.onClick.AddListener(() =>
            {
                StartCoroutine(tweening.ShowCustomer(_character.transform,
                    _character.StartAnimPos,
                    _character.EndAnimPos,
                    _character.CharacterImage,
                    _character.DialogueImage,
                    _character.AcceptBtn
                ));
                // _character.gameObject.SetActive(true);
                foreach (var quest in customer.quests)
                {
                    if (!quest.IsActive && !quest.IsFinished)
                    {
                        _character.ShowQuest(quest.Description, quest.Narrative, customer.SpriteCharacter);
                        _character.AcceptOrder(quest, _questView);
                        _character.CancelOrder(quest, _questView);
                        break;
                    }
                }
            });
        }
    }

    private CustomerQuestView CreateCustomerView(SO_Customer customer)
    {
        CustomerQuestView customerView = Instantiate(_customerViewPrefab, _customerContainer);

        customerView.SetCustomer(customer.SpriteTable, customer.CustomerName);
        return customerView;
    }
}
