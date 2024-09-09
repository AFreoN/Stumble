using UnityEngine.UI;
using UnityEngine;

public class GiftShower : MonoBehaviour
{
    public Sprite[] LayerImages;
    public Text layerName;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
		if(LayerContentDisplay.change == true)
        {
            LayerContentDisplay.change = false;
            anim.SetTrigger("collected");
            textChooser(LayerContentDisplay.LayerNum);
            gameObject.GetComponent<Image>().sprite = LayerImages[LayerContentDisplay.LayerNum];
        }
	}
    #region TextChooser for displaying Layer Name
    void textChooser(int s)
    {
        switch(s)
        {
            case 1:
                layerName.text = "White Tiles";
                break;
            case 2:
                layerName.text = "Blossom";
                break;
            case 3:
                layerName.text = "Brick1";
                break;
            case 4:
                layerName.text = "Brick2";
                break;
            case 5:
                layerName.text = "Retro";
                break;
            case 6:
                layerName.text = "Leather";
                break;
            case 7:
                layerName.text = "Wood";
                break;
            case 8:
                layerName.text = "Steel";
                break;
            case 9:
                layerName.text = "Check";
                break;
        }
    }
    #endregion
}
