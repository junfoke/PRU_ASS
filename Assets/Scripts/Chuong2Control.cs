using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chuong2Control : MonoBehaviour
{
    private CircleCollider2D coll;
    public Animator anim;
    private float speed;
    private Vector2 size = new Vector2(0.3f, 0.3f);
    private Vector2 size2 = new Vector2(0.8f, 0.8f);

    [SerializeField]
    private GameObject chuongPosition2;
    [SerializeField] private string Player1;
    public ManageHealth ManageHealth;

    private float timeVanChuong = 0;
    private float timeComplete = 0;
    private bool isMoving;

    private float mana = 0;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
        speed = 0;
        transform.localScale = size;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            anim.SetBool("shoot", true);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            mana += Time.deltaTime * 10;
        }
        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            timeVanChuong += Time.deltaTime;
            if (timeVanChuong >= 0.35f)
            {
                transform.localScale = size2;
                transform.Translate(chuongPosition2.transform.position - transform.position);
                speed = 10;
                timeVanChuong = 0;
                isMoving = false;

            }
        }

        gameObject.transform.position = new Vector2(
                    transform.position.x - Time.deltaTime * speed,
                    transform.position.y
                );
        if (speed > 0 && mana != 0)
        {
            ManageHealth.Manage_Mana(1, -1 * mana);
            damage = mana * 3;
            mana = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player1))
        {
            ManageHealth.Manage_HP(1, -1*damage);
            gameObject.SetActive(false);
            speed = 0;
            timeVanChuong = 0;
            transform.localScale = size;
        }
    }
}
