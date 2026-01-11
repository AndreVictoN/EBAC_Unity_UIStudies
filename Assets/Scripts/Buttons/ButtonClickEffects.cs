using UnityEngine;

public class ButtonClickEffects : MonoBehaviour
{
    public ParticleSystem particleSys;

    public void OnClick() => particleSys.Play();
}
