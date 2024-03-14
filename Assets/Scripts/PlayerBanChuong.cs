using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBanChuong : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    //private Animator anim;
    private float speed = 0;
    private Vector2 size = new Vector2(0.5f, 0.5f);
    private float time = 0; // Thời gian để bắt đầu vận chưởng
    private float time01 = 0; // Thời gian để bắt đầu bắn nếu vận chưởng chưa đủ

    [SerializeField]
    public GameObject chuongPosition;
    [SerializeField]
    public GameObject prefabs;

    List<GameObject> ChuongPool;
    int poolSize = 10;
    GameObject Chuong;
    ChuongControl script;

    Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        gameObject.transform.localScale = size;
        ChuongPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(prefabs);
            bullet.SetActive(false); // đánh dấu chưa dùng
            ChuongPool.Add(bullet);
        }
        Chuong = new GameObject();
        position = new Vector2();
    }

    // Update is called once per frame
    public void Update()
    {
        //Vector2 position = new Vector2(chuongPosition.transform.position.x, chuongPosition.transform.position.y);
        //Debug.Log("test:   " + Chuong.transform.position.x);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Chuong = GetFreeChuong();
            script = Chuong.GetComponent<ChuongControl>();
            //Chuong.transform.localScale = size;
            script.size = size;
            speed = 0;
            time = 0;
            position = new Vector2(chuongPosition.transform.position.x, chuongPosition.transform.position.y);
        }
        if (Input.GetKey(KeyCode.F))
        {
            time += Time.deltaTime;
            if (time > 0.48f)
            {
                Chuong.transform.position = position;
                //Chuong.transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime * 2, transform.localScale.y + Time.deltaTime * 2);
                script.speedChangeSize = 2;
                script.anim.SetBool("shoot", true);
            }
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (time > 0.48f)
            {
                script.speed = 10;
                script.speedChangeSize = 0;
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
                Chuong.transform.position = position;
                Chuong.transform.localScale = size;
                script.anim.SetBool("shoot", true);
                script.speed = 10;
                time = 0;
                time01 = 0;
            }
        }

    }

    GameObject GetFreeChuong()
    {
        foreach (var item in ChuongPool)
        {
            if (item.activeSelf == false)
            {
                item.SetActive(true);
                return item;
            }

        }
        return null;
    }
}
