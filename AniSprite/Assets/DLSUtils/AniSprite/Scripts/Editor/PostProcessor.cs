using UnityEngine;
using UnityEditor;

namespace DLSUtils.AniSprite.Editor
{
    public class PostProcessor : AssetPostprocessor
    {
        void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
        {
            PostProcesserUI.ShowUI(texture,sprites, assetImporter as TextureImporter);
        }

        void OnPostprocessTexture(Texture2D texture)
        {
        }
    }
}