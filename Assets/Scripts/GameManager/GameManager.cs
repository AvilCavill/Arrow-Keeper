using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (TowerHealth.Instance.health <= 0)
            {
                YouLost();
            }
        }

        private void YouLost()
        {
            //Show how many rounds you survived
            //Enemies killed
            //Canvas with restart button o main menu button
        }
        
        private void YouWin()
        {
            //Show how many rounds you survived
            //Enemies killed
            //Canvas with restart button o main menu button
        }
    }
}
