using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //! importar las propiedades de audio que nos ofrece unity
using UnityEngine.UI; // ! importar las propiedades graficas que nos ofrece unity

public class ControlVolumen : MonoBehaviour
{
    //* Variables
    public AudioMixer mixer; 
    public Slider musicaSlider;
    public Slider efectosSlider;

    private void Awake() {
        musicaSlider.onValueChanged.AddListener(ControlMusicaVolumen);
        
        efectosSlider.onValueChanged.AddListener(ControlEfectosVolumen);
    }

    private void Start() {
        Cargar();
    }

    private void ControlMusicaVolumen(float valor){

        mixer.SetFloat("VolumenMusica", Mathf.Log10(valor) * 20);

        PlayerPrefs.SetFloat("VolumenMusica", musicaSlider.value);
    }

    private void ControlEfectosVolumen(float valor){
        mixer.SetFloat("VolumenEfectos", Mathf.Log10(valor) * 20);
        
        PlayerPrefs.SetFloat("VolumenEfectos", efectosSlider.value);
    }

    private void Cargar(){
        musicaSlider.value = PlayerPrefs.GetFloat("VolumenMusica", 0.75f);
        efectosSlider.value = PlayerPrefs.GetFloat("VolumenEfectos", 0.75f);
        
        ControlMusicaVolumen(musicaSlider.value);
        ControlEfectosVolumen(efectosSlider.value);
    }
}
