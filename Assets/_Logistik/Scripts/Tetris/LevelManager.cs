using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Newtonsoft.Json;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Loading")]
    [SerializeField] private GameObject _loadingView;

    [Header("UI")]
    [SerializeField] private GameObject _pauseView;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer bgSprite;
    [SerializeField] private TMP_Text score_txt;
    [SerializeField] private TMP_Text time_txt;
    [SerializeField] private TMP_Text quest_txt;
    [SerializeField] private TMP_Text countdown_txt;
    [SerializeField] private TMP_Text exp_txt;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private IntructionPopUp popUp;

    [Space(10)]
    [SerializeField] private SO_DataPreview dataPreview;
    [SerializeField] private SO_Transportation dataTransportation;
    [SerializeField] private ResultScreen resultScreen;

    [SerializeField] private Canvas canvasPopup;
    [Space(10)]

    [Header("Level Params")]
    public int targetRows;
    public float scorePerColumn;

    [Header("Progress Match")]
    [SerializeField] private Image _progressImage;
    [SerializeField] private TextMeshProUGUI _progressTmp;

    [Space(10)]
    [SerializeField] Board board;

    [SerializeField] private Image fillArmada;
    [SerializeField] private Image siluetArmada;
    public float maxTimer;

    private float timeRemaining = 60;
    [SerializeField] private bool usingTimer = false;
    public bool isPlaying = false;
    private bool isPaused = false;
    private bool isFinished = false;
    private int _resultScore;

    public float score;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // if (Input.GetKey(KeyCode.K))
        // {
        //     Play();
        // }

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            ResumeGame();
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

    private void UpdateProgress()
    {
        _progressImage.fillAmount = (float)score / (float)targetRows;
        _progressTmp.text = $"{score}/{targetRows}";
    }

    public void Start()
    {
        popUp.SetContent(QuestActiveController.ActiveQuest.destination, QuestActiveController.ActiveQuest.GoodsAmount, QuestActiveController.ActiveQuest.Timer);
        popUp.gameObject.SetActive(true);
        Initialize();
        timeRemaining = maxTimer;

        SetTime(timeRemaining);
        // Play();
        UpdateProgress();
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
        bgSprite.sprite = QuestActiveController.ActiveQuest.spriteBg;

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
        UpdateProgress();
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
        if (isFinished) return;

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
        isFinished = true;

        AudioController.instance.PlayWin(false);
        isPlaying = false;
        resultScreen.ShowSuccess(false);
        // board.GameOver();
        Debug.Log("GameOver");
    }

    public void Finish()
    {
        isFinished = true;

        AudioController.instance.PlayWin(true);
        Debug.Log("Finish ");
        isPlaying = false;
        board.GetComponent<Piece>().enabled = false;
        exp_txt.text = "Exp : " + score;
        
        _resultScore = (int)score;
        if (maxTimer != 0)
        {
            print(_resultScore + ", "+ BonusScore());
            _resultScore += BonusScore();
        }

        DeliveryController.instance.currentScore = _resultScore;
        SendToken();
    }
    
    private int BonusScore()
    {
        float total = maxTimer - timeRemaining;

        float offset1 = maxTimer * 0.3f;
        float offset2 = maxTimer * 0.5f;
        float offset3 = maxTimer * 0.7f;

        if (total < offset1)
        {
            return 3;
        } 
        else if (total >= offset1 && total < offset2)
        {
            return 2;
        }
        else if (total >= offset2 && total < offset3)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void SendToken()
    {
        _loadingView.SetActive(true);
        FormUtils.SetFormPlay(AuthenticationSession.GetKey.rawKey);
        Authentication.instance.PostDataToken(Gateway.URI + Path.Play, FormUtils.GetForm, (result) =>
        {
            _loadingView.SetActive(false);
            resultScreen.ShowSuccess(true);
            var response = JsonConvert.DeserializeObject<ResponsePlay>(result);

            print(response.Status == "success" ? "success send key" : "error");
        });
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

    public void KirimBarang()
    {
        _loadingView.SetActive(true);
        FormUtils.SetFormWallet(_resultScore, AuthenticationSession.GetKey.generatedKey);
        Authentication.instance.PostDataToken(Gateway.URI + Path.Wallets, FormUtils.GetForm, (result) =>
        {
            _loadingView.SetActive(false);
            resultScreen.ShowSuccess(true);
            var response = JsonConvert.DeserializeObject<ResponseWalletSend>(result);

            if (response.Status == "success")
            {
                mainCamera.enabled = false;
                DeliveryController.instance.SetDelivery(dataTransportation.GetTransportasi(QuestActiveController.ActiveQuest.TransportationType).type, targetRows, QuestActiveController.ActiveQuest.destination.ToString());
                DeliveryController.instance.Shipment();
                GameManager.instance.UnloadScene(1);
                print("success");
            }
            else
            {
                canvasPopup.gameObject.SetActive(true);
                print(response.Message[0].Value);
                print("error");
            }
        });
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseView.SetActive(true);
    }

    public void PauseGame(GameObject obj)
    {
        Time.timeScale = 0;
        obj.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _pauseView.SetActive(false);
    }

    public void ResumeGame(GameObject obj)
    {
        Time.timeScale = 1;
        obj.SetActive(false);
    }

    public void Surrender()
    {
        Time.timeScale = 1;
        GameManager.instance.ChangeSceneNormal(0);
    }
}
