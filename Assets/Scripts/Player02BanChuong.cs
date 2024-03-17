using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player02BanChuong : MonoBehaviour
{
    private float speed = 0;
    private float time = 0;
    private Vector2 size1 = new Vector2(0.3f, 0.3f);
    private Vector2 size2 = new Vector2(0.8f, 0.8f);
    private bool isMoving = false;

    [SerializeField]
    private GameObject chuongPosition1;
    [SerializeField]
    private GameObject chuongPosition2;
    [SerializeField]
    public GameObject prefabs;
    List<GameObject> ChuongPool;
    int poolSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        ChuongPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject chuong = Instantiate(prefabs);
            chuong.SetActive(false); // đánh dấu chưa dùng
            ChuongPool.Add(chuong);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            GameObject chuong = GetFreeChuong();
            chuong.transform.position = new Vector2(chuongPosition1.transform.position.x, chuongPosition1.transform.position.y);
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
