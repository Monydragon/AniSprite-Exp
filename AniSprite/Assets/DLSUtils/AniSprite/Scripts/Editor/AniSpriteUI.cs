using UnityEngine;
using UnityEditor;

namespace DLSUtils.AniSprite.Editor
{
    public class AniSpriteUI : EditorWindow
    {
        //Control-Shift-A as hotkey
        [MenuItem("DLSUtils/AniSprite/AniSprite Editor %#a", priority = 0)]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            AniSpriteUI uiWindow = (AniSpriteUI)GetWindow(typeof(AniSpriteUI));
            uiWindow.Show();
        }

        /// <summary>
        /// This is the About window that displays a window containing software credits and attributions.
        /// </summary>
        [MenuItem("DLSUtils/AniSprite/About", priority = 3)]
        public static void About()
        {
            EditorUtility.DisplayDialog("About",
                "AniSprite\nDeveloped by: DLSUtils\nVersion: 0.1",
                "Close");
        }

        void OnEnable()
        {

        }

        void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            GUILayout.Button("TestButton");
            EditorGUILayout.Popup(0, new string[] { "Option 1", "Option2" });
            
            EditorGUILayout.EndVertical();
        }

        //This needs to be on a subclass

        void OnPostprocessTexture(Texture2D texture)
        {

        }
    }
}
