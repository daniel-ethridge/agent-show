using UnityEngine;

public class LeaveCube : MonoBehaviour
{

    public GameObject boundCube;


    public void GenerateCube()
    {
        GameObject.Instantiate(boundCube, this.transform.position, Quaternion.identity);
    }
}
