<?php
	
	// �s�u��� = �s�u(���A����m�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��);
	$connect = mysqli_connect("localhost", "id18084990_kid1988421", "Kkk1988~0421", "id18084990_unitydb");

	// Unity �n�d�ߪ���� - search ���
	// $search = $_POST["search"];

	$search = "coin";

	// SQL �d��
	$sql = "SELECT `".$search."` FROM `playerdata` WHERE 1";

	// �d�ߵ��G = SQL �d��(�s�u��ơA�d��)
	$result = mysqli_query($connect, $sql);

	// ��X �d�ߵ��G ����������W
	echo $result;
?>