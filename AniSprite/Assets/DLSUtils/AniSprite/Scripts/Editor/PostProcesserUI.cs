using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DLSUtils.AniSprite.Editor
{
    public class PostProcesserUI : EditorWindow
    {
        public static string Message;
        public static string DebugingMessage;
        public static string ButtonMessage;

        public static void Init()
        {
            PostProcesserUI popup = CreateInstance<PostProcesserUI>();
            popup.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 300);
            popup.ShowUtility();
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField(Message, EditorStyles.wordWrappedLabel);
            GUILayout.Space(25);
            EditorGUILayout.PrefixLabel("Debugging");
            EditorGUILayout.LabelField(DebugingMessage, EditorStyles.wordWrappedLabel);
            GUILayout.Space(25);
            if (GUILayout.Button(ButtonMessage)) this.Close();
        }

        public static void ShowUIWithData(Texture2D texture, Sprite[] sprites)
        {
            ButtonMessage = "Please Press Me";

            var tempMessage = "";
            //            string path = AssetDatabase.GetAssetPath(sprites[0]);
            //            var activeObj = Selection.assetGUIDs;
            //            foreach (var s in activeObj)
            //            {
            //                Debug.Log(s);
            //            }

            Debug.Log("IID Real: " + texture.GetInstanceID());
            //string path = AssetDatabase.GetAssetPath(texture.GetInstanceID());
            string path = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
            Debug.Log("PATH: " + path);
            //            Debug.Log("IID Selection: " + Selection.activeInstanceID);
            //TextureImporter textureImporter = (TextureImporter)AssetImporter.GetAtPath(path);

            //            if (textureImporter.spriteImportMode != SpriteImportMode.Multiple)
            //                return;
            //            DebugingMessage = $"Mode: {textureImporter.spriteImportMode}\n Rect: {sprites[0].rect}";

            for (var index = 0; index < sprites.Length; index++)
            {
                var sprite = sprites[index];
                tempMessage += $"[{index}]{sprite.name}";
                if (index < sprites.Length) { tempMessage += ", "; }
            }

            Message = tempMessage;
            Init();
        }
    }
}