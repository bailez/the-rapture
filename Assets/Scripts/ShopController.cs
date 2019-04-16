using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour {

    int mode_id;
    public int max_modes;
    public GameObject[] skins,level;

	void Start () {
        mode_id = 0;
        Debug.Log("skinID:" + PlayerPrefs.GetInt("skinID") + "//" + "levelID:" + PlayerPrefs.GetInt("levelID") + "//");
    
}

    public void menu(){
        SceneManager.LoadScene("Menu");
    }

    public void mode(bool up){
        if (up && mode_id != 0)
            mode_id--;
        else if(up && mode_id == 0)
            mode_id = max_modes;

        if (!up && mode_id != max_modes)
            mode_id++;
        else if (!up && mode_id == max_modes)
            mode_id = 0;
       
    }

    public void change(bool right){
        int mod, lenght;
        if (mode_id == 0)
        {   mod = PlayerPrefs.GetInt("skinID");
            lenght = skins.Length - 1;
        }
        else
        {   mod = PlayerPrefs.GetInt("levelID");
            lenght = level.Length - 1;
        }
                
        //cima
        if (right && mod != 0)
            mod--;
        else if (right && mod == 0)
            mod = lenght;
        //baixo
        if (!right && mod != lenght)
            mod++;
        else if (!right && mod == lenght)
            mod = 0;

        if (mode_id == 0){
           PlayerPrefs.SetInt("skinID", mod);
        }
        else{
           PlayerPrefs.SetInt("levelID", mod);
        }

        Debug.Log("skinID:" + PlayerPrefs.GetInt("skinID") + "//" + "levelID:" + PlayerPrefs.GetInt("levelID") + "//" );
    }

    public int ModeId()
    {
        return mode_id;
    }
}
