using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;
    // true�� �Ǹ� ���콺�� �������� ���� ����� �������� ����
    // false�϶� i ������ �κ��丮 on / true�϶� i ������ �κ��丮 off

    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject _inventoryBase;
    [SerializeField]
    private GameObject _slotsParent;  // slot���� �θ� ��ü - grid�ΰ�?

    // ���Ե�
    private Slot[] slots;
    void Start()
    {
        slots = _slotsParent.GetComponentsInChildren<Slot>(); // slot���� slots �迭 �ȿ� ���� �ȴ� - ��Ƴ�;;
    }

    
    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {

            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OpenInventory()
    {
        GameManager.isOpenIventory = true;
        _inventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        GameManager.isOpenIventory = false;
        _inventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }
}
