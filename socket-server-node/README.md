## heroku 버전
- heroku --version

## login
heroku login -i

## 로그 실시간 보기
- heroku logs -t

## git 릴리즈 보기
- heroku releases

## 해당버전으로 롤백
- heroku rollback v12

## 3rd-party buildpacks
heroku plugins:install heroku-repo

## 배포
```
heroku login
heroku git:remote -a thawing-ravine-21547
git add .
git commit -m "수정내역"
git push -f heroku master
heroku ps:scale web=1
```

