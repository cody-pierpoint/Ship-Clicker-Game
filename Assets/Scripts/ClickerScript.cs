using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Alex
{

    public class ClickerScript : MonoBehaviour
    {
        //Displaytext displays numbers everytime ClickerButton pressed
        public TextMeshProUGUI displayText;
        //Number shown in display text as currency
        public float Currency;
        //ClickerButton adds numbers to display text
        public void ClickerButton()
        {
            Currency++;
            /*display text takes in a string to display a string */
            displayText.text =/* a float cannot be assigned as a string on its own */ "Ships: " + Currency;

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}