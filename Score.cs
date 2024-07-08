using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI speedUpText;
    public TextMeshProUGUI speedCutterText;
    public TextMeshProUGUI jumpUpperText;
    public TextMeshProUGUI jumpCutterText;
    public TextMeshProUGUI fullUpperText;
     public TextMeshProUGUI fullCutterText;
     public TextMeshProUGUI checkPointText;
     public TextMeshProUGUI deathCounterText;
    private int score = 0;
    private int deathCounter= 0;
    public GameObject deathPanel;
    private bool isDead= false;


    [SerializeField] AudioClip clickSoundUpper;
    [SerializeField] AudioClip clickSoundCutter;
    [SerializeField] AudioClip clickSoundRestart;
    [SerializeField] AudioClip clickSoundEnd;
    void Start()
    {
        UpdateScoreText();
        UpdateDeathCounter();
        speedUpText.text = "";
        speedCutterText.text = "";
        jumpUpperText.text = "";
        jumpCutterText.text= "";
        fullUpperText.text = "";
        fullCutterText.text="";
        checkPointText.text = "";
        deathCounterText.text="";
       deathPanel.SetActive(false);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void UpdateDeathCounter()
    {
        deathCounterText.text =" " +deathCounter.ToString();
    }

    void UpdateSpeedUpText()
    {
        speedUpText.text = "Speed+";
         StartCoroutine(BlinkText(speedUpText, 5f, 0.5f));
    }
    void UpdateSpeedCutterText()
    {
        speedCutterText.text = "Speed-";
        StartCoroutine(BlinkText(speedCutterText, 5f, 0.5f));
    }
     void UpdateJumpUpperText()
    {
        jumpUpperText.text = "Jump+";
        StartCoroutine(BlinkText(jumpUpperText, 5f, 0.5f));
    }
     void UpdateJumpCutterText()
    {
        jumpCutterText.text = "Jump-";
        StartCoroutine(BlinkText(jumpCutterText, 5f, 0.5f));
    }
    void UpdateFullUpperText()
    {
        fullUpperText.text = "Speed+ \n Jump+";
        StartCoroutine(BlinkText(fullUpperText, 5f, 0.5f));
    }
    void UpdateFullCutterText()
    {
        fullCutterText.text = "Speed- \n Jump-";
        StartCoroutine(BlinkText(fullCutterText, 5f, 0.5f));
    }
    void UpdateCheckPointText()
    {   
        checkPointText.text = "Checkpoint Saved";
        StartCoroutine(BlinkText(checkPointText, 3f, 0.5f));
    }

    private IEnumerator  BlinkText(TextMeshProUGUI text, float duration, float blinkInterval)
    {
        float elapsedTime = 0f;
        bool isTextVisible = true;

         while (elapsedTime < duration)
        {
            elapsedTime += blinkInterval;
            isTextVisible = !isTextVisible;
            text.enabled = isTextVisible;
            yield return new WaitForSeconds(blinkInterval);
        }

        text.enabled = false;

        speedUpText.text = "";
        speedCutterText.text ="";
        jumpUpperText.text="";
        jumpCutterText.text = "";
        fullCutterText.text="" ;
        fullUpperText.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreUpper"))
        {
            score += 1;
            UpdateScoreText();
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(clickSoundUpper,other.transform.position);
        }
        if (other.gameObject.CompareTag("ScoreCutter"))
        {
            score -= 1;
            UpdateScoreText();
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(clickSoundCutter,other.transform.position);
        }
        if (other.gameObject.CompareTag("SpeedUpper"))
        {
            UpdateSpeedUpText();
            AudioSource.PlayClipAtPoint(clickSoundUpper,other.transform.position);
        }
        if(other.gameObject.CompareTag("SpeedCutter"))
        {
            UpdateSpeedCutterText();
            AudioSource.PlayClipAtPoint(clickSoundCutter,other.transform.position);
        }
        if(other.gameObject.CompareTag("JumpUpper"))
        {
             UpdateJumpUpperText();
            AudioSource.PlayClipAtPoint(clickSoundUpper,other.transform.position);
        }
        if(other.gameObject.CompareTag("JumpCutter"))
        {
             UpdateJumpCutterText();
            AudioSource.PlayClipAtPoint(clickSoundCutter,other.transform.position);
        }
        if(other.gameObject.CompareTag("FullUpper"))
        {
             UpdateFullUpperText();
            AudioSource.PlayClipAtPoint(clickSoundUpper,other.transform.position);
        }
        if(other.gameObject.CompareTag("FullCutter"))
        {
             UpdateFullCutterText();
             AudioSource.PlayClipAtPoint(clickSoundCutter,other.transform.position);
        }
        if(other.gameObject.CompareTag("Ball")|| other.gameObject.CompareTag("CheckPoint"))
        {
            UpdateCheckPointText();
        }
        if(score<0)
        {
            ShowPanel();
        }
         if (other.CompareTag("RestartLevel") || other.CompareTag("Obstacle"))
        {
            score=score-1;
            UpdateScoreText();
            deathCounter=deathCounter+1;
            
            UpdateDeathCounter();
            if(score<0)
            {   
                ShowPanel();
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            AudioSource.PlayClipAtPoint(clickSoundRestart,other.transform.position);
        }
        if(other.CompareTag("EndLevel"))
        {
            AudioSource.PlayClipAtPoint(clickSoundEnd,other.transform.position);
        }

    }
    void ShowPanel()
    {
        deathPanel.SetActive(true);
        isDead=true;
        Time.timeScale=0f;
    }
}

