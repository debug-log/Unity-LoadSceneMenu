using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class EditorLoadScene : MonoBehaviour
{
	[MenuItem ("Load Scene/SceneSetup/Save SceneSetup &#s")]
	static void SaveSceneSetup ()
	{
		SceneSetup[] sceneSetup = EditorSceneManager.GetSceneManagerSetup ();
		SavedSceneSetup savedSceneSetup = ScriptableObject.CreateInstance<SavedSceneSetup> ();
		savedSceneSetup.sceneSetup = sceneSetup;

		string path = EditorUtility.SaveFilePanel (
			              "Save SceneSetup as ScriptableObject",
			              "Assets/Editor",
			              "SavedSceneSetup.asset",
			              "asset");
		if (path.StartsWith (Application.dataPath))
		{
			path = string.Format ("Assets{0}", path.Substring (Application.dataPath.Length));
		}
		AssetDatabase.CreateAsset (savedSceneSetup, path);
	}


	[MenuItem ("Load Scene/SceneSetup/Load SceneSetup &#o")]
	static void LoadSceneSetup ()
	{
		string path = EditorUtility.OpenFilePanel ("Select SceneSetup ScriptableObject", "Assets/Editor", "asset");
		if (path.StartsWith (Application.dataPath))
		{
			path = string.Format ("Assets{0}", path.Substring (Application.dataPath.Length));
		}

		SceneSetup[] sceneSetup = AssetDatabase.LoadAssetAtPath<SavedSceneSetup> (path).sceneSetup;
		EditorSceneManager.RestoreSceneManagerSetup (sceneSetup);
	}


	[MenuItem ("Load Scene/Unload Selected Scene %#u")]
	static void CloseSelectedScene ()
	{
		var targetScene = Selection.activeGameObject.scene;
		EditorSceneManager.SaveScene (targetScene);
		EditorSceneManager.CloseScene (targetScene, false);
	}
}
