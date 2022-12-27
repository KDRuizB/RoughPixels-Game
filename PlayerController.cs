using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
[SerializeField] private AudioClip shootSoundClip;
[SerializeField] private AudioClip reloadingSoundClip;

public Rigidbody2D playerBody;
public float moveSpeed = 5f;
public Weapon waffe;
public bool isFiring; 
public TextMeshProUGUI ammoDisplay;

private AudioSource audioSource;

public int maxAmmo = 30;
public int currentAmmo;
public float reloadTime = 1f;
private bool isReloading = false;

Vector2 moveDirection;
Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
        //playerBody.AddForce(Vector2.up * 200);

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY).normalized;

        //Hol dir die Mauspostion, ändere sie in eine Welt koordinate
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        ammoDisplay.text = currentAmmo.ToString();
        if (isReloading)
            return;
            if (!PauseMenu.isPaused)
            {
                // OnClick feure die Waffe
                if(Input.GetMouseButtonDown(0)){
                    waffe.fire();
                    isFiring = true;
                    currentAmmo--;
                    audioSource.clip = shootSoundClip;
                    audioSource.Play();
                    isFiring = false;
                }

                if (currentAmmo <= 0)
                {
                    StartCoroutine(Reload());
                    return;
                }
            
            }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        audioSource.clip = reloadingSoundClip;
        audioSource.Play();
        
        Debug.Log("Reloading... ");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private void FixedUpdate() {
        //Bewege den Spieler
        playerBody.velocity = new Vector2(moveDirection.x *moveSpeed, moveDirection.y * moveSpeed);


        //Zielrichtung ist die Mausposition im vergleich zum spieler
        Vector2 aimDircetion = mousePosition - playerBody.position;
        
        //Mathe Funktion ATangens
        float aimAngle = Mathf.Atan2(aimDircetion.y, aimDircetion.x) * Mathf.Rad2Deg;
        
        //Dreh den Spieler in Richtung Maus
        playerBody.rotation = aimAngle;
    }

}
