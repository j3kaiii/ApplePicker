using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightAge = 4f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBeetwenAppleDrop = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBeetwenAppleDrop);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightAge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightAge)
        {
            speed = -Mathf.Abs(speed);
        } 
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }
}
