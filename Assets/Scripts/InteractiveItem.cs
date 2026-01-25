using UnityEngine;
using UnityEngine.UIElements;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField] private ItemDataObject itemData;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (itemData != null) UpdateVisual();
    }

    public void Configure(ItemDataObject dataFromSpawner)
    {
        itemData = dataFromSpawner;
        UpdateVisual();
    }
    
    void UpdateVisual()
    {
        if (spriteRenderer != null && itemData != null)
        {
            spriteRenderer.sprite = itemData.icon;
            gameObject.name = itemData.itemName; // Ubah nama GameObject biar rapi
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect();
        }
    }

    void ApplyEffect()
    {
        if (itemData == null)
        {
            Debug.LogWarning("ItemDataObject is not assigned!");
            return;
        }

        if (itemData is HarvestData harvest)
        {
            Debug.Log($"Got Score for {harvest.scoreBonus} points!");
            Destroy(gameObject);
            // Additional logic for collecting harvest items can go here
        }
        else if (itemData is HazardData hazard)
        {
            Debug.Log($"Damage taken: {hazard.damageAmount}");
            // Additional logic for hazard effects can go here
        }
        else 
        {
            Debug.LogWarning("Unknown ItemDataObject type!");
        }
    }
}