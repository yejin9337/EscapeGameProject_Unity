using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;

    //[SerializeField]
    //private Rigidbody myRigid;

    private CharacterController charController;

    void Start()
    {
        //myRigid = GetComponent<Rigidbody>();
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
       if(GameManager.canPlayerMove)
       {
            Move();
       }
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal") * walkSpeed;
        float _moveDirZ = Input.GetAxisRaw("Vertical") * walkSpeed;

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        // 두개의 벡터값을 하나로 합침
        //Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized;
        charController.SimpleMove(_moveHorizontal + _moveVertical);
    }
}
