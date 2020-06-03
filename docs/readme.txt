Установка веб сервиса:


1) Установить IIS WEB сервера
  Пуск - Настройка - Панель управления - Установка и удаление программ - Установка компанентов Windows - Internet Information Services (IIS)
2) Проверить, что IIS установился успешно
  Internet Explorer: http://localhost
-------------------------------------------
эти пункты необходимы при использовании FirebirdNETProvider-a - необходимо его заменить на другой
3) Установить .NET 1.1
4) Установить FirebirdNETProvider-1.7.1.exe
5) При необходимости - переписать файл msvcr71.dll в папке c:\windows\system32
--------------------------------------------
6) Установить .NET 4.0
7) Установить ASP.NET 4.0 - запустить: "aspnet_regiis -i" в папке c:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\


Установка WEB service
8) Создать папку для сервиса (NdeWS) в c:\Inetpub\wwwroot\
9) Опубликовать сервис:
  а) Visual Studio - NdeServices - Publish...
  б) Publish Method - FileSystem
  в) Target Location - c:\Inetpub\wwwroot\NdeWS
  г) Delete all existing files prior to publish
  д) нажать Publish
10) Пуск - Выполнить - inetmgr

IIS 5.0 (5.1)
10) Выбираем узел GdeService - Свойства
11) В появившемся окне в закладке "Каталог" отмечаем все checkboxes: "Доступ к тексту сценария" и др.
12) Нажимаем "Создать" напротив "Имя приложения"
13) "Разрешен запуск" - выбираем "Сценарии и исполняемые файлы"
подробнее: http://itscommonsensestupid.blogspot.com/2008/11/deploy-aspnet-mvc-app-on-windows-xp-iis.html

IIS 6
10) Пулы приложений - Добавить пул приложений...
Имя: .NET40POOL
Версии среды .NET: 4.0
Режим: встроенный
ОК
11) Сайты - Default Web Site - Преобразовать в приложение
Пул приложений - Выбрать... .NET40POOL
ОК





