using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;

public class StaffSelector : MonoBehaviour
{
    [SerializeField] private SimpleScrollSnap simpleScrollSnap;

    public void SaveBatMaterialChoice()
    {
        DataWorker.Instance.SaveChooseStaff(simpleScrollSnap.TargetPanel);
        OpenMenu();
    }

    public void GetRandomBat()
    {
        int randomPanel = Random.Range(0, simpleScrollSnap.NumberOfPanels);
        simpleScrollSnap.GoToPanel(randomPanel);
    }

    public void OpenMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
