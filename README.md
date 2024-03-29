# RE:Paint (2021)

### 프로젝트 소개
- RE:Paint는 부산예일직업학교 Unity3D 개발자 양성 교육에서 제작한 게임입니다.
- 총 3명의 팀원이 참여하였고, 개발 기간은 약 8주입니다.


### 게임 소개
- RE:Paint는 인공지능 전투 시뮬레이션 게임으로, 전장에 병사들을 배치하여 전투를 치러 승리하는 게임입니다.
- 전투가 진행되는 동안, 플레이어는 하나의 병사에게 강림하여 직접 전투에 참여할 수 있습니다.
- 전투에서 살아남은 병사들은, 전투 숙련도가 증가하여 추후 전투에서 더욱 잘 싸우게 됩니다.
- 전투가 끝난 후 얻은 보상으로, 병사들을 업그레이드하거나, 병사 수를 보충할 수 있습니다.
- 주어진 모든 전투에서 승리하는것이 게임의 목표입니다.


### 개발 스킬
- 전장은 Unity의 Terrain Tool을 이용하여 제작하였습니다.
- 병사들의 애니메이션은 Unity의 Animation Rigging 패키지를 활용하여 보완하였습니다.
- 배치하고자하는 병사들의 수와, 배치하고자 하는 영역의 크기에 따라 병사들이 고르게 배치되는 알고리즘을 개발하였습니다.
- 각종 쉐이더와 파티클을 활용하여 아트적인 요소를 첨가하였습니다.


### 게임플레이
![Repaint](https://user-images.githubusercontent.com/70570420/179783011-9abcf480-4b00-4720-b44e-0563d59ebbda.png)
[플레이 영상](https://youtu.be/UIOzqf8liU8)


### 내 역할 및 업무성과
- 인공지능 전투 알고리즘을 개발하였습니다.
> Q. 단순히 치고 받는 인공지능이 아닌, 보다 사람다운 인공지능을 개발하고 싶다.
> > A. 시야를 만들어 주어 적을 인식하고, 적의 행동을 보고 자신의 행동을 결정하도록 하자.
![fsm](https://user-images.githubusercontent.com/70570420/193786086-cb37a826-4c34-42e1-831d-c942af48a923.PNG)
```C#
private IEnumerator StateCoroutine()
    {
        while (true)
        {
            //어떤 행동을 취하고 있는 중이라면 넘어감
            if (doSomething)
            {
                yield return waitReaction;
                continue;
            }
            
            //타겟 재설정
            target = See();
            if (target == null)
            {
                yield return waitReaction;
                continue;
            }

            //타겟정보로부터 다음 행동 결정
            state = GetNextState(target);

            //행동
            Do(state);

            yield return waitReaction;     //병사의 반응속도 능력치만큼 딜레이
        }
    }
```

> Q. 어떻게 볼 것인가?
> > A. 전방은 멀리, 양 옆은 가까이, 뒤쪽은 매우 가까이
![시야개요](https://user-images.githubusercontent.com/70570420/193786134-58c57d89-a493-4038-b2a5-bdc195cf3035.PNG)
![시야20221004_185036](https://user-images.githubusercontent.com/70570420/193789843-e79a3e35-b570-4e1e-8188-b9e7fc7f9a80.gif)

> Q. 누구를 볼 것인가?
> > A. 가장 가까이 있는 적?
> > > Problem. 모든 아군이 한 적군을 바라보는(목표로 하는) 현상 발생
![가장가까이](https://user-images.githubusercontent.com/70570420/193830019-d1157629-a0e3-4663-9e9a-d7cd4dab19f8.gif)
> > > Solution. 목표로 하는 아군의 수가 가장 적은 적군에 가중치 부여
![가중치](https://user-images.githubusercontent.com/70570420/193830069-d29e3144-7a49-479b-9586-c5431cfbacd3.gif)
```C#
private Knight See()
{
    targetInViewRadius = Physics.OverlapSphere(transform.position, seeDistance, layerMask);

    if (targetInViewRadius.Length == 0) return null;

    //거리가 가까운 순서로 타겟 후보자 검색을 위한 SortedList
    SortedList<float, Knight> candidates = new SortedList<float, Knight>();
    for (int i = 0; i < targetInViewRadius.Length; i++)
    {
        Knight seenTarget = targetInViewRadius[0].GetComponentInChildren<Knight>();

        //기사가 아니거나, 같은 팀이거나, 죽은상태라면 스킵
        if (!seenTarget || seenTarget.team == team || seenTarget.state == EAIState.Defend)
            continue;

        Transform targetCandidate = seenTarget.transform;

        float distance = Vector3.Distance(transform.position, targetCandidate.position);
        Vector3 dirToTarget = (targetCandidate.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToTarget);

        //내적 결과, 각도에 따라 볼 수 있는 거리 제한
        if (dot >= 0.1f && distance <= seeDistance && !candidates.ContainsKey(distance + seenTarget.threat))
            candidates.Add(distance + seenTarget.threat, seenTarget);
        else if (dot < 0.1f && dot > -0.3f && distance <= seeDistance * 0.3f && !candidates.ContainsKey(distance + seenTarget.threat))
            candidates.Add(distance + seenTarget.threat, seenTarget);
        else if (dot < 0.3f && distance <= seeDistance * 0.1f && !candidates.ContainsKey(distance + seenTarget.threat))
            candidates.Add(distance + seenTarget.threat, seenTarget);
    }
    
    if(candidates.Count != 0)
        return candidates.Values[0];
    
    return null;
}
```



> Q. 어떻게 싸울 것인가?
> > A. 적의 공격을 피하기도 하고, 막기도 하는 전투  
> >      게임성을 위해 병사가 가진 능력치에 기반하여 확률적으로 공격을 방어하고 회피
![전투20221004_231441](https://user-images.githubusercontent.com/70570420/193843149-7a63e814-3c2a-4a7e-bd16-cf1b5745ec7d.gif)

- 병사들의 전투를 보다 자연스럽게 연출하였습니다.
> Q. 한정된 애니메이션 에셋으로 보다 자연스러운 전투를 구현해야 한다.
> > A. Animation Rigging 패키지를 활용하여 애니메이션 수정
![IK](https://user-images.githubusercontent.com/70570420/193847650-8feb1c79-c20f-4874-8702-d5067134de83.png)
![조준20221004_234855](https://user-images.githubusercontent.com/70570420/193851727-f8decb90-9d4f-4bc2-83dc-e72d574213a1.gif)

- 그 외 갖가지 작은 기능들과 UI들을 구현하였습니다.


