using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class masterScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        moneyText.text = money.ToString();
        pauseGroup.SetActive(false);
        gameGroup.SetActive(true);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public TextMeshProUGUI moneyText;
    public int money = 100;

    public int mode = 0;
    /* Mode Codes Below
     * 0: Nothing
     * 1: Placement
     */

    public GameObject[] tanks;
    public GameObject[] tanksGhost;
    private GameObject currentGhost;
    public int[] tankCosts;
    public int tankSelect;

    RaycastHit hit;
    Ray ray;

    public void PlaceTank(int tank)
    {
        tankSelect = tank;
        mode = 1;
    }

    public Camera cam;

    public NavMeshAgent selectAgent;

    // Update is called once per frame
    void Update()
    {
        bool rayHit = false;
        moneyText.text = money.ToString();
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            rayHit = true;
        }
        switch (mode)
        {
            case (0):
                PauseCheck();
                if (Input.GetMouseButtonDown(0))
                {
                    if (rayHit)
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
                        if (Physics.Raycast(ray, out hit))
                        {
                            selectAgent.SetDestination(hit.point);
                        }
                    }

                }
                break;
            case (1):
                //Ghost Stuff
                if (currentGhost == null)
                {
                    currentGhost = GameObject.Instantiate(tanksGhost[tankSelect], hit.point, Quaternion.identity);
                }
                currentGhost.GetComponent<Transform>().position = hit.point;

                //Placement stuff
                if (money >= tankCosts[tankSelect])
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Destroy(currentGhost);
                        mode = 0;
                        break;
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {
                        if (rayHit)
                        {
                            Instantiate(tanks[tankSelect], hit.point, Quaternion.identity);
                            money -= tankCosts[tankSelect];
                            Destroy(currentGhost);
                            mode = 0;
                        }
                    }
                }
                else
                {
                    Destroy(currentGhost);
                    mode = 0;
                }
                break;
            default:
                mode = 0;
                break;
        }
    }

    //Pause Manager
    public GameObject pauseGroup;
    public GameObject gameGroup;

    bool paused = false;

    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            paused = !paused;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseGroup.SetActive(true);
        gameGroup.SetActive(false);
    }

    public void Resume()
    {
        gameGroup.SetActive(true);
        pauseGroup.SetActive(false);
        Time.timeScale = 1;
    }

    private bool optionsOpen = false;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void Options()
    {
        //Play Animation
        optionsOpen = !optionsOpen;
        mainMenu.SetActive(!optionsOpen);
        optionsMenu.SetActive(optionsOpen);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    //Options Menu
    public GameObject inputField;

    public void AddMoney()
    {
        money += int.Parse(inputField.GetComponent<TMP_InputField>().text);
    }
}
