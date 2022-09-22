using UnityEngine;

[CreateAssetMenu(menuName = "Collectable", fileName = "New Collectable")]

public class SOScriptable : ScriptableObject
{
    [SerializeField] private Powerup powerupPickup;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool respawnable;

    public Sprite GetSprite() => sprite;
    public Powerup GetPowerup() => powerupPickup;
    public Sprite GetOutlineSprite() => outlineSprite;
    public bool GetRespawn() => respawnable;
}
