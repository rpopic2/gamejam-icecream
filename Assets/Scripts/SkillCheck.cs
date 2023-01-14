using UnityEngine;

public class SkillCheck : FillTweener
{
    private const int begin = -135;
    private const int end = 88;
    public static SkillCheck Instance;
    private bool _isFilling = true;
    [SerializeField] public Vector3 _snapOffset;
    [SerializeField] public RectTransform _starZone;
    [SerializeField] public RectTransform _star;
    [SerializeField] private float _minSpeedSecond = 0;
    [SerializeField] private float _maxSpeedSecond = 0;
    [SerializeField] private float _minWidth = 0;
    [SerializeField] private float _maxWidth = 0;
    [SerializeField] private float _minStartX = 0;
    [SerializeField] private float _maxEndX = 0;
    private float _speed = 1;
    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
    public void StartSkillCheck()
    {
        gameObject.SetActive(true);
        _tweenTarget.fillAmount = 0;
        var randomSize = Random.Range(0f, 1f);
        _starZone.sizeDelta = Vector2.Lerp(new(_minWidth, 0f), new(_maxWidth, 0f), randomSize);
        var randomMove = Random.Range(_minStartX, _maxEndX);
        _starZone.localPosition = Vector3.right * randomMove;
        _speed = 100 * Random.Range(_minSpeedSecond, _maxSpeedSecond);
    }
    public void StopSkillCheck()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        int target = _isFilling ? end : begin;
        var fill = Mathf.MoveTowards(_star.localPosition.x, target, _speed * Time.deltaTime);
        if (fill == end) _isFilling = false;
        else if (fill == begin) _isFilling  = true;
        _star.localPosition = new(fill, _star.localPosition.y, 0f);
    }
    public void SnapPosition(Transform dest)
    {
        transform.position = dest.position + _snapOffset;
    }
}
