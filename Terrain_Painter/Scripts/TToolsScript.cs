using UnityEngine;

public class TToolsScript : MonoBehaviour
{
    public Terrain terrain;
    public TerrainLayer sand, rock, grass, snow;
    public float grassHeight, grassSlope, snowHeight, snowHeightTwo;

    TerrainData t;

    public void Option()
    {
        t = terrain.terrainData;

        TerrainLayer[] myLayers = new TerrainLayer[4];
        myLayers[0] = sand;
        myLayers[1] = rock;
        myLayers[2] = grass;
        myLayers[3] = snow;

        t.terrainLayers = myLayers;

        grassHeight = grassHeight == 0.0f ? 0.01f : grassHeight;
        grassSlope = grassSlope == 0.0f ? 0.25f : grassSlope;
        snowHeight = snowHeight == 0.0f ? 0.65f : snowHeight;
        snowHeightTwo = snowHeightTwo == 0.0f ? 0.8f : snowHeightTwo;
    }

    public void TTexturing()
    {
        float[,,] splatMap = new float[t.alphamapWidth, t.alphamapHeight, t.alphamapLayers];

        for (int y = 0; y < t.alphamapHeight; y++)
        {
            for (int x = 0; x < t.alphamapWidth; x++)
            {
                float normY = (float)y / (t.alphamapHeight - 1);
                float normX = (float)x / (t.alphamapWidth - 1);

                float slope = t.GetSteepness(normY, normX) / 90.0f;
                float height = t.GetHeight(y, x) / t.size.y;

                splatMap[x, y, 0] = 1 - height;
                splatMap[x, y, 1] = Mathf.Clamp01(slope * 1.2f);

                if (height >= grassHeight && slope < grassSlope)
                {
                    splatMap[x, y, 2] = Mathf.Clamp01((1 - slope) / height);
                }

                if (height >= snowHeight)
                {
                    splatMap[x, y, 3] = slope / height;
                }
                else if (height >= snowHeightTwo)
                {
                    splatMap[x, y, 3] = height;
                }
            }
        }

        t.SetAlphamaps(0, 0, splatMap);
    }
}
