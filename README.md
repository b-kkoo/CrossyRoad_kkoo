# CrossyRoad_kkoo
내일배움캠프 유니티 심화 주차 개인 프로젝트입니다.

## 길건너 친구들 만들어보기
레거시 코드를 바탕으로 부족한 기능을 추가하거나 코드 리팩터링 진행

### 1.프로젝트 목표
#### 최우선 목표
- 후진 기능 추가, 후진시 뒤 돌아보도록 하기
- 나무 등 장애물 통과 못하게 수정
- 물에 닿을 시 게임 오버
#### 기본 목표
- 플레이어 진행에 따라 전방에 맵 생성 및 후방 맵 파괴
#### 도전 목표
- 실제 게임처럼 일정 시간 전진하지 못할 시 게임 오버
- 실제 게임처럼 좌, 우로 공간 제약 추가

### 2.구현사항
#### 완성
- 후진 기능 추가, 후진시 뒤 돌아보도록 하기
- 나무 등 장애물 통과 못하게 수정
- 플레이어 진행에 따라 전방에 맵 생성 및 후방 맵 파괴
<br/><추가> Object Pool 관련 코드들을 PoolManager.cs를 만들어 기존 Manager.cs에서 분리하여 관리
#### 보류
- 물에 닿을 시 게임 오버
<br/>물에 닿을 시 게임오버 되는 기능을 추가하고 작동까지는 확인했지만
<br/>통나무 위에서도 게임오버되는 현상이 발생하여 보류
#### 미구현
- 실제 게임처럼 일정 시간 전진하지 못할 시 게임 오버
- 실제 게임처럼 좌, 우로 공간 제약 추가
