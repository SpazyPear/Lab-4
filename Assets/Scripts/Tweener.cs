using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    List<Tween> activeTweens = new List<Tween>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = activeTweens.Count; x > 0; x--)
        {
            //float progress = activeTweens[x].target.position / activeTweens[x].endPos;
        }

    }

    public void addTween(Transform target, Vector3 endPos, float duration)
    {
        activeTweens.Add(new Tween(target, endPos, duration));
    }


}

public struct Tween
{
    public Transform target;
    public Vector3 startPos;
    public Vector3 endPos;
    public float duration;

    public Tween(Transform target, Vector3 endPos, float duration)
    {
        this.target = target;
        this.startPos = target.position;
        this.endPos = endPos;
        this.duration = duration;
    }
}
