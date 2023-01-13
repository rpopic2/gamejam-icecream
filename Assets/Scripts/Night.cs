using Rpopic.Window;
using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    private GameObjectDict<Button> _buttons;
    private void Awake() {
        _buttons = new(_canvas.gameObject);

        _buttons.Bind("btn_end_day", OnEndDay);
    }
    private void OnEndDay()
    {
        AlertBox.Instance.Alert("Result of the day: ", OnAnswer);
        void OnAnswer(bool _)
        {
            SceneLoader.Load(Scene.Day);
        }
    }
}
