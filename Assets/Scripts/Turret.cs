using System.Collections;
using UnityEngine.EventSystems;

using UnityEngine;

public class Turret : MonoBehaviour
{
BuildManager buildManager;
    private Transform target;

private Node node;


[Header("Attributes")]


 public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f;

    public bool followingBullet = true;

    public bool isUpgraded = false;
    


[Header("Unity setup Fields")]
    public string type;
    public string enemyTag = "Enemy";

    public Transform partToRotate;

    public float turnSpeed = 10f;


    public GameObject bulletPrefab;
    public Transform firePoint;

   



    void Start()
    {
         buildManager = BuildManager.instance;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        if(gameObject.GetComponent<BoxCollider>() == null)
    {
        Debug.Log("BOX COLLIDER NEEDS TO BE ADDED");
    }
    }

    void UpdateTarget (){

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        } 

        else {
           target = null; 
        }

    }



    void Update()
    {
        if(target == null){
            return;
        }

    Vector3 dir = target.position - transform.position;
    Quaternion lookRotation = Quaternion.LookRotation(dir);
    Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
    partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    if (fireCountdown <= 0f){

        Shoot();
        fireCountdown = 1f / fireRate;
    }

    fireCountdown -= Time.deltaTime;

    }

    void Shoot (){
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null){

            if(followingBullet)
            {
                bullet.Seek(target);
            }
            else{
            bullet.setLandingSpot(target.transform.position);

            }
        }

    }


    void OnDrawGizmosSelected (){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
           return;
       }

        buildManager.tui.Show(buildManager.shop.getBluePrintByType(type),this);
        buildManager.tui.Toggle(true);
        buildManager.shop.Toggle(false);
        buildManager.selectTurret(this);
       
        buildManager.drawRange();
    }

    public void setNode (Node node)
    {
        this.node = node;
    }

    public Node getNode()
    {
        return node;
    }

}
