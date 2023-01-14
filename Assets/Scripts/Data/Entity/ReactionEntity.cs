using System;

[Serializable]
public class ReactionEntity
{
    public ActionType ActionType;
    public string Script;
    public float Reward;
    public long Honor;

    public ReactionEntity Clone()
    {
        return new ReactionEntity
        {
            ActionType = ActionType,
            Script = Script,
            Reward = Reward,
            Honor = Honor,
        };
    }
}