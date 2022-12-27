using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    // Die werden in Unity "gefüllt". Man kann das auch ggf. sogar besser mit GetComponent machen
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void fire(){
        //Das erstellt ein neues Object Anhand des "PreFab", der Position und der Rotation
        GameObject myBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //Gibt einen Imbulse
        myBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

    }

    // Update is called once per frame 
    void Update()
    {
        
    }
}
