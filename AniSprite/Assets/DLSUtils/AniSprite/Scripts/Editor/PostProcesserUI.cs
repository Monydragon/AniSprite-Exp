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
        public static Texture2D t2 = null;
        public static string texturePath = string.Empty;

        public static void Init()
        {
            PostProcesserUI popup = CreateInstance<PostProcesserUI>();
            popup.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 300);
            popup.ShowUtility();
        }

        void OnGUI()
        {
            t2 = (Texture2D)EditorGUILayout.ObjectField("Texture: ", t2, typeof(Texture2D), true);

            EditorGUILayout.LabelField(Message, EditorStyles.wordWrappedLabel);
            GUILayout.Space(25);
            EditorGUILayout.PrefixLabel("Debugging");
            EditorGUILayout.LabelField(DebugingMessage, EditorStyles.wordWrappedLabel);
            GUILayout.Space(25);

            if (GUILayout.Button(ButtonMessage))
            {
                this.Close();
            }

//            texturePath = AssetDatabase.GetAssetPath(t2Edit);
//            Debug.Log($"Set Texture Path to:{texturePath}");
            //if (t2Edit /*&& string.IsNullOrWhiteSpace(texturePath)*/)
//            {
//
//            }
        }

        public static void ShowUIWithData(Texture2D texture, Sprite[] sprites)
        {
            if (texture != null) { t2 = texture; }

            texturePath = AssetDatabase.GetAssetPath(texture);
            Debug.Log($"Set Sprite Path to:{texturePath}");


            ButtonMessage = "Please Press Me";
            var tempMessage = "";

            //if (textureImporter.spriteImportMode != SpriteImportMode.Multiple)
            //    return;
            //            DebugingMessage = $"Mode: {textureImporter.spriteImportMode}\n";

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