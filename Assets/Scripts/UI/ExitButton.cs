using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    GameObject parent;
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    public void onclickExit()
    {
        parent.gameObject.SetActive(false);
        GameManager.isOpenUI = false;
    }
}
