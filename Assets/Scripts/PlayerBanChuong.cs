using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBanChuong : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float speed = 0;
    private Vector2 size = new Vector2(0.5f, 0.5f);
    private float time = 0; // Thời gian để bắt đầu vận chưởng
    private float time01 = 0; // Thời gian để bắt đầu bắn nếu vận chưởng chưa đủ

    [SerializeField]
    public GameObject chuongPosition;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.transform.localScale = size;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 position = new Vector2(chuongPosition.transform.position.x, chuongPosition.transform.position.y);

        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.transform.localScale = size;
            speed = 0;
            time = 0;
        }
        if (Input.GetKey(KeyCode.F))
        {
            time += Time.deltaTime;
            if (time > 0.48f)
            {
                gameObject.transform.position = position;
                gameObject.transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime * 2, transform.localScale.y + Time.deltaTime * 2);
                anim.SetBool("shoot", true);
            }
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (time > 0.48f)
            {
                speed = 10;
                time = 0;
            }
            else
            {
                time01 = time;
            }

        }

        if (time < 0.48f && time > 0 && !Input.GetKey(KeyCode.F))
        {
            time01 += Time.deltaTime;
            if (time01 > 0.48f)
            {
                gameObject.transform.position = position;
                gameObject.transform.localScale = size;
                anim.SetBool("shoot", true);
                speed = 10;
                time = 0;
                time01 = 0;
            }
        }

        gameObject.transform.position = new Vector3(
                    transform.position.x + Time.deltaTime * speed,
                    transform.position.y, -1
                );
    }
}
