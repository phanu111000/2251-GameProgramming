using TMPro;
using UnityEngine;

public class ShowLives : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void LiveUpdate(int live)
    {
        scoreText.text = "Lives: " + live;
    }
}