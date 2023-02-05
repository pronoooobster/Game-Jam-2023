using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonPersistent<GameManager>
{
    public float hydration = 100;
    public float nutrition = 100;
    // use of stats in one turn
    public float hydrationDelta = 10f;
    public float nutritionDelta = 10f;

    public Image hydrationBar;
    public Image nutritionBar;

    public int step = 0;

    public int stepLength = 3;

    public Queue<ElementScript> elements = new Queue<ElementScript>();

    public void Update()
    {
        // check if the player is dead
        if (hydration <= 0 || nutrition <= 0)
        {
            // end the game
            // switch scene to game over
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

    public void stepForward()
    {
        // update stats
        hydration -= hydrationDelta;
        nutrition -= nutritionDelta;

        // update elements
        if (elements.Count > 0)
        {
            // check elements that expire this step
            while(elements.Peek().endStep <= step) {
                ElementScript element = elements.Peek();
                elements.Dequeue();

                //! uncomment this line to destroy the element after it reaches the end
                Destroy(element.gameObject);

                if(elements.Count <= 0) {
                    break;
                }
            }
        }

        // get nutrition from elements
        // type of element
        // 0: water
        // 1: rock
        // 2: mineral (coal)
        // 3: gem
        foreach (ElementScript element in elements)
        {
            switch (element.type)
            {
                case 0:
                    setHydration(hydration + 20);
                    break;
                case 2:
                    setNutrition(nutrition + 20);
                    break;
                case 3:
                    setNutrition(nutrition + 30);
                    break;
            }
        }

        // update bars
        hydrationBar.fillAmount = hydration / 100;
        nutritionBar.fillAmount = nutrition / 100;

        step++;
    }

    // make setters for nutrition and hydration so it doesnt go over 100\
    public void setHydration(float hydration)
    {
        this.hydration = hydration;
        if (this.hydration > 100)
        {
            this.hydration = 100;
        }
    }

    public void setNutrition(float nutrition)
    {
        this.nutrition = nutrition;
        if (this.nutrition > 100)
        {
            this.nutrition = 100;
        }
    }

    // make a function to add elements to the queue
    public void addElement(ElementScript element)
    {
        // set the end step of the element
        element.endStep = step + stepLength;
        elements.Enqueue(element);
    }
}
