using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private VolumeType volumeType;
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = SoundManager.Instance.GetVolume(volumeType);
    }
}
