using UnityEngine;
using System.Collections;
public class Collectable : MonoBehaviour
{
    public CollectableType CollectableType;
    public Powerup powerup;
    public Transform SpawnPoint;
    public GameObject player;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private SOScriptable collectableObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeCol();

            PowerActivation();

            //Destroy(gameObject);

            StartCoroutine(RespawnCollectible());
        }
    }

    public void ChangeCol()
    {
        switch (CollectableType)
        {
            case CollectableType.Blue:
                sr.color = Color.blue;
                break;
            case CollectableType.Green:
                sr.color = Color.green;
                break;
            case CollectableType.Red:
                sr.color = Color.red;
                break;
            case CollectableType.Yellow:
                sr.color = Color.yellow;
                break;
        }
    }

    public void PowerActivation()
    {
        switch (powerup)
        {
            case Powerup.DoubleJump:
                Debug.Log("CanDoubleJump");
                break;
        }
    }

    public IEnumerator RespawnCollectible()
    {
        Debug.Log("Dead");
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(4f);
        Debug.Log("Respawn");
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
