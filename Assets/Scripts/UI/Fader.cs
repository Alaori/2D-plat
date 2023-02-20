using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private Animator anim;
    private int loadLevel;
    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();
        GameManager.SetFader(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLevel(int level)
    {
        loadLevel = level;
        anim.SetTrigger("Fade");
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(loadLevel);
    }
    private void Restart()
    {
        SetLevel(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartLevel()
    {
        Invoke("Restart", 1.5f);

    }
}
