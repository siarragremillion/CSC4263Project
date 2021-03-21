/**
Reference: https://www.youtube.com/watch?v=6Lxc27gg9DA Enemy AI - Grunt Follow by Tyler Potts
will likely need to replace with pathfinding AI later once we add obstacles
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectDistance = 5f;
    [SerializeField] Transform target;

    private void Update(){
        if(target != null){
            /**
            ROTATE ENEMY was in video but we probably won't use, I just left it in case we want 
            like a worm enemy or something
            */
            // float offset = -90f;
            // Vector2 _direction = target.position - transform.position;
            // _direction.Normalize();
            // float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

            // transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, _angle + offset));

            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate(){
        target = FindTarget();
    }
    Transform FindTarget(){
        if(target == null){
            Transform _target = GameObject.FindGameObjectWithTag("Player").transform;

            if(_target != null){
                float _dist = Vector2.Distance(_target.position, transform.position);

                if(_dist <= detectDistance){
                    return _target;
                }else{
                    return null;
                }
            }else{
                return null;
            }
        }else{
            float _dist = Vector2.Distance(target.position, transform.position);

            if(_dist <= detectDistance){
                return target;
            }else{
                return null;
            }
        }
    }
}
