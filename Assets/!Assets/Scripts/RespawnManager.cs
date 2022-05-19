using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> MobPool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCount;
    public PlayerControl player;

    public float SpawnIntervalMAX = 0;
    public float SpawnIntervalMIN = 0;

    private void Awake()
    {
        for(int i = 0; i<Mobs.Length; i++)
        {
            for(int q = 0; q < objCount; q++)
            {
                MobPool.Add(CreateObj(Mobs[i], transform));
            }
        }
    }

    private void Start()
    {
        StartCoroutine(CreateMob());
    }

    IEnumerator CreateMob()
    {
        while (true)
        {
            if (!GameManager.instance.onQuiz && player.isLive)
            {
                MobPool[DisableMob()].SetActive(true);
            }
            yield return new WaitForSecondsRealtime(Random.Range(SpawnIntervalMIN, SpawnIntervalMAX));
        }
    }

    int DisableMob()
    {
        List<int> num = new List<int>();
        for(int i=0; i<MobPool.Count; i++)
        {
            if (!MobPool[i].activeSelf)
            {
                num.Add(i);
            }
        }
        int x = 0;
        if (num.Count > 0)
        {
            x = num[Random.Range(0, num.Count)];
        }
        //Debug.Log($"{x}번째 오브젝트({MobPool[x].gameObject.name})가 선택됨");
        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
}
