using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _renderer = _animator.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Flip the sprite based on the X axis input.
        _renderer.flipX = InputManager.Instance.MoveValue.x < 0;
    }

    public void Play(string animationName)
    {
        if (InputManager.Instance.MoveValue.y > 0) animationName += "Up";
        else animationName += "Down";
        
        _animator.Play(animationName);
    }

}
