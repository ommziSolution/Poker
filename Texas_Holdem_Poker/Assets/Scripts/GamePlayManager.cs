/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// The GamePlayManager.cs Script is used for the management of gameplay states like distribution of cards, working on the states of the player
/// managing the pot, amount each player will have and many more things
/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GamePlayManager : Singleton<GamePlayManager> {

    #region public variables

    public Sprite[] cards;

    public List<Sprite> DeckCards = new List<Sprite>();

    public GameObject Deck;

    public GameObject CardPrefab;
    
    public GameObject PlayerPositions;

    public GameObject[] OpponentsPosition;

    public GameObject[] HoleCardPositions;

    public GameObject TableCardPoint;


    public GameObject dealer;

    public GameObject small_Blind;

    public GameObject big_blind;

    public Text Pot_Amt_Text;

    public GameObject DealerChip;



    public int Calling_amt;
    public int small_blind_amt;
    public int big_blind_amt;
    public int pot_amt;


    #endregion

    #region private variables

    bool first_hand = true;
    List<Sprite> cardlist = new List<Sprite>();
#endregion


    #region Dealer Selection


    
    public void StartGame()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            cardlist.Add(cards[i]);
        }
        SelectDealer();

        StartCoroutine(HoleCards());
    }

    void SelectDealer()
    {
        if (first_hand)
        {

            int x = Random.Range(0, 10);

            if (x == 0)
            {
                dealer = PlayerPositions;
            }
            else
            {
                dealer = OpponentsPosition[x - 1];
            }

        }
        else
        {
            dealer = small_Blind;
        }

        DealerChip.transform.position = dealer.transform.position;
        SelectSmallBlind();
        SelectBigBlind();
    }
    #endregion


    #region Blind


    void SelectSmallBlind()
    {
        if(dealer == PlayerPositions)
        {
            small_Blind = OpponentsPosition[0];
        }
        else if(dealer == OpponentsPosition[OpponentsPosition.Length - 2])
        {
            small_Blind = OpponentsPosition[OpponentsPosition.Length - 1];
        }
        else if(dealer == OpponentsPosition[OpponentsPosition.Length - 1])
        {
            small_Blind = PlayerPositions;
        }
        else
        {
            for(int i = 0; i < OpponentsPosition.Length - 2; i++)
            {
                if(OpponentsPosition[i] == dealer)
                {
                    small_Blind = OpponentsPosition[i + 1];
                }
            }
        }
    }


    void SelectBigBlind()
    {
        if (dealer == PlayerPositions)
        {
            small_Blind = OpponentsPosition[0];
        }
        else if (dealer == OpponentsPosition[OpponentsPosition.Length - 2])
        {
            big_blind = PlayerPositions;
        }
        else if (dealer == OpponentsPosition[OpponentsPosition.Length - 1])
        {
            big_blind = OpponentsPosition[0];
        }
        else
        {
            for (int i = 0; i < OpponentsPosition.Length - 2; i++)
            {
                if (OpponentsPosition[i] == dealer)
                {
                    big_blind = OpponentsPosition[i + 2];
                }
            }
        }
    }

    #endregion


    #region Card Distribution



    IEnumerator HoleCards()
    {
        int dir = 1;
        for(int turns = 0; turns < 2; turns++)
        {
            for(int i = 0; i < HoleCardPositions.Length; i++)
            {
                GameObject go = (GameObject)Instantiate(CardPrefab, Deck.transform.position, Quaternion.identity);
                int num = Random.Range(0, cardlist.Count);
                go.GetComponent<UnityEngine.UI.Image>().sprite = cardlist[num];
                cardlist.Remove(cardlist[num]);
                go.transform.SetParent(HoleCardPositions[i].transform,false);
                StartCoroutine(MoveGeneratedCards(go));
                yield return new WaitForSeconds(0.1f);
                go.transform.eulerAngles = new Vector3(0, 0, 20 * dir);
            }
            dir = -1;
        }
    }



    IEnumerator TurnCards()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = (GameObject)Instantiate(CardPrefab, Deck.transform.position, Quaternion.identity);
            go.transform.SetParent(TableCardPoint.transform, false);
            StartCoroutine(MoveTableCards(go));
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FoldCards()
    {

        GameObject go = (GameObject)Instantiate(CardPrefab, Deck.transform.position, Quaternion.identity);
        go.transform.SetParent(TableCardPoint.transform, false);
        StartCoroutine(MoveTableCards(go));
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator RiverCards()
    {

        GameObject go = (GameObject)Instantiate(CardPrefab, Deck.transform.position, Quaternion.identity);
        go.transform.SetParent(TableCardPoint.transform, false);
        StartCoroutine(MoveTableCards(go));
        yield return new WaitForSeconds(0.1f);
    }


    IEnumerator MoveGeneratedCards(GameObject Target)
    {
        for(float timer = 0; timer < 1f; timer += Time.deltaTime)
        {
            Target.transform.localPosition = Vector3.Lerp(Target.transform.localPosition, Vector3.zero, 0.3f);
            yield return null;
        }
        Target.transform.localPosition = Vector3.zero;
    }


    IEnumerator MoveTableCards(GameObject Target)
    {
        
        for (float timer = 0; timer < 1f; timer += Time.deltaTime)
        {
            Target.transform.position = Vector3.Lerp(Target.transform.position, new Vector3(Target.transform.parent.position.x + (Target.transform.parent.childCount - 1) * Target.transform.localScale.x , 0, 0 ), 0.5f);
            yield return null;
        }
        Target.transform.position = new Vector3(Target.transform.parent.position.x + (Target.transform.parent.childCount - 1) * Target.transform.localScale.x, 0, 0);

    }
    #endregion

   

    #region Manage Pot




    #endregion



}
