<?php
	
	// �s�u��� = �s�u(���A����m�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��);
	$connect = mysqli_connect("localhost", "id18084990_kid1988421", "Kkk1988~0421", "id18084990_unitydb");

	// �����ܼ� = Unity �z�L POST �ǿ��ơA�W�٬� coin�BposX�BpoY �����
	$coin = $_POST["coin"];
	$posX = $_POST["posX"];
	$posY = $_POST["posY"];

	// ��s playerdata �s�� 1 �������� $coin
	// ��s playerdata �]�w coin = $coin ��m�b playerdata.id = 1
	$sqlCoin = "UPDATE `playerdata` SET `coin` = '".$coin."' WHERE `playerdata`.`id` = 1";
	$sqlX = "UPDATE `playerdata` SET `posX` = '".$posX."' WHERE `playerdata`.`id` = 1";
	$sqlY = "UPDATE `playerdata` SET `posY` = '".$posY."' WHERE `playerdata`.`id` = 1";

	// ���� SQL(�s�u��ơA�d�߸��)
	mysqli_query($connect, $sqlCoin);
	mysqli_query($connect, $sqlX);
	mysqli_query($connect, $sqlY);
?>
