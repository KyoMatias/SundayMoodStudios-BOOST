using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Story Chapter",menuName = "MenuMain/Story")]
public class StoryChapter : ScriptableObject
{
    public int ChapterID;
    public string Title;
    public string Eyecatch;
    [Header("Description")]
    [TextArea]
    public string Description;

    [Header("Chapter Logic")]
    public bool InProgress;
    public bool Completed;

}
