using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePoint : MonoBehaviour, TimedInputHandler
{
    public MultimediaObject _multObj;
    private Collider _collider;
    private RaycastReceiverMultimedia _raycast;

    public Vector3 scaleIn;
    public Vector3 scaleOut;

    // Start is called before the first frame update
    void Start()
    {
        scaleIn = transform.localScale;
        scaleOut = new Vector3(0, 0, 0);

        transform.localScale = scaleOut;

        _raycast = GetComponentInParent<RaycastReceiverMultimedia>();

        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hide()
    {
        _collider.enabled = false;
        StartCoroutine(RepeatLerp(transform.localScale, scaleOut, 1.0f, 1.0f));
    }

    public void Show()
    {
        _collider.enabled = true;
        StartCoroutine(RepeatLerp(transform.localScale, scaleIn, 1.0f, 1.0f));
    }

    public void HandleTimedInput(){
        _raycast.AnimateOut();
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time, float speed)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
