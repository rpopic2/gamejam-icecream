using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Threading.Tasks;

public class CustomerTweener : MonoBehaviour
{
    public static CustomerTweener Instance;
    [SerializeField] private Transform _tweenTarget;
    [SerializeField] private Ease _ease = Ease.InBounce;
    [SerializeField] private float _outTargetPos;
    [SerializeField] private float _inTargetPos;
    [SerializeField] private float _overshoot = 0.1f;
    [SerializeField] private float _duration = 1f;
    private float _imageHeight;
    private void Awake()
    {
        Instance = this;
        _imageHeight = 500;
    }
    public async Task CustomerIn()
    {
        var tween = _tweenTarget.DOLocalMoveY(_inTargetPos, _duration);
        tween.SetEase(_ease, _overshoot);
        await tween.AsyncWaitForCompletion();
    }
    public async Task CustomerOut()
    {
        var tween = _tweenTarget.DOLocalMoveY(_outTargetPos, 1f);
        await tween.AsyncWaitForCompletion();
    }
}
