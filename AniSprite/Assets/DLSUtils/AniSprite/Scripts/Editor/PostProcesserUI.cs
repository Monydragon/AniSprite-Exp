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

        public static void ShowUI(Texture2D texture, Sprite[] sprites, TextureImporter textureImporter)
        {
            ButtonMessage = "Please Press Me";
            var tempMessage = "";

            if (textureImporter.spriteImportMode != SpriteImportMode.Multiple)
            { return; }

            for (var index = 0; index < sprites.Length; index++)
            {
                var sprite = sprites[index];
                tempMessage += $"[{index}]{sprite.name}";
                if (index < sprites.Length) { tempMessage += ", "; }
            }

            Message = tempMessage;

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

            if (GUILayout.Button(ButtonMessage))
            {
                this.Close();
            }
        }
    }
}