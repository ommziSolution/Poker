using UnityEngine;

public class CardManager : MonoBehaviour {

    public int Weight;
    public int CategoryWeight;
    public int Preference;
    string name;

    void Start()
    {
        name = transform.GetComponent<UnityEngine.UI.Image>().sprite.name;
    }

    void ManageWeight()
    {
        if(name.Contains("Ace"))
        {
            Weight = 1;
            Preference = 1;
        }
        else if(name.Contains("2"))
        {

            Weight = 2;
            Preference = 2;
        }
        else if(name.Contains("3"))
        {

            Weight = 3;
            Preference = 3;
        }
        else if(name.Contains("4"))
        {

            Weight = 4;
            Preference = 4;
        }
        else if(name.Contains("5"))
        {

            Weight = 5;
            Preference = 5;
        }
        else if (name.Contains("6"))
        {

            Weight = 6;
            Preference = 6;
        }
        else if(name.Contains("7"))
        {

            Weight = 7;
            Preference = 7;
        }
        else if(name.Contains("8"))
        {

            Weight = 8;
            Preference = 8;
        }
        else if(name.Contains("9"))
        {

            Weight = 9;
            Preference = 9;
        }
        else if (name.Contains("10"))
        {

            Weight = 10;
            Preference = 10;
        }
        else if(name.Contains("Jack"))
        {

            Weight = 10;
            Preference = 11;
        }
        else if(name.Contains("Queen"))
        {

            Weight = 10;
            Preference = 12;
        }
        else if(name.Contains("King"))
        {

            Weight = 10;
            Preference = 13;
        }
    }

    void ManageCategory()
    {
        if(name.Contains("Clubs"))
        {
            CategoryWeight = 0;
        }
        else if(name.Contains("Diamond"))
        {
            CategoryWeight = 1;
        }
        else if(name.Contains("Heart"))
        {
            CategoryWeight = 2;
        }
        else if(name.Contains("Spades"))
        {
            CategoryWeight = 3;
        }
    }
}
