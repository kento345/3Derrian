using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private int count = 0;
    private int max = 10;

   



    void Start()
    {
        if(count < max)
        {
            if(enemy == null) {return;}
            var randx = Random.Range(0, 53);
            var randz = Random.Range(0, 53);
            Instantiate(enemy, new Vector3(randx, 0, randz), Quaternion.identity);
            count++;
        }
       

    }

    void Update()
    {
    
    }

   
}
