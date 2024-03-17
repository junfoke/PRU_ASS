using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChuongControl : MonoBehaviour
{
    private CircleCollider2D coll;
    public Animator anim;
    private float speed;
    private Vector2 size = new Vector2(0.5f, 0.5f);
    private Vector2 size2 = new Vector2(1.7f, 1.7f);
    private float speedChangeSize;

    [SerializeField] private string Player2;
    public ManageHealth ManageHealth;

    private float timeVanChuong = 0;
    private float timeComplete = 0;
    private float mana = 0;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
        speed = 0;
        transform.localScale = size;
        speedChangeSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && speed == 0)
        {
            timeVanChuong += Time.deltaTime;
            mana += Time.deltaTime*10;
            if (timeVanChuong > 0.48f)
            {
                speedChangeSize = 2;
                anim.SetBool("shoot", true);
            }
        }

        if (Input.GetKeyUp(KeyCode.F) && speed == 0)
        {
            if (timeVanChuong > 0.48f)
            {
                speed = 10;
                speedChangeSize = 0;
                timeVanChuong = 0;
            }
            else
            {
                mana = 5f;
                timeComplete = timeVanChuong;
            }

        }

        if (timeVanChuong < 0.48f && timeVanChuong > 0 && !Input.GetKey(KeyCode.F) && speed == 0)
        {
            timeComplete += Time.deltaTime;
            if (timeComplete > 0.48f)
            {
                transform.position = new Vector2(transform.position.x - 0.16f, transform.position.y);
                anim.SetBool("shoot", true);
                speed = 10;
                timeVanChuong = 0;
                timeComplete = 0;
            }
        }

        transform.position = new Vector2(
                    transform.position.x + Time.deltaTime * speed,
                    transform.position.y
                );
        if (transform.localScale.x <= size2.x)
        {
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime * speedChangeSize, transform.localScale.y + Time.deltaTime * speedChangeSize);
        }
        coll.radius = gameObject.transform.localScale.x * (0.23f / 0.8f);

        if (speed > 0 && mana != 0)
        {
            ManageHealth.Manage_Mana(1, -1*mana);
            damage = mana * 3;
            mana = 0;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player2))
        {
            Debug.Log(damage);
            ManageHealth.Manage_HP(2, -1* damage);
            gameObject.SetActive(false);
            speed = 0; 
            speedChangeSize = 0; 
            timeVanChuong = 0;
            transform.localScale = size;
            damage = 0;
        }
    }

}
