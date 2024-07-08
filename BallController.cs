
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float speed = 1f;
    private Rigidbody2D rb;
    private bool isDead = false;
    private CameraController cameraController;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraController = Camera.main.GetComponent<CameraController>();
        audioSource=GetComponent<AudioSource>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        originalColor=spriteRenderer.color;

        if (GameManager.instance != null)
        {
            transform.position = GameManager.instance.GetCheckpoint();
            if (cameraController != null)
            {
                cameraController.UpdateOffset();
               
            }
        }
       
    }

    void Update()
    {
        if (!isDead)
        {
            MoveBall();
            HorizontalMove();
        }
    }

    void MoveBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {    PlayJumpSound();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           
        }
    }

    void HorizontalMove()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Die()
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        rb.simulated = false; 
        Invoke("Respawn", 2f);
        audioSource.PlayOneShot(deathSound);
    }

    void Respawn()
    {
        if (GameManager.instance != null)
        {
            transform.position = GameManager.instance.GetCheckpoint();
            rb.velocity = Vector2.zero;
            rb.simulated = true; 
            isDead = false;
            if (cameraController != null)
            {
                cameraController.UpdateOffset();
                cameraController.ForceUpdatePosition(); 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedUp"))
        {
            speed = speed * 1.2f;
        }
        if (other.CompareTag("RestartLevel") || other.CompareTag("Obstacle"))
        {   
            StartCoroutine(ChangeColorTemporarily(Color.red));
            Die();
        }
        if (other.CompareTag("SpeedUpper"))
        {
            speed = speed * 1.2f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SpeedCutter"))
        {
            speed = speed * 0.7f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("JumpUpper"))
        {
            jumpForce = jumpForce * 1.2f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("JumpCutter"))
        {
            jumpForce = jumpForce * 0.5f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("FullUpper"))
        {
            jumpForce = jumpForce * 1.5f;
            speed = speed * 1.5f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("FullCutter"))
        {
            jumpForce = jumpForce * 0.5f;
            speed = speed * 0.7f;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("EndLevel"))
        {   
            if (GameManager.instance != null)
            {
                GameManager.instance.ResetCheckPoint();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    void PlayJumpSound()
    {
        if(audioSource!=null&&jumpSound!=null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
       
    }
    IEnumerator ChangeColorTemporarily(Color newColor)
    {
        spriteRenderer.color=newColor;
        yield return new WaitForSeconds(2f);
        spriteRenderer.color=originalColor;
    }
}



