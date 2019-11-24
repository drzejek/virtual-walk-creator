using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerToMultimedia : Pointer
{
    private Collider _collider;

    void Start()
    {
        scaleIn = transform.localScale;
        scaleOut = new Vector3(0,0,0);

        _rend = GetComponent<Renderer>();
        _rend.material.color = new Color(0, 0, 1, 0.5f);
        _collider = GetComponentInParent<BoxCollider>();
    }
    
    public override void PushOut()
    {
        _collider.enabled = false;
        //transform.localScale = scaleOut;
        StartCoroutine(RepeatLerp(transform.localScale, scaleOut, 1.0f, 1.0f));
    }

    public override void PullIn()
    {
        _collider.enabled = true;
        //transform.localScale = scaleIn;
        StartCoroutine(RepeatLerp(transform.localScale, scaleIn, 1.0f, 1.0f));
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
