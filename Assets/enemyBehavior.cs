using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolDestination == 0) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f) {
                //hardcoded enemy size. try to use .x and y transform
                transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                patrolDestination = 1;
            }
        }
        if(patrolDestination == 1) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position,patrolPoints[1].position) < .2f) {
                transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
                patrolDestination = 0;
            }
        }
    }
}
