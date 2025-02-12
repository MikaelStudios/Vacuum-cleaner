using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    //public LevelSO Level;
   // public GameObject[] dirt;
    public float xPositive;
    public float xNegative;
    public float zPositive;
    public float zNegative;
    public Transform yPos;
    public float yOffset;

    public float colliderRadius = 0.2f;

    public float spawnTimer = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

        //InvokeRepeating("SpawnDirt", 0, spawnTimer);
        for (int i = 0; i < GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene.Length; i++)
        {
            if (GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i].CompareTag("coin"))
            {
                xPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickXPositive;
                xNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickXNegative;
                zPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickZPositive;
                zNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickZNegative;
                yOffset = 1.5f;
                //StartCoroutine(SpawnItem(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i].GetComponent<Item>(), i));
                for (int j = 0; j < GameManager.instance.gameLevel[GameManager.instance.currentLevelId].eggCount; j++)

                    Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i], RandomPos(), Quaternion.identity);
            }
            else if (GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i].CompareTag("Enemy"))
            {
                xPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].henXPositive;
                xNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].henXNegative;
                zPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].henZPositive;
                zNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].henZNegative;
                yOffset = 0;

                for (int j = 0; j < GameManager.instance.gameLevel[GameManager.instance.currentLevelId].henCount; j++)
                    Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i], RandomPos(), Quaternion.identity);
            }
            else if (GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i].CompareTag("dirt"))
            {
                xPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickXPositive;
                xNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickXNegative;
                zPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickZPositive;
                zNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickZNegative;
                yOffset = 0;
                for (int j = 0; j < GameManager.instance.gameLevel[GameManager.instance.currentLevelId].chickCount; j++)
                    Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i], RandomPos(), Quaternion.identity);
            }

            else if (GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i].CompareTag("Obstacles"))
            {
                xPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].fenceXPositive;
                xNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].fenceXNeagtive;
                zNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].fenceZNegative;
                zPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].fenceZPostive;
                yOffset = 4f;
                //float angle = Random.Range(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].minAngle, GameManager.instance.gameLevel[GameManager.instance.currentLevelId].maxAngle);
                float angle = Random.Range(0, 90);
                for (int j = 0; j < GameManager.instance.gameLevel[GameManager.instance.currentLevelId].fenceCount ; j++)
                {

                    Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i], SpawnSs(), Quaternion.AngleAxis(angle, Vector3.up));
                    //angle = Random.Range(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].minAngle, GameManager.instance.gameLevel[GameManager.instance.currentLevelId].maxAngle);
                    angle = Random.Range(0, 90);
                }


            }

            else if(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i].CompareTag("SpeedPowerUp"))
            {
                xPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].speedXPositive;
                xNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].speedXNegative;
                zNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].speedZNegative;
                zPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].speedZpositive;
                yOffset = 2.8f;

                StartCoroutine(SpawnEgg(i));
                
            }
            else if(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i].CompareTag("CrateBox"))
            {
                xPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].boxXPositive;
                xNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].boxXNegative;
                yOffset = 2.8f;
                zNegative = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].boxZNegative;
                zPositive = GameManager.instance.gameLevel[GameManager.instance.currentLevelId].boxZPositive;
                for (int j = 0; j < GameManager.instance.gameLevel[GameManager.instance.currentLevelId].boxCount; j++)
                    Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[i], RandomPos(), Quaternion.identity);
            }
        }
    }


    IEnumerator SpawnBox(int id)
    {
        yield return new WaitForSeconds(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].displayTimer);


        Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[id], RandomPos(), Quaternion.identity);
    }

    IEnumerator SpawnEgg(int id)
    {
        yield return new  WaitForSeconds(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].speedTimer);
             Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[id], RandomPos(), Quaternion.identity);
    }

    Vector3 RandomObstaclesPos()
    {
        float x = Random.Range(-4, 24);
        float y = yOffset;
        float z = Random.Range(-24, 30);

        Vector3 ns = new Vector3(x, y, z);
        return ns;
    }


    Vector3 SpawnSs()
    {
        Vector3 newPos = RandomObstaclesPos();

        Collider[] intersecting = Physics.OverlapSphere(newPos, colliderRadius);

        while (intersecting.Length != 0)
        {
            newPos = RandomObstaclesPos();
            intersecting = Physics.OverlapSphere(newPos, colliderRadius);
        }
        return newPos;
    }

    Vector3 RandomPos()
    {
        //bool validSpawnPoint = false;
        float Y = yPos.position.y + yOffset;
        float X = Random.Range(xNegative, xPositive);

       
        /*if (dirt[id].CompareTag("damage"))
            Y = 0.5f;
        else
            Y = 0.25f;*/
        
        float Z = Random.Range(zNegative, zPositive);

        Vector3 newPos = new Vector3(X,Y,Z);
       /* Collider[] intersecting = Physics.OverlapSphere(new Vector3(newPos.x, -1f, newPos.z), colliderRadius);
        Collider[] surface = Physics.OverlapSphere(newPos, colliderRadius);

        while (intersecting.Length == 0 || (surface.Length != 0 && !surface[0].CompareTag("validspawnpoint")))
        {
            X = Random.Range(xNegative, xPositive);
            Z = Random.Range(zNegative, zPositive);
            newPos = new Vector3(X, Y, Z);
            surface = Physics.OverlapSphere(newPos, colliderRadius);
            intersecting = Physics.OverlapSphere(new Vector3(newPos.x, -1f, newPos.z), colliderRadius);
        }

        intersecting = Physics.OverlapSphere(newPos, colliderRadius);

        while (intersecting.Length != 0 && intersecting[0].CompareTag("validspawnpoint"))
        {
            Y += 1.0f;
            newPos = new Vector3(X, Y, Z);
            intersecting = Physics.OverlapSphere(newPos, colliderRadius);
        }*/

        return newPos; 
    }


    void SpawnDirt()
    {
        int id = Random.Range(0, GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene.Length);
        float probability = Random.Range(0f, 1.0f);
         while (GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[id].GetComponent<Item>().itemType == Item.ItemType.Vacuum && probability > 0.2)
            id = Random.Range(0, GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene.Length);

        Instantiate(GameManager.instance.gameLevel[GameManager.instance.currentLevelId].itemsSpawnedInScene[id], RandomPos(), Quaternion.identity);
    }
}
