using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
  
    public GameObject[] projectiles;

    private GameObject activeProjectile; 

    public float bulletforce = 20f;

    private int number = 0;

    private void Start()
    {
        activeProjectile = projectiles[0];
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Shoot();  
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(number > 2)
            {
                number = 0;
            } 

            else
            {
                number++;
                Debug.Log("number");
                activeProjectile = projectiles[number];
            } 
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(activeProjectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
