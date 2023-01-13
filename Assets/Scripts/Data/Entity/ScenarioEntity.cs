using System;

[Serializable]
public class ScenarioEntity
{
    // 시나리오 묶음
    public long GroupId;
    // 대사 순번
    public long Order;
    // 목표 점수
    public long NeedScore;
    // 현재 대화 상태
    public CommunicationType CommunicationType;
    // 대사 멘트
    public string ScenarioScript;
}

public class Scenario
{
    public long GroupId { get; private set; }
    public long Order { get; private set; }
    public long NeedScore { get; private set; }
    public CommunicationType CommunicationType { get; private set; }
    public string Script { get; private set; }

    public Scenario(long groupId, long order, long needScore, CommunicationType communicationType, string script)
    {
        GroupId = groupId;
        Order = order;
        NeedScore = needScore;
        CommunicationType = communicationType;
        Script = script;
    }
}
