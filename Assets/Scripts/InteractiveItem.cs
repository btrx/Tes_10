using UnityEngine;
using UnityEngine.UIElements;

public class InteractiveItem : MonoBehaviour
{
    // --- AREA INI NANTI AKAN KITA GANTI DENGAN SCRIPTABLE OBJECT ---
    [Header("Hardcoded Data")]
    public string itemName;
    public enum ItemType { Potion, Coin, Trap, Fruit }
    public ItemType type;
    public int valueAmount;
    // ----------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect();
        }
    }

    void ApplyEffect()
    {
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
    }
}