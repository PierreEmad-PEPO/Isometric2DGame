using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // --- Singleton Pattern ---
    public static InputManager Instance { get; private set; }

    [Header("Input Buffering")]
    [SerializeField] private float _inputBufferTime = 0.2f;

    public Vector2 MoveValue => _inputActions.Player.Move.ReadValue<Vector2>();
    public Vector2 LookValue => _inputActions.Player.Look.ReadValue<Vector2>();
    public bool RunIsPressing =>
        _inputActions.Player.Run.IsPressed();
    public bool AttackPressed => 
        Time.time - _attackBufferTimestamp <= _inputBufferTime;
    public bool DodgePressed =>
        Time.time - _dodgeBufferTimestamp <= _inputBufferTime;

    private InputActionsMap _inputActions;
    private float _attackBufferTimestamp;
    private float _dodgeBufferTimestamp;

    private void Awake()
    {
        // --- Singleton Setup ---
        if (Instance != null && Instance != this)
        {
            // If an instance already exists, destroy this one.
            Destroy(gameObject);
            return;
        }
        // This is the one and only instance.
        Instance = this;

        // Creating an instance of the action map.
        _inputActions = new InputActionsMap();
    }
    private void OnEnable()
    {
        // Register events to process the input buffer technique.
        _inputActions.Player.Attack.performed += AttackPerformed;
        _inputActions.Player.Dodge.performed += DodgePerformed;
    }
    private void OnDisable()
    {
        // Unregister events to avoid memory leaks.
        _inputActions.Player.Attack.performed -= AttackPerformed;
        _inputActions.Player.Dodge.performed -= DodgePerformed;
    }

    private void Start()
    {
        // Enabling the gameplay controls on begin.
        _inputActions.Player.Enable();
    }


    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        _attackBufferTimestamp = Time.time;
    }

    private void DodgePerformed(InputAction.CallbackContext obj)
    {
        _dodgeBufferTimestamp = Time.time;
    }
}
