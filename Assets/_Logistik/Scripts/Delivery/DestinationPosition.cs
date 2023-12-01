using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestinationPosition : MonoBehaviour
{
    [SerializeField] private List<Transform> positionList = new List<Transform>();

    public Transform GetDestination(string name)
    {
        var destination = positionList.First(pos => pos.name.ToLower() == name.ToLower());
        return destination;
    }
}
