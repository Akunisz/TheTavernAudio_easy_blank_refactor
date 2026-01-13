using UnityEngine;
using UnityEngine.UI;

public class VCA_control : MonoBehaviour
{
    private FMOD.Studio.VCA vca;
    private Slider slider;

    [Header("Ustawienia FMOD")]
    [SerializeField] private string vcaPath;
    [SerializeField] private string saveKey;

    [Header("Poziom G³oœnoœci")]
    [SerializeField] float vcaVolume;
    void Start()
    {
        slider = GetComponent<Slider>();
        vca = FMODUnity.RuntimeManager.GetVCA(vcaPath);

        float savedVolume = PlayerPrefs.GetFloat(saveKey, 1);


        vca.getVolume(out vcaVolume);
        slider.value = savedVolume;
    }

    public void SetVoliume(float volume)
    { 
        vca.setVolume(volume);

        PlayerPrefs.SetFloat(saveKey, volume);
    }
}
