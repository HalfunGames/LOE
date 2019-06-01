using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public float animationTimer = 0;

    public bool animationPlaying = true;

    public int animationTotal = 3;

    public int animationSelected = 1;

    public Vector2 delay;

    public Animator anim;

    public Sprite[] backgrounds;

    public Image sprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackgroundAnimation());
    }

    IEnumerator BackgroundAnimation()
    {
        while (animationPlaying)
        {
            //randomly chooses new animation
            animationSelected = (int)Random.Range(1, animationTotal);
            //randomly chooses new background and apply background
            sprite.sprite = backgrounds[(int)Random.Range(0, backgrounds.Length)];
            //play animation
            anim.SetInteger("number", animationSelected);
            yield return new WaitForSeconds(1);
            //after animation:
            anim.GetCurrentAnimatorStateInfo(0).IsName("temp");
            anim.SetInteger("number", 0);
            //randomly choose new time
            animationTimer = Random.Range(delay.x, delay.y);
            //wait time
            yield return new WaitForSeconds(animationTimer);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        Debug.Log("Oops something went wrong!");
    }

    public void Options()
    {
        //play animation
    }

    public void Exit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
