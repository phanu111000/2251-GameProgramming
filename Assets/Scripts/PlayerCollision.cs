using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Collider2D _playerCollider;
    private GameManager _gameManager;

    private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            _gameManager.TakeDamage();
        }
    }
}