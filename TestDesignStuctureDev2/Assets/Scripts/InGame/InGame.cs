using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public void Init(int stageLevel)
    {
        Debug.Log("InGame Init");
        //타이틀로 돌아가기전까지 이 오브젝트를 파괴하지 말라.
        DontDestroyOnLoad(this);

        if (stageLevel == 0)
        {
            //인트로 실행
        }
        else
        {
            //Camp 로드
        }

        #region
        //인트로가 끝나면 캠프 stageLevel++(=1), Camp 로드

        //현재의 캠프가 끝나면 stage 로드

        //stage 클리어시 연출(stageLevel) 로드(if(stageLevel==5)//Ending

        //연출 끝나면 stageLevel++, Camp로드

        //stage 클리어 실패 + 마을로 돌아가기 선택시 Camp 로드

        //stage 클리어 실패 + 다시 하기 선택시 Stage로드

        //Ending 끝나면 타이틀로 돌아가면서 InGame 오브젝트 파괴
        #endregion
    }
}
