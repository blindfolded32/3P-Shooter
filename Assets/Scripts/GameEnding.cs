using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup WinImage;
   // public AudioSource exitAudio;
    public CanvasGroup LostImage;
  //  public AudioSource caughtAudio;

   
    float m_Timer;
   
    

    public bool DeadPlayer ()
    {
       if (!GameObject.FindGameObjectWithTag("Player")) return true;
        return false;
    }
    public bool DeadBoss()
    {
        if (!GameObject.FindGameObjectWithTag("Boss")) return true;
        return false;
    }

    void Update ()
    {
        if (DeadBoss())
        {
            EndLevel(WinImage, false);//, exitAudio);
        }
        else if (DeadPlayer())
        {
            EndLevel(LostImage, true);//, caughtAudio);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart)//, AudioSource audioSource)
    {
       
            
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene (0);
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}
