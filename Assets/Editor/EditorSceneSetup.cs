using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public static class EditorSceneSetup {

    private static Dictionary<string, int> priorityTable = new Dictionary<string, int> ();

    [MenuItem ("Load Scene/Generate Scene Menus")]
    static void Generate()
    {
        TextAsset templateMenuItem = Resources.Load ("TemplateMenuItem") as TextAsset;
        StringBuilder stringBuilder = new StringBuilder ();
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        
        for (int i = 0; i < sceneCount; ++i)
        {
            int level = GetCommonCategoryLevel ();
            string path = SceneUtility.GetScenePathByBuildIndex (i);
            string name = Path.GetFileNameWithoutExtension (path);
            string category = path.Split ('/').GetValue (level) as string;

            if (priorityTable.ContainsKey (category))
            {
                priorityTable[category]++;
            }
            else
            {
                priorityTable.Add (category, priorityTable.Keys.Count * sceneCount * 10 + 1);
            }

            int priority = priorityTable[category];
            string menuItemText = templateMenuItem.text;
            menuItemText = menuItemText.Replace ("#ScenePath", path);
            menuItemText = menuItemText.Replace ("#SceneName", name);
            menuItemText = menuItemText.Replace ("#Priority", priority.ToString());
            stringBuilder.AppendLine (menuItemText);
        }


        TextAsset templateEditorSceneSetup = Resources.Load ("TemplateEditorSceneSetup") as TextAsset;
        string output = templateEditorSceneSetup.text.Replace ("#MenuItemList", stringBuilder.ToString ());


        string scriptFile = Application.dataPath + "/Editor/GeneratedSceneSetupMenuItem.cs";
        System.IO.File.Delete (scriptFile);
        System.IO.File.WriteAllText (scriptFile, output, System.Text.Encoding.UTF8);
        AssetDatabase.ImportAsset ("Assets/Editor/GeneratedSceneSetupMenuItem.cs");

        Debug.Log ("Create file [Assets/Editor/EditorSceneSetup.cs]");
    }

    static int GetCommonCategoryLevel ()
    {
        int level = 0;
        string currentFolderName = "";
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        List<string[]> pathList = new List<string[]> ();

        //Init
        for (int i = 0; i < sceneCount; ++i)
        {
            string path = SceneUtility.GetScenePathByBuildIndex (i);
            pathList.Add (path.Split ('/'));
        }

        //Find the lowest-level folder name that is not common
        while(true)
        {
            currentFolderName = pathList[0].GetValue (level) as string;

            foreach (var path in pathList)
            {
                if (path.GetValue (level) == null)
                {
                    return level;
                }

                string nextFolderName = path.GetValue (level) as string;
                if(!currentFolderName.Equals(nextFolderName))
                {
                    return level;
                }
            }

            ++level;
        }
    }
}
