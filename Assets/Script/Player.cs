using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour {
    [SerializeField] GameManager gameManager;
    [SerializeField] GameOverManager gameOverManager;
    public float speed = 150f; //toc do di chuyen tren ban phim
    public Animator animator;
    bool isLookingRight = true; //nhin ben phai
    [SerializeField] private AudioSource gameOverSound;
    private Rigidbody2D rb;

    public float mapWidth = 3.25f; 
    //gioi han di chuyen tren man hinh

    public float MouseSpeed = 5f; // toc do di chuot

    public float slowness = 10f; // slow motion khi player thua


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {   
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //doi ben trai
        {
            spriteRenderer.flipX = true;
            isLookingRight = false;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) //doi ben phai
        {
            spriteRenderer.flipX = false;
            isLookingRight = true;

        }

    }

    // Update is called once per frame
    void FixedUpdate() {
        // dung 'A' or 'D' hoac right/left arrow de di chuyen
        

        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        float horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (x == 0) {
            x = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * speed * MouseSpeed; // use mouse to control
        }
  
        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition(newPosition);
        
                
 
    }



    void OnCollisionEnter2D() {
        gameOverSound.Play();
        Time.timeScale = 1f / slowness; // khien time chay se giam tan toi 0.1 frame/s
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness; // de xu ly hinh anh duoc muot hon
        animator.SetBool("isDeath", true);
        EndGame();
           
    }

    public void EndGame() {
        gameOverManager.SetGameOver();
        // StartCoroutine(RestartLevel());
    }

    // }
    //IEnumerator RestartLevel() {

        //Time.timeScale = 1f / slowness; // khien time chay se giam tan toi 0.1 frame/s
        //Time.fixedDeltaTime = Time.fixedDeltaTime / slowness; // de xu ly hinh anh duoc muot hon

        // yield return new WaitForSeconds(2f / slowness);
        // // luu y la khi xai timeScale se anh huong den waitForSeconds() 
        // // vi vay phai chia cho so sloness de chay dung so second 

        // Time.timeScale = 1f; // reset time ve bt
        // Time.fixedDeltaTime = Time.fixedDeltaTime * slowness; // tra lai fixdeltaTime ban dau

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

}