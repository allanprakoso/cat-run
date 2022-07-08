using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;

    [SerializeField]
    public bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;
    
    public TMP_Text ScoreTxt;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                isGrounded = false;
                RB.AddForce(Vector2.up * JumpForce);
            }
        }

        if(isGrounded==false){
            anim.SetBool("isJump", true);
        }else{
            anim.SetBool("isJump", false);
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "Score : " + score.ToString("F");
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }

   
}