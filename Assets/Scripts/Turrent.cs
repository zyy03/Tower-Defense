using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public Transform target;

    public float range = 15f;
    public string enemyTag = "Enemy";
    public float turnspeed = 10f;
    public Transform partToRotate;

    //fire model
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    private float DistanceToTarget = Mathf.Infinity;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies){
            float distanceToenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToenemy < shortestDistance){
                shortestDistance = distanceToenemy;
                nearestEnemy = enemy;
            }
        }
        if(target == null){
            if(nearestEnemy != null && shortestDistance <= range){
                target = nearestEnemy.transform;
            }else{
                target = null;
            }

        }else{
            if(DistanceToTarget > range){
                if(nearestEnemy != null && shortestDistance <= range){
                    target = nearestEnemy.transform;
                }else{
                    target = null;
                }
            }
        }
            
    }

    void Update(){
        if (target == null) return;
        DistanceToTarget = Vector3.Distance(target.position, transform.position);
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null){
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
