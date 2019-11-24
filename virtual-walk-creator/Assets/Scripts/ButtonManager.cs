using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static string deviceName;
    public Image black;
    public Animator anim;

    private void Start()
    {
        StartCoroutine(WaitOneSecond());
        //black.enabled = false;
    }
    public void ModeVR(string scene)
    {
        deviceName = "Cardboard";
        StartCoroutine(Fading(scene));
        //OpenApp(scene);
    }

    public void Mode360(string scene)
    {
        deviceName = "";
        StartCoroutine(Fading(scene));
        //OpenApp(scene);
    }

    public void QuitApplication()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    void OpenApp(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    IEnumerator Fading(string scene)
    {
        black.enabled = true;
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);

        OpenApp(scene);
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1.1f);
        black.enabled = false;
    }
}
