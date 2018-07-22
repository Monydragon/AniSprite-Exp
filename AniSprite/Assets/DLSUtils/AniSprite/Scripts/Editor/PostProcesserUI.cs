using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DLSUtils.AniSprite.Editor
{
    public class PostProcesserUI : EditorWindow
    {
        public static string Message;
        public static string DebugingMessage = "Debug";
        public static string ButtonMessage;

        Texture2D texture;
        Sprite[] sprites;
        TextureImporter textureImporter;

        public void ShowUI(Texture2D texture, Sprite[] sprites, TextureImporter textureImporter)
        {
            if (textureImporter.spriteImportMode != SpriteImportMode.Multiple)
                return;

            this.texture = texture;
            this.sprites = sprites;
            this.textureImporter = textureImporter;
            Show();
        }

        void OnGUI()
        {
            for (var index = 0; index < sprites.Length; index++)
            {
                Message += $"[{index}]{sprites[index].name}";

                if (index < sprites.Length)
                    Message += ", ";
            }

            EditorGUILayout.LabelField(Message, EditorStyles.wordWrappedLabel);
            GUILayout.Space(25);

            EditorGUILayout.PrefixLabel("Debugging: ");
            EditorGUILayout.LabelField(DebugingMessage, EditorStyles.wordWrappedLabel);
            GUILayout.Space(25);

            if (GUILayout.Button("Close"))
            {
                this.Close();
            }
        }
    }
}