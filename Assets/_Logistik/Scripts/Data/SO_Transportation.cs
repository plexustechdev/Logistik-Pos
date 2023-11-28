using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Transportation Data")]

public class SO_Transportation : ScriptableObject
{
    [Serializable]
    public struct ArmadaData{
        public Transportation type;
        public Sprite Siluet;
        public Sprite fillImg;
    }

    public List<ArmadaData> armadas;
}

[Serializable]
public enum Transportation
{
    MOTORCYCLE,
    VAN,
    TRUCK,
    SHIPS,
    PLANE
}

