using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void Awake()
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Explosive"))
            _cubes.Add(cube.GetComponent<Cube>());
    }

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
            cube.Click += ProcessEvent;
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
            cube.Click -= ProcessEvent;
    }

    private void ProcessEvent(Cube cube)
    {
        float segmentation—hance = Random.Range(0, 100);

        print($"{segmentation—hance} vs {cube.SegmentationThreshold}");

        if (segmentation—hance <= cube.SegmentationThreshold)
        {
            GameObject[] newCubes = _spawner.SpawnCubes(cube);

            foreach (GameObject newCube in newCubes)
                newCube.gameObject.GetComponent<Cube>().Click += ProcessEvent;

            _exploder.Explode(newCubes, cube);
        }

        Destroy(cube.gameObject);
    }
}