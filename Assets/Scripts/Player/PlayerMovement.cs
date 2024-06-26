using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Sounds, IPausablePlayer
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float lerpTime;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector2 inputVector;
    private Vector2 lerpInputVector;
    private bool isPaused = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPaused)
        {
            return;
        }

        inputVector.Normalize();
        lerpInputVector = Vector2.Lerp(lerpInputVector, inputVector, Time.deltaTime * lerpTime);
        rigidBody.velocity = lerpInputVector * playerSpeed;

        animator.SetFloat("Horizontal", inputVector.x);
        animator.SetFloat("Vertical", inputVector.y);
        animator.SetFloat("Speed", inputVector.magnitude);
    }

    public void GetInputVector(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void PlayOneStep()
    {
        PlaySound(sounds[0], volume: 0.35f);
    }

}
