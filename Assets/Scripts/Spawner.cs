using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{


    private Queue<GameObject> pool = new Queue<GameObject>();
    private float xPosition;
    private float zPosition;
    public static int numEnemys;
    public TextMeshProUGUI enemyCountText;
    GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddToPool(10);
        StartCoroutine(CreateEnemy());
    }


    void AddToPool(int size) {
        for(int i = 0; i< size;i++){
            // xPosition = Random.Range(-10,20);
            // zPosition = Random.Range(-10,18);
            enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            enemy.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            enemy.AddComponent<Enemy>();
            enemy.SetActive(false);
            pool.Enqueue(enemy);
            
            enemyCountText.text = "0";
        }
    }


    void SpawnerEnemy() {
        if(pool.Count>0){
            float x = Random.Range(-10f, 20f);
            float z = Random.Range(-10f, 18f);   
            enemy = pool.Dequeue();
           enemy.transform.position = new Vector3(x,0.51f,z);
           enemy.SetActive(true);
           numEnemys++;
           enemyCountText.text = numEnemys.ToString();
        }else {
            AddToPool(1);
            SpawnerEnemy();
        }
    }

    public void ReturnPool(GameObject enemy){
      enemy.SetActive(false);
      pool.Enqueue(enemy);
       numEnemys--;
       enemyCountText.text = numEnemys.ToString();

    }


    IEnumerator CreateEnemy(){
        while(numEnemys< 11){

        yield return new WaitForSeconds(2);
        SpawnerEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        numEnemys =  FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Length;
    }
}
