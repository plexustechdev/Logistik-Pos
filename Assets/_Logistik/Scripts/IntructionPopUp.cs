using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class IntructionPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text tujuan;
    [SerializeField] private TMP_Text instruksi;


    public void Main()
    {
        LevelManager.instance.Play();
    }

    public void SetContent(Destination destinasi, int goodsAmount, float time)
    {
        string teks = "";
        if (QuestActiveController.ActiveQuest.Level % 2 == 1)
        {
            teks = string.Format("Untuk mengirimkan {0} paket ke {1} kamu harus:{2} Menyusun {3} baris kotak paket.", goodsAmount * 10, destinasi.ToString(), Environment.NewLine, goodsAmount);
        }
        else
        {
            teks = string.Format("Untuk mengirimkan {0} paket ke {1} paling lambat {2} hari kamu harus:{3} Menyusun {4} baris kotak paket.", goodsAmount * 10, destinasi.ToString(), time, Environment.NewLine, goodsAmount);
        }


        instruksi.text = teks;
    }
}
