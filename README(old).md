# CsharpProject

경북산업직업 전문 학교 3조 C# 데이터 분석 및 시각화 프로젝트 입니다.

---

### 프로젝트 관련 사항

1. AIHub [상품 이미지 데이터셋](https://aihub.or.kr/aihubdata/data/view.do?currMenu=115&topMenu=100&aihubDataSe=realm&dataSetSn=64)
2. AI API[(지금은 안 됨)](https://www.youtube.com/watch?v=wdXsv4-2emg)
   
---

### 구현 목록(ChatGPT도움받음)(프로젝트 요구사항)  
상품 등록 및 재고 관리:  
MyProduct 테이블에서 정보를 읽어와 MyInventory 테이블에 새로운 상품을 등록합니다(위치 정보도 넣어주세요). --> 정선호  
MyInventory 테이블에 있는 기존 상품의 정보를 수정하고 삭제할 수 있는 기능을 제공합니다. --> 정선호  
MyInventory 테이블에 존재하는 제품의 입고 및 출고를 기록하고 조회할 수 있습니다. --> 정선호   

재고 알림:  
재고 수량을 실시간으로 추적하고 부족한 제품을 알려주는 기능입니다.  --> 신동훈  
재고 수량이 일정 기준 이하로 떨어질 때 관리자에게 알림을 보내거나 자동으로 재고를 주문할 수 있는 알림 기능입니다. --> 신동훈  

제품 검색 및 필터링:  
제품을 효율적으로 검색하고, 필터링하여 특정 조건에 맞는 제품을 찾을 수 있는 기능을 제공합니다. --> 이수성  
제품의 이름, 식별자, 가격 등을 기준으로 검색할 수 있습니다. --> 이수성  
제품을 라벨링(QR 코드)하여 효율적으로 결제 및 관리하고 찾을 수 있습니다. --> 이수성  

보고서 및 통계:  
재고 상태, 판매량, 입출고 기록 등의 정보를 기반으로 보고서와 통계를 생성합니다. --> 김신혁  
바코드를 넣으면 상품 이미지 출력 --> 김신혁(구현완료)  
MyProduct 테이블에 xml 데이터 넣기 --> 김신혁(구현완료)  

결제:  
결제기능입니다. --> 최은지  
환불기능입니다. --> 최은지  
회원 등록 및 수정, 삭제 기능입니다. --> 최은지  
마일리지 사용 및 적립, 조회 기능입니다. --> 최은지  


구현 방식에 대해서는 기타폴더의 기능별 구현방법 토론 텍스트 파일을 참조해주시길 바랍니다.
-----------------------------------------------------------------

---

### [데이터 분석 및 시각화] 제조 데이터를 시각화하고 분석을 위한 응용SW 제작

⬜️ DataGridView와 Chart를 활용하여 제조데이터를 시각화하고, 그에 따른 분석 결과도 포함할 것  
⬜️ DBMS를 활용하여 데이터를 관리할 것

---

#### 요구 명세서 작성 필요(양식 참조)

⬜️ 테이블 명세서(개발 정도\_ER 참고)  
⬜️ API 명세서  
⬜️ 요구사항 명세서(예시 자료 엑셀 파일 참고)

## ⬜️제조데이터 기반 데이터 분석결과 시각화 서비스 구현

#### 다음 상황들을 반드시 고려할 것

1.  프로젝트 개요
2.  팀 구성원 역할 소개
3.  프로젝트 수행절차
4.  프로젝트 수행결과
5.  자체 평가의견
