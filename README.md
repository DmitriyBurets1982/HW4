1. Необходимо установить значение строки соединения с сервером PostgreSQL в файле k8s\templates\secret.yaml в формате base64 по нижеследующему исходному шаблону в формате json:
    ```json
    {
        "ConnectionStrings": {
            "Users": "Server=<HOST>';port=<PORT>;User ID=<USERNAME>;Password=<PASSWORD>;Database=Users"
        }
    }
    ```
    
    <b>Примеры</b>
    
    Параметры:
      ```json
      {
          "ConnectionStrings": {
            "Users": "Server=host.docker.internal;port=5432;User ID=postgres;Password=postgres;Database=Users"
          }
      }
      ```

      
      Значение секрета:
      ```yaml
      data:
        appsettings.secret.json: ewogICAgIkNvbm5lY3Rpb25TdHJpbmdzIjogewogICAgICAiVXNlcnMiOiAiU2VydmVyPWhvc3QuZG9ja2VyLmludGVybmFsO3BvcnQ9NTQzMjtVc2VyIElEPXBvc3RncmVzO1Bhc3N3b3JkPXBvc3RncmVzO0RhdGFiYXNlPVVzZXJzIgogICAgfQp9
      ```


2. Из корневой директории (где расположен данный файл) выполнить команду
```
helm install hw4 k8s
```

3. Postman коллекция: **HW4.postman_collection** </br>
Вывод команды newman находится в файле **newman.png**

4. Для удаления деплоймента из корневой директории (где расположен данный файл) выполнить команду </br>
```
helm uninstall hw4
```

PS: при проверке стоит обратить внимание на то, что колонка Id в таблице Users с автоинкрементом, поэтому при повторных запусках newman необходимо либо актуализировать параметры запросов (id пользователя), либо выполнить команду в БД:</br>
    ```
    TRUNCATE public."Users" RESTART IDENTITY;
    ```
