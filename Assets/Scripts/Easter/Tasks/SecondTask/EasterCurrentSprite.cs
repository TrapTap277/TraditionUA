using System;
using UnityEngine;

public class EasterCurrentSprite : MonoBehaviour
{
    public static EasterCurrentSprite Instance;

    public EggSprites mySpriteType;
    private Sprite mySprite;
    private SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        Instance = this;  
        
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        ChangeType();
    }

    public void ChangeType()
    {
        string spriteName = mySpriteRenderer.sprite.name.ToString();
        Enum.Parse(typeof(EggSprites), spriteName);


        string path = "EggSprites/" + mySpriteType.ToString();
        //mySprite = Resources.Load<Sprite>(path);


        Debug.Log(mySpriteType.ToString());
    }

    public void CheckSprite(Sprite sprite)
    {
        Debug.Log(sprite); 
        Debug.Log(mySprite); // null

        if (mySprite != null)
        {
            if (sprite.name == mySpriteType.ToString())
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Shooting.Singleton.EggsRemover(this.gameObject);
                Debug.Log("Remove");
            }
        }

        else
        {
            string path = "EggSprites/" + mySpriteType.ToString();
            Debug.LogError("Спрайт не було знайдено за шляхом: " + path);
        }
    }
}
