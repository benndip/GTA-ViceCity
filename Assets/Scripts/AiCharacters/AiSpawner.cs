using System.Collections;
using UnityEngine;

public class AiSpawner : MonoBehaviour
{
    public GameObject[] AiPrefabs;
    public int AiToSpawn;
    public int Timer;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;

        while(count < AiToSpawn)
        {
            int randomIndex = Random.Range(0, AiPrefabs.Length);

            GameObject obj = Instantiate(AiPrefabs[randomIndex]);

            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));

            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForSeconds(Timer);

            count++;
        }
    }

}
