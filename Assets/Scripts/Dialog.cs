using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private float _typindIntervalSeconds = 0.01f;
    public static Dialog Instance;
    private TMP_Text _dialogText;
    private string _dialog;
    private int _ptr = 0;
    private int _strlen = 0;
    private void Awake()
    {
        Instance = this;
        _dialogText = GetComponent<TMP_Text>();
    }
    public void Print(string dialog)
    {
        _dialog = dialog;
        StartCoroutine(PrintDialogEffect());
    }
    private IEnumerator PrintDialogEffect()
    {
        _ptr = 0;
        _strlen = _dialog.Length;
        _dialogText.text = "";
        while (_ptr < _strlen) {
            _dialogText.text += _dialog[_ptr++];
            yield return new WaitForSeconds(_typindIntervalSeconds);
        }
    }
    public async Task WaitDialogAsync()
    {
        while (_ptr < _strlen)
        {
            await Task.Delay(100);
        }
    }
}
