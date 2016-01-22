using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour {

    public Text OP_Text;
    public Text CurrentAmt;

    public void Call()
    {
        /// ////////////////////////////////////////////
        /// will add betting amount of the table to pot from the table account of the player
        /// ////////////////////////////////////////////
        /// 
        if (GamePlayManager.Instance.Calling_amt <= transform.GetComponent<Player_Mgmt>().TableAmt)
        {
            transform.GetComponent<Player_Mgmt>().TableAmt -= GamePlayManager.Instance.Calling_amt;
            GamePlayManager.Instance.pot_amt += GamePlayManager.Instance.Calling_amt;
        }
        else
        {
            GamePlayManager.Instance.pot_amt += transform.GetComponent<Player_Mgmt>().TableAmt;
            transform.GetComponent<Player_Mgmt>().TableAmt = 0;
        }
        NextPlayer();
        OP_Text.text = "Call " + GamePlayManager.Instance.Calling_amt;
        GamePlayManager.Instance.Pot_Amt_Text.text = GamePlayManager.Instance.pot_amt.ToString();
        CurrentAmt.text = transform.GetComponent<Player_Mgmt>().TableAmt.ToString();
    }


    
       

    public void Raise(GameObject Slider)
    {
        /// /////////////////////////////////////////////
        /// Will add the raised amount of the table to pot from teh table amount of the player
        /// raise can only be in multiple and minimum raise will be 2 times
        /// /////////////////////////////////////////////
        Slider.SetActive(true);

    }


    public void Raise_Confirm(Slider slider)
    {
        GamePlayManager.Instance.Calling_amt += (int)slider.value * 2;
        Call();
        slider.transform.parent.gameObject.SetActive(false);
        OP_Text.text = "Raise by *" +slider.value * 2;

    }

    public void Raise_Cancel(GameObject obj)
    {
        obj.SetActive(false);
        

    }

    public void Fold()
    {
        /// //////////////////////////////////////////////
        /// fold will make the player non playable and he can only see the game play
        /// Remove me from Game
        /// //////////////////////////////////////////////
        RemoveMeFromGamePlay();
        // RemovePlayerFrom
        OP_Text.text = "Fold";

    }

    public void Check()
    {
        /// //////////////////////////////////////////////
        /// Check is the calling without adding any amount to the pot 
        /// //////////////////////////////////////////////
        OP_Text.text = "Check";

    }

    public void NextPlayer()
    {
        /// ///////////////////////////////////////////////////////////
        /// Send Data to server and next player message
        /// ///////////////////////////////////////////////////////////
    }


    public void RemoveMeFromGamePlay()
    {

    }
   
}
