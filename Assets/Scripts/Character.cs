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
    [HideInInspector] public bool unBeatTime = false;
    [HideInInspector] public bool isCrouch = false;

    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Image image;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;

    private bool isJump = false;
    private bool isDie = false;
    private int health;
    private float jumpDelay = 1.8f;

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
        if (!GameManager.instance.isPlay || isDie)
            return;
        CharacterAction();
    }
    public void Move(bool _isplay)
    {
        animator.SetBool("Move", _isplay);
    }
    private void CharacterAction()
    {
        if (inputJump && !isJump)
        {
            StartCoroutine(JumpCoroutine());
        }
        Crouch();
    }

    void Crouch()
    {
        if(isJump)
            return;

        isCrouch = inputCrouch;
        animator.SetBool("Crouch", isCrouch);

        if (inputCrouch)
        {
            boxCollider.offset = new Vector2(0.1f, -0.4f);
            boxCollider.size = new Vector2(1.3f, 1.2f);
        }
        else
        {
            boxCollider.offset = new Vector2(-0.1f, -0.3f);
            boxCollider.size = new Vector2(1.2f, 1.4f);
        }
    }

    private IEnumerator JumpCoroutine()
    {
        isJump = true;

        animator.SetTrigger("Jump");
        rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        AudioManager.instance.PlayJumpSound();

        yield return new WaitForSecondsRealtime(jumpDelay);

        inputJump = false;
        isJump = false;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Monster" && !unBeatTime)
        {
            animator.SetTrigger("Hurt");
            health--;
            UIManager.instance.hpIcons[health].color = new Color32(255, 255, 255, 0);
            AudioManager.instance.PlayHitSound();

            if (health <= 0)
            {
                StopCoroutine(HitCoroutine());
                Die();
            }
            else 
            {
                unBeatTime = true;
                StartCoroutine(HitCoroutine());
            }
        }
        else if (other.gameObject.tag == "Item" && health < maxHealth)
        {
            health++;
            UIManager.instance.hpIcons[health].color = new Color32(255, 255, 255, 255);
        }
    }

    void Die()
    {
        isDie = true;
        animator.SetBool("Move", false);
        GameManager.instance.isPlay = false;
        GameManager.instance.GameOver();
    }

    private IEnumerator HitCoroutine()
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
            yield return new WaitForSecondsRealtime(0.2f);
            count++;
        }
        image.color = new Color32(255, 255, 255, 255);
        unBeatTime = false;
    }
}