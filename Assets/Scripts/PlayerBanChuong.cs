using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBanChuong : MonoBehaviour
{

    [SerializeField]
    public GameObject chuongPosition;
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
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject Chuong = GetFreeChuong();
            Chuong.transform.position = new Vector2(chuongPosition.transform.position.x, chuongPosition.transform.position.y);
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
