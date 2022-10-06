using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private CollectibleSpawner collectibleSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SOCollectibles collectibleObject;
    
    private CollectibleType _collectibleType;
    private bool _isRespawnable;
    private AudioManager _audioManager;

    private void Start()
    {
        SetCollectible();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public CollectibleType GetCollectibleInfoOnContact()
    {
        
        gameObject.SetActive(false);

        if (_isRespawnable)
        {
            collectibleSpawner.StartRespawningCountdown();
            _audioManager.Diamond();
        }

        return _collectibleType;
    }
    
    private void SetCollectible()
    {
        collectibleSpawner.SetOutlineSprite(collectibleObject.GetOutlineSprite());
        spriteRenderer.sprite = collectibleObject.GetSprite();
        _collectibleType = collectibleObject.GetCollectibleType();
        _isRespawnable = collectibleObject.GetRespawnable();
    }
}
