using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;  //아이템 이름
    public GameObject itemPrefab; // 아이템을 월드상에 떨어뜨릴 때 필요한 실체
    public Sprite itemImage; // 인벤토리에 뜨는 아이템 이미지
    public string weaponType;  // 손에 든 것
    public ItemType itemType;
    public enum ItemType
    {
        Equipment,
        Used
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
