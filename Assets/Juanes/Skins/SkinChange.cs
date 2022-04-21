using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChange : MonoBehaviour
{

    [SerializeField] private List<Material> skins;
    [SerializeField] private GameObject[] puntaajes;
    [SerializeField] private CharacterData data;

    [SerializeField] Eventos cambioSkin;
    private int index;
    private int Gameindex;
    private void Start()
    {
        
       
        index = data.CurrentMaterialIndex;
        Gameindex = data.CurrentPuntajeIndex;
        puntaajes[0].SetActive(true);
        puntaajes[1].SetActive(false);
        puntaajes[2].SetActive(false);
        puntaajes[3].SetActive(false);

        PlayerPrefs.SetInt("SkinA", index);
     
        ChangeSkinA(0);
 
    }


    public void ChangeSkinA(int x)
    {
        index += x;
   
        if (index < 0 )
        {
            index = skins.Count - 1;
           
            PlayerPrefs.SetInt("SkinA", index);
        }
        if (index > skins.Count )
        {
            index = 0;
          
            PlayerPrefs.SetInt("SkinA", index);
        }
        PlayerPrefs.SetInt("SkinA", index);
        cambioSkin.FireEvent();
        UpdateSkin();
    }
   
   /* public void ChangePuntajes (int x)
    {
        {
            
            Gameindex += x;
            if ( Gameindex < 0)
            {
                
                Gameindex = puntaajes.Count - 1;
                
            }
            if ( Gameindex > skins.Count)
            {
                
                Gameindex = 0;
               
            }
           
            
            UpdatePuntaje();
        }

    }*/

    public void UpdateSkin()
    {
        data.CurrentMaterialIndex = index;
        data.material = skins[index];
        data.materialChanged?.Invoke(data.material);
        

    }
    public void UpdatePuntaje()
    {
        data.CurrentPuntajeIndex = Gameindex;
        data.Puntajes = puntaajes[Gameindex];
        data.PuntajeChange?.Invoke(data.Puntajes);
    }

}
