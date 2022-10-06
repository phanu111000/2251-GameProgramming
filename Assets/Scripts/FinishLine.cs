using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private const string PlayerTag = "Player";

    private GameManager _gameManager;
    private AudioManager _audioManager;
    // Why are we checking if the player reaches the finish line here? So, we do not
    // have to check for every time the player collides with something for a finish line.
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(PlayerTag)) return;

        if (_gameManager.GetCurrentBuildIndex() == 1 || _gameManager.GetCurrentBuildIndex() == 2)
        {
            _audioManager.Win();
            StartCoroutine(_gameManager.LoadNextLevel());
            print("Scene loading...");

        }

        else
        {
            _audioManager.Win();
            _gameManager.LoadScene(1);
        }
    }
}
