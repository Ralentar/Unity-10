using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public GameObject[] SpawnCubes(Cube parent)
    {
        float segmentationThreshold = parent.SegmentationThreshold / 2;
        float scaleRatio = 0.5f;

        Vector3 position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
        Vector3 localScale = parent.transform.localScale * scaleRatio;

        int count = Random.Range(2, 7);
        GameObject[] newCubes = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = Random.insideUnitSphere * position.magnitude * 0.1f;
            GameObject cube = Instantiate(_prefab, position + offset, Quaternion.identity);

            cube.transform.localScale = localScale;
            cube.GetComponent<Cube>().SetSegmentationThreshold(segmentationThreshold);

            newCubes[i] = cube;
        }

        return newCubes;
    }
}