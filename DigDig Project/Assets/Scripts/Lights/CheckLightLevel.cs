using UnityEngine;

public class CheckLightLevel : MonoBehaviour
{
    //Variables
    public RenderTexture sourceTexture;

    public float lightLevel;
    public int roundedLight;

    public float maxTime = 10;
    private float currentTime;

    private void Start()
    {
        currentTime = maxTime;
    }

    void Update()
    {
        //declare, instansiate temptexture and sourceTexture into tempTexture
        RenderTexture tempTexture = RenderTexture.GetTemporary(sourceTexture.width, sourceTexture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
        Graphics.Blit(sourceTexture, tempTexture);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = tempTexture;

        //declare, instansiate texture2D and read pixels
        Texture2D texture2D = new Texture2D(sourceTexture.width, sourceTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, tempTexture.width, tempTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(tempTexture);

        //loop through pixels and add the white level
        Color32[] colors = texture2D.GetPixels32();
        lightLevel = 0;
        for (int i = 0; i < colors.Length; i++)
        {
            //formula to add just the white level
            lightLevel += (0.2126f * colors[i].r) + (0.7152f * colors[i].g) + (0.0722f * colors[i].b);
        }

        lightLevel -= 259330;
        lightLevel = lightLevel / colors.Length;
        roundedLight = Mathf.RoundToInt(lightLevel);

        //wait, then reload level
        if (lightLevel <= -3.9f)
        {
            Debug.Log(currentTime);
            currentTime -= Time.deltaTime;
            if (currentTime < 0) FindObjectOfType<LevelLoader>().ReloadCurrentLevel();

        }
        else currentTime = maxTime;
    }
}
