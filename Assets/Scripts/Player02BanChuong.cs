using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player02BanChuong : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float speed = 0;
    private float time = 0;
    private Vector2 size1 = new Vector2(0.3f, 0.3f);
    private Vector2 size2 = new Vector2(0.8f, 0.8f);
    private bool isMoving = false;

    [SerializeField]
    public GameObject chuongPosition1;
    public GameObject chuongPosition2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //gameObject.transform.localScale = size1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.localScale = size1;
            transform.position = chuongPosition1.transform.position;
            anim.SetBool("shoot", true);
            isMoving = false;
            time = 0;
            speed = 0;
        }

        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            time += Time.deltaTime;
            if (time >= 0.35f)
            {
                transform.localScale = size2;
                transform.Translate(chuongPosition2.transform.position - transform.position);
                speed = 10;
                time = 0;
                isMoving = false;
            }
        }

        gameObject.transform.position = new Vector3(
                    transform.position.x - Time.deltaTime * speed,
                    transform.position.y, -1
                );

    }
}
