using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuongControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public Animator anim;
    public float speed;
    public Vector2 size;
    public float speedChangeSize;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = 0;
        transform.localScale = size;
        speedChangeSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
                    transform.position.x + Time.deltaTime * speed,
                    transform.position.y, -1
                );
        transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime * speedChangeSize, transform.localScale.y + Time.deltaTime * speedChangeSize);
    }


}
