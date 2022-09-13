using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType CollectableType;

    [SerializeField] private SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeCol();

            Destroy(gameObject);
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
}
