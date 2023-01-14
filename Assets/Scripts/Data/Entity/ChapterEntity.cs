using System;

[Serializable]
public class ChapterEntity
{
    public long ChapterId;
    public long StageId;
    public long DayCount;
}

public class Chapter
{
    public long ChapterId;
    public long StageId;
    public long DayCount;

    public Chapter(ChapterEntity data)
    {
        ChapterId = data.ChapterId;
        StageId = data.StageId;
        DayCount = data.DayCount;
    }
}