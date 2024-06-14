using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private const int maxHealth = 3;
    private const int hitDelay = 10;
    private bool unBeatTime = false;

    private const float jumpPower = 8.0f;

    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Image image;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;

    [HideInInspector] public bool inputCrouch = false;
    [HideInInspector] public bool inputJump = false;

    [HideInInspector] public bool isCrouch { get; private set; } = false;
    private bool isJump = false;
    private bool isDie = false;
    private int health;
    private float jumpDelay = 1.8f;

    private Vector2[] colliderOffsets = new Vector2[]
    {
        new Vector2(-0.1f, -0.3f),
        new Vector2(0.1f, -0.4f)
    };
    private Vector2[] colliderSizes = new Vector2[]
    {
        new Vector2(1.2f, 1.4f),
        new Vector2(1.3f, 1.2f)
    };
    private Color32[] heartColors = new Color32[]
    {
        new Color32(255,255,255,90),
        new Color32(255,255,255,180),
        new Color32(255,255,255,255),
        new Color32(255,255,255,0),
    };
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
    private void Crouch()
    {
        if(isJump)
            return;

        isCrouch = inputCrouch;
        animator.SetBool("Crouch", isCrouch);

        boxCollider.offset = colliderOffsets[Convert.ToInt32(inputCrouch)];
        boxCollider.size = colliderSizes[Convert.ToInt32(inputCrouch)];
    }
    private IEnumerator JumpCoroutine()
    {
        isJump = true;

        animator.SetTrigger("Jump");
        rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        AudioManager.instance.PlayEffect(AudioManager.EffectType.Jump);

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
            UIManager.instance.hpIcons[health].color = heartColors[3];
            AudioManager.instance.PlayEffect(AudioManager.EffectType.Hit);

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
            UIManager.instance.hpIcons[health].color = heartColors[2];
        }
    }
    private void Die()
    {
        isDie = true;
        animator.SetBool("Move", false);
        GameManager.instance.GameOver();
    }
    private IEnumerator HitCoroutine()
    {
        int count = 0;
        Color32 prevColor = image.color;

        while(count < hitDelay)
        {
            image.color = heartColors[count % 2];
            yield return new WaitForSecondsRealtime(0.2f);
            count++;
        }

        image.color = prevColor;
        unBeatTime = false;
    }
}