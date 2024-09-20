using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObisCaution : MonoBehaviour
{
    //private GameObject gameSystemObject_;
    private GameSystem gameSystem_;

    [SerializeField]
    private GameObject textObject_;

    private GameObject playerObject_;

    [SerializeField]
    private GameObject uiImageObject_;
    private Image image_;

    // Start is called before the first frame update
    void Start()
    {
        gameSystem_ = GameObject.Find("GameSystem").GetComponent<GameSystem>();

        playerObject_ = GameObject.Find("Player");

        image_ = uiImageObject_.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ObisManager obisManager = gameSystem_.GetWaveSystem().GetObisManager();
        if (obisManager != null)
        {
            Obis obis = obisManager.GetNextObis();
            if(obis != null && !obis.passing_)
            {
                image_.enabled = true;

                var playerPos = playerObject_.transform.position;
                var obisPos = obis.transform.position;

                float dist = obisPos.y - playerPos.y;

                //ÉQÅ[ÉÄì‡ÇÃíPà Ç…Ç»ÇÈÇ◊Ç≠çáÇ§ÇÊÇ§Ç…ï‚ê≥
                dist *= 15.0f;
                int distInt = (int)dist;

                Text cautionText = textObject_.GetComponent<Text>();
                cautionText.text = distInt.ToString() + "M";
            }
            else
            {
                image_.enabled = false;
                Text cautionText = textObject_.GetComponent<Text>();
                cautionText.text = "";
            }
        }
    }
}
