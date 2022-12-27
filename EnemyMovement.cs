using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float MaxHitpoints = 100;
    public float HitPoints;
    public HealthManager healthBar;

    // Start is called before the first frame update

    private float distance;
    void Start()
    {
        HitPoints = MaxHitpoints;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

      private void OnCollisionEnter2D(Collision2D collision)
   {
        if(collision.gameObject.tag == "Player")
        {
            healthBar.TakeDamage(20);
        }
   }
}
