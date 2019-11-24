using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultimediaObject : MonoBehaviour
{
    protected Renderer _rend;
    protected Vector3 minScale;
    protected Scene _scene;
    protected string _multimediaType;
    private Vector4 inColor;

    protected Vector3 maxScale;
    private Vector4 outColor;
    protected bool isPositionOut;
	public bool isActive;
    public int sceneNumber;
    public EventTrigger trigger;
    public RaycastReceiverMultimedia _raycastReceiver;

    protected float localPositionX;
    public float speed;
    public float duration;
    protected float i;

    public Vector3 positionOut;
    public Vector3 positionIn;

    public ClosePoint _closePoint;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        //sceneNumber = GetComponentInParent<Scene>().GetSceneNumber();
        //trigger = GetComponent<EventTrigger>();

        positionIn = transform.position;
        isPositionOut = false;

        minScale = new Vector3(0, 0, 0);
        maxScale = transform.localScale;
        SetColor();
		isActive = false;
    }

    public void SetColor()
    {
        outColor = new Color (1.0f, 1.0f, 1.0f, 1.0f);
        inColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        _rend.material.color = outColor;
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, Vector4 c, Vector4 d, float time)
    {
        i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            _rend.material.color = Vector4.Lerp(c, d, i);

            if(i >= 1.0f && isPositionOut) {
                transform.localPosition = positionIn;
                isPositionOut = false;
            }
            yield return null;
        }
    }

    public IEnumerator AnimateIn()
    {
		isActive = true;
        yield return RepeatLerp(maxScale, minScale, inColor, outColor, duration);
    }

    public IEnumerator AnimateOut()
    {
		isActive = false;
        yield return RepeatLerp(minScale, maxScale, outColor, inColor, duration);
    }

    public void PullIn()
    {
        transform.localPosition = positionOut;
        StartCoroutine(AnimateIn());
    }

    public void PushOut()
    {
        isPositionOut = true;
        StartCoroutine(AnimateOut());
    }

    /*public void ChangeVisibility(bool isVisible)
    {
        trigger.enabled = isVisible;
        _raycastReceiver.enabled = isVisible;
        //Debug.Log(trigger.enabled);
    }*/

    public virtual void PlayMultimedia() {
    }

    public virtual void StopMultimedia(){
    }

    public virtual void RotateToLeft(){
    }

    public virtual void RotateToRight(){
    }

    public string GetMultimediaType()
    {
        return _multimediaType;
    }

    public Vector3 GetGlobalPosition()
    {
        return transform.position;
    }

    public Vector3 GetTopRightCorner(Vector3 position)
    {
        float xLocalScale = (transform.localScale.x * 10) / 2;
        float zLocalScale = (transform.localScale.z * 10) / 2;
        Vector3 topRightCorner = new Vector3(
            position.x - 0.01f,
            position.y + zLocalScale,
            position.z - xLocalScale);
        return topRightCorner;
    }

    public Vector3 GetDownLeft(Vector3 position)
    {
        float xLocalScale = (transform.localScale.x * 10) / 2;
        float zLocalScale = (transform.localScale.z * 10) / 2;
        Vector3 downLeft = new Vector3(
            position.x - 0.01f,
            position.y - zLocalScale,
            position.z - 0.1f);
        return downLeft;
    }

    public Vector3 GetUp(Vector3 position)
    {
        Vector3 up = new Vector3(
            position.x,
            position.y + 0.05f,
            position.z);
        return up;
    }

    public Vector3 GetDownRight(Vector3 position)
    {
        float xLocalScale = (transform.localScale.x * 10) / 2;
        float zLocalScale = (transform.localScale.z * 10) / 2;
        Vector3 downLeft = new Vector3(
            position.x - 0.01f,
            position.y - zLocalScale,
            position.z + 0.1f);
        return downLeft;
    }

    public virtual Vector2 GetRightCorner(){
        return new Vector2(0, 0);
    }
}
