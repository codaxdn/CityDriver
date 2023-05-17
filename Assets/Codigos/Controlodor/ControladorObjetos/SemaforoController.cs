using UnityEngine;
using System.Collections;

public class SemaforoController : MonoBehaviour
{
    private SemaforoView semaforoView;

    private void Start()
    {
        semaforoView = GetComponent<SemaforoView>();
        StartCoroutine(CambiarSemaforo());
    }

    private IEnumerator CambiarSemaforo()
    {
        while (true)
        {
            semaforoView.EncenderVerde();
            yield return new WaitForSeconds(10f);

            semaforoView.EncenderAmarillo();
            yield return new WaitForSeconds(2f);

            semaforoView.EncenderRojo();
            yield return new WaitForSeconds(10f);

            semaforoView.EncenderAmarillo();
            yield return new WaitForSeconds(2f);
        }
    }
}