using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ans;

    private DoorMovement _door;
    private string password = "911";

    public void Number(int number)
    {
        ans.text += number.ToString();
    }

    public void Execute()
    {
        if(ans.text == password)
        {
            ans.text = "Correct";
            _door.playerEntered = true;
        }
        else
        {
            ans.text = string.Empty;
        }
    }
}
