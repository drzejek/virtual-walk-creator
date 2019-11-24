using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private IDictionary<int, Vector3> cameraPositionDictionary;

    public RaycastReceiverMultimedia[] reiceversMultimedia;
    public RaycastReceiverPointer[] reiceversPointer;

    public PointerToMoveCamera _pointer;

    public MultimediaAndPointerContainer _container;

    private int currentScene;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraPositionDictionary = new Dictionary<int, Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter != 1)
        {
            _container = FindObjectOfType<MultimediaAndPointerContainer>();

            Scene[] scenes = GameObject.FindObjectsOfType<Scene>();
            for (int i = 0; i < scenes.Length; i++)
            {
                cameraPositionDictionary.Add(scenes[i].GetSceneNumber(), scenes[i].GetScenePosition());
                if (transform.localPosition == scenes[i].GetScenePosition())
                {
                    currentScene = scenes[i].GetSceneNumber();
                }
            }

            counter = 1;
        }
    }

	public void MoveCamera(int nextScene)
    {
        _container.HideAndChangeVisibility(currentScene, nextScene);
        StartCoroutine(LerpFromTo(transform.localPosition, cameraPositionDictionary[nextScene], 1f));
        currentScene = nextScene;
    }

	IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        transform.position = pos2;
    }

}
