using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AntEnergy : MonoBehaviour
{
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject panel;

    PlayerMovement movement;
    private float initialSpeed;
    public float t = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        initialSpeed = movement.speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        t -= (0.01f * Time.deltaTime)/2;
        t = Mathf.Clamp(t,0f,1f);
        bar.GetComponent<Image>().fillAmount = t;
        
        if (t <= 0)
        {
            sleep();
        }
        
    }

    void sleep()
    {
        movement.speed = 0;
        panel.SetActive(true);
    }

    public void RestartGame() 
    {
        t= 1.0f;
        movement.speed = initialSpeed;
        panel.SetActive (false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     public void doExitGame() 
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
