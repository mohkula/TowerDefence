
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public Transform partToRotate;
    public float turnSpeed = 10f;


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

        WaveSpawner.EnemiesAlive --;
        Destroy(gameObject);
    }


    void Update (){

        

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


         
    Quaternion lookRotation = Quaternion.LookRotation(dir);
    Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
    partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);



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
WaveSpawner.EnemiesAlive --;
    PlayerStats.Lives --;
    }

}
