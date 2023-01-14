using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ConeSelection : MonoBehaviour
{
    private Button _buttons;
    private int _index;
    private void Awake()
    {
        _index = transform.GetSiblingIndex();
        _buttons = GetComponent<Button>();
        _buttons.onClick.AddListener(SelectCone);

    }
    private void SelectCone()
        => PreviewIcecream.Instance.SetCone(_index);
}
