using UnityEngine;

public class playerInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                spawnButton button = hit.transform.GetComponent<spawnButton>();
                if(button != null)
                {
                    button.spawn();
                }
            }
        }
    }
}
