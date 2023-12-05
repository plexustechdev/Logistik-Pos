using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("UI")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TMP_Text score_txt;
    [SerializeField] private TMP_Text time_txt;
    [SerializeField] private TMP_Text quest_txt;
    [SerializeField] private TMP_Text countdown_txt;

    [Space(10)]
    [SerializeField] private SO_DataPreview dataPreview;
    [SerializeField] private SO_Transportation dataTransportation;
    [SerializeField] private ResultScreen resultScreen;






    [Space(10)]

    [Header("Level Params")]
    public int targetRows;
    public float scorePerColumn;

    [Space(10)]
    [SerializeField] Board board;

    [SerializeField] private Image fillArmada;
    [SerializeField] private Image siluetArmada;
    public float maxTimer;

    private float timeRemaining = 60;
    [SerializeField] private bool usingTimer = false;
    public bool isPlaying = false;


    public float score;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Play();
        }

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
        Debug.Log(QuestActiveController.ActiveQuest.Description);
        maxTimer = QuestActiveController.ActiveQuest.Timer * 60;
        usingTimer = QuestActiveController.ActiveQuest.IsUsingTimer;
        quest_txt.text = QuestActiveController.ActiveQuest.Description;
        targetRows = QuestActiveController.ActiveQuest.GoodsAmount;
        siluetArmada.sprite = dataTransportation.GetTransportasi(QuestActiveController.ActiveQuest.TransportationType).Siluet;
        fillArmada.sprite = dataTransportation.GetTransportasi(QuestActiveController.ActiveQuest.TransportationType).fillImg;

    }

    public void Play()
    {
        StartCoroutine(Countdown(3));
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
        FillBar(1f / (float)targetRows);
        CheckTarget();

    }

    IEnumerator Countdown(int i)
    {
        do
        {
            i--;
            countdown_txt.text = (i + 1).ToString();
            yield return new WaitForSeconds(1);
        } while (i >= 0);
        isPlaying = true;
        countdown_txt.gameObject.SetActive(false);
    }

    private void CheckTarget()
    {
        if (this.score / scorePerColumn >= this.targetRows)
        {
            Finish();
        }
        else if (timeRemaining <= 0 && usingTimer)
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
        fillArmada.fillAmount += amount;
    }

    public void SetNextPiecePreview(Tetromino tetromino)
    {
        Sprite sprite = dataPreview.GetPreview(tetromino);
        spriteRenderer.sprite = sprite;
    }

}
