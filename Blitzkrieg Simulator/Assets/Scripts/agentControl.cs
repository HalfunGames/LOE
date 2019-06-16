using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentControl : MonoBehaviour
{
    public GameObject turrent;
    public GameObject target;

    public float turrentSpeed = 1;

    public float timeCount;

    private RaycastHit range;
    private RaycastHit sight;

    public NavMeshAgent agent;

    public  GameObject bulletModel; 

    private void Update()
    {
        Physics.Raycast(turrent.transform.position, turrent.transform.forward, out sight);
        Physics.Raycast(turrent.transform.position, turrent.transform.forward, out range, 20);
        if (target != null)
        {
            Vector3 targetDir = target.transform.position - turrent.transform.position;

            // The step size is equal to speed times frame time.
            float step = turrentSpeed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(turrent.transform.forward, targetDir, step, 0.0f);

            // Move our position a step closer to the target.
            turrent.transform.rotation = Quaternion.LookRotation(newDir);
            timeCount = 0;
        }
        else
        {
            turrent.transform.rotation = Quaternion.Slerp(turrent.transform.rotation, Quaternion.Euler(0,0,0), timeCount);
            timeCount = timeCount + Time.deltaTime / 25;
        }
        if (target != null && sight.collider != null && range.collider != null)
        {
            if (sight.collider.gameObject == target && range.collider.gameObject == target)
            {
                //stop movement
                agent.isStopped = true;
                //shoot
                StartCoroutine(shoot());
            }
            else
            {
                //continue movement
                agent.isStopped = false;
            }
        }
        if (canFire == false)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            canFire = true;
        }
    }

    public GameObject flash;

    public int ammo = 3;
    public bool canFire = true;
    public float reloadTime = 5;
    private float time = 0;

    public float firingTime = 1;

    IEnumerator shoot()
    {
        if (ammo > 0 && canFire)
        {
            canFire = false;
            time = reloadTime;
            ammo--;
            //fire projectile
            //instantiate object
            yield return new WaitForSeconds(firingTime);
            flash.SetActive(true);
            Instantiate(bulletModel, turrent.transform.position, turrent.transform.rotation);
            yield return new WaitForSeconds(0.25f);
            flash.SetActive(false);
        }
        
    }

}
