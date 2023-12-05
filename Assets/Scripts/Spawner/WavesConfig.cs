using UnityEngine;

[CreateAssetMenu(menuName = "Spawner/Config")]
public class WavesConfig : ScriptableObject
{
    [Range(1, 60)]public float PrepareToStartTime;
    public WaveConfig[] Waves; 
}
