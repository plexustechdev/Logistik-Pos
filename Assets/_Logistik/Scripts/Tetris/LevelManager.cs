using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("UI")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SO_DataPreview dataPreview;

    [Space(10)]

    [SerializeField] private Image fillArmada;
    public float score;

    void Start(){
        instance = this;
    }


    public void SetScore(float score){
        this.score += score;
        FillBar(this.score);
    }
    public void FillBar(float amount){
        fillArmada.fillAmount = amount / 100;
    }

    public void SetNextPiecePreview(Tetromino tetromino){
        Sprite sprite = dataPreview.GetPreview(tetromino);
        spriteRenderer.sprite = sprite;
    }

}
