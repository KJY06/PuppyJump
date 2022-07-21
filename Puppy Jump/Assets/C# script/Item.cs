using UnityEngine;

public class Item : MonoBehaviour
{
    public bool forspawn;
    public int spawncnt;
    [SerializeField] private GameObject item;
    void Start()
    {
        forspawn = true;
        spawncnt = 0;
    }

    private void OnDestroy()
    {
        forspawn = true;
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (spawncnt == 1 && forspawn == true)
        {
            spawncnt++;
            float randomX = Random.Range(20, 30);
            forspawn = false;
            Instantiate(item, new Vector3(randomX, -2.7f, 0f), Quaternion.identity); 

        }
    }
}