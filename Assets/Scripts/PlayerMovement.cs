using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 15f;
    PlayerScript playerScript;

    SpriteRenderer sprite;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;

    void Awake()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        // myAnimator.SetBool(AnimationConstants.Walk, playerHasHorizontalSpeed);


        // if (myRigidbody.velocity.x > 0)
        // {
        //     sprite.flipX = false;
        // }
        // else if (myRigidbody.velocity.x < 0)
        // {
        //     sprite.flipX = true;
        // }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        // LayerMask groundLayer = LayerMask.GetMask(LayerConstants.Ground);
        //     if (value.isPressed && myBoxCollider.IsTouchingLayers(groundLayer))
        //     {
        //         myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        //         sound.PlayOneShot(soundJump);
        //         myAnimator.SetTrigger(AnimationConstants.hasJump);
        //     }
    }
    void OnEscape(InputValue value)
    {
        // SceneManager.LoadScene(SceneConstants.Menu);
    }

}
