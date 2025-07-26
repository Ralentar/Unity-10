using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] int _force = 500;
    [SerializeField] int _radius = 5;

    public void Explode(GameObject[] cubes, Cube parent)
    {       
        foreach (GameObject explodableObject in cubes)
            explodableObject.GetComponent<Rigidbody>().AddExplosionForce(_force, parent.transform.position, _radius);
    }
}