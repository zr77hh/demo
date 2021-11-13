using UnityEngine;

public class spawnButton : MonoBehaviour
{
    [SerializeField] cube cubePrefab;
    int cubeLength = 2;
    Vector3 raycastPos;
    private void OnEnable()
    {
        UIButton.onClicked += setCubeLength;
    }
    public void spawn()
    {
        raycastPos = transform.position + transform.forward * 0.4f + new Vector3(0, 0, -1);
        if (Physics.Raycast(raycastPos, transform.forward, out RaycastHit hit, 10))
        {
            if (thereIsSpace(hit.point))
            {
                cube _cube = Instantiate(cubePrefab, raycastPos, transform.rotation);
                _cube.setCubeLength(cubeLength);
                _cube.calculateTargetPosition(hit.point);
            }
        }
    }
    void setCubeLength(int lenght)
    {
        cubeLength = lenght;
    }
    bool thereIsSpace(Vector3 hitPoint)
    {
        return Vector3.Distance(raycastPos, hitPoint) >= cubeLength;
    }
    private void OnDisable()
    {
        UIButton.onClicked -= setCubeLength;
    }
}
