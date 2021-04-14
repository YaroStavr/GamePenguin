using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManeger : MonoBehaviour
{
    
    void Start()
    {
        Application.targetFrameRate=60;
        

    }

    public Penguin movement;
 
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            Restart();
        }
        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
