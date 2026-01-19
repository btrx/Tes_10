using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Items/Harvest (Fruit)")]
public class HarvestData : ItemDataObject // Warisi dari ItemData
{
    [Header("Harvest Specific")]
    public int scoreBonus;
    public AudioClip collectSound; // Contoh data spesifik lain
}