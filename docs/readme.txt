��⠭���� ��� �ࢨ�:


1) ��⠭����� IIS WEB �ࢥ�
  ��� - ����ன�� - ������ �ࠢ����� - ��⠭���� � 㤠����� �ணࠬ� - ��⠭���� ��������⮢ Windows - Internet Information Services (IIS)
2) �஢����, �� IIS ��⠭������ �ᯥ譮
  Internet Explorer: http://localhost
-------------------------------------------
�� �㭪�� ����室��� �� �ᯮ�짮����� FirebirdNETProvider-a - ����室��� ��� �������� �� ��㣮�
3) ��⠭����� .NET 1.1
4) ��⠭����� FirebirdNETProvider-1.7.1.exe
5) �� ����室����� - ��९���� 䠩� msvcr71.dll � ����� c:\windows\system32
--------------------------------------------
6) ��⠭����� .NET 4.0
7) ��⠭����� ASP.NET 4.0 - ��������: "aspnet_regiis -i" � ����� c:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\


��⠭���� WEB service
8) ������� ����� ��� �ࢨ� (NdeWS) � c:\Inetpub\wwwroot\
9) ��㡫������� �ࢨ�:
  �) Visual Studio - NdeServices - Publish...
  �) Publish Method - FileSystem
  �) Target Location - c:\Inetpub\wwwroot\NdeWS
  �) Delete all existing files prior to publish
  �) ������ Publish
10) ��� - �믮����� - inetmgr

IIS 5.0 (5.1)
10) �롨ࠥ� 㧥� GdeService - �����⢠
11) � ���襬�� ���� � �������� "��⠫��" �⬥砥� �� checkboxes: "����� � ⥪��� �業���" � ��.
12) �������� "�������" ����⨢ "��� �ਫ������"
13) "����襭 �����" - �롨ࠥ� "�業�ਨ � �ᯮ��塞� 䠩��"
���஡���: http://itscommonsensestupid.blogspot.com/2008/11/deploy-aspnet-mvc-app-on-windows-xp-iis.html

IIS 6
10) ��� �ਫ������ - �������� �� �ਫ������...
���: .NET40POOL
���ᨨ �।� .NET: 4.0
�����: ���஥���
��
11) ����� - Default Web Site - �८�ࠧ����� � �ਫ������
�� �ਫ������ - �����... .NET40POOL
��





