using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] HealthBarScript healthBarScript;
    PlayerScript playerScript;
    BoxCollider2D myBoxCollider;
    SpriteRenderer sprite;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    AudioSource sound;
    [SerializeField] AudioClip[] jumpSounds;
    Animator myAnimator;
    GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
    }

    public void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        myAnimator.SetBool(AnimationConstants.Walk, playerHasHorizontalSpeed);

        if (myRigidbody.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            sprite.flipX = true;
        }
    }

    void OnMove(InputValue value)
    {
        if (!healthBarScript.hasAlreadyDead)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void OnJump(InputValue value)
    {
        LayerMask groundLayer = LayerMask.GetMask(LayerConstants.Ground);
        if (value.isPressed && myBoxCollider.IsTouchingLayers(groundLayer) && !healthBarScript.hasAlreadyDead)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            sound.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
            myAnimator.SetTrigger(AnimationConstants.Jump);
        }
    }

    void OnEscape(InputValue value)
    {
        SceneManager.LoadScene(SceneConstants.Menu);
    }
    void OnInitiateMenu(InputValue value)
    {
        gameManager.HandleSceneTransition();
    }

    public void Dead()
    {
        myAnimator.SetTrigger(AnimationConstants.Dead);
    }
}
