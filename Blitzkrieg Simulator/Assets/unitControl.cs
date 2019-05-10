using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class unitControl : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public Camera cam;

    public NavMeshAgent selectAgent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    selectAgent = hit.collider.gameObject.GetComponent<NavMeshAgent>();
                }
                else
                {
                    selectAgent = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (selectAgent != null)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    selectAgent.SetDestination(hit.point);
                }
            }
            
        }
    }
}
