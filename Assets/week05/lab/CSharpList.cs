using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal {
    public string AnimalType;
    public string Name;
    public float Weight;

    public Animal(string _type, string _name, float _w) {
        AnimalType = _type;
        Name = _name;
        Weight = _w;
    }
}

public class CSharpList : MonoBehaviour
{
    private List<int> playerScoreList;

    private List<Animal> animalList = new List<Animal>();
    
    void Start() {
        Animal pikachu = new Animal("Rat", "Pikachu", 5f);
        Animal turtle = new Animal("Turtle", "Leonado", 10f);
        Animal cow = new Animal("Cow", "Wagyu", 50f);

        animalList.Add(pikachu);      
        animalList.Add(turtle);      
        animalList.Add(cow);

        // animalList.RemoveAt( 1 );
        animalList.Remove(turtle);

        for(int i = 0; i < animalList.Count; ++i) {
            Debug.Log(animalList[i].Name);
        }    
    }
    
    void TestListInt()
    {
        playerScoreList = new List<int>();
        playerScoreList.Add(5);
        playerScoreList.Add(2);
        playerScoreList.Add(3);
        playerScoreList.Add(7);

        // 0, 1, 2, 3
        // 5, 2, 3, 7

        playerScoreList.RemoveAt(2);

        playerScoreList.Clear();

        if( playerScoreList.Contains(3) ) {
            Debug.Log("This list has a player with score 3");
        } else {
            Debug.Log("This list has no player with score 3");
        }

        for(int i = 0; i < playerScoreList.Count; ++i) {
            Debug.Log("[" + i + "] : " + playerScoreList[i]);
        }
    }
}
