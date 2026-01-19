using UnityEngine;
using System.Collections.Generic; // Wajib untuk pakai List<>

public class ItemSpawner : MonoBehaviour
{
    [Header("Factory Settings")]
    [Tooltip("Prefab kosong yang ada script InteractiveItem-nya")]
    public GameObject itemPrefab; 
    
    [Tooltip("Daftar Scriptable Object yang ingin dispawn")]
    public List<ItemDataObject> possibleItems; 

    [Header("Spawn Settings")]
    public int totalItemsToSpawn = 10;
    public Vector2 spawnAreaSize = new Vector2(10, 5); // Ukuran area spawn

    void Start()
    {
        SpawnAllItems();
    }

    void SpawnAllItems()
    {
        // Validasi: Jangan spawn kalau prefab atau data kosong
        if (itemPrefab == null || possibleItems.Count == 0) return;

        for (int i = 0; i < totalItemsToSpawn; i++)
        {
            SpawnSingleItem();
        }
    }

    void SpawnSingleItem()
    {
        // 1. Tentukan Posisi Acak
        Vector2 randomPos = new Vector2(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );

        // Tambahkan offset posisi Spawner (supaya area ikut geser kalau spawner digeser)
        Vector2 finalPos = (Vector2)transform.position + randomPos;

        // 2. Instantiate (Lahirkan) Prefab Kosong
        GameObject newItem = Instantiate(itemPrefab, finalPos, Quaternion.identity);

        // 3. Ambil Script dan Suntikkan Data (Dependency Injection sederhana)
        InteractiveItem script = newItem.GetComponent<InteractiveItem>();
        
        // Pilih data acak dari List
        ItemDataObject randomData = possibleItems[Random.Range(0, possibleItems.Count)];
        
        // Konfigurasi Item
        script.Configure(randomData);
        
        // Opsional: Masukkan ke dalam folder parent biar Hierarchy rapi
        newItem.transform.SetParent(this.transform);
    }

    // Fitur Debug: Menggambar kotak area spawn di Scene View
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0));
    }
}