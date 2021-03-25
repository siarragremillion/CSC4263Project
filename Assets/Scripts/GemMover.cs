using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMover : MonoBehaviour
{
    public float speed = 3f;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z);
        Debug.Log(target);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            target = other.transform.position;
        }
    }
}
