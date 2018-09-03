using UnityEditor;
using UnityEditor.SceneManagement;

namespace LoadSceneWithMenuItem
{
    public static class MenuItemScene
    {
        private static bool toggleAdditive;

        [MenuItem ("Load Scene/Additive Mode %#t")]
        static void ToggleAdditiveMode ()
        {
            toggleAdditive = !toggleAdditive;
            Menu.SetChecked ("Load Scene/Additive Mode", toggleAdditive);
        }

        [MenuItem ("Load Scene/MasterScene", false, 1)]
        static void LoadMasterScene ()
        {
            if (toggleAdditive)
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Common/MasterScene.unity", OpenSceneMode.Additive);
            }
            else
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Common/MasterScene.unity");
            }
        }

        [MenuItem ("Load Scene/BackDrop", false, 71)]
        static void LoadBackDrop ()
        {
            if (toggleAdditive)
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Environment/BackDrop.unity", OpenSceneMode.Additive);
            }
            else
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Environment/BackDrop.unity");
            }
        }

        [MenuItem ("Load Scene/Forest", false, 72)]
        static void LoadForest ()
        {
            if (toggleAdditive)
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Environment/Forest.unity", OpenSceneMode.Additive);
            }
            else
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Environment/Forest.unity");
            }
        }

        [MenuItem ("Load Scene/TreeAndBox", false, 73)]
        static void LoadTreeAndBox ()
        {
            if (toggleAdditive)
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Environment/TreeAndBox.unity", OpenSceneMode.Additive);
            }
            else
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/Environment/TreeAndBox.unity");
            }
        }

        [MenuItem ("Load Scene/PlayZone", false, 141)]
        static void LoadPlayZone ()
        {
            if (toggleAdditive)
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/GamePlay/PlayZone.unity", OpenSceneMode.Additive);
            }
            else
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/GamePlay/PlayZone.unity");
            }
        }

        [MenuItem ("Load Scene/UIPopup", false, 211)]
        static void LoadUIPopup ()
        {
            if (toggleAdditive)
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/UI/UIPopup.unity", OpenSceneMode.Additive);
            }
            else
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/UI/UIPopup.unity");
            }
        }

        [MenuItem ("Load Scene/UIScene", false, 212)]
        static void LoadUIScene ()
        {
            if (toggleAdditive)
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/UI/UIScene.unity", OpenSceneMode.Additive);
            }
            else
            {
                EditorSceneManager.OpenScene ("Assets/Scenes/UI/UIScene.unity");
            }
        }


    }
}