using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorMovement : MonoBehaviour
{
    public Animator anim;
    private GameObject player;

    private bool playerEntered = false;
    private bool open = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void Update()
    {
        if (playerEntered)
        {

            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("버튼눌림");
                anim.enabled = !open;
                open = !open;
                //anim.SetBool("isOpen_Obj_1", true);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("플레이어 있음");
            playerEntered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("플레이어 없음");
            playerEntered = false;
        }
    }
}

