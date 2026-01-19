using UnityEngine;
using UnityEngine.UIElements;

public class InteractiveItem : MonoBehaviour
{
    // --- SCRIPTABLE OBJECT METHOD ---
    [SerializeField] private ItemDataObject itemData;
    private SpriteRenderer spriteRenderer;

    // --- OLD HARDCODED DATA (DEPRECATED) ---
    /*
    [Header("Hardcoded Data")]
    public string itemName;
    public enum ItemType { Potion, Coin, Trap, Fruit }
    public ItemType type;
    public int valueAmount;
    */
    // -----------------------------------------------

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
        
        // // --- NEW METHOD USING SCRIPTABLE OBJECT ---
        // if (itemData == null)
        // {
        //     Debug.LogWarning("ItemDataObject is not assigned!");
        //     return;
        // }

        // switch (itemData.type)
        // {
        //     case InteractType.Heal:
        //         Debug.Log($"Healed for {itemData.effectValue}");
        //         break;

        //     case InteractType.Buah:
        //         Debug.Log($"Got Score for {itemData.effectValue} points!");
        //         break;

        //     case InteractType.Trap:
        //         Debug.Log($"Damage taken: {itemData.effectValue}");
        //         break;
        // }

        // // Destroy object (kecuali Trap)
        // if (itemData.type != InteractType.Trap)
        // {
        //     Destroy(gameObject);    
        // }

        /*
        // --- OLD HARDCODED METHOD (DEPRECATED) ---
        // TODO 5: Lengkapi Switch Case ini
        // ----- Sebelum Scriptable Object -----

        switch (type)
        {
            case ItemType.Potion:
                Debug.Log($"Healed for {valueAmount}");
                break;

            case ItemType.Coin:
                // Tampilkan Log: "Got Coin!"
                Debug.Log("Got Coin!");
                break;

            case ItemType.Trap:
                Debug.Log($"Damage taken: {valueAmount}");
                break;

            case ItemType.Fruit:
                Debug.Log($"Got Score for {valueAmount} points!");
                break;
        }

        // TODO 6: Logic destroy object (kecuali Trap)
        if (type != ItemType.Trap)
        {
            // ...
            Destroy(gameObject);    
        }
        */
    }
}