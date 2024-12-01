using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Debug/Developer Script", fileName = "BOOST_Chapter")]
public class BOOST_Chapter : ScriptableObject
{
        public string ChapterName;
        public int ChapterCode;
        public bool IsFinished;

        private void OnEnable()
        {
                GetName();
                GetCode();
                GetCompletion();
        }
        
        public string GetName()
        {
                return ChapterName;
        }

        public int GetCode()
        {
                return ChapterCode;
        }

        public bool GetCompletion()
        {
                return IsFinished;
        }
}
