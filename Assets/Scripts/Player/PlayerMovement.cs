using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float lerpTime;


    private Rigidbody2D rigidBody;
    private Animator _animator;
    private Vector2 inputVector;
    private Vector2 lerpInputVector;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputVector.Normalize();
        lerpInputVector = Vector2.Lerp(lerpInputVector, inputVector, Time.deltaTime * lerpTime);
        rigidBody.velocity = lerpInputVector * playerSpeed;

        _animator.SetFloat("Horizontal", inputVector.x);
        _animator.SetFloat("Vertical", inputVector.y);
        _animator.SetFloat("Speed", inputVector.magnitude);
    }

    public void GetInputVector(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }
}
