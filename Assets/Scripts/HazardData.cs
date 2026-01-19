using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Items/Hazard (Trap)")]
public class HazardData : ItemDataObject // Warisi dari ItemData
{
    [Header("Hazard Specific")]
    public int damageAmount;
    public float knockbackForce = 5f; // Paku punya knockback, Apel tidak
}