## 소켓전송 클라이언트

## 구성
- user interface library
  > react.js
  
  > next.js (ssr)

- type check compiler
  > typescript

- linter
  > tslint

- style
  > scss

- deploy
  > heroku

- source controller
  > git
  
  > heroku git

## heroku deploy
  ```
  heroku login
  git add .
  git commit -m "소스수정"
  git push heroku master
  heroku git:remote -a socket-client-node
  heroku logs -t
  heroku remote -v
  git push heroku testbranch:master(브랜치 푸쉬)
  ```

## styled-jsx 를 쓸 때 유의점
- styled-jsx 를 쓸 때 css 인텔리센스가 나오지 않기 때문에 `styled-jsx Language Server` 익스텐션을 깔고 쓰면 인텔리센스가 뜬다.
- 다만, 아래와 같이 중괄호가 `<style>` 태그 아래에 있으면 `styled-jsx Language Server` 인텔리센스가 나오지 않고 출력창에 오류가 뜬다
  ```html
  <style jsx>
  {`
    input { width: 100px; }
  `}
  </style>
  ```
- 아래와 같이 중괄호와 `<style>` 태그를 붙여서 써야 인텔리센스도 나오고 출력창에 오류도 나오지 않는다.
  ```html
  <style jsx>{`
    input { width: 100px; }
  `}</style>
  ```