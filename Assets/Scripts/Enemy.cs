using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Spawner spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = FindAnyObjectByType<Spawner>();
    }
    public void SetSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }

    void OnMouseDown()
    {
        if(gameObject.activeSelf){
        spawner.ReturnPool(gameObject);
        //  Spawner.numEnemys--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
