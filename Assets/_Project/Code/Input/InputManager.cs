using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input Buffering")]
    [SerializeField] private float inputBufferTime = 0.2f;

    public Vector2 MoveValue => _inputActions.Player.Move.ReadValue<Vector2>();
    public Vector2 LookValue => _inputActions.Player.Look.ReadValue<Vector2>();
    public bool AttackPressed => 
        Time.time - _attackBufferTimestamp <= inputBufferTime;
    public bool DodgePressed =>
        Time.time - _dodgeBufferTimestamp <= inputBufferTime;
    public bool RunPressed =>
        Time.time - _runBufferTimestamp <= inputBufferTime;

    private InputActionsMap _inputActions;
    private float _attackBufferTimestamp;
    private float _dodgeBufferTimestamp;
    private float _runBufferTimestamp;

    private void Awake()
    {
        // Creating an instance of the action map.
        _inputActions = new InputActionsMap();
    }
    private void OnEnable()
    {
        // Register events to process the input buffer technique.
        _inputActions.Player.Attack.performed += AttackPerformed;
        _inputActions.Player.Dodge.performed += DodgePerformed;
        _inputActions.Player.Run.performed += RunPerformed;
    }
    private void OnDisable()
    {
        // Unregister events to avoid memory leaks.
        _inputActions.Player.Attack.performed -= AttackPerformed;
        _inputActions.Player.Dodge.performed -= DodgePerformed;
        _inputActions.Player.Run.performed -= RunPerformed;
    }

    private void Start()
    {
        // Enabling the gameplay controls on begin.
        _inputActions.Player.Enable();
    }


    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack Performed");
        _attackBufferTimestamp = Time.time;
    }

    private void DodgePerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Dodge Performed");
        _dodgeBufferTimestamp = Time.time;
    }

    private void RunPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Run Performed");
        _runBufferTimestamp = Time.time;
    }
}
