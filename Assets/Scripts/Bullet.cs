
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Transform target;

   private Vector3 landingSpot;

   public float turnSpeed = 100f;

    public float speed = 70f;

private bool following = true;
    
    public float damage = 50f;

    public float explosionRadius = 0f;

    public GameObject impactEffect;

   public void Seek (Transform _target)
   {
       following = true;
target = _target;
   }

   public void setLandingSpot(Vector3 spot)
   {
       following = false;
landingSpot = spot;
   }

    void Update()
    {

        


if(following)
{
moveFollowing();

}

   else{
       moveToLandingSpot();
   }    

  
    
        
    }

    void moveFollowing() 
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
 Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;



        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

           void moveToLandingSpot()
           {
                Vector3 dir = landingSpot - transform.position;
                        float distanceThisFrame = speed * Time.deltaTime;
                        
                        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

                        transform.Translate (dir.normalized * distanceThisFrame, Space.World);


           }


    void HitTarget()
    {
      GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
    
      Destroy(effectIns, 5f);

      if (explosionRadius > 0f)
      {
          Explode();
      }
      else 
      {
          Damage(target);
      }

     
        Destroy(gameObject);
    }


    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
        e.TakeDamage(damage);
        }

        

    }

    void Explode ()
    {
        Collider[] colliders = Physics.OverlapSphere(landingSpot, explosionRadius);
        
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage (collider.transform);
            }
        }
    }

     void OnDrawGizmosSelected (){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
