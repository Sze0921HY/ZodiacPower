using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animation creditAnimation;
    public bool isCredit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCredit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startButton()
    {
        SceneManager.LoadScene("InGame");
    }

    void creditButton()
    {
        if (!isCredit) 
        {
            isCredit = true;
            creditAnimation["creditPage"].speed = 1f;

            creditAnimation.Play("creditPage");
        }
        else
        {
            isCredit = false;
            creditAnimation["creditPage"].speed = -1f;
            creditAnimation["creditPage"].time = creditAnimation["creditPage"].length;
            creditAnimation.Play("creditPage");
        }
    }

    void exitButton()
    {
        Application.Quit();
    }
}
