using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace Yermides.ProjectFolderCreator
{
    [CreateAssetMenu(menuName = "Yermides/New Folder Structure", fileName = "FolderStructure")]
    public class CreateProjectFolders : ScriptableObject
    {
        [SerializeField] private Folder rootFolder;
        [SerializeField] private bool showLog = true;
        private const string K_PARENT_FOLDER = "Assets";

        [Button]
        private void InitFolderStructure()
        {
            if (null == rootFolder || null == rootFolder.GetName())
            {
                Debug.LogError("No folder name");
            }
            
            // string pathToCheck = $"{K_PARENT_FOLDER}/{rootFolder.GetName()}";
            string accumulatedName = K_PARENT_FOLDER;

            Create(rootFolder, accumulatedName);

            Debug.Log("Folder structure created!");
        }

        private void Create(Folder currentFolder, string accumulatedName = null)
        {
            if (null == currentFolder)
            {
                return;
            }
            
            string pathToCheck = $"{accumulatedName}/{currentFolder.GetName()}";

            if (AssetDatabase.AssetPathExists(pathToCheck))
            {
                if (showLog)
                {
                    Debug.LogWarning($"{pathToCheck} path exists");
                }
            }
            else
            {
                if (showLog)
                {
                    Debug.Log($"{pathToCheck} path does not exist, creating...");
                }
                
                AssetDatabase.CreateFolder(accumulatedName, currentFolder.GetName());
            }
            
            // Whether we skip creating or not, we need to check subfolders
            foreach (var folder in currentFolder.GetChildren())
            {
                Create(folder, pathToCheck);
            }
        }
        
    }
}
