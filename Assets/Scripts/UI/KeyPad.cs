using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ans;
    
    public DoorMovement _door;
    private string password = "9999";

    public void Number(int number)
    {
        ans.text += number.ToString();
    }

    public void Execute()
    {
        if(ans.text == password)
        {
            ans.text = "Correct";           
            _door.onKeyPad = false;
        }
        else
        {
            ans.text = string.Empty;
        }
    }
}
