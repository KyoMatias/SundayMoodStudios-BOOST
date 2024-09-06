using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterStorage : MonoBehaviour
{
    public StoryChapter[] storyChapters;

    public StoryChapter[] GetStoryChapters()
    {
        return storyChapters;
    }

}
