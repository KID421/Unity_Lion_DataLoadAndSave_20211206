<?php
	
	// 連線資料 = 連線(伺服器位置，資料庫帳號，資料庫密碼，資料庫名稱);
	$connect = mysqli_connect("localhost", "id18084990_kid1988421", "Kkk1988~0421", "id18084990_unitydb");

	// 金幣變數 = Unity 透過 POST 傳輸資料，名稱為 coin、posX、poY 的資料
	$coin = $_POST["coin"];
	$posX = $_POST["posX"];
	$posY = $_POST["posY"];

	// 更新 playerdata 編號 1 的金幣為 $coin
	// 更新 playerdata 設定 coin = $coin 位置在 playerdata.id = 1
	$sqlCoin = "UPDATE `playerdata` SET `coin` = '".$coin."' WHERE `playerdata`.`id` = 1";
	$sqlX = "UPDATE `playerdata` SET `posX` = '".$posX."' WHERE `playerdata`.`id` = 1";
	$sqlY = "UPDATE `playerdata` SET `posY` = '".$posY."' WHERE `playerdata`.`id` = 1";

	// 執行 SQL(連線資料，查詢資料)
	mysqli_query($connect, $sqlCoin);
	mysqli_query($connect, $sqlX);
	mysqli_query($connect, $sqlY);
?>
