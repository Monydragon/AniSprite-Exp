using UnityEngine;
using UnityEditor;

namespace DLSUtils.AniSprite.Editor
{
    public class PostProcessor : AssetPostprocessor
    {
        void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
        {
            PostProcesserUI.ShowUIWithData(texture,sprites);
            Debug.Log("Got a callback on Sprites PP");
        }

        void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log("Got a callback on Texture PP");
        }
    }
}