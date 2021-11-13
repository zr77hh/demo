using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color offsetColor, baseColor;
    [SerializeField] Renderer renderer;
    public void Init(bool isOffset)
    {
        if (isOffset)
        {
            renderer.material.color = offsetColor;
        }
        else
        {
            renderer.material.color = baseColor;
        }
    }
}