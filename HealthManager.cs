using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public float health;
    public MainMenu mainMenu;
    public int healPoints;
    public int maxHealPoints = 3;
    public TextMeshProUGUI healthPointDisplay;

    // Start is called before the first frame update
    void Start()
    {
        health = healthAmount;
        healPoints = maxHealPoints;
        StartCoroutine(HealthReg());
    }

    // Update is called once per frame
    void Update()
    {
        healthPointDisplay.text = healPoints.ToString();

         if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20f);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            //TODO bei maximalen hp werten kann mann sich nicht healen
            if (healPoints > 0)
            {
                Input.GetMouseButtonDown(1);
                Heal(30);
                healPoints --;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;

        if (healthAmount <= 0)
        {
            Debug.Log("You died!");
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
            //TODO player score auf 0 zurücksetzen
        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healingAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    IEnumerator HealthReg()
    {
        yield return new WaitForSeconds(2);
        Heal(5f);
        StartCoroutine(HealthReg());
    }

}