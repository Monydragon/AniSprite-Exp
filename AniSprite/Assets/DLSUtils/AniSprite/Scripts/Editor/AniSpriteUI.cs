using UnityEditor;

namespace DLSUtils.AniSprite.Editor
{
    public class AniSpriteUI : EditorWindow
    {
        [MenuItem("DLSUtils/AniSprite/AniSprite Editor %#a", priority = 0)]  //Control-Shift-A as hotkey
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            AniSpriteUI window = (AniSpriteUI)GetWindow(typeof(AniSpriteUI));
            window.Show();
        }

        [MenuItem("DLSUtils/AniSprite/About", priority = 3)]
        public static void About()
        {
            EditorUtility.DisplayDialog("About", "AniSprite\nAn Asset by: DLSUtils\nVersion: 0.1", "Close");
        }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
