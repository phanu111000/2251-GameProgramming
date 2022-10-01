using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    [SerializeField] public int playerLives = 3;
    [SerializeField] private Transform textDestroy; //to make lives dissappear in main menu
    [SerializeField] private ShowLives showLives;

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdatePlayerLives();
    }

    private void Update()
    {
        if(playerLives <= 0)
        {
            Destroy(gameObject);
            LoadScene(0);
        }
        
        if(GetCurrentBuildIndex() == 0)
        {
            textDestroy.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            textDestroy.gameObject.SetActive(true);
        }
    }

    public void ProcessPlayerDeath()
    {
        LoadScene(GetCurrentBuildIndex());
        UpdatePlayerLives();
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        LoadScene(nextSceneIndex);
        UpdatePlayerLives();
    }

    public int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
        DOTween.KillAll();
        UpdatePlayerLives();
    }

    public void LiveDeduct()
    {
        playerLives -= 1;
        UpdatePlayerLives();
    }

    public void UpdatePlayerLives()
    {
        showLives.LiveUpdate(playerLives);
    }

}
