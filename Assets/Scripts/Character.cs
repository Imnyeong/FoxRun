using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public static Character instance = null;

    private int maxHealth = 3;
    private float jumpPower = 8.0f;

    [HideInInspector] public bool inputCrouch = false;
    [HideInInspector] public bool inputJump = false;
    [HideInInspector] public bool UnBeatTime = false;

    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Image image;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;

    private bool isJump = false;
    private bool isDie = false;
    private int health;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {   
        health = maxHealth;
    }
    private void Update()
    {
        if (!GameManager.instance.isPlay)
            return;
        CharacterAction();
    }
    public void Move(bool _isplay)
    {
        animator.SetBool("Move", inputCrouch);
    }
    private void CharacterAction()
    {
        if (health == 0)
        {
            if (!isDie)
            {
                isDie = true;
            }
            return;
        }

        if (inputJump && !isJump)
        {
            Jump();
        }

        Crouch();
    }

    void Crouch()
    {
        animator.SetBool("Crouch", inputCrouch);

        if (!inputCrouch)
        {
            boxCollider.offset = new Vector2(-0.1f, -0.3f);
            boxCollider.size = new Vector2(1.2f, 1.4f);
        }
        if(inputCrouch)
        {
            boxCollider.offset = new Vector2(0.1f, -0.4f);
            boxCollider.size = new Vector2(1.3f, 1.2f);
        }
    }

    public void Jump()
    {
        isJump = true;
        animator.SetTrigger("Jump");
        rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 0)
        {
            isJump = false;
            inputJump = false;
        }

        if(other.gameObject.tag == "Monster" && !UnBeatTime)
        {
            animator.SetTrigger("Hurt");
            health--;
            UnBeatTime = true;
            StartCoroutine(UnBeat());
        }
    }

    void Die()
    {
        //GM.StartButton.SetActive(true);
        //SceneManager.LoadScene(0);
    }

    private IEnumerator UnBeat()
    {
        int count = 0;
        while(count < 10)
        {
            if(count%2 == 0)
            {
                image.color = new Color32(255,255,255,90);
            }
            else
            {
                image.color = new Color32(255,255,255,180);
            }
            yield return new WaitForSeconds(0.2f);
            count++;
        }
        animator.SetBool("Hurt", false);
        UnBeatTime = false;
        yield return null;
    }
}