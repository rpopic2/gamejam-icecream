using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Threading.Tasks;

public class CustomerTweener : MonoBehaviour
{
    public static CustomerTweener Instance;
    [SerializeField] private Image _customerImage;
    private float _imageHeight;
    private void Awake()
    {
        Instance = this;
        _imageHeight = 500;
    }
    public async Task CustomerIn()
    {
        var tween = _customerImage.transform.DOLocalMoveY(0f, 1f);
        tween.SetEase(Ease.InBounce, 0.1f);
        await tween.AsyncWaitForCompletion();
    }
    public async Task CustomerOut()
    {
        var tween = _customerImage.transform.DOLocalMoveY(-_imageHeight, 1f);
        await tween.AsyncWaitForCompletion();
    }
}
