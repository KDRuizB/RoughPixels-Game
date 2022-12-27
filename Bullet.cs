using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireForce = 20f;
    public void update()
    {
        transform.position += -transform.right * fireForce * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //TODO Hier kann man dann auch eine explosion oder sowas abspielen


        //TODO: ??? Hier kann man dem "Anderen Object" Others Schaden zufügen oder mit AddForce "Wegschleudern"
        
        //Zerstöre dich selbst bei einer Collison
        Destroy(gameObject);
    }
}
