using UnityEngine;

/// <summary>
/// Player Control Panel, that controls all the integrated player systems.
/// </summary>
[RequireComponent (typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public PlayerMovement PlayerMovement { get; private set; }

    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
    }
}
