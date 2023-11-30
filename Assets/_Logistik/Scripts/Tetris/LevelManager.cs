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
    [SerializeField] private ResultScreen resultScreen;





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
    [SerializeField] private bool isPlaying = false;


    public float score;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!usingTimer)
            return;

        if (timeRemaining > 0 && isPlaying)
        {
            timeRemaining -= Time.deltaTime;
            SetTime(timeRemaining);
        }
        else
        {
            CheckTarget();
        }
    }

    public void Start()
    {
        Initialize();
        timeRemaining = maxTimer;

        SetTime(timeRemaining);
        Play();
    }

    public void Initialize()
    {
        maxTimer = QuestActiveController.ActiveQuest.Timer * 60;
        usingTimer = QuestActiveController.ActiveQuest.IsUsingTimer;

    }

    public void Play(){
        isPlaying = true;
    }

    public void Restart()
    {
        spriteRenderer.sprite = null;
        timeRemaining = maxTimer;
        score = 0;
        Play();
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
        isPlaying = false;
        resultScreen.ShowSuccess(false);
        // board.GameOver();
        Debug.Log("GameOver");
    }

    public void Finish()
    {
        Debug.Log("Finish");
        isPlaying = false;
        board.GetComponent<Piece>().enabled = false;
        resultScreen.ShowSuccess(true);
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
