using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BingoLineManager : MonoBehaviour
{

    public BingoLineObject[] bingoLineObjects;

    private bool sw_Ani;

    
    public void ShowBingoLine(int countBingoLine)
    {
        Debug.Log(countBingoLine);

        CloseAllBingoLine();

        for(int i = 0 ; i < countBingoLine ; i++)
        {
            SetBingoLineOpen(i+1);
        }
    }

    public void OpenBingoLine(int id_bingoline)
    {
        SetBingoLineOpen(id_bingoline);
    }

    public void CloseBingoLine(int id_bingolines)
    {
        SetBingoLineClose(id_bingolines);
    }

    public void OpenBingoLine(int[] ids_bingolines)
    {
        foreach (int integer in ids_bingolines)
            SetBingoLineOpen(integer);
    }

    public void CloseBingoLine(int[] id_bingoline)
    {
        foreach (int integer in id_bingoline)
            SetBingoLineClose(integer);
    }
    
    public void StartPlayAnimation(int[] lineids)
    {
        sw_Ani = true;
        StartCoroutine(DoAnimation(lineids));
    }


    // 開啟某一條線
    private void SetBingoLineOpen(int idx)
    {
        bingoLineObjects[idx - 1].Open();
    }

    // 關閉某一條線
    private void SetBingoLineClose(int idx)
    {
        bingoLineObjects[idx - 1].Close();
    }

    public void CloseAllBingoLine()
    {
        foreach (BingoLineObject bingo in bingoLineObjects)
            bingo.Close();
    }

    IEnumerator DoAnimation(int[] lineids)
    {
        int nowidx = 0;
        do
        {
            SetBingoLineOpen(lineids[nowidx]);

            yield return new WaitForSeconds(1.0f);
            SetBingoLineClose(lineids[nowidx]);


            nowidx++;
            if (nowidx >= lineids.Length)
                nowidx = 0;

        } while (sw_Ani);

        //this.CloseBingoLine(lineids);
    }

    public void StopDoAnimation()
    {
        // Stop DoAnimation Coroutine
        sw_Ani = false;

        this.CloseAllBingoLine();
    }
    

}
