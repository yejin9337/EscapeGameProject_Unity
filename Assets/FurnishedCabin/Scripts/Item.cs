using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;  //������ �̸�
    public GameObject itemPrefab; // �������� ����� ����߸� �� �ʿ��� ��ü
    public Sprite itemImage; // �κ��丮�� �ߴ� ������ �̹���
    public string weaponType;  // �տ� �� ��
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
