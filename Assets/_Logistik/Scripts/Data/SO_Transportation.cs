using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Transportation Data")]

public class SO_Transportation : ScriptableObject
{
    [Serializable]
    public struct ArmadaData
    {
        public Transportation type;
        public Sprite Siluet;
        public Sprite fillImg;
    }

    public List<ArmadaData> armadas;

    public ArmadaData GetTransportasi(Transportation type)
    {
        for (int i = 0; i < armadas.Count; i++)
        {
            if (armadas[i].type == type)
            {
                return armadas[i];
            }
        }

        return armadas[0];
    }
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

