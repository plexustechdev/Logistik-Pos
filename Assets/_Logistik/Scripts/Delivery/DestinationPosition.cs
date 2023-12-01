using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestinationPosition : MonoBehaviour
{
    [SerializeField] private List<Transform> smallMapPosList = new List<Transform>();
    [SerializeField] private List<Transform> largeMapPosList = new List<Transform>();

    public Transform GetDestination(string name, bool isSmallMap)
    {
        Transform destination = isSmallMap ? smallMapPosList.First(pos => pos.name.ToLower() == name.ToLower()) : largeMapPosList.First(pos => pos.name.ToLower() == name.ToLower());

        return destination;
    }
}
