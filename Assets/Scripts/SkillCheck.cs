using UnityEngine;

public class SkillCheck : FillTweener
{
    public static SkillCheck Instance;
    private bool _isFilling = true;
    [SerializeField] public Vector3 _snapOffset;
    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
    public void StartSkillCheck()
    {
        gameObject.SetActive(true);
        _tweenTarget.fillAmount = 0;
    }
    public void StopSkillCheck()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        int target = _isFilling ? 1 : 0;
        var fill = Mathf.MoveTowards(_tweenTarget.fillAmount, target, 1 / _time * Time.deltaTime);
        if (fill == 1) _isFilling = false;
        else if (fill == 0) _isFilling  = true;
        _tweenTarget.fillAmount = fill;
    }
    public void SnapPosition(Transform dest)
    {
        transform.position = dest.position + _snapOffset;
    }
}
