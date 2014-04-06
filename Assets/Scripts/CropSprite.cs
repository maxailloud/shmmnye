using UnityEngine;
using System.Collections;

public class CropSprite : MonoBehaviour 
{
    //  Reference for sprite which will be cropped and it has BoxCollider or BoxCollider2D
    public GameObject spriteToCrop;

    void Update () 
    {
        cropSprite(); 
    }

    //  Following method crops as per displayed cropping area
    private void cropSprite()
    {
        Debug.Log ("Crop sprite");
        SpriteRenderer spriteRenderer = spriteToCrop.GetComponent<SpriteRenderer>();
        Sprite spriteToCropSprite     = spriteRenderer.sprite;
        Texture2D spriteTexture       = spriteToCropSprite.texture;
        Rect spriteRect               = spriteToCrop.GetComponent<SpriteRenderer>().sprite.textureRect;
        
        int pixelsToUnits = 50; // It's PixelsToUnits of sprite which would be cropped
        
        //      Crop sprite
        
        GameObject croppedSpriteObj = new GameObject("CroppedSprite");
        Rect croppedSpriteRect = spriteRect;
        croppedSpriteRect.width = 66;
        croppedSpriteRect.x = 0;
        croppedSpriteRect.height = 190;
        croppedSpriteRect.y = 0;

        Sprite croppedSprite = Sprite.Create(spriteTexture, croppedSpriteRect, new Vector2(0,1), pixelsToUnits);
        SpriteRenderer cropSpriteRenderer = croppedSpriteObj.AddComponent<SpriteRenderer>();

        cropSpriteRenderer.sprite = croppedSprite;
        croppedSpriteObj.transform.position = new Vector3(0,0, 0);
        croppedSpriteObj.transform.parent = spriteToCrop.transform.parent;
        croppedSpriteObj.transform.localScale = spriteToCrop.transform.localScale;
        Destroy(spriteToCrop);
    }
}