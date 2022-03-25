
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private float health = 100f;
    public float startHealth = 100f;

    public int value = 50;

    private Transform target;
    private int wavepointIndex = 0;


    [Header("Unity Sturff")]
    public Image healthBar;

    void Start (){
        target = Waypoints.points[0];
        health = startHealth;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {

        PlayerStats.Money += value;
        Destroy(gameObject);
    }


    void Update (){

        

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {

            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {

        if(wavepointIndex >= Waypoints.points.Length - 1){

            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath ()
    {
    Destroy(gameObject);
    PlayerStats.Lives --;
    }

}
