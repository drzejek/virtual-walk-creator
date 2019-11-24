using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultimediaAndPointerContainer : MonoBehaviour
{
    public RaycastReceiverMultimedia[] reiceversMultimedia;
    public RaycastReceiverPointer[] reiceversPointer;

    private int _currentScene = 0;
    private int counter = 0;
    //private int currentScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        reiceversMultimedia = GameObject.FindObjectsOfType<RaycastReceiverMultimedia>();
        reiceversPointer = GameObject.FindObjectsOfType<RaycastReceiverPointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter != 1)
        {
            for (int i = 0; i < reiceversMultimedia.Length; i++)
            {
                bool isVisible = reiceversMultimedia[i]._sceneNumber == _currentScene;
                reiceversMultimedia[i].ChangeVisibility(isVisible);
            }

            for (int i = 0; i < reiceversPointer.Length; i++)
            {
                bool isVisible = reiceversPointer[i]._sceneNumber == _currentScene;
                reiceversPointer[i].ChangeVisibility(isVisible);
            }
            counter = 1;
        }
    }

    public void HideAndChangeVisibility(int currentScene, int nextScene)
    {

        for (int i = 0; i < reiceversMultimedia.Length; i++)
        {
            if (reiceversMultimedia[i]._multObj && reiceversMultimedia[i]._sceneNumber == currentScene)
            {
                reiceversMultimedia[i].AnimateOut();
            }
            bool isVisible = reiceversMultimedia[i]._sceneNumber == nextScene;
            reiceversMultimedia[i].ChangeVisibility(isVisible);
        }

        for (int i = 0; i < reiceversPointer.Length; i++)
        {
            bool isVisible = reiceversPointer[i]._sceneNumber == nextScene;
            reiceversPointer[i].ChangeVisibility(isVisible);
        }

        _currentScene = currentScene;
    }
}
