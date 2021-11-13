using UnityEngine;
using TMPro;
public class UIButton : MonoBehaviour
{
    [SerializeField] int length;

    public delegate void clickAction(int num);
    public static event clickAction onClicked;

    private void Start()
    {
        GetComponentInChildren<TMP_Text>().text = $"{length} unit";
    }

    public void setCubeLength()
    {
        onClicked.Invoke(length);
    }
}
