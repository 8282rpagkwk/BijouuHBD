using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [Header("스테이지")]
    /*[SerializeField] List<GameObject> Stage1 = new List<GameObject>();
    [SerializeField] List<GameObject> Stage2 = new List<GameObject>();
    [SerializeField] List<GameObject> Stage3 = new List<GameObject>();
    [SerializeField] List<GameObject> Stage4 = new List<GameObject>();*/
    public GameObject[] Grounds;
    GameManager gm;
    private void Start()
    {
        gm = GameManager.instance;
    }

    public void SpawnGround()
    {

        /*if(index <= Stage1.Count - 1)
        {
            GameObject obj = Instantiate(Stage1[index], new Vector3(gm.MAX_RIGHT_POS, 0, 0), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
            index++;
        }*/
        GameObject obj = Instantiate(Grounds[gm.stage - 1], new Vector3(gm.MAX_RIGHT_POS + 3.5f, 0, 0), Quaternion.identity);
        obj.transform.SetParent(this.gameObject.transform);
    }
}
