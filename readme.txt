Front
В PowerShell из папки front запустить команды:
yarn install
yarn build
yarn start

Back
1.Собрать проект. 
2. В файле appsettings.json изменить строку "DefaultConnection" на вашу строку подключения к ms sql server.
3. Выполнить накатку миграций через Package Manager Console командой Update-Database
4. Запустить проект