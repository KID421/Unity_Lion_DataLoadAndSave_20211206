<?php
	
	// 連線資料 = 連線(伺服器位置，資料庫帳號，資料庫密碼，資料庫名稱);
	$connect = mysqli_connect("localhost", "id18084990_kid1988421", "Kkk1988~0421", "id18084990_unitydb");

	// 金幣變數 = Unity 透過 POST 傳輸資料，名稱為 json 的資料
	$json = $_POST["json"];

	// 更新 playerdata 設定 json = $json 位置在 playerdata.id = 1
	$sql = "UPDATE `playerjson` SET `json` = '".$json."' WHERE `playerjson`.`id` = 1";

	// 執行 SQL(連線資料，查詢資料)
	mysqli_query($connect, $sql);
?>
