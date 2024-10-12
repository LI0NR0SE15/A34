using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

[System.Serializable]
public class ProgressAndVolumeAndIluminationSaver : MonoBehaviour
{
    public static ProgressAndVolumeAndIluminationSaver Instance;
    [SerializeField] Vector2 position;
    [SerializeField] float volume;
    [SerializeField] float soundEffects;
    [SerializeField] float illumination;
    [SerializeField] float progressPorsentage;
    public GameObject jugador;
    public string archivosDeGuardado;
    public guardadoFinal guardado = new guardadoFinal();
    public SaveingDataScriptable DataScriptableObject;

    private void Awake()
    {

        if (ProgressAndVolumeAndIluminationSaver.Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
        //archivosDeGuardado = Application.dataPath + "/datosDeGuardado.json";
        jugador = GameObject.FindGameObjectWithTag("Player");
        cargarDatosAbrir();
        Debug.Log(DataScriptableObject.volume);
    }
    public void recivirPosicion(Vector2 _Pos) { 
        position = _Pos;
    }
    public void recivirVolumen(float _Vol)
    {
        volume = _Vol;
    }
    public void recivirEfectosDeSonido(float _SE)
    {
        soundEffects = _SE;
    }
    public void recivirIluminacion(float _Lumin)
    {
        illumination = _Lumin;
    }
    public void recivirProgresso(float _Progreso)
    {
        progressPorsentage = _Progreso;
    }
    public void cargarDatos() {
       /* if (File.Exists(archivosDeGuardado)) { 
            string contenido = File.ReadAllText(archivosDeGuardado);
            guardado = JsonUtility.FromJson<guardadoFinal>(contenido);
            Debug.Log("posicion jugador : " + guardado.posicion);

            jugador.transform.position = guardado.posicion;
        }*/

            jugador.transform.position = DataScriptableObject.position;
            volume = DataScriptableObject.volume;
            soundEffects = DataScriptableObject.soundEffects;
            illumination = DataScriptableObject.illumination;
            progressPorsentage = DataScriptableObject.progressPorsentage;
        
    }
    public void cargarDatosAbrir()
    {
        //cargar datos

            PlayerPrefs.GetFloat("PlayerPosX", position.x);
            PlayerPrefs.GetFloat("PlayerPosY", position.y);
            PlayerPrefs.GetFloat("Volume", volume);
            PlayerPrefs.GetFloat("SoundEfectVolume", soundEffects);
            PlayerPrefs.GetFloat("IlluminationValue", illumination);
            PlayerPrefs.GetFloat("ProgressPorcentage", progressPorsentage);
            //obtener datos de inicio 
            jugador.transform.position = DataScriptableObject.position;
            volume = DataScriptableObject.volume;
            soundEffects = DataScriptableObject.soundEffects;
            illumination = DataScriptableObject.illumination;
            progressPorsentage = DataScriptableObject.progressPorsentage;
            //guardar datos en sus respectivas variables
            DataScriptableObject.position = jugador.transform.position;
            DataScriptableObject.volume = volume;
            DataScriptableObject.soundEffects = soundEffects;
            DataScriptableObject.illumination = illumination;
            DataScriptableObject.progressPorsentage = progressPorsentage;
            //cargar datos
        
    }
    public void guardarDatos() {
        /* guardadoFinal nuevoGuardado = new guardadoFinal() {
             posicion = position
         };

         string jsonString = JsonUtility.ToJson(nuevoGuardado);

         File.WriteAllText(archivosDeGuardado, jsonString);

         Debug.Log("archivo Guardado");*/


            DataScriptableObject.position = jugador.transform.position;
            DataScriptableObject.progressPorsentage = progressPorsentage;
            Debug.Log("archivo Guardado");
            PlayerPrefs.SetFloat("PlayerPosX", position.x);
            PlayerPrefs.SetFloat("PlayerPosY", position.y);
            PlayerPrefs.SetFloat("ProgressPorcentage", progressPorsentage);
        
    }

}
public class guardadoFinal {
    [SerializeField] public Vector2 posicion;
    [SerializeField] public float volume;
    [SerializeField] public float soundEffects;
    [SerializeField] public float illumination;
    [SerializeField] public float progressPorsentage;
}
