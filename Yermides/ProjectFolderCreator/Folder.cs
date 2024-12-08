using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yermides.ProjectFolderCreator
{
    [Serializable]
    public class Folder
    {
        [SerializeField] private string name;
        [SerializeField] private List<Folder> children;

        public string GetName() => name;
        public List<Folder> GetChildren() => children;
    }
}