using UnityEngine;


public enum Destination {
    Sukabumi,
    Jakarta,
    Jogjakarta,
    Pontianak,
    Papua, 
    Banjarmasin,
    Padang,
    Lampung,
    Makassar
}

[System.Serializable]
public class Quest
{
    public int Level;
    public float GoodsAmount;
    [TextArea]
    public string Description;
    [TextArea]
    public string Narrative;
    public Destination destination;
    public Transportation TransportationType;
    public float Timer;
    public bool IsActive;
    public bool IsFinished;
    public bool IsUsingTimer;
}
