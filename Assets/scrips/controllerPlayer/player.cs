using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int maxHp;
    int nowHp;
    [SerializeField] health healthBar;
    public float moveSpeed = 5f;
    Vector3 moveInput;
    void Start()
    {
        nowHp = maxHp;
        healthBar.updateBar(nowHp, maxHp);
    }

    // void takeDamage(int damage)
    // {
    //     nowHp -= damage;
    //     if (nowHp < 0)
    //     {

    //     }

    // }

    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        // if (moveInput.x!=0)
        // {
        //     if (moveInput.x>0)
        //     {
        //         transform.localRotation = Quaternion.Euler(0, 0, 0);
        //     }else
        //     {
        //        transform.localRotation = Quaternion.Euler(0, 0, 180);
        //     }
        // }
        //         if (moveInput.y!=0)
        // {
        //     if (moveInput.y>0)
        //     {
        //         transform.localRotation = Quaternion.Euler(0, 0, 90);
        //     }else
        //     {
        //        transform.localRotation = Quaternion.Euler(0, 0, 270);
        //     }
        // }

    }
}
