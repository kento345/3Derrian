using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private int count = 0;
    private int max = 10;

    [SerializeField] private GameObject point;


    const int FIELD_SIZE_X = 6;
    const int FIELD_SIZE_Z = 6;



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
        for (int x = 0; x < FIELD_SIZE_X; x++)
        {
            for (int z = 0; z < FIELD_SIZE_Z; z++)
            {
                var sprit = Instantiate(point, new Vector3(10.0f * x, 0, 10.0f * z), Quaternion.identity);
            }
        }

    }

    void Update()
    {
    
    }

   
}
