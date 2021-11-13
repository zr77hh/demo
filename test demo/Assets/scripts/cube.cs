using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour
{
    Vector3 targetPos;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime*15);
    }
    public int getCubeLength()
    {
        return (int) transform.localScale.z;
    }
    public void setCubeLength(int length)
    {
        transform.localScale = new Vector3(1, 1, length);
    }
    public void calculateTargetPosition(Vector3 hitPoint)
    {
        targetPos = hitPoint - transform.forward * getCubeLength() / 2;
    }
    
}
