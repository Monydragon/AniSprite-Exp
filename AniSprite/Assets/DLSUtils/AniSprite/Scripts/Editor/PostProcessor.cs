using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace DLSUtils.AniSprite.Editor
{
    public class PostProcessor : AssetPostprocessor
    {
        void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
        {
            //PostProcesserUI popup = ScriptableObject.CreateInstance<PostProcesserUI>();
            //popup.ShowUI(texture, sprites, assetImporter as TextureImporter);

            int wanted = sprites.Length;
            ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[wanted];
            for (int i = 0; i < wanted; i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe
                {
                    time = i,
                    value = sprites[i]
                };
            }

            AnimationClip animClip = new AnimationClip { frameRate = 30 };
            AnimationUtility.SetObjectReferenceCurve(animClip, new EditorCurveBinding() { path = "", propertyName = "sprite", type = typeof(SpriteRenderer) }, spriteKeyFrames);

            var resourcesSprites = Resources.LoadAll<Sprite>("Test2");
            spriteKeyFrames[0].value = resourcesSprites[0]; //Loading from resources works fine!!
            AnimatorController ac = AnimatorController.CreateAnimatorControllerAtPathWithClip("assets/mycontroller.controller", animClip);

            AssetDatabase.CreateAsset(animClip, "assets/myanim.anim");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

        }

        void OnPostprocessTexture(Texture2D texture)
        {
        }
    }
}