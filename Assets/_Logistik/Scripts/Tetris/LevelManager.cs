using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("UI")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TMP_Text score_txt;
    [SerializeField] private TMP_Text time_txt;
    [SerializeField] private SO_DataPreview dataPreview;
    [SerializeField] private Transform resultScreen;





    [Space(10)]

    [Header("Level Params")]
    public float targetRows;
    public float scorePerColumn;

    [Space(10)]
    [SerializeField] Board board;

    [SerializeField] private Image fillArmada;
    public float maxTimer;

    private float timeRemaining = 60;
    [SerializeField] private bool usingTimer = false;


    public float score;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!usingTimer)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            SetTime(timeRemaining);
        }
        else
        {
            CheckTarget();
        }
    }

    public void Start(){
        timeRemaining = maxTimer;
    }

    public void Restart(){
        spriteRenderer.sprite = null;
        timeRemaining = maxTimer;
        score = 0;
    }


    private void SetTime(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Round(time % 60);
        time_txt.text = string.Format("{0}:{1}", minutes, seconds);
    }

    public void SetScore(float score)
    {
        this.score += score;
        score_txt.text = this.score.ToString();

        CheckTarget();
        FillBar(this.score);
    }

    private void CheckTarget()
    {
        if (this.score / scorePerColumn >= this.targetRows)
        {
            Finish();
        }
        else if (timeRemaining <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        board.GameOver();
        Debug.Log("GameOver");
    }

    public void Finish()
    {
        Debug.Log("Finish");
        board.GetComponent<Piece>().enabled = false;
        resultScreen.gameObject.SetActive(true);
    }
    public void FillBar(float amount)
    {
        fillArmada.fillAmount = amount / 100;
    }

    public void SetNextPiecePreview(Tetromino tetromino)
    {
        Sprite sprite = dataPreview.GetPreview(tetromino);
        spriteRenderer.sprite = sprite;
    }

}
