<?php
	
	// �s�u��� = �s�u(���A����m�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��);
	$connect = mysqli_connect("localhost", "id18084990_kid1988421", "Kkk1988~0421", "id18084990_unitydb");

	// �����ܼ� = Unity �z�L POST �ǿ��ơA�W�٬� json �����
	$json = $_POST["json"];

	// ��s playerdata �]�w json = $json ��m�b playerdata.id = 1
	$sql = "UPDATE `playerjson` SET `json` = '".$json."' WHERE `playerjson`.`id` = 1";

	// ���� SQL(�s�u��ơA�d�߸��)
	mysqli_query($connect, $sql);
?>
